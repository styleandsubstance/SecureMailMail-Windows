using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.WebService.Model
{
    class GuidFileProperties
    {
        public bool mustBeAccountMember { get; set; }
        public bool mustBeAuthenticated { get; set; }
        public String filename { get; set; }
        public long fileSize { get; set; }
        public bool isReady { get; set; }
        public bool isDeleted { get; set; }
    }
}
