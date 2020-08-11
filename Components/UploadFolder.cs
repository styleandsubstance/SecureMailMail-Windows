using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Forms;

namespace SecureMedMail.Components
{
    public partial class UploadFolder : UserControl
    {
        public UploadFolder()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                localFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        internal bool ValidateForm()
        {
            //check to make sure that user has selected a folder
            if (string.IsNullOrEmpty(this.localFolderPath.Text))
            {
                throw new ValidationException("Please select a folder");
            }

            //check to make sure that the selected folder exists on the system
            if (Directory.Exists(this.localFolderPath.Text) == false)
            {
                throw new ValidationException("Please select a valid folder");
            }

            if (Directory.GetDirectories(this.localFolderPath.Text).Length +
                Directory.GetFiles(this.localFolderPath.Text).Length == 0)
            {
                throw new ValidationException("Please select a folder that is not empty");
            }

            this.uploadFileOptions.Validate();

            return true;
        }

        internal UploadFileForm buildUploadForm()
        {
            UploadFileAttributesForm uploadFileAttributesForm = this.uploadFileOptions.buildUploadForm();

            UploadFileForm uploadFileForm = new UploadFileForm(
                this.localFolderPath.Text, uploadFileAttributesForm);

            return uploadFileForm;
        }

        private void UploadFolder_Load(object sender, EventArgs e)
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
        }
    }
}
