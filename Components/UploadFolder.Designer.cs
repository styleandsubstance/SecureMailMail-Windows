namespace SecureMedMail.Components
{
    partial class UploadFolder
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
            this.localFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.uploadFileOptions = new SecureMedMail.Components.UploadFileOptions();
            this.SuspendLayout();
            // 
            // localFolderPath
            // 
            this.localFolderPath.Location = new System.Drawing.Point(145, 29);
            this.localFolderPath.Name = "localFolderPath";
            this.localFolderPath.Size = new System.Drawing.Size(253, 20);
            this.localFolderPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(405, 28);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // uploadFileOptions
            // 
            this.uploadFileOptions.Location = new System.Drawing.Point(0, 55);
            this.uploadFileOptions.Name = "uploadFileOptions";
            this.uploadFileOptions.Size = new System.Drawing.Size(572, 260);
            this.uploadFileOptions.TabIndex = 5;
            // 
            // UploadFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadFileOptions);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.localFolderPath);
            this.Controls.Add(this.label1);
            this.Name = "UploadFolder";
            this.Size = new System.Drawing.Size(572, 331);
            this.Load += new System.EventHandler(this.UploadFolder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox localFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button browseButton;
        private UploadFileOptions uploadFileOptions;
    }
}
