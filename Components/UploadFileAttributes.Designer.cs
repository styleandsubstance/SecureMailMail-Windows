namespace SecureMedMail.Components
{
    partial class UploadFileAttributes
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userProfileBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.deleteAfterNumberOfDaysTextBox = new System.Windows.Forms.TextBox();
            this.deleteAfterNumberOfDownloadsTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.profileSelectBox = new System.Windows.Forms.ComboBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.deleteAfterNumberOfDaysCheckbox = new System.Windows.Forms.CheckBox();
            this.deleteAfterNumberOfDownloadsCheckbox = new System.Windows.Forms.CheckBox();
            this.notifyUploaderAfterDownloadCheckbox = new System.Windows.Forms.CheckBox();
            this.billDownloadToUploaderCheckbox = new System.Windows.Forms.CheckBox();
            this.mustBeAccountMemberCheckbox = new System.Windows.Forms.CheckBox();
            this.mustBeAuthenticatedCheckbox = new System.Windows.Forms.CheckBox();
            this.profileLabel = new System.Windows.Forms.Label();
            this.deleteAfterDownloadCheckbox = new System.Windows.Forms.CheckBox();
            this.deleteAfterDownloadHelp = new System.Windows.Forms.PictureBox();
            this.mustBeAuthenticatedHelp = new System.Windows.Forms.PictureBox();
            this.mustBeAccountMemberHelp = new System.Windows.Forms.PictureBox();
            this.billDownloadToUploaderHelp = new System.Windows.Forms.PictureBox();
            this.deleteAfterNumberOfDownloadsHelp = new System.Windows.Forms.PictureBox();
            this.deleteAfterNumberOfDaysHelp = new System.Windows.Forms.PictureBox();
            this.notifyUploaderAfterDownloadHelp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAfterDownloadHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mustBeAuthenticatedHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mustBeAccountMemberHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDownloadToUploaderHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAfterNumberOfDownloadsHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAfterNumberOfDaysHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyUploaderAfterDownloadHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteAfterNumberOfDaysTextBox
            // 
            this.deleteAfterNumberOfDaysTextBox.Location = new System.Drawing.Point(473, 167);
            this.deleteAfterNumberOfDaysTextBox.Name = "deleteAfterNumberOfDaysTextBox";
            this.deleteAfterNumberOfDaysTextBox.Size = new System.Drawing.Size(61, 20);
            this.deleteAfterNumberOfDaysTextBox.TabIndex = 42;
            // 
            // deleteAfterNumberOfDownloadsTextBox
            // 
            this.deleteAfterNumberOfDownloadsTextBox.Location = new System.Drawing.Point(473, 143);
            this.deleteAfterNumberOfDownloadsTextBox.Name = "deleteAfterNumberOfDownloadsTextBox";
            this.deleteAfterNumberOfDownloadsTextBox.Size = new System.Drawing.Size(59, 20);
            this.deleteAfterNumberOfDownloadsTextBox.TabIndex = 41;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(107, 58);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(183, 38);
            this.descriptionTextBox.TabIndex = 28;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(48, 70);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 40;
            this.descriptionLabel.Text = "Description";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(107, 32);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(130, 20);
            this.confirmPasswordTextBox.TabIndex = 27;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(48, 39);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(42, 13);
            this.confirmPasswordLabel.TabIndex = 39;
            this.confirmPasswordLabel.Text = "Confirm";
            // 
            // profileSelectBox
            // 
            this.profileSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileSelectBox.FormattingEnabled = true;
            this.profileSelectBox.Location = new System.Drawing.Point(107, 107);
            this.profileSelectBox.Name = "profileSelectBox";
            this.profileSelectBox.Size = new System.Drawing.Size(183, 21);
            this.profileSelectBox.TabIndex = 29;
            this.profileSelectBox.SelectedIndexChanged += new System.EventHandler(this.profileSelectBox_SelectedIndexChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(107, 6);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(130, 20);
            this.passwordTextBox.TabIndex = 26;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(48, 13);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 38;
            this.passwordLabel.Text = "Password";
            // 
            // deleteAfterNumberOfDaysCheckbox
            // 
            this.deleteAfterNumberOfDaysCheckbox.AutoSize = true;
            this.deleteAfterNumberOfDaysCheckbox.Location = new System.Drawing.Point(277, 165);
            this.deleteAfterNumberOfDaysCheckbox.Name = "deleteAfterNumberOfDaysCheckbox";
            this.deleteAfterNumberOfDaysCheckbox.Size = new System.Drawing.Size(163, 17);
            this.deleteAfterNumberOfDaysCheckbox.TabIndex = 37;
            this.deleteAfterNumberOfDaysCheckbox.Text = "Delete After Number Of Days";
            this.deleteAfterNumberOfDaysCheckbox.UseVisualStyleBackColor = true;
            this.deleteAfterNumberOfDaysCheckbox.CheckedChanged += new System.EventHandler(this.deleteAfterNumberOfDaysCheckbox_CheckedChanged);
            // 
            // deleteAfterNumberOfDownloadsCheckbox
            // 
            this.deleteAfterNumberOfDownloadsCheckbox.AutoSize = true;
            this.deleteAfterNumberOfDownloadsCheckbox.Location = new System.Drawing.Point(277, 143);
            this.deleteAfterNumberOfDownloadsCheckbox.Name = "deleteAfterNumberOfDownloadsCheckbox";
            this.deleteAfterNumberOfDownloadsCheckbox.Size = new System.Drawing.Size(192, 17);
            this.deleteAfterNumberOfDownloadsCheckbox.TabIndex = 36;
            this.deleteAfterNumberOfDownloadsCheckbox.Text = "Delete After Number Of Downloads";
            this.deleteAfterNumberOfDownloadsCheckbox.UseVisualStyleBackColor = true;
            this.deleteAfterNumberOfDownloadsCheckbox.CheckedChanged += new System.EventHandler(this.deleteAfterNumberOfDownloadsCheckbox_CheckedChanged);
            // 
            // notifyUploaderAfterDownloadCheckbox
            // 
            this.notifyUploaderAfterDownloadCheckbox.AutoSize = true;
            this.notifyUploaderAfterDownloadCheckbox.Location = new System.Drawing.Point(277, 187);
            this.notifyUploaderAfterDownloadCheckbox.Name = "notifyUploaderAfterDownloadCheckbox";
            this.notifyUploaderAfterDownloadCheckbox.Size = new System.Drawing.Size(175, 17);
            this.notifyUploaderAfterDownloadCheckbox.TabIndex = 35;
            this.notifyUploaderAfterDownloadCheckbox.Text = "Notify Uploader After Download";
            this.notifyUploaderAfterDownloadCheckbox.UseVisualStyleBackColor = true;
            // 
            // billDownloadToUploaderCheckbox
            // 
            this.billDownloadToUploaderCheckbox.AutoSize = true;
            this.billDownloadToUploaderCheckbox.Location = new System.Drawing.Point(103, 210);
            this.billDownloadToUploaderCheckbox.Name = "billDownloadToUploaderCheckbox";
            this.billDownloadToUploaderCheckbox.Size = new System.Drawing.Size(152, 17);
            this.billDownloadToUploaderCheckbox.TabIndex = 34;
            this.billDownloadToUploaderCheckbox.Text = "Bill Download To Uploader";
            this.billDownloadToUploaderCheckbox.UseVisualStyleBackColor = true;
            // 
            // mustBeAccountMemberCheckbox
            // 
            this.mustBeAccountMemberCheckbox.AutoSize = true;
            this.mustBeAccountMemberCheckbox.Location = new System.Drawing.Point(103, 187);
            this.mustBeAccountMemberCheckbox.Name = "mustBeAccountMemberCheckbox";
            this.mustBeAccountMemberCheckbox.Size = new System.Drawing.Size(149, 17);
            this.mustBeAccountMemberCheckbox.TabIndex = 33;
            this.mustBeAccountMemberCheckbox.Text = "Must Be Account Member";
            this.mustBeAccountMemberCheckbox.UseVisualStyleBackColor = true;
            // 
            // mustBeAuthenticatedCheckbox
            // 
            this.mustBeAuthenticatedCheckbox.AutoSize = true;
            this.mustBeAuthenticatedCheckbox.Location = new System.Drawing.Point(103, 165);
            this.mustBeAuthenticatedCheckbox.Name = "mustBeAuthenticatedCheckbox";
            this.mustBeAuthenticatedCheckbox.Size = new System.Drawing.Size(134, 17);
            this.mustBeAuthenticatedCheckbox.TabIndex = 32;
            this.mustBeAuthenticatedCheckbox.Text = "Must Be Authenticated";
            this.mustBeAuthenticatedCheckbox.UseVisualStyleBackColor = true;
            // 
            // profileLabel
            // 
            this.profileLabel.AutoSize = true;
            this.profileLabel.Location = new System.Drawing.Point(48, 110);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(36, 13);
            this.profileLabel.TabIndex = 31;
            this.profileLabel.Text = "Profile";
            // 
            // deleteAfterDownloadCheckbox
            // 
            this.deleteAfterDownloadCheckbox.AutoSize = true;
            this.deleteAfterDownloadCheckbox.Location = new System.Drawing.Point(103, 143);
            this.deleteAfterDownloadCheckbox.Name = "deleteAfterDownloadCheckbox";
            this.deleteAfterDownloadCheckbox.Size = new System.Drawing.Size(133, 17);
            this.deleteAfterDownloadCheckbox.TabIndex = 30;
            this.deleteAfterDownloadCheckbox.Text = "Delete After Download";
            this.deleteAfterDownloadCheckbox.UseVisualStyleBackColor = true;
            // 
            // deleteAfterDownloadHelp
            // 
            this.deleteAfterDownloadHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAfterDownloadHelp.Image = global::SecureMedMail.Properties.Resources.Help_icon_small;
            this.deleteAfterDownloadHelp.Location = new System.Drawing.Point(232, 142);
            this.deleteAfterDownloadHelp.Name = "deleteAfterDownloadHelp";
            this.deleteAfterDownloadHelp.Size = new System.Drawing.Size(16, 16);
            this.deleteAfterDownloadHelp.TabIndex = 43;
            this.deleteAfterDownloadHelp.TabStop = false;
            this.deleteAfterDownloadHelp.Click += new System.EventHandler(this.deleteAfterDownloadHelp_Click);
            // 
            // mustBeAuthenticatedHelp
            // 
            this.mustBeAuthenticatedHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mustBeAuthenticatedHelp.Image = global::SecureMedMail.Properties.Resources.Help_icon_small;
            this.mustBeAuthenticatedHelp.Location = new System.Drawing.Point(232, 165);
            this.mustBeAuthenticatedHelp.Name = "mustBeAuthenticatedHelp";
            this.mustBeAuthenticatedHelp.Size = new System.Drawing.Size(16, 16);
            this.mustBeAuthenticatedHelp.TabIndex = 44;
            this.mustBeAuthenticatedHelp.TabStop = false;
            this.mustBeAuthenticatedHelp.Click += new System.EventHandler(this.mustBeAuthenticatedHelp_Click);
            // 
            // mustBeAccountMemberHelp
            // 
            this.mustBeAccountMemberHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mustBeAccountMemberHelp.Image = global::SecureMedMail.Properties.Resources.Help_icon_small;
            this.mustBeAccountMemberHelp.Location = new System.Drawing.Point(246, 187);
            this.mustBeAccountMemberHelp.Name = "mustBeAccountMemberHelp";
            this.mustBeAccountMemberHelp.Size = new System.Drawing.Size(16, 16);
            this.mustBeAccountMemberHelp.TabIndex = 45;
            this.mustBeAccountMemberHelp.TabStop = false;
            this.mustBeAccountMemberHelp.Click += new System.EventHandler(this.mustBeAccountMemberHelp_Click);
            // 
            // billDownloadToUploaderHelp
            // 
            this.billDownloadToUploaderHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.billDownloadToUploaderHelp.Image = global::SecureMedMail.Properties.Resources.Help_icon_small;
            this.billDownloadToUploaderHelp.Location = new System.Drawing.Point(251, 209);
            this.billDownloadToUploaderHelp.Name = "billDownloadToUploaderHelp";
            this.billDownloadToUploaderHelp.Size = new System.Drawing.Size(16, 16);
            this.billDownloadToUploaderHelp.TabIndex = 46;
            this.billDownloadToUploaderHelp.TabStop = false;
            this.billDownloadToUploaderHelp.Click += new System.EventHandler(this.billDownloadToUploaderHelp_Click);
            // 
            // deleteAfterNumberOfDownloadsHelp
            // 
            this.deleteAfterNumberOfDownloadsHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAfterNumberOfDownloadsHelp.Image = global::SecureMedMail.Properties.Resources.Help_icon_small;
            this.deleteAfterNumberOfDownloadsHelp.Location = new System.Drawing.Point(538, 144);
            this.deleteAfterNumberOfDownloadsHelp.Name = "deleteAfterNumberOfDownloadsHelp";
            this.deleteAfterNumberOfDownloadsHelp.Size = new System.Drawing.Size(16, 16);
            this.deleteAfterNumberOfDownloadsHelp.TabIndex = 47;
            this.deleteAfterNumberOfDownloadsHelp.TabStop = false;
            this.deleteAfterNumberOfDownloadsHelp.Click += new System.EventHandler(this.deleteAfterNumberOfDownloadsHelp_Click);
            // 
            // deleteAfterNumberOfDaysHelp
            // 
            this.deleteAfterNumberOfDaysHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAfterNumberOfDaysHelp.Image = global::SecureMedMail.Properties.Resources.Help_icon_small;
            this.deleteAfterNumberOfDaysHelp.Location = new System.Drawing.Point(538, 169);
            this.deleteAfterNumberOfDaysHelp.Name = "deleteAfterNumberOfDaysHelp";
            this.deleteAfterNumberOfDaysHelp.Size = new System.Drawing.Size(16, 16);
            this.deleteAfterNumberOfDaysHelp.TabIndex = 48;
            this.deleteAfterNumberOfDaysHelp.TabStop = false;
            this.deleteAfterNumberOfDaysHelp.Click += new System.EventHandler(this.deleteAfterNumberOfDaysHelp_Click);
            // 
            // notifyUploaderAfterDownloadHelp
            // 
            this.notifyUploaderAfterDownloadHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notifyUploaderAfterDownloadHelp.Image = global::SecureMedMail.Properties.Resources.Help_icon_small;
            this.notifyUploaderAfterDownloadHelp.Location = new System.Drawing.Point(451, 187);
            this.notifyUploaderAfterDownloadHelp.Name = "notifyUploaderAfterDownloadHelp";
            this.notifyUploaderAfterDownloadHelp.Size = new System.Drawing.Size(16, 16);
            this.notifyUploaderAfterDownloadHelp.TabIndex = 49;
            this.notifyUploaderAfterDownloadHelp.TabStop = false;
            this.notifyUploaderAfterDownloadHelp.Click += new System.EventHandler(this.notifyUploaderAfterDownloadHelp_Click);
            // 
            // UploadFileAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.notifyUploaderAfterDownloadHelp);
            this.Controls.Add(this.deleteAfterNumberOfDaysHelp);
            this.Controls.Add(this.deleteAfterNumberOfDownloadsHelp);
            this.Controls.Add(this.billDownloadToUploaderHelp);
            this.Controls.Add(this.mustBeAccountMemberHelp);
            this.Controls.Add(this.mustBeAuthenticatedHelp);
            this.Controls.Add(this.deleteAfterDownloadHelp);
            this.Controls.Add(this.deleteAfterNumberOfDaysTextBox);
            this.Controls.Add(this.deleteAfterNumberOfDownloadsTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.profileSelectBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.deleteAfterNumberOfDaysCheckbox);
            this.Controls.Add(this.deleteAfterNumberOfDownloadsCheckbox);
            this.Controls.Add(this.notifyUploaderAfterDownloadCheckbox);
            this.Controls.Add(this.billDownloadToUploaderCheckbox);
            this.Controls.Add(this.mustBeAccountMemberCheckbox);
            this.Controls.Add(this.mustBeAuthenticatedCheckbox);
            this.Controls.Add(this.profileLabel);
            this.Controls.Add(this.deleteAfterDownloadCheckbox);
            this.Name = "UploadFileAttributes";
            this.Size = new System.Drawing.Size(572, 233);
            this.Load += new System.EventHandler(this.UploadFileAttributes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deleteAfterDownloadHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mustBeAuthenticatedHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mustBeAccountMemberHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDownloadToUploaderHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAfterNumberOfDownloadsHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAfterNumberOfDaysHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyUploaderAfterDownloadHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker userProfileBackgroundWorker;
        private System.Windows.Forms.TextBox deleteAfterNumberOfDaysTextBox;
        private System.Windows.Forms.TextBox deleteAfterNumberOfDownloadsTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.ComboBox profileSelectBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.CheckBox deleteAfterNumberOfDaysCheckbox;
        private System.Windows.Forms.CheckBox deleteAfterNumberOfDownloadsCheckbox;
        private System.Windows.Forms.CheckBox notifyUploaderAfterDownloadCheckbox;
        private System.Windows.Forms.CheckBox billDownloadToUploaderCheckbox;
        private System.Windows.Forms.CheckBox mustBeAccountMemberCheckbox;
        private System.Windows.Forms.CheckBox mustBeAuthenticatedCheckbox;
        private System.Windows.Forms.Label profileLabel;
        private System.Windows.Forms.CheckBox deleteAfterDownloadCheckbox;
        private System.Windows.Forms.PictureBox deleteAfterDownloadHelp;
        private System.Windows.Forms.PictureBox mustBeAuthenticatedHelp;
        private System.Windows.Forms.PictureBox mustBeAccountMemberHelp;
        private System.Windows.Forms.PictureBox billDownloadToUploaderHelp;
        private System.Windows.Forms.PictureBox deleteAfterNumberOfDownloadsHelp;
        private System.Windows.Forms.PictureBox deleteAfterNumberOfDaysHelp;
        private System.Windows.Forms.PictureBox notifyUploaderAfterDownloadHelp;
    }
}
