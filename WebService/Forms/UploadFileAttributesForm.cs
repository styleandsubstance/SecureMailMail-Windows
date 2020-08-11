using SecureMedMail.Util.Encryption;
using SecureMedMail.WebService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.WebService.Forms
{
    public class UploadFileAttributesForm
    {
        public static int PASSWORD_MIN_LEN = 8;
        public static int PASSWORD_MAX_LEN = 16;
        public static int GUID_MIN_LEN = 8;
        public static int DELETE_AFTER_NUMBER_OF_DAYS_MAX = 180;

        public static bool PasswordContainsInvalidCharacters(String val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                int characterValue = (int) val[i];
                if (characterValue < 32 || characterValue > 127)
                {
                    return true;
                }
            }

            return false;
        }

        
        String password;
        String description;

        Boolean deleteAfterDownload;
        Boolean mustBeAuthenticated;
        Boolean mustBeAccountMember;
        Boolean billDownloadToUploader;
        Boolean deleteAfterNumberOfDownloads;
        UInt32 deleteAfterNumberOfDownloadsValue;
        Boolean deleteAfterNumberOfDays;
        UInt32 deleteAfterNumberOfDaysValue;
        Boolean notifyUploaderAfterDownload;

        public UploadFileAttributesForm(
            String password,
            String description,
            Boolean deleteAfterDownload,
            Boolean mustBeAuthenticated,
            Boolean mustBeAccountMember,
            Boolean billDownloadToUploader,
            Boolean deleteAfterNumberOfDownloads,
            UInt32 deleteAfterNumberOfDownloadsValue,
            Boolean deleteAfterNumberOfDays, 
            UInt32 deleteAfterNumberOfDaysValue,
            Boolean notifyUploaderAfterDownload)
        {
            this.password = password;
            this.description = description;
            this.deleteAfterDownload = deleteAfterDownload;
            this.mustBeAuthenticated = mustBeAuthenticated;
            this.mustBeAccountMember = mustBeAccountMember;
            this.billDownloadToUploader = billDownloadToUploader;
            this.deleteAfterNumberOfDownloads = deleteAfterNumberOfDownloads;
            this.deleteAfterNumberOfDownloadsValue = deleteAfterNumberOfDownloadsValue;
            this.deleteAfterNumberOfDays = deleteAfterNumberOfDays;
            this.deleteAfterNumberOfDaysValue = deleteAfterNumberOfDaysValue;
            this.notifyUploaderAfterDownload = notifyUploaderAfterDownload;
        }


        private String buildFormFieldName(String propertyName)
        {
            return "file_properties." + propertyName;
        }


        public Dictionary<String, String> buildDictionaryForPost()
        {

            Dictionary<String, String> values = new Dictionary<String, String>();
            if (description != null)
            {
                values.Add("description", description);
            }

            if (password != null)
            {
                values.Add("password_hash", HashFunctions.Sha256(this.password));
            }
            else
            {
                values.Add("password_hash", "");
            }

            if ( deleteAfterDownload == true )
            {
                values.Add(buildFormFieldName(UploadFileProperty.DeleteAfterDownload), "true");
            }

            if ( mustBeAuthenticated == true )
            {
                values.Add(buildFormFieldName(UploadFileProperty.MustBeAuthenticated), "true");
            }

            if (mustBeAccountMember == true)
            {
                values.Add(buildFormFieldName(UploadFileProperty.MustBeAccountMember), "true");
            }

            if (billDownloadToUploader == true)
            {

                values.Add(buildFormFieldName(UploadFileProperty.BillDownloadToUploader), "true");
            }

            if ( deleteAfterNumberOfDownloads == true )
            {
                values.Add(buildFormFieldName(UploadFileProperty.DeleteAfterNumberOfDownloads), deleteAfterNumberOfDownloadsValue.ToString());
            }

            if (deleteAfterNumberOfDays == true)
            {
                values.Add(buildFormFieldName(UploadFileProperty.DeleteAfterNumberOfDays), deleteAfterNumberOfDaysValue.ToString());
            }

            if (notifyUploaderAfterDownload == true)
            {
                values.Add(buildFormFieldName(UploadFileProperty.NotifyUploaderAfterDownload), "true");
            }

            return values;
        }

        public String getPassword()
        {
            return password;
        }

        
    }
}
