using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using log4net;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Model;
using Newtonsoft.Json;
using SecureMedMail.WebService.Forms;

namespace SecureMedMail
{
    public partial class UploadFile : UserControl
    {

        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        List<FilePropertyProfile> profiles = null;

        public UploadFile()
        {
            InitializeComponent();
        }


        public bool Validate()
        {
            //check to see if  they have selected a path
            if (string.IsNullOrEmpty(this.localFilePath.Text))
            {
                throw new ValidationException("Please select a file to upload");
            }

            //make sure that the file exists
            if (File.Exists(this.localFilePath.Text) == false)
            {
                throw new ValidationException("Please select a select that exists");
            }

            this.uploadFileOptions.Validate();

            return true;

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        private void UploadFile_Load(object sender, EventArgs e)
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


        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                localFilePath.Text = openFileDialog1.FileName;
            }
        }

        public UploadFileForm buildUploadForm()
        {
            UploadFileForm uploadForm = new UploadFileForm(this.localFilePath.Text,
                this.uploadFileOptions.buildUploadForm());

            return uploadForm;
        }
    }
}
