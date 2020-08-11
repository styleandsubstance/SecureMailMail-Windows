using SecureMedMail.WebService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.WebService.Forms
{
    public class UploadFileForm
    {
        String filepath;
        UploadFileAttributesForm uploadFileAttributesForm;

        public UploadFileForm(String filepath,
            UploadFileAttributesForm uploadFileAttributesForm)
        {
            this.filepath = filepath;
            this.uploadFileAttributesForm = uploadFileAttributesForm;
            
        }

        public String getFilePath()
        {
            return filepath;
        }

        public UploadFileAttributesForm getUploadFileAttributesForm()
        {
            return uploadFileAttributesForm;
        }

    }
}
