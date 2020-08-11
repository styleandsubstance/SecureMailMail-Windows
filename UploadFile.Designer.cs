namespace SecureMedMail
{
    partial class UploadFile
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.localFilePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.uploadFileOptions = new SecureMedMail.Components.UploadFileOptions();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local File:";
            // 
            // localFilePath
            // 
            this.localFilePath.Location = new System.Drawing.Point(145, 26);
            this.localFilePath.Name = "localFilePath";
            this.localFilePath.Size = new System.Drawing.Size(253, 20);
            this.localFilePath.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(407, 24);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // uploadFileOptions
            // 
            this.uploadFileOptions.Location = new System.Drawing.Point(0, 55);
            this.uploadFileOptions.Name = "uploadFileOptions";
            this.uploadFileOptions.Size = new System.Drawing.Size(572, 250);
            this.uploadFileOptions.TabIndex = 3;
            // 
            // UploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadFileOptions);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.localFilePath);
            this.Controls.Add(this.label1);
            this.Name = "UploadFile";
            this.Size = new System.Drawing.Size(572, 331);
            this.Load += new System.EventHandler(this.UploadFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox localFilePath;
        private System.Windows.Forms.Button browseButton;
        private Components.UploadFileOptions uploadFileOptions;
    }
}