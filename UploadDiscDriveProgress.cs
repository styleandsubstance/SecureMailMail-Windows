using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DiscUtils.Iso9660;
using log4net;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Forms;
using SecureMedMail.Util.Encryption;
using System.Security.AccessControl;
using SecureMedMail.Dialog;

namespace SecureMedMail
{
    public partial class UploadDiscDriveProgress : UserControl
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UploadDiscDriveForm uploadDiscDriveForm {get; set;}
        private String isoFilePath;
        private long driveSize;

        public UploadDiscDriveProgress()
        {
            InitializeComponent();
        }

        private void UploadDiscDriveProgress_Load(object sender, EventArgs e)
        {
            this.isoFilePath = TempFile.GetTempFilePathWithExtension(".tmp");

            isoCreationThread.WorkerReportsProgress = true;
            isoCreationThread.DoWork += new DoWorkEventHandler(isoCreationThread_packageFile);
            isoCreationThread.ProgressChanged += new ProgressChangedEventHandler(isoCreationThread_ProgressChanged);
            isoCreationThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(isoCreationThread_RunCompleted);
            isoCreationThread.RunWorkerAsync();
        }

        private void isoCreationThread_packageFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                log.Debug("Getting Drive Info: " + this.uploadDiscDriveForm.getDrive());
                DriveInfo discDrive = new DriveInfo(this.uploadDiscDriveForm.getDrive());

                log.Debug("Done getting Drive Info: " + this.uploadDiscDriveForm.getDrive());

                this.driveSize = discDrive.TotalSize;

                log.Debug("Done getting Drive Drive Size: " + this.uploadDiscDriveForm.getDrive());

                log.Info("Begin building iso to path: : " + isoFilePath);

                CDBuilder cdBuilder = buildIsoForDirectory(this.uploadDiscDriveForm.getDrive());
                cdBuilder.SetCallback(isoCreationCallback);
                cdBuilder.Build(isoFilePath);

                log.Info("Done building iso to path: : " + isoFilePath);
            }
            catch (Exception ex)
            {
                log.Error("Error while creating ISO: " + this.isoFilePath);
                throw ex;
            }

        }

        private void isoCreationThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            isoCreationProgressBar.Value = e.ProgressPercentage;
        }

        private void isoCreationThread_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FileCleanup();
                throw new UnrecoverableErrorException("There has been error while creating an ISO of the disc.  Please contact customer support.");
            }
            
            //ISO creation is finished.  Now encrypt/transfer the file
            isoCreationProgressBar.Value = 100;

            log.Info("Finished creating iso at path: " + this.isoFilePath);

            this.uploadProgess.StartUpload(this.isoFilePath, "image.iso", uploadDiscDriveForm.getUploadFileAttributesForm());

            FileCleanup();

            log.Info("Called Start Upload Function: " + this.isoFilePath);
        }

        private void FileCleanup()
        {
            if (File.Exists(this.isoFilePath))
            {
                File.Delete(this.isoFilePath);
            }
        }

        public void isoCreationCallback(long bytesWrittenValue)
        {
            int percentageComplete = (int)((bytesWrittenValue * 100 / driveSize));
            isoCreationThread.ReportProgress(percentageComplete);
        }

        public CDBuilder buildIsoForDirectory(String rootDirectory)
        {

            CDBuilder builder = new CDBuilder();

            List<String> uniqueFiles = new List<String>();


            if (rootDirectory.EndsWith("" + Path.DirectorySeparatorChar) == false)
            {
                rootDirectory += Path.DirectorySeparatorChar;
            }

            string[] rootDirectoryFiles = Directory.GetFiles(rootDirectory);
            foreach (String file in rootDirectoryFiles)
            {
                string fileWithoutRootDirectory = file.Substring(rootDirectory.Length);


                if (uniqueFiles.Contains(fileWithoutRootDirectory) == false)
                {

                    if (HaveReadPemissionOnFile(file))
                    {
                        builder.AddFile(fileWithoutRootDirectory, file);
                        uniqueFiles.Add(fileWithoutRootDirectory);
                    }

                }
                else
                {
                    log.Info("Ignorning file due to permissions: " + file);
                }
            }


            string[] directories = Directory.GetDirectories(rootDirectory, "*.*", SearchOption.AllDirectories);
            foreach (string directory in directories)
            {

                string directoryWithoutRootDirectory = directory.Substring(rootDirectory.Length);

                if (uniqueFiles.Contains(directoryWithoutRootDirectory) == false)
                {
                    builder.AddDirectory(directoryWithoutRootDirectory);
                    uniqueFiles.Add(directoryWithoutRootDirectory);
                }

                string[] files = Directory.GetFiles(directory);
                foreach (String file in files)
                {
                    if (HaveReadPemissionOnFile(file))
                    {
                        string fileWithoutRootDirectory = file.Substring(rootDirectory.Length);

                        if (uniqueFiles.Contains(fileWithoutRootDirectory) == false)
                        {
                            builder.AddFile(fileWithoutRootDirectory, file);
                            uniqueFiles.Add(fileWithoutRootDirectory);
                        }
                    }
                    else
                    {
                        log.Info("Ignorning file due to permissions: " + file);
                    }
                }

            }

            return builder;
        }


        bool HaveReadPemissionOnFile(string path)
        {
            bool readAllow = false;
            bool readDeny = false;

            FileSecurity fileSecurity = null;
            try
            {
                fileSecurity = File.GetAccessControl(path);
            }
            catch (Exception e)
            {
                return false;
            }

            if (fileSecurity == null)
            {
                return false;
            }

            AuthorizationRuleCollection ac = fileSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

            if (ac == null)
            {
                return false;
            }

            foreach (FileSystemAccessRule far in ac)
            {
                if ((FileSystemRights.Read & far.FileSystemRights) != FileSystemRights.Read)
                {
                    continue;
                }

                if (far.AccessControlType == AccessControlType.Allow)
                {
                    readAllow = true;
                }
                else if (far.AccessControlType == AccessControlType.Deny)
                {
                    readDeny = true;
                }
            }

            return readAllow && !readDeny;
        }
    }
}
