using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SecureMedMail.WebService.Forms;
using System.IO;
using System.Security.Cryptography;
using SecureMedMail.Util.Encryption;
using SecureMedMail.Dialog;

namespace SecureMedMail
{
    public partial class UploadFileProgress : UserControl
    {
        public String GUID { get; set; }

        private UploadFileForm uploadFileForm;

        public UploadFileProgress(UploadFileForm uploadFileForm)
        {
            this.uploadFileForm = uploadFileForm;


            InitializeComponent();

            this.uploadProgess.StartUpload(this.uploadFileForm.getFilePath(), 
                Path.GetFileName(this.uploadFileForm.getFilePath()), this.uploadFileForm.getUploadFileAttributesForm());
        }

        private void progressLabel_Click(object sender, EventArgs e)
        {

        }

        private void UploadProgress_Load(object sender, EventArgs e)
        {

        }
    }
}
