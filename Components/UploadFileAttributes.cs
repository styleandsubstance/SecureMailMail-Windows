using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using log4net;
using SecureMedMail.Components.Dialog;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Model;
using Newtonsoft.Json;
using SecureMedMail.WebService.Forms;

namespace SecureMedMail.Components
{
    public partial class UploadFileAttributes : UserControl
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        List<FilePropertyProfile> profiles = null;
        
        public UploadFileAttributes()
        {
            InitializeComponent();
            
        }

        private void UploadFileAttributes_Load(object sender, EventArgs e)
        {

        }


        public void LoadProfileValues()
        {
            userProfileBackgroundWorker.DoWork += new DoWorkEventHandler(userProfileBackgroundWorker_GetUserFilePropertyProfiles);
            userProfileBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(userProfileBackgroundWorker_PopulateProfileValeues);
            userProfileBackgroundWorker.RunWorkerAsync();
        }

        private void userProfileBackgroundWorker_GetUserFilePropertyProfiles(object sender, DoWorkEventArgs e)
        {
            //make the request to the server
            String userProfileFilePropertiesJSON = SecureMedMailHttpSession.getSession().GetUserFilePropertyProfiles();

            //convert the JSON string to an array of FilePropertyProfiles
            profiles = JsonConvert.DeserializeObject<List<FilePropertyProfile>>(userProfileFilePropertiesJSON);
        }

        private void userProfileBackgroundWorker_PopulateProfileValeues(object sender, RunWorkerCompletedEventArgs e)
        {
            log.Debug("Populating user profile values");
            //populate the profile select box
            this.profileSelectBox.Items.Clear();
            FilePropertyProfile defaultProfile = null;
            profiles.ForEach(profile =>
            {
                log.Debug("Adding profile with name: " + profile.name);
                this.profileSelectBox.Items.Add(profile.name);

                if (profile.is_default_profile)
                {
                    defaultProfile = profile;
                    this.profileSelectBox.SelectedIndex = this.profileSelectBox.Items.Count - 1;
                }
            });

            //populate the checkbox with the default profile's values
            PopulateCheckboxesForProfile(defaultProfile);

        }

        private void PopulateCheckboxesForProfile(FilePropertyProfile profile)
        {
            foreach (UploadFileProperty fileProperty in profile.properties)
            {
                if (fileProperty.name == UploadFileProperty.DeleteAfterDownload)
                {
                    this.deleteAfterDownloadCheckbox.Checked =
                        UploadFileProperty.uploadFilePropertyValueToBoolean(fileProperty.value);
                }
                else if (fileProperty.name == UploadFileProperty.MustBeAuthenticated)
                {
                    this.mustBeAuthenticatedCheckbox.Checked =
                        UploadFileProperty.uploadFilePropertyValueToBoolean(fileProperty.value);
                }
                else if (fileProperty.name == UploadFileProperty.MustBeAccountMember)
                {
                    this.mustBeAccountMemberCheckbox.Checked =
                        UploadFileProperty.uploadFilePropertyValueToBoolean(fileProperty.value);
                }
                else if (fileProperty.name == UploadFileProperty.BillDownloadToUploader)
                {
                    this.billDownloadToUploaderCheckbox.Checked =
                        UploadFileProperty.uploadFilePropertyValueToBoolean(fileProperty.value);
                }
                else if (fileProperty.name == UploadFileProperty.DeleteAfterNumberOfDownloads)
                {

                    if (fileProperty.value == null)
                    {
                        this.deleteAfterNumberOfDownloadsCheckbox.Checked = false;
                        this.deleteAfterNumberOfDownloadsTextBox.Enabled = false;
                    }
                    else
                    {
                        this.deleteAfterNumberOfDownloadsCheckbox.Checked = true;
                        this.deleteAfterNumberOfDownloadsTextBox.Enabled = true;
                        this.deleteAfterNumberOfDownloadsTextBox.Text = fileProperty.value;
                    }
                }
                else if (fileProperty.name == UploadFileProperty.DeleteAfterNumberOfDays)
                {
                    if (fileProperty.value == null)
                    {
                        this.deleteAfterNumberOfDaysCheckbox.Checked = false;
                        this.deleteAfterNumberOfDaysTextBox.Enabled = false;
                    }
                    else
                    {
                        this.deleteAfterNumberOfDaysCheckbox.Checked = true;
                        this.deleteAfterNumberOfDaysTextBox.Enabled = true;
                        this.deleteAfterNumberOfDaysTextBox.Text = fileProperty.value;
                    }
                }
                else if (fileProperty.name == UploadFileProperty.NotifyUploaderAfterDownload)
                {
                    this.notifyUploaderAfterDownloadCheckbox.Checked =
                        UploadFileProperty.uploadFilePropertyValueToBoolean(fileProperty.value);
                }
            }
        }

        public UploadFileAttributesForm buildUploadForm()
        {
            UInt32 deleteAfterNumberOfDownloads = 0;
            UInt32 deleteAfterNumberOfDays = 0;

            if (this.deleteAfterNumberOfDownloadsCheckbox.Checked)
            {
                deleteAfterNumberOfDownloads = Convert.ToUInt32(this.deleteAfterNumberOfDownloadsTextBox.Text);
            }

            if (deleteAfterNumberOfDaysCheckbox.Checked)
            {
                deleteAfterNumberOfDays = Convert.ToUInt32(this.deleteAfterNumberOfDaysTextBox.Text);
            }

            UploadFileAttributesForm uploadFileAttributesForm = new UploadFileAttributesForm(
                this.passwordTextBox.Text,
                this.descriptionTextBox.Text,
                this.deleteAfterDownloadCheckbox.Checked,
                this.mustBeAuthenticatedCheckbox.Checked,
                this.mustBeAccountMemberCheckbox.Checked,
                this.billDownloadToUploaderCheckbox.Checked,
                this.deleteAfterNumberOfDownloadsCheckbox.Checked,
                deleteAfterNumberOfDownloads,
                this.deleteAfterNumberOfDaysCheckbox.Checked,
                deleteAfterNumberOfDays,
                this.notifyUploaderAfterDownloadCheckbox.Checked);

            return uploadFileAttributesForm;
        }

        private void profileSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String profileNameSelected = this.profileSelectBox.SelectedItem.ToString();

            FilePropertyProfile selectedProfile = profiles.Find(p => p.name == profileNameSelected);
            PopulateCheckboxesForProfile(selectedProfile);
        }

        private void deleteAfterNumberOfDownloadsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.deleteAfterNumberOfDownloadsCheckbox.Checked)
            {
                this.deleteAfterNumberOfDownloadsTextBox.Enabled = true;
                this.deleteAfterNumberOfDownloadsTextBox.Text = "";
            }
            else
            {
                this.deleteAfterNumberOfDownloadsTextBox.Text = "";
                this.deleteAfterNumberOfDownloadsTextBox.Enabled = false;
            }
        }

        private void deleteAfterNumberOfDaysCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.deleteAfterNumberOfDaysCheckbox.Checked)
            {
                this.deleteAfterNumberOfDaysTextBox.Enabled = true;
                this.deleteAfterNumberOfDaysTextBox.Text = "";
            }
            else
            {
                this.deleteAfterNumberOfDaysTextBox.Text = "";
                this.deleteAfterNumberOfDaysTextBox.Enabled = false;
            }
        }


        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.passwordTextBox.Text))
            {
                throw new ValidationException("Please enter a strong password for this file");
            }

            if (string.IsNullOrEmpty(this.confirmPasswordTextBox.Text))
            {
                throw new ValidationException("Please confirm the password for this file");
            }

            if (this.passwordTextBox.Text != this.confirmPasswordTextBox.Text)
            {
                this.passwordTextBox.Text = "";
                this.confirmPasswordTextBox.Text = "";
                throw new ValidationException("Password do not match.  Please try again");
            }

            if (this.passwordTextBox.Text.Length < UploadFileAttributesForm.PASSWORD_MIN_LEN)
            {
                this.passwordTextBox.Text = "";
                this.confirmPasswordTextBox.Text = "";
                throw new ValidationException("Password must be a minimum of " + UploadFileAttributesForm.PASSWORD_MIN_LEN + " characters");
            }

            if (this.passwordTextBox.Text.Length > UploadFileAttributesForm.PASSWORD_MAX_LEN)
            {
                this.passwordTextBox.Text = "";
                this.confirmPasswordTextBox.Text = "";
                throw new ValidationException("Password must be a maximum of " + UploadFileAttributesForm.PASSWORD_MAX_LEN + " characters");
            }

            if (UploadFileAttributesForm.PasswordContainsInvalidCharacters(this.passwordTextBox.Text))
            {
                this.passwordTextBox.Text = "";
                this.confirmPasswordTextBox.Text = "";
                throw new ValidationException("Password can only contain ASCII characters");
            }

            //check to make sure that they have selected some file deletion scheme..either after download,
            //after a set number of days, or after a set number of dowloads
            if (this.deleteAfterDownloadCheckbox.Checked == false
                && this.deleteAfterNumberOfDaysCheckbox.Checked == false
                && this.deleteAfterNumberOfDownloadsCheckbox.Checked == false)
            {
                throw new ValidationException("You must select at least one file deletion option");
            }

            if (this.deleteAfterNumberOfDaysCheckbox.Checked == true)
            {
                if (string.IsNullOrEmpty(this.deleteAfterNumberOfDaysTextBox.Text))
                {
                    throw new ValidationException("You must select a value if Delete After Number Of Days is checked");
                }

                int numberOfDays = 0;
                try
                {
                     numberOfDays = Convert.ToInt32(this.deleteAfterNumberOfDaysTextBox.Text);
                }
                catch (Exception e)
                {
                    throw new ValidationException("Please enter a valid number for Delete After Number Of Days");
                }

                if (numberOfDays <= 0)
                {
                    throw new ValidationException("Please enter a positive number of days for Delete After Number Of Days");
                }

                if (numberOfDays <= 0 || numberOfDays > UploadFileAttributesForm.DELETE_AFTER_NUMBER_OF_DAYS_MAX)
                {
                    throw new ValidationException("The maxium number of days a file can be stored is "
                        + UploadFileAttributesForm.DELETE_AFTER_NUMBER_OF_DAYS_MAX);
                }
            }

            if (this.deleteAfterNumberOfDownloadsCheckbox.Checked == true)
            {
                if (string.IsNullOrEmpty(this.deleteAfterNumberOfDownloadsTextBox.Text))
                {
                    throw new ValidationException("You must select a value if Delete After Number Of Downloads is checked");
                }

                int numberODownloads = 0;
                try
                {
                    numberODownloads = Convert.ToInt32(this.deleteAfterNumberOfDownloadsTextBox.Text);

                }
                catch (Exception e)
                {
                    throw new ValidationException("Please enter a valid number for Delete After Number Of Downloads");
                }

                if (numberODownloads <= 0)
                {
                    throw new ValidationException("Please enter a positive number of days for Delete After Number Of Downloads");
                }
            }

            //check to make sure that anonymous downloads are billed to uploader
            if (this.mustBeAccountMemberCheckbox.Checked == false 
                && this.mustBeAuthenticatedCheckbox.Checked == false 
                && this.billDownloadToUploaderCheckbox.Checked == false) 
            {
                throw new ValidationException("Bill Download To Uploader must be checked for anonymous downloads");
            }

            return true;
        }


        public void OpenHelpPage(String topicId)
        {
            Help.ShowHelp(this, "SecureMedMail.chm", HelpNavigator.TopicId, topicId);
        }


        private void deleteAfterDownloadHelp_Click(object sender, EventArgs e)
        {
            OpenHelpPage(Resources.HelpFileValues.deleteAfterDownloadHelpTopicId);
        }


        private void mustBeAuthenticatedHelp_Click(object sender, EventArgs e)
        {
            OpenHelpPage(Resources.HelpFileValues.mustBeAuthenticatedHelpTopicId);
        }

        private void mustBeAccountMemberHelp_Click(object sender, EventArgs e)
        {
            OpenHelpPage(Resources.HelpFileValues.mustBeAccountMemberHelpTopicId);
        }

        private void billDownloadToUploaderHelp_Click(object sender, EventArgs e)
        {
            OpenHelpPage(Resources.HelpFileValues.billDownloadToUploaderHelpTopicId);
        }

        private void deleteAfterNumberOfDownloadsHelp_Click(object sender, EventArgs e)
        {
            OpenHelpPage(Resources.HelpFileValues.deleteAfterNumberOfDownloadsHelpTopicId);
        }

        private void deleteAfterNumberOfDaysHelp_Click(object sender, EventArgs e)
        {
            OpenHelpPage(Resources.HelpFileValues.deleteAfterNumberOfDaysHelpTopicId);
        }

        private void notifyUploaderAfterDownloadHelp_Click(object sender, EventArgs e)
        {
            OpenHelpPage(Resources.HelpFileValues.notifyUploaderAfterDownloadHelpTopicId);
        }
    }
}
