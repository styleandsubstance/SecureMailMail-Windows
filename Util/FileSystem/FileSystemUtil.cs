using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using log4net;

namespace SecureMedMail.Util.FileSystem
{
    public class FileSystemUtil
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void DeleteFileOrFolder(String path)
        {

            if (File.Exists(path) == false && Directory.Exists(path) == false)
            {
                log.Debug("The path " + path + " does not exist as a file or a folder on the filesystem");
                return;
            }

            FileAttributes attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                log.Debug("Recusively deleting directory " + path);
                Directory.Delete(path, true);
            }
            else
            {
                log.Debug("Deleting file " + path);
                File.Delete(path);
            }
        }

    }
}
