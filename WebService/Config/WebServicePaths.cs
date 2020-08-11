using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace SecureMedMail.WebService.Config
{
    class WebServicePaths : ConfigurationSection
    {
//        private static String serverUrl = null;
//        private static NameValueCollection pathsConfigSection = null;
//
//        private static String getServerUrl()
//        {
//            if (WebServicePaths.serverUrl == null)
//            {
//                serverUrl = ConfigurationManager.AppSettings["ServerUrl"];
//            }
//            return serverUrl;
//        }
//
//        private static NameValueCollection getPathsConfigSection()
//        {
//            if (WebServicePaths.pathsConfigSection == null)
//            {
//                pathsConfigSection = ConfigurationManager.GetSection("WebServicePaths") as NameValueCollection;
//            }
//            return pathsConfigSection;
//        }
//
//        public static String Authenticate()
//        {
//            String url = getPathsConfigSection()["Authenticate"];
//            return getServerUrl() + url;
//        }
//
//
//        public static String Upload()
//        {
//            String url = getPathsConfigSection()["UploadFile"];
//            return getServerUrl() + url;
//        }
//
//        public static String Download()
//        {
//            String url = getPathsConfigSection()["DownloadFile"];
//            return getServerUrl() + url;
//
//        }
//
//        public static String GetUserFilePropertyProfiles()
//        {
//            String url = getPathsConfigSection()["GetUserFilePropertyProfiles"];
//            return getServerUrl() + url;
//
//        }
//
//
//        public static String GetFilePropertiesByGuid()
//        {
//            String url = getPathsConfigSection()["GetFilePropertiesByGuid"];
//            return getServerUrl() + url;
//        }

        private static String getServerUrl()
        {
            return Resources.WebServiceUrls.ServerUrl;
        }

        public static String Authenticate()
        {
            return getServerUrl() + Resources.WebServiceUrls.Authenticate;
        }


        public static String Upload()
        {
            return getServerUrl() + Resources.WebServiceUrls.UploadFile;
        }

        public static String Download()
        {
            return getServerUrl() + Resources.WebServiceUrls.DownloadFile;

        }

        public static String GetUserFilePropertyProfiles()
        {
            return getServerUrl() + Resources.WebServiceUrls.GetUserFilePropertyProfiles;

        }

        public static String GetFilePropertiesByGuid()
        {
            return getServerUrl() + Resources.WebServiceUrls.GetFilePropertiesByGuid;
        }

        public static String VerifyFilePasswordHash()
        {
            return getServerUrl() + Resources.WebServiceUrls.VerifyFilePasswordHash;
        }

        public static String CreateNewAccount()
        {
            return getServerUrl() + Resources.WebServiceUrls.AccountCreate;
        }

        public static String ConfirmDownloadByGuid()
        {
            return getServerUrl() + Resources.WebServiceUrls.ConfirmDownloadByGuid;
        }
    }
}
