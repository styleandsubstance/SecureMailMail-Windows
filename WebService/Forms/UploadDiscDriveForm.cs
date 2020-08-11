using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.WebService.Forms
{
    public class UploadDiscDriveForm
    {
        String drive;
        UploadFileAttributesForm uploadFileAttributesForm;

        public UploadDiscDriveForm(String drive,
            UploadFileAttributesForm uploadFileAttributesForm)
        {
            this.drive = drive;
            this.uploadFileAttributesForm = uploadFileAttributesForm;
        }

        public String getDrive()
        {
            return drive;
        }

        public UploadFileAttributesForm getUploadFileAttributesForm()
        {
            return uploadFileAttributesForm;
        }
    }
}
