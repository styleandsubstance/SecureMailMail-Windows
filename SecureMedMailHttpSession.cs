using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Configuration;
using DiscUtils.Ext;
using log4net;
using Newtonsoft.Json;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Config;
using SecureMedMail.WebService.Forms;
using SecureMedMail.Util.FileTransfer;
using System.Threading;
using SecureMedMail.WebService.Response;


namespace SecureMedMail
{
    public class SecureMedMailHttpSession
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static SecureMedMailHttpSession session = null;

        public static SecureMedMailHttpSession getSession()
        {
            if (session == null)
            {
                session = new SecureMedMailHttpSession();
            }

            return session;
        }

        private bool authenticated = false;
        private CookieContainer cookies = new CookieContainer();

        public bool Authenticated()
        {
            return authenticated;
        }

        private HttpWebResponse HttpPost(string URI, string Parameters)
        {
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.CookieContainer = cookies;
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
            return resp;
        }

        private HttpWebResponse HttpGet(string URI)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
            req.CookieContainer = cookies;
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            return resp;
        }


        private String JSONWebRequest(string URI)
        {
            HttpWebResponse resp = HttpGet(URI);

            StringBuilder jsonString = new StringBuilder();
            
            byte[] buffer = new byte[4096];
            int bytesRead = 0;

            while ((bytesRead = resp.GetResponseStream().Read(buffer, 0, buffer.Length)) != 0)
            {
                jsonString.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return jsonString.ToString();
        }

        private String JSONPostRequest(string URI, string parameters)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
            req.ContentType = "application/json";
            req.CookieContainer = cookies;
            req.Method = "POST";

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            
        
            StringBuilder jsonString = new StringBuilder();

            byte[] buffer = new byte[4096];
            int bytesRead = 0;


            while ((bytesRead = resp.GetResponseStream().Read(buffer, 0, buffer.Length)) != 0)
            {
                jsonString.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                if (resp.Headers.Get("Error") != null && resp.Headers.Get("Error") == "True")
                {
                    throw new WebServiceException(jsonString.ToString());
                }

                return jsonString.ToString();
            }
            else
            {
                throw new WebServiceException("Unknown error");
            }
        }

        private HttpWebResponse HttpUploadFileWithCallback(string URI, UploadFileAttributesForm uploadFileAttributesForm, String filename, String encryptedFilePath, System.ComponentModel.BackgroundWorker uploadWorker)
        {

            FileInfo fileInfo = new FileInfo(encryptedFilePath);
            long filesize = fileInfo.Length;
            long totalSent = 0;


            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(URI);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.CookieContainer = cookies;
            wr.KeepAlive = true;
            wr.Timeout = System.Threading.Timeout.Infinite;
            wr.Headers.Add("File-Size", "" + filesize);
            

            List<byte> headerBuffer = new List<byte>();





            //Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            Dictionary<String, String> uploadFormValues = uploadFileAttributesForm.buildDictionaryForPost();

            foreach (string key in uploadFormValues.Keys)
            {
                //rs.Write(boundarybytes, 0, boundarybytes.Length);
                headerBuffer.AddRange(boundarybytes);

                string formitem = string.Format(formdataTemplate, key, uploadFormValues[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                //rs.Write(formitembytes, 0, formitembytes.Length);
                headerBuffer.AddRange(formitembytes);
            }


            //rs.Write(boundarybytes, 0, boundarybytes.Length);
            headerBuffer.AddRange(boundarybytes);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, "file", filename, "application/octet-stream");
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            //rs.Write(headerbytes, 0, headerbytes.Length);
            headerBuffer.AddRange(headerbytes);

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");



            long contentLength = headerBuffer.ToArray().LongLength + fileInfo.Length + trailer.LongLength;
            wr.ContentLength = contentLength;
            wr.AllowWriteStreamBuffering = false;
            
            ManualResetEvent allDone = new ManualResetEvent(false);
            

            AsyncFileUpload asyncFileUpload = new AsyncFileUpload(headerBuffer.ToArray(), trailer, encryptedFilePath, uploadWorker, wr, allDone);


            IAsyncResult result =
                      (IAsyncResult)wr.BeginGetRequestStream(new AsyncCallback(AsyncFileUpload.GetRequestStreamCallback), asyncFileUpload);


            allDone.WaitOne();


            return (HttpWebResponse)asyncFileUpload.response;
        }


        private HttpWebResponse HttpUploadFile(string URI, UploadFileAttributesForm uploadFileAttributesForm, String filename, String encryptedFilePath, System.ComponentModel.BackgroundWorker uploadWorker)
        {

            FileInfo fileInfo = new FileInfo(encryptedFilePath);
            long filesize = fileInfo.Length;
            long totalSent = 0;


            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(URI);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.CookieContainer = cookies;
            wr.KeepAlive = true;
            wr.Timeout = System.Threading.Timeout.Infinite;
            //wr.SendChunked = true;
            //wr.AllowWriteStreamBuffering = false;
            //wr.ContentLength = filesize + 4096;
            //wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            Dictionary<String, String> uploadFormValues = uploadFileAttributesForm.buildDictionaryForPost();
            
            foreach (string key in uploadFormValues.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, uploadFormValues[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            

            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, "file", filename, "application/octet-stream");
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            

            FileStream fileStream = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
                totalSent += bytesRead;

                if (totalSent % 262144 == 0)
                {
                    int progressValue = (int)((totalSent * 100) / filesize);
                    uploadWorker.ReportProgress(progressValue); 
                }

            }

            log.Debug("Done Writing file...closing file stream");

            fileStream.Close();

            log.Debug("Writing boundry");

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            log.Debug("Writing boundry...Loc 2");
            rs.Write(trailer, 0, trailer.Length);

            log.Debug("Writing boundry...Close");

            rs.Close();

            log.Debug("Done Closing");

            WebResponse wresp = null;
            try
            {
                log.Debug("Getting Web Response");
                wresp = wr.GetResponse();
                log.Debug("Getting Web Response Stream");
                Stream stream2 = wresp.GetResponseStream();
                log.Debug("Getting Web Response Stream LOC 2");
                StreamReader reader2 = new StreamReader(stream2);
                log.Debug(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
            }
            catch (Exception ex)
            {
                log.Error("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }

            return (HttpWebResponse)wresp;
        }


        private HttpWebResponse HttpDownloadFile(string URI, string localPath, System.ComponentModel.BackgroundWorker downloadWorker)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.CookieContainer = cookies;
            req.Method = "GET";
            //Stream os = req.GetRequestStream();
            //os.Write(bytes, 0, bytes.Length); //Push it out there
            //os.Close();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            
            //Create the local File
            FileStream fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write);
            
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            long filesize = Convert.ToInt64(resp.GetResponseHeader("Content-Length"));
            long totalReceived = 0;

            while ((bytesRead = resp.GetResponseStream().Read(buffer, 0, buffer.Length)) != 0)
            {
                fileStream.Write(buffer, 0, bytesRead);

                totalReceived += bytesRead;

                if (totalReceived % 262144 == 0)
                {
                    int progressValue = (int)((totalReceived * 100) / filesize);
                    downloadWorker.ReportProgress(progressValue);
                }
            }

            fileStream.Close();

            return resp;
        }


        public bool Authenticate(String username, String password)
        {
            //encode the URL paramaters
            //String postData = HttpUtility.UrlEncode("username=" + username + "&password" + password);

            try
            {
                String postData = "username=" + username + "&password=" + password;
                HttpWebResponse resp = HttpPost(WebServicePaths.Authenticate(), postData);

                if (resp == null || resp.StatusCode == HttpStatusCode.BadRequest)
                {
                    return false;
                }
               
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                cookies.Add(resp.Cookies);
                authenticated = true;
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception while trying to authenticate", ex);
                return false;
            }
            
        }


        public String Upload(UploadFileAttributesForm uploadFileAttributesForm, String filename, String encryptedFilePath, System.ComponentModel.BackgroundWorker uploadWorker)
        {
            try
            {
                log.Debug("Uploading to: " + WebServicePaths.Upload());
                HttpWebResponse resp = HttpUploadFileWithCallback(WebServicePaths.Upload(), uploadFileAttributesForm, filename, encryptedFilePath, uploadWorker);
                
                //HttpWebResponse resp = HttpUploadFile(WebServicePaths.Upload(), uploadFileAttributesForm, filename, encryptedFilePath, uploadWorker);

                if (resp.StatusCode == HttpStatusCode.BadRequest || resp.GetResponseHeader("GUID") == null)
                {
                    throw new Exception("Error while trying to upload file.  Please try again later");
                }

                return resp.GetResponseHeader("GUID");
            }
            catch (Exception ex)
            {
                log.Error("Exception while trying to upload file", ex);
                throw ex;
            }
        }


        public DownloadFileResponse Download(String guid, String localPath, System.ComponentModel.BackgroundWorker downloadWorker)
        {
            try
            {
                HttpWebResponse resp = HttpDownloadFile(WebServicePaths.Download() + "/" + guid, localPath, downloadWorker);
                if (resp.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("Error while trying to download file.  Please try again later");
                }

                String fileName = resp.GetResponseHeader("File-Name");
                String downloadGuid = resp.GetResponseHeader("GUID");

                if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(downloadGuid))
                {
                    throw new Exception("Download Response didn't contain filename: " + fileName + " or guid: " + downloadGuid);
                }

                return new DownloadFileResponse(fileName, downloadGuid);

            }
            catch (Exception ex)
            {
                log.Error("Exception while trying to download file", ex);
                throw ex;
            }
        }


        public String GetUserFilePropertyProfiles()
        {
            try
            {
                return JSONWebRequest(WebServicePaths.GetUserFilePropertyProfiles());
            }
            catch (Exception ex)
            {
                log.Error("Exception while getting file proeprties for profiles", ex);
                throw ex;
            }
        }

        public String GetFilePropertiesByGUID(string GUID)
        {
            var jsonData = new {guid = GUID};
            return JSONPostRequest(WebServicePaths.GetFilePropertiesByGuid(), JsonConvert.SerializeObject(jsonData));
        }

        public bool VerifyFilePasswordHash(string GUID, string passwordHash)
        {
            var jsonData = new { guid = GUID, password_hash = passwordHash};
            JSONPostRequest(WebServicePaths.VerifyFilePasswordHash(), JsonConvert.SerializeObject(jsonData));
            return true;
        }

        public String ConfirmDownloadByGuid(string GUID)
        {
            var jsonData = new { guid = GUID };
            return JSONPostRequest(WebServicePaths.ConfirmDownloadByGuid(), JsonConvert.SerializeObject(jsonData));
        }

    }
}
