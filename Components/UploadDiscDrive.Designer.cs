namespace SecureMedMail.Components
{
    partial class UploadDiscDrive
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
            this.discDriveLabel = new System.Windows.Forms.Label();
            this.discDriveComboBox = new System.Windows.Forms.ComboBox();
            this.uploadFileOptions = new SecureMedMail.Components.UploadFileOptions();
            this.SuspendLayout();
            // 
            // discDriveLabel
            // 
            this.discDriveLabel.AutoSize = true;
            this.discDriveLabel.Location = new System.Drawing.Point(48, 21);
            this.discDriveLabel.Name = "discDriveLabel";
            this.discDriveLabel.Size = new System.Drawing.Size(32, 13);
            this.discDriveLabel.TabIndex = 1;
            this.discDriveLabel.Text = "Drive";
            // 
            // discDriveComboBox
            // 
            this.discDriveComboBox.FormattingEnabled = true;
            this.discDriveComboBox.Location = new System.Drawing.Point(146, 18);
            this.discDriveComboBox.Name = "discDriveComboBox";
            this.discDriveComboBox.Size = new System.Drawing.Size(43, 21);
            this.discDriveComboBox.TabIndex = 2;
            // 
            // uploadFileOptions
            // 
            this.uploadFileOptions.Location = new System.Drawing.Point(0, 44);
            this.uploadFileOptions.Name = "uploadFileOptions";
            this.uploadFileOptions.Size = new System.Drawing.Size(572, 260);
            this.uploadFileOptions.TabIndex = 3;
            // 
            // UploadDiscDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadFileOptions);
            this.Controls.Add(this.discDriveComboBox);
            this.Controls.Add(this.discDriveLabel);
            this.Name = "UploadDiscDrive";
            this.Size = new System.Drawing.Size(572, 331);
            this.Load += new System.EventHandler(this.UploadDiscDrive_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label discDriveLabel;
        private System.Windows.Forms.ComboBox discDriveComboBox;
        private UploadFileOptions uploadFileOptions;
    }
}
