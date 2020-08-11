namespace SecureMedMail.Components
{
    partial class UploadFileOptions
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
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadAllowedForComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deletionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.billingComboBox = new System.Windows.Forms.ComboBox();
            this.deletionTextValue = new System.Windows.Forms.TextBox();
            this.deletionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyUploaderAfterDownloadCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(144, 67);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(183, 38);
            this.descriptionTextBox.TabIndex = 43;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(46, 80);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 46;
            this.descriptionLabel.Text = "Description:";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(145, 35);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(130, 20);
            this.confirmPasswordTextBox.TabIndex = 42;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(47, 40);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(94, 13);
            this.confirmPasswordLabel.TabIndex = 45;
            this.confirmPasswordLabel.Text = "Confirm Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(145, 3);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(130, 20);
            this.passwordTextBox.TabIndex = 41;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(47, 7);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 44;
            this.passwordLabel.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 116);
            this.label1.MaximumSize = new System.Drawing.Size(100, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 26);
            this.label1.TabIndex = 47;
            this.label1.Text = "Downloads are allowed for:";
            // 
            // downloadAllowedForComboBox
            // 
            this.downloadAllowedForComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.downloadAllowedForComboBox.FormattingEnabled = true;
            this.downloadAllowedForComboBox.Location = new System.Drawing.Point(144, 118);
            this.downloadAllowedForComboBox.Name = "downloadAllowedForComboBox";
            this.downloadAllowedForComboBox.Size = new System.Drawing.Size(241, 21);
            this.downloadAllowedForComboBox.TabIndex = 48;
            this.downloadAllowedForComboBox.SelectedIndexChanged += new System.EventHandler(this.downloadAllowedForComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 156);
            this.label2.MaximumSize = new System.Drawing.Size(100, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Delete this file:";
            // 
            // deletionComboBox
            // 
            this.deletionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deletionComboBox.FormattingEnabled = true;
            this.deletionComboBox.Location = new System.Drawing.Point(144, 151);
            this.deletionComboBox.Name = "deletionComboBox";
            this.deletionComboBox.Size = new System.Drawing.Size(241, 21);
            this.deletionComboBox.TabIndex = 50;
            this.deletionComboBox.SelectedIndexChanged += new System.EventHandler(this.deletionComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 183);
            this.label3.MaximumSize = new System.Drawing.Size(100, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 26);
            this.label3.TabIndex = 51;
            this.label3.Text = "Bill downloads of this file to:";
            // 
            // billingComboBox
            // 
            this.billingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.billingComboBox.FormattingEnabled = true;
            this.billingComboBox.Location = new System.Drawing.Point(145, 185);
            this.billingComboBox.Name = "billingComboBox";
            this.billingComboBox.Size = new System.Drawing.Size(240, 21);
            this.billingComboBox.TabIndex = 52;
            this.billingComboBox.SelectedIndexChanged += new System.EventHandler(this.billingComboBox_SelectedIndexChanged);
            // 
            // deletionTextValue
            // 
            this.deletionTextValue.Location = new System.Drawing.Point(396, 151);
            this.deletionTextValue.Name = "deletionTextValue";
            this.deletionTextValue.Size = new System.Drawing.Size(53, 20);
            this.deletionTextValue.TabIndex = 53;
            this.deletionTextValue.Visible = false;
            // 
            // deletionLabel
            // 
            this.deletionLabel.AutoSize = true;
            this.deletionLabel.Location = new System.Drawing.Point(456, 155);
            this.deletionLabel.Name = "deletionLabel";
            this.deletionLabel.Size = new System.Drawing.Size(0, 13);
            this.deletionLabel.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 219);
            this.label4.MaximumSize = new System.Drawing.Size(100, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 26);
            this.label4.TabIndex = 55;
            this.label4.Text = "E-mail me after file downloaded:";
            // 
            // notifyUploaderAfterDownloadCheckbox
            // 
            this.notifyUploaderAfterDownloadCheckbox.AutoSize = true;
            this.notifyUploaderAfterDownloadCheckbox.Location = new System.Drawing.Point(146, 226);
            this.notifyUploaderAfterDownloadCheckbox.Name = "notifyUploaderAfterDownloadCheckbox";
            this.notifyUploaderAfterDownloadCheckbox.Size = new System.Drawing.Size(15, 14);
            this.notifyUploaderAfterDownloadCheckbox.TabIndex = 56;
            this.notifyUploaderAfterDownloadCheckbox.UseVisualStyleBackColor = true;
            // 
            // UploadFileOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.notifyUploaderAfterDownloadCheckbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deletionLabel);
            this.Controls.Add(this.deletionTextValue);
            this.Controls.Add(this.billingComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deletionComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.downloadAllowedForComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Name = "UploadFileOptions";
            this.Size = new System.Drawing.Size(572, 260);
            this.Load += new System.EventHandler(this.UploadFileOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox downloadAllowedForComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox deletionComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox billingComboBox;
        private System.Windows.Forms.TextBox deletionTextValue;
        private System.Windows.Forms.Label deletionLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox notifyUploaderAfterDownloadCheckbox;
    }
}
