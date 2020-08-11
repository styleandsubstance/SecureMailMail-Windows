using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SecureMedMail.Components.Dialog;
using SecureMedMail.Util.Exceptions;
using SecureMedMail.WebService.Forms;

namespace SecureMedMail.Components
{
    public partial class UploadFileOptions : UserControl
    {
        private int SELECTED_DOWNLOAD_FOR_INDEX = 0;
        private int BILLING_MY_ACCOUNT_INDEX = 0;
        
        
        
        public UploadFileOptions()
        {
            InitializeComponent();
        }


        private void UploadFileOptions_Load(object sender, EventArgs e)
        {
            this.downloadAllowedForComboBox.Items.Add(Resources.UploadFileOptions.DOWNLOAD_FOR_MEMBERS_ONLY);
            this.downloadAllowedForComboBox.Items.Add(Resources.UploadFileOptions.DOWNLOAD_FOR_REGISTERED_USERS);
            this.downloadAllowedForComboBox.Items.Add(Resources.UploadFileOptions.DOWNLOAD_FOR_ANYONE);
            this.downloadAllowedForComboBox.SelectedIndex = 0;



            this.deletionComboBox.Items.Add(Resources.UploadFileOptions.DELETE_FILE_IMMEDIATELY);
            this.deletionComboBox.Items.Add(Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DAYS);
            this.deletionComboBox.Items.Add(Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DOWNLOADS);
            this.deletionComboBox.SelectedIndex = 0;


            this.billingComboBox.Items.Add(Resources.UploadFileOptions.BILL_TO_DOWNLOADING_USER);
            this.billingComboBox.Items.Add(Resources.UploadFileOptions.BILL_TO_MY_ACCOUNT);
            this.BILLING_MY_ACCOUNT_INDEX = this.billingComboBox.Items.Count - 1;

            this.billingComboBox.SelectedIndex = 0;

        }

        public UploadFileAttributesForm buildUploadForm()
        {
            UInt32 deleteAfterNumberOfDownloads = 0;
            UInt32 deleteAfterNumberOfDays = 0;

            if (this.deletionComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DOWNLOADS)
            {
                deleteAfterNumberOfDownloads = Convert.ToUInt32(this.deletionTextValue.Text);
            }

            if (this.deletionComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DAYS)
            {
                deleteAfterNumberOfDays = Convert.ToUInt32(this.deletionTextValue.Text);
            }

            UploadFileAttributesForm uploadFileAttributesForm = new UploadFileAttributesForm(
                this.passwordTextBox.Text,
                this.descriptionTextBox.Text,
                this.deletionComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DELETE_FILE_IMMEDIATELY,
                this.downloadAllowedForComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DOWNLOAD_FOR_MEMBERS_ONLY ||
                    this.downloadAllowedForComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DOWNLOAD_FOR_REGISTERED_USERS,
                this.downloadAllowedForComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DOWNLOAD_FOR_MEMBERS_ONLY,
                this.billingComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.BILL_TO_MY_ACCOUNT,
                this.deletionComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DOWNLOADS,
                deleteAfterNumberOfDownloads,
                this.deletionComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DAYS,
                deleteAfterNumberOfDays,
                this.notifyUploaderAfterDownloadCheckbox.Checked);

            return uploadFileAttributesForm;
        }

        private void deletionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.deletionComboBox.SelectedItem.ToString() ==
                Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DOWNLOADS)
            {
                this.deletionTextValue.Visible = true;
                this.deletionLabel.Text = "downloads";
            }
            else if (this.deletionComboBox.SelectedItem.ToString() ==
                     Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DAYS)
            {
                this.deletionTextValue.Visible = true;
                this.deletionLabel.Text = "days";
            }
            else
            {
                this.deletionTextValue.Visible = false;
                this.deletionLabel.Text = "";
            }
        }

        private void downloadAllowedForComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if the user has selected downloads are allowed for anyone,
            //warn and confirm
            if (this.downloadAllowedForComboBox.SelectedItem.ToString() ==
                Resources.UploadFileOptions.DOWNLOAD_FOR_ANYONE)
            {
                WarningDialog warningDialog = new WarningDialog();
                warningDialog.StartPosition = FormStartPosition.CenterParent;
                warningDialog.WarningText =
                    "Anonymous downloads will be billed to your account.  Are you sure?";

                if (warningDialog.ShowDialog() == DialogResult.Yes)
                {
                    warningDialog.Dispose();
                    this.billingComboBox.SelectedIndex = this.BILLING_MY_ACCOUNT_INDEX;
                }
                else
                {
                    this.downloadAllowedForComboBox.SelectedIndex = this.SELECTED_DOWNLOAD_FOR_INDEX;
                }
            }

            this.SELECTED_DOWNLOAD_FOR_INDEX = this.downloadAllowedForComboBox.SelectedIndex;
        }


        private void billingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.downloadAllowedForComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DOWNLOAD_FOR_ANYONE
                && this.billingComboBox.SelectedItem.ToString() != Resources.UploadFileOptions.BILL_TO_MY_ACCOUNT)
            {
                ErrorDialog errorDialog = new ErrorDialog("Anonymous downloads must be billed to your account.");
                errorDialog.StartPosition = FormStartPosition.CenterParent;
                errorDialog.ShowDialog(this);
                errorDialog.Dispose();
                this.billingComboBox.SelectedIndex = this.BILLING_MY_ACCOUNT_INDEX;
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

            if (this.deletionComboBox.SelectedItem.ToString() ==
                     Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DAYS)
            {
                if (string.IsNullOrEmpty(this.deletionTextValue.Text))
                {
                    throw new ValidationException("You must set a number of days to delete the file after");
                }

                int numberOfDays = 0;
                try
                {
                    numberOfDays = Convert.ToInt32(this.deletionTextValue.Text);
                }
                catch (Exception e)
                {
                    throw new ValidationException("Please enter a valid number of number days to delete the file after");
                }

                if (numberOfDays <= 0)
                {
                    throw new ValidationException("Please enter a positive number of days to delete the file after");
                }

                if (numberOfDays <= 0 || numberOfDays > UploadFileAttributesForm.DELETE_AFTER_NUMBER_OF_DAYS_MAX)
                {
                    throw new ValidationException("The maxium number of days a file can be stored is "
                        + UploadFileAttributesForm.DELETE_AFTER_NUMBER_OF_DAYS_MAX);
                }
            }

            if (this.deletionComboBox.SelectedItem.ToString() ==
                Resources.UploadFileOptions.DELETE_FILE_AFTER_NUMBER_OF_DOWNLOADS)
            {
                if (string.IsNullOrEmpty(this.deletionTextValue.Text))
                {
                    throw new ValidationException("You must set a number of downloads to delete the file after");
                }

                int numberODownloads = 0;
                try
                {
                    numberODownloads = Convert.ToInt32(this.deletionTextValue.Text);

                }
                catch (Exception e)
                {
                    throw new ValidationException("Please enter a valid number of downloads to delete the file after");
                }

                if (numberODownloads <= 0)
                {
                    throw new ValidationException("Please enter a positive number of downloads to delete the file after");
                }
            }

            //check to make sure that anonymous downloads are billed to uploader
            if (this.downloadAllowedForComboBox.SelectedItem.ToString() == Resources.UploadFileOptions.DOWNLOAD_FOR_ANYONE
                && this.billingComboBox.SelectedItem.ToString() != Resources.UploadFileOptions.BILL_TO_MY_ACCOUNT)
            {
                throw new ValidationException("Anonymous downloads of require that your account be billed");
            }

            return true;
        }

    }
}
