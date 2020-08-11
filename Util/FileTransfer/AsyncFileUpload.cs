using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Net;
using System.Threading;
using log4net;

namespace SecureMedMail.Util.FileTransfer
{
    class AsyncFileUpload
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public byte[] header = null;
        public byte[] footer = null;
        public String filePath;
        public BackgroundWorker uploadWorker;
        public WebRequest request;
        public WebResponse response;
        public ManualResetEvent allDone;


        private FileStream fileStream;
        public Stream stream;

        private long fileSize = 0;

        private long totalBytesWritten = 0;
        private long totalBytesToWrite = 0;


        public AsyncFileUpload(byte[] header, byte[] footer, String filePath, BackgroundWorker uploadWorker, WebRequest request, ManualResetEvent allDone)
        {
            this.header = header;
            this.footer = footer;
            this.filePath = filePath;
            this.uploadWorker = uploadWorker;
            this.request = request;
            this.allDone = allDone;

            if (File.Exists(filePath) == false)
            {
                throw new Exception("Invalid file path for asynchronous upload request");
            }


            FileInfo fileInfo = new FileInfo(filePath);
            this.fileSize = fileInfo.Length;
            totalBytesToWrite += header.LongLength + fileSize + footer.LongLength;

            fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        }


        byte[] getDataToSend(int numBytesToSend)
        {
            
            if (totalBytesWritten < header.Length)
            {
                log.Debug("In getDataToSend Loc 1 Header Len: " + header.Length);
                totalBytesWritten += header.LongLength;
                return header;
            }

            if ( totalBytesWritten < ( header.Length + fileSize ) )
            {
                byte[] buffer = new byte[numBytesToSend];
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                byte[] newBuffer = new byte[bytesRead];
                Array.Copy(buffer, newBuffer, bytesRead);

                totalBytesWritten += newBuffer.LongLength;

                return newBuffer;
            }

            //header and file have been written...write the footer
            if (totalBytesWritten < totalBytesToWrite)
            {
                log.Debug("In getDataToSend Loc 3 Header Len: " + footer.Length);
                totalBytesWritten += footer.LongLength;
                return footer;
            }

            return new byte[0];
        }



        public static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            log.Debug("In GetRequestStreamCallback Loc 1");
            
            AsyncFileUpload asyncFileUpload = (AsyncFileUpload)asynchronousResult.AsyncState;

            // End the operation
            Stream postStream = asyncFileUpload.request.EndGetRequestStream(asynchronousResult);

            asyncFileUpload.stream = postStream;

            byte [] dataToPost = asyncFileUpload.getDataToSend(4096);

            log.Debug("In GetRequestStreamCallback Loc 2 dataToPost Len: " + dataToPost.Length);

            postStream.BeginWrite(dataToPost, 0, dataToPost.Length, new AsyncCallback(WriteCallback), asyncFileUpload);

        }

        public static void WriteCallback(IAsyncResult asynchronousResult)
        {
            AsyncFileUpload asyncFileUpload = (AsyncFileUpload)asynchronousResult.AsyncState;

            asyncFileUpload.stream.EndWrite(asynchronousResult);

            //if (asyncFileUpload.totalBytesWritten % 262144 == 0)
            //{
                int progressValue = (int)((asyncFileUpload.totalBytesWritten * 100) / asyncFileUpload.totalBytesToWrite);
                asyncFileUpload.uploadWorker.ReportProgress(progressValue);
            //}

            byte[] dataToPost = asyncFileUpload.getDataToSend(65536);
            if (dataToPost.Length > 0)
            {
                asyncFileUpload.stream.BeginWrite(dataToPost, 0, dataToPost.Length, new AsyncCallback(WriteCallback), asyncFileUpload);
            }
            else
            {
                log.Debug("Get Data returned zero....closing stream");
                asyncFileUpload.stream.Close();
                asyncFileUpload.fileStream.Close();

                WebResponse wresp = null;
                try
                {
                    wresp = asyncFileUpload.request.GetResponse();
                    Stream stream2 = wresp.GetResponseStream();
                    StreamReader reader2 = new StreamReader(stream2);
                    log.Debug(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));

                    asyncFileUpload.response = wresp;

                    asyncFileUpload.allDone.Set();
                }
                catch (Exception ex)
                {
                    log.Error("Error uploading file", ex);
                    if (wresp != null)
                    {
                        wresp.Close();
                        wresp = null;
                    }

                    //TODO need to throw an exception and let the user know what happened
                }
                finally
                {
                    //wr = null;
                }
            }
            
        }
    }
}
