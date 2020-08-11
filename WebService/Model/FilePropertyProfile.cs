using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.WebService.Model
{
    class FilePropertyProfile
    {
        public String name;
        public String description;
        public Boolean is_default_profile;
        public List<UploadFileProperty> properties;
    }
}
