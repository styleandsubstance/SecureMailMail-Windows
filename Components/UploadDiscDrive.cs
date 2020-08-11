using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Forms;

namespace SecureMedMail.Components
{
    public partial class UploadDiscDrive : UserControl
    {
        public UploadDiscDrive()
        {
            InitializeComponent();
        }

        public bool ValidateForm()
        {
            String selectedDrive = this.discDriveComboBox.SelectedItem.ToString();

            DriveInfo driveInfo = new DriveInfo(selectedDrive);
            if (driveInfo.DriveType != DriveType.CDRom)
            {
                throw new ValidationException("Please select a valid CD/DVD/BluRay drive");
            }


            //check to see if the disc drive selected has a disc in it
            if (driveInfo.IsReady == false)
            {
                throw new ValidationException("There does not seem to be a disc in the selected drive");
            }

            if (driveInfo.TotalSize == 0)
            {
                throw new ValidationException("There does not seem to be any data on this disc");
            }

            if (Directory.GetDirectories(selectedDrive).Length + Directory.GetFiles(selectedDrive).Length == 0)
            {
                throw new ValidationException("There are no visible files/folders on this disc");
            }

            //validate the other parameters
            this.uploadFileOptions.Validate();

            return true;
        }

        private void uploadFileAttributes1_Load(object sender, EventArgs e)
        {
            
        }

        private void UploadDiscDrive_Load(object sender, EventArgs e)
        {
            if (SecureMedMailHttpSession.getSession().Authenticated() == false)
            {
                Login login = new Login();
                login.StartPosition = FormStartPosition.CenterParent;
                login.SetError("Please login to continue");
                login.ShowDialog();
                if (login.DialogResult != DialogResult.OK)
                {
                    throw new UnrecoverableErrorException("Uploads require authentication");
                }
            }

            DriveInfo[] drives = System.IO.DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.CDRom)
                {
                    this.discDriveComboBox.Items.Add(drive.Name);
                }
            }

            if (this.discDriveComboBox.Items.Count > 0)
            {
                this.discDriveComboBox.SelectedIndex = 0;
            }

        }

        public UploadDiscDriveForm buildUploadForm()
        {
            UploadFileAttributesForm uploadFileAttributesForm = this.uploadFileOptions.buildUploadForm();

            UploadDiscDriveForm uploadDiscDriveForm = new UploadDiscDriveForm(
                this.discDriveComboBox.SelectedItem.ToString(),
                uploadFileAttributesForm);

            return uploadDiscDriveForm;
        }
    }
}
