using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecureMedMail.Util.Encryption
{
    public class TempFile
    {
        public static string GetTempFilePathWithExtension(string extension)
        {
            var path = Path.GetTempPath();
            var fileName = Guid.NewGuid().ToString() + extension;
            return Path.Combine(path, fileName);
        }

    }

}
