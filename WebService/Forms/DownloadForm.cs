using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.WebService.Forms
{
    public class DownloadForm
    {
        public String directory {get; set;}
        public String guid {get; set;}
        public String password {get; set;}

        public DownloadForm(String directory, String guid, String password)
        {
            this.directory = directory;
            this.guid = guid;
            this.password = password;

        }


    }
}
