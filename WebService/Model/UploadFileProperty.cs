using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.WebService.Model
{
    class UploadFileProperty
    {
        public static String DeleteAfterDownload = "DeleteAfterDownload";
        public static String MustBeAuthenticated = "MustBeAuthenticated";
        public static String MustBeAccountMember = "MustBeAccountMember";
        public static String BillDownloadToUploader = "BillDownloadToUploader";
        public static String DeleteAfterNumberOfDownloads = "DeleteAfterNumberOfDownloads";
        public static String DeleteAfterNumberOfDays = "DeleteAfterNumberOfDays";
        public static String NotifyUploaderAfterDownload = "NotifyUploaderAfterDownload";

        public static bool uploadFilePropertyValueToBoolean(String value)
        {
            if (value != null)
                return (value == "true");

            return false;
        }

        public static bool numericaUploadFilePropertyValueToBoolean(String value)
        {
            if (value == null)
            {
                return false;
            }

            return true;
        }


        public String name;
        public String value;
        public String type;



    }
}
