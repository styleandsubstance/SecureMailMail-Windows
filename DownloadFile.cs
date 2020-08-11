using System.IO;
using log4net;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json;
using SecureMedMail.Components.Dialog;
using SecureMedMail.Util.Encryption;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.Util.FileSystem;
using SecureMedMail.WebService.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SecureMedMail.WebService.Model;

namespace SecureMedMail
{
    public partial class DownloadFile : UserControl
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DownloadFile()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                downloadFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        public bool ValidateForm()
        {
            //check to make sure they entered a download directory
            if (string.IsNullOrEmpty(this.downloadFolderTextBox.Text))
            {
                throw new ValidationException("Please select a download folder");
            }

            //check to make sure the download directory they selected exists
            if (Directory.Exists(this.downloadFolderTextBox.Text) == false)
            {
                throw new ValidationException("The download directory does not exist");
            }

            //first check to make sure the user has entered a GUID
            if (string.IsNullOrEmpty(this.guidTextBox.Text))
            {
                throw new ValidationException("Please enter a GUID");
            }

            if (this.guidTextBox.Text.Length < UploadFileAttributesForm.GUID_MIN_LEN)
            {
                throw new ValidationException("GUID must at least " + UploadFileAttributesForm.GUID_MIN_LEN + " characters");
            }

            //check to make sure they entered a password
            if (string.IsNullOrEmpty(this.passwordTextBox.Text))
            {
                throw new ValidationException("Please enter a decryption password");
            }

            if (this.passwordTextBox.Text.Length < UploadFileAttributesForm.PASSWORD_MIN_LEN)
            {
                this.passwordTextBox.Text = "";
                throw new ValidationException("Password must be a minimum of " + UploadFileAttributesForm.PASSWORD_MIN_LEN + " characters");
            }

            if (this.passwordTextBox.Text.Length > UploadFileAttributesForm.PASSWORD_MAX_LEN)
            {
                this.passwordTextBox.Text = "";
                throw new ValidationException("Password must be a maximum of " + UploadFileAttributesForm.PASSWORD_MAX_LEN + " characters");
            }

            if (UploadFileAttributesForm.PasswordContainsInvalidCharacters(this.passwordTextBox.Text))
            {
                this.passwordTextBox.Text = "";
                throw new ValidationException("Password can only contain ASCII characters");
            }

            GuidFileProperties guidFileProperties;
            try
            {
                //all basic checks passed. check the server for information about
                //the specified GUID for further checks
                String json = SecureMedMailHttpSession.getSession().GetFilePropertiesByGUID(this.guidTextBox.Text);
                guidFileProperties = JsonConvert.DeserializeObject<GuidFileProperties>(json);

                //check to make sure the password they entered matches or download will be wasted
                SecureMedMailHttpSession.getSession().VerifyFilePasswordHash(
                    this.guidTextBox.Text, HashFunctions.Sha256(this.passwordTextBox.Text));
            }
            catch (WebServiceException wex)
            {
                throw new ValidationException(wex.Message);
            }

            if (guidFileProperties.mustBeAuthenticated == true || guidFileProperties.mustBeAccountMember == true)
            {
                if (SecureMedMailHttpSession.getSession().Authenticated() == false)
                {
                    Login login = new Login();
                    login.StartPosition = FormStartPosition.CenterParent;
                    login.SetError("This file requires authentication");
                    login.ShowDialog();
                    if (login.DialogResult != DialogResult.OK)
                    {
                        throw new ValidationException("This file requires authentication");
                    }
                }
            }

            if (guidFileProperties.isDeleted == true)
            {
                throw new ValidationException("This file is no longer available because it has been deleted");
            }

            if (guidFileProperties.isReady == false)
            {
                throw new ValidationException("This file is not ready to be downloaded.  Please try again later");
            }

            //now check to see if the user has enough free space on their filesystem to download this file
            DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(this.downloadFolderTextBox.Text));
            if (driveInfo.IsReady == false)
            {
                throw new ValidationException("Unable to write to this download location");
            }

            long spaceNeededForDownload = guidFileProperties.fileSize*3;
            log.Debug("The disk space needed for this file:" + spaceNeededForDownload + " Filesize on server: " + guidFileProperties.fileSize);

            if (driveInfo.TotalFreeSpace < spaceNeededForDownload)
            {
                throw new ValidationException("There is not enough space on this drive");
            }

            //handle warning if the file/directory associated with this
            //GUID already exists in the destination directory
            String destinationPath = Path.Combine(this.downloadFolderTextBox.Text, guidFileProperties.filename);
            log.Debug("Checing for file system existence of " + destinationPath);

            if (File.Exists(destinationPath) == true || Directory.Exists(destinationPath))
            {
                //prompt the user to confirm that file/directory should be overwritten
                WarningDialog warningDialog = new WarningDialog();
                warningDialog.StartPosition = FormStartPosition.CenterParent;
                warningDialog.WarningText = "A file/folder with the name " + guidFileProperties.filename 
                    + " exists in the download directory and will be overwritten.";
                
                if (warningDialog.ShowDialog() != DialogResult.Yes)
                {
                    log.Debug("Dialog did not return yes...throwning a validation exception");
                    warningDialog.Dispose();
                    this.downloadFolderTextBox.Text = string.Empty;
                    throw new ValidationException("Please select a different download directory");
                }
                else
                {
                    log.Debug("User has autherized deletion of previous file/folder: " + destinationPath);
                    warningDialog.Dispose();
                    try
                    {
                        FileSystemUtil.DeleteFileOrFolder(destinationPath);
                    }
                    catch (Exception exception)
                    {
                        log.Error("Unable to delete file/folder: " + destinationPath, exception);
                        throw new ValidationException("Unable to delete preexisting file/folder.");
                    }
                }
            }

            //TODO check to see if user has permission to write to this directory

            return true;
        }

        
        public DownloadForm buildDownloadForm()
        {
            DownloadForm downloadForm = 
                new DownloadForm(this.downloadFolderTextBox.Text, this.guidTextBox.Text, this.passwordTextBox.Text);

            return downloadForm;
        }

        private void DownloadFile_Load(object sender, EventArgs e)
        {

        }


    }
}
