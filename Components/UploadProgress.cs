using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using log4net;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Forms;
using SecureMedMail.Util.Encryption;
using System.IO;
using System.Security.Cryptography;
using SecureMedMail.Dialog;
using SevenZip;

namespace SecureMedMail.Components
{
    public partial class UploadProgress : UserControl
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public String GUID { get; set; }

        private UploadFileAttributesForm uploadFileAttributesForm;
        private String fileName = null;
        private String filePath = null;
        private String compressedFile = null;
        private String encryptedFile = null;

        public UploadProgress()
        {
            InitializeComponent();
        }

        private void UploadProgess_Load(object sender, EventArgs e)
        {

        }

        
        public void StartUpload(String filePath, String fileName, UploadFileAttributesForm uploadFileAttributesForm)
        {
            this.filePath = filePath;
            this.fileName = fileName;
            this.uploadFileAttributesForm = uploadFileAttributesForm;
            this.compressedFile = TempFile.GetTempFilePathWithExtension(".tmp");
            this.encryptedFile = TempFile.GetTempFilePathWithExtension(".tmp");

            compressionWorkerThread.WorkerReportsProgress = true;
            compressionWorkerThread.DoWork += new DoWorkEventHandler(compressionWorkerThread_CompressFile);
            compressionWorkerThread.ProgressChanged += new ProgressChangedEventHandler(compressionWorkerThread_ProgressChanged);
            compressionWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(compressionWorkerThread_RunCompleted);
            compressionWorkerThread.RunWorkerAsync();
        }

        private void compressionWorkerThread_CompressFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                log.Debug("Compressing file " + this.filePath + " to path: " + this.compressedFile);
            
                /*
                var tmp = new SevenZipCompressor();
            
                tmp.ArchiveFormat = OutArchiveFormat.Zip;
                tmp.CompressionLevel = CompressionLevel.Fast;
                tmp.CompressionMethod = CompressionMethod.Default;
            
                //tmp.FileExtractionStarted += (s, ev) =>
                tmp.Compressing += (s, ev) =>
                {
                    compressionWorkerThread.ReportProgress(ev.PercentDone);

                };
                tmp.FileCompressionFinished += (s, ev) =>
                {
                    compressionWorkerThread.ReportProgress(100);
                };

                if (Directory.Exists(this.filePath))
                {
                    tmp.CompressDirectory(this.filePath, this.compressedFile);
                }
                else
                {
                    tmp.CompressFiles(this.compressedFile, this.filePath);    
                }
                 */

                Chilkat.Zip zip = new Chilkat.Zip();

                bool success;

                //  Any string unlocks the component for the 1st 30-days.
                success = zip.UnlockComponent("Anything for 30-day trial");
                if (success != true)
                {
                    throw new Exception("Component load failed");
                }

                success = zip.NewZip(this.compressedFile);
                if (success != true)
                {
                    throw new Exception("Failed creating zip file");
                }

                zip.OnPercentDone += (s,a) => compressionWorkerThread.ReportProgress(a.PercentDone);

                if (Directory.Exists(this.filePath))
                {
                    string recursiveDirectoryPath = Path.Combine(this.filePath, "*");
                    success = zip.AppendFiles(recursiveDirectoryPath, true);
                }
                else
                {
                    success = zip.AppendOneFileOrDir(this.filePath, false);
                }

                if (success != true)
                {
                    zip.CloseZip();;
                    throw new Exception("Zip file creation failed");
                }

                success = zip.WriteZipAndClose();
                if (success != true)
                {
                    throw new Exception("Failed to close zip file");
                }

            }
            catch (Exception ex)
            {
                log.Error("Error while compressing file: " + this.filePath + " for upload", ex);
                throw ex;
            }
            
        }

        private void compressionWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            compressionProgressBar.Value = e.ProgressPercentage;
        }

        private void compressionWorkerThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while compressing this file.  Please contact customer support.");
            }
            
            compressionProgressBar.Value = 100;

            encryptionThread.WorkerReportsProgress = true;
            encryptionThread.DoWork += new DoWorkEventHandler(encryptionThread_EncryptFile);
            encryptionThread.ProgressChanged += new ProgressChangedEventHandler(encryptionThread_ProgressChanged);
            encryptionThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(encryptionThread_RunCompleted);
            encryptionThread.RunWorkerAsync();
        }


        private void encryptionThread_EncryptFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                log.Debug("Begin Encrypting: " + this.compressedFile);

                FileInfo fileInfo = new FileInfo(this.compressedFile);
                long filesize = fileInfo.Length;
                long numBytesEncrypted = 0;
            
                //UnicodeEncoding ue = new UnicodeEncoding();
                ASCIIEncoding ae = new ASCIIEncoding();


                byte[] key = ae.GetBytes(this.uploadFileAttributesForm.getPassword());
                string cryptFile = this.encryptedFile;

                log.Debug("Creating encrypred file at: " + this.encryptedFile);

                using (FileStream fileCrypt = new FileStream(cryptFile, FileMode.Create))
                {
                    using (RijndaelManaged encrypt = new RijndaelManaged())
                    {
                        encrypt.KeySize = 256;
                        encrypt.BlockSize = 128;
                        encrypt.GenerateIV();


                        byte[] initializationVector = new byte[16];
                        Array.Copy(key, initializationVector, Math.Min(key.Length, 16));


                        //log.Debug("EncryptIV Len: " + encrypt.IV.Length);
                        log.Debug("Key bytes length: " + key.Length + " Initilization Vector Length: " + initializationVector.Length);

                        using (CryptoStream cs = new CryptoStream(fileCrypt, encrypt.CreateEncryptor(key, initializationVector), CryptoStreamMode.Write))
                        {
                            using (FileStream fileInput = new FileStream(this.compressedFile, FileMode.Open))
                            {
                                int data;
                                while ((data = fileInput.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                    numBytesEncrypted++;

                                    if (numBytesEncrypted % 262144 == 0)
                                    {
                                        cs.Flush();
                                        log.Debug("Num bytes encrypted: " + numBytesEncrypted);
                                        int progressValue = (int)((numBytesEncrypted * 100) / filesize);
                                        encryptionThread.ReportProgress(progressValue);
                                    }
                                }
                            }
                        }
                    }
                }

                log.Info("Done creating encrypred file at: " + this.encryptedFile);
            }
            catch (Exception ex)
            {
                log.Error("Error while encrypting file: " + this.compressedFile, ex);
                throw ex;
            }
        }

        private void encryptionThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();

            encryptionProgressBar.Value = e.ProgressPercentage;

        }

        private void encryptionThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while compressing this file.  Please contact customer support.");
            }

            log.Info("Encryption Process finished at: " + DateTime.Now);

            encryptionProgressBar.Value = 100;

            log.Debug("Starting upload thread");

            uploadWorkerThread.WorkerReportsProgress = true;
            uploadWorkerThread.DoWork += new DoWorkEventHandler(uploadWorkerThread_UploadFile);
            uploadWorkerThread.ProgressChanged += new ProgressChangedEventHandler(uploadWorkerThread_ProgressChanged);
            uploadWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(uploadWorkerThread_RunCompleted);
            uploadWorkerThread.RunWorkerAsync();
        }

        
        private void uploadWorkerThread_UploadFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                GUID = SecureMedMailHttpSession.getSession().Upload(this.uploadFileAttributesForm, 
                    this.fileName, this.encryptedFile, uploadWorkerThread);
            }
            catch (Exception ex)
            {
                log.Error("Error while uploading file: " + this.encryptedFile, ex);
                throw ex;
            }
        }

        void uploadWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            uploadProgressBar.Value = e.ProgressPercentage;
        }

        void uploadWorkerThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while compressing this file.  Please contact customer support.");
            }
            
            log.Info("Upload Process finished at: " + DateTime.Now);

            uploadProgressBar.Value = 100;

            UploadGuid uploadGuid = new UploadGuid();
            uploadGuid.SetGuid(GUID);
            uploadGuid.StartPosition = FormStartPosition.CenterParent;
            uploadGuid.ShowDialog(this);
        }

        private void FileCleanup()
        {
            if (File.Exists(this.encryptedFile))
            {
                File.Delete(this.encryptedFile);
            }

            if (File.Exists(this.compressedFile))
            {
                File.Delete(this.compressedFile);
            }
        }
    }
}
