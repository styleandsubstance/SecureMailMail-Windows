using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecureMedMail.WebService.Response
{
    public class DownloadFileResponse
    {
        public String fileName { get; set; }
        public String guid { get; set; }

        public DownloadFileResponse(String fileName, String guid)
        {
            this.fileName = fileName;
            this.guid = guid;
        }
    }
}
