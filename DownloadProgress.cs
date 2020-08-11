using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using log4net;
using SecureMedMail.Components.Dialog;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Forms;
using SecureMedMail.Util.Encryption;
using System.IO;
using System.Security.Cryptography;
using SecureMedMail.WebService.Response;
using SevenZip;

namespace SecureMedMail
{
    public partial class DownloadProgress : UserControl
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DownloadForm downloadForm;
        private String downloadedFilePath = null;
        private String decryptedFilePath = null;
        private String decompressedFolderPath = null;
        private String decompressedFilePath = null;
        private String filenameForGuid = null;
        private String filePath = null;
        private String downloadGuid = null;

        public DownloadProgress(DownloadForm downloadForm)
        {
            InitializeComponent();

            this.downloadForm = downloadForm;
            this.downloadedFilePath = TempFile.GetTempFilePathWithExtension(".tmp");


            downloadWorkerThread.WorkerReportsProgress = true;
            downloadWorkerThread.DoWork += new DoWorkEventHandler(downloadWorkerThread_DownloadFile);
            downloadWorkerThread.ProgressChanged += new ProgressChangedEventHandler(downloadWorkerThread_ProgressChanged);
            downloadWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(downloadWorkerThread_RunCompleted);


            downloadWorkerThread.RunWorkerAsync();
        }

        private void downloadWorkerThread_DownloadFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                log.Debug("Downloading with with upload GUID: " + this.downloadForm.guid + " to location: " + this.downloadedFilePath);
                DownloadFileResponse downloadResponse = SecureMedMailHttpSession.getSession().Download(downloadForm.guid, this.downloadedFilePath, downloadWorkerThread);
                this.filenameForGuid = downloadResponse.fileName;
                this.downloadGuid = downloadResponse.guid;
                log.Info("Upload GUID of : " + this.downloadForm.guid + " has a filename of " +  this.filenameForGuid + " and has been assigned a download GUID: " + this.downloadGuid);
            }
            catch (Exception ex)
            {
                log.Error("Error while downloading file with GUID: " + this.downloadForm.guid, ex);
                throw ex;
            }
        }

        void downloadWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            downloadProgressBar.Value = e.ProgressPercentage;
        }

        void downloadWorkerThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while downloading this file.  Please contact customer support.");
            }

            downloadProgressBar.Value = 100;

            decryptionWorkerThread.WorkerReportsProgress = true;
            decryptionWorkerThread.DoWork += new DoWorkEventHandler(decryptionWorkerThread_DecryptFile);
            decryptionWorkerThread.ProgressChanged += new ProgressChangedEventHandler(decryptionWorkerThread_ProgressChanged);
            decryptionWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(decryptionWorkerThread_RunCompleted);


            decryptionWorkerThread.RunWorkerAsync();
        }



        private void decryptionWorkerThread_DecryptFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(this.downloadedFilePath);
                long filesize = fileInfo.Length;
                long numBytesDecrypted = 0;

                //String decrytedFilePath = Path.Combine(downloadForm.directory, "NewFile.txt");
                this.decryptedFilePath = TempFile.GetTempFilePathWithExtension(".dec");


                ASCIIEncoding ae = new ASCIIEncoding();

                byte[] key = ae.GetBytes(downloadForm.password);


                using (FileStream fileCrypt = new FileStream(this.decryptedFilePath, FileMode.Create))
                {
                    using (RijndaelManaged decrypt = new RijndaelManaged())
                    {
                        decrypt.KeySize = 256;
                        decrypt.BlockSize = 128;
                        //encrypt.GenerateIV();

                        byte[] initializationVector = new byte[16];
                        Array.Copy(key, initializationVector, key.Length);



                        using (CryptoStream cs = new CryptoStream(fileCrypt, decrypt.CreateDecryptor(key, initializationVector), CryptoStreamMode.Write))
                        {
                            using (FileStream fileInput = new FileStream(this.downloadedFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fileInput.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                    numBytesDecrypted++;

                                    if (numBytesDecrypted % 262144 == 0)
                                    {
                                        cs.Flush();
                                        int progressValue = (int)((numBytesDecrypted * 100) / filesize);
                                        decryptionWorkerThread.ReportProgress(progressValue);
                                    }
                                }

                                cs.Flush();
                                decryptionWorkerThread.ReportProgress(100);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error while decryting file: " + this.downloadForm.guid, ex);
                throw ex;
            }
        }

        private void decryptionWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            decryptionProgressBar.Value = e.ProgressPercentage;
        }

        private void decryptionWorkerThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while decrypting this file.  Please contact customer support.");
            }

            this.decryptionProgressBar.Value = 100;

            decompressionWorkerThread.WorkerReportsProgress = true;
            decompressionWorkerThread.DoWork += new DoWorkEventHandler(decompressWorkerThread_DecompressFile);
            decompressionWorkerThread.ProgressChanged += new ProgressChangedEventHandler(decompressWorkerThread_ProgressChanged);
            decompressionWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(decompressWorkerThread_RunCompleted);

            decompressionWorkerThread.RunWorkerAsync();
        }

        private void decompressWorkerThread_DecompressFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.decompressedFolderPath = TempFile.GetTempFilePathWithExtension("");

                log.Info("Saving decompressed file to directory: " + decompressedFolderPath);

//                using (var tmp = new SevenZipExtractor(
//                    File.OpenRead(this.decryptedFilePath)))
//                {
//                    tmp.FileExtractionStarted += (s, ev) =>
//                    {
//                        decompressionWorkerThread.ReportProgress(ev.PercentDone);
//
//                    };
//                    tmp.ExtractionFinished += (s, ev) =>
//                    {
//                        decompressionWorkerThread.ReportProgress(100);
//                    };
//                    tmp.ExtractArchive(this.decompressedFolderPath);
//                }

                Chilkat.Zip zip = new Chilkat.Zip();

                bool success;

                //  Any string unlocks the component for the 1st 30-days.
                success = zip.UnlockComponent("Anything for 30-day trial");
                if (success != true)
                {
                    throw new Exception(zip.LastErrorText);
                }

                zip.OpenZip(this.decryptedFilePath);

                zip.OnPercentDone += (s, a) => decompressionWorkerThread.ReportProgress(a.PercentDone); ;

                Directory.CreateDirectory(this.decompressedFolderPath);

                int unzipCount = zip.Unzip(this.decompressedFolderPath);
                if (unzipCount < 0)
                {
                    zip.CloseZip();
                    throw new Exception(zip.LastErrorText);
                }

                zip.CloseZip();
            }
            catch(Exception ex)
            {
                log.Error("Error while decompressing file: " + this.downloadForm.guid, ex);
                throw ex;
            }
        }

        private void decompressWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            decompressionProgressBar.Value = e.ProgressPercentage;
        }


        private void decompressWorkerThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while decompressing this file.  Please contact customer support.");
            }

            extractionWorkerThread.WorkerReportsProgress = true;
            extractionWorkerThread.DoWork += new DoWorkEventHandler(extractionWorkerThread_ExtractFile);
            extractionWorkerThread.ProgressChanged += new ProgressChangedEventHandler(extractionWorkerThread_ProgressChanged);
            extractionWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(extractionWorkerThread_RunCompleted);

            extractionWorkerThread.RunWorkerAsync();
        }


        private void extractionWorkerThread_ExtractFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                String[] filesInDecompressedDirectory = Directory.GetFiles(this.decompressedFolderPath);
                String extensionOfFilenameForGuid = Path.GetExtension(this.filenameForGuid);

                if (extensionOfFilenameForGuid == ".iso" && filesInDecompressedDirectory.Length == 1)
                {
                    this.filePath = Path.Combine(downloadForm.directory, Path.GetFileNameWithoutExtension(this.filenameForGuid));
                    this.decompressedFilePath = filesInDecompressedDirectory[0];
                    Directory.CreateDirectory(this.filePath);

                    using (var tmp = new SevenZipExtractor(
                        File.OpenRead(this.decompressedFilePath)))
                    {
                        tmp.FileExtractionStarted += (s, ev) =>
                        {
                            extractionWorkerThread.ReportProgress(ev.PercentDone);

                        };
                        tmp.ExtractionFinished += (s, ev) => 
                        {
                            extractionWorkerThread.ReportProgress(100);
                        };
                        tmp.ExtractArchive(this.filePath);
                    }
                }
                else
                {
                    this.filePath = Path.Combine(downloadForm.directory, this.filenameForGuid);

                    if (filesInDecompressedDirectory.Length == 1)
                    {
                        this.decompressedFilePath = filesInDecompressedDirectory[0];
                        File.Move(this.decompressedFilePath, this.filePath);
                    }
                    else
                    {
                        //in this, they must have 
                        Directory.CreateDirectory(filePath);

                        for (int i = 0; i < filesInDecompressedDirectory.Length; i++)
                        {
                            this.decompressedFilePath = filesInDecompressedDirectory[i];
                            String newPath = Path.Combine(filePath, Path.GetFileName(this.decompressedFilePath));
                            File.Move(this.decompressedFilePath, newPath);
                        }

                        //now go through any directories that were in the compressed folder
                        String[] directoriesInDecompressedDirectory = Directory.GetDirectories(this.decompressedFolderPath);
                        for (int i = 0; i < directoriesInDecompressedDirectory.Length; i++)
                        {
                            this.decompressedFilePath = directoriesInDecompressedDirectory[i];
                            String newPath = Path.Combine(filePath, Path.GetFileName(this.decompressedFilePath));
                            Directory.Move(this.decompressedFilePath, newPath);
                        }


                    }

                    extractionWorkerThread.ReportProgress(100);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error while extracting file: " + this.downloadForm.guid, ex);
                throw ex;
            }
        }

        private void extractionWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            extractionProgressBar.Value = e.ProgressPercentage;
        }


        private void extractionWorkerThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while downloading this file.  Please contact customer support.");
            }

            this.extractionProgressBar.Value = 100;

            confirmationWorkerThread.WorkerReportsProgress = false;
            confirmationWorkerThread.DoWork += new DoWorkEventHandler(confirmationWorkerThread_confirmDownload);
            confirmationWorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(confirmationWorkerThread_RunCompleted);

            confirmationWorkerThread.RunWorkerAsync();
        }

        private void confirmationWorkerThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileCleanup();

            if (e.Error != null)
            {
                throw new UnrecoverableErrorException("There has been error while confirming this download.  Please contact customer support.");
            }
            
            String folderPath = this.filePath;
            if (Directory.Exists(folderPath) == false)
            {
                folderPath = Path.GetDirectoryName(this.filePath);
            }

            DownloadSuccess downloadSuccess = new DownloadSuccess(folderPath);
            downloadSuccess.StartPosition = FormStartPosition.CenterParent;
            downloadSuccess.ShowDialog(this);
        }

        private void confirmationWorkerThread_confirmDownload(object sender, DoWorkEventArgs e)
        {
            try
            {
                log.Debug("Confirmation download with GUID: " + this.downloadGuid);
                SecureMedMailHttpSession.getSession().ConfirmDownloadByGuid(this.downloadGuid);
                log.Debug("Successfully confirmed download with GUID: " + this.downloadGuid);
            }
            catch (Exception ex)
            {
                log.Error("Failed to verify download with GUID: " + this.downloadGuid, ex);
                throw ex;
            }
        }

        private void FileCleanup()
        {
            if (File.Exists(this.downloadedFilePath))
            {
                File.Delete(this.downloadedFilePath);
            }

            if (File.Exists(this.decryptedFilePath))
            {
                File.Delete(this.decryptedFilePath);
            }

            if (Directory.Exists(this.decompressedFolderPath))
            {
                Directory.Delete(this.decompressedFolderPath, true);
            }
        }


        private void DownloadProgress_Load(object sender, EventArgs e)
        {

        }
    }
}
