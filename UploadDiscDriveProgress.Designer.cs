namespace SecureMedMail
{
    partial class UploadDiscDriveProgress
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
            this.isoProgressLabel = new System.Windows.Forms.Label();
            this.isoCreationProgressBar = new System.Windows.Forms.ProgressBar();
            this.isoCreationThread = new System.ComponentModel.BackgroundWorker();
            this.uploadProgess = new SecureMedMail.Components.UploadProgress();
            this.SuspendLayout();
            // 
            // isoProgressLabel
            // 
            this.isoProgressLabel.AutoSize = true;
            this.isoProgressLabel.Location = new System.Drawing.Point(40, 41);
            this.isoProgressLabel.Name = "isoProgressLabel";
            this.isoProgressLabel.Size = new System.Drawing.Size(72, 13);
            this.isoProgressLabel.TabIndex = 1;
            this.isoProgressLabel.Text = "ISO Progress:";
            // 
            // isoCreationProgressBar
            // 
            this.isoCreationProgressBar.Location = new System.Drawing.Point(176, 31);
            this.isoCreationProgressBar.Name = "isoCreationProgressBar";
            this.isoCreationProgressBar.Size = new System.Drawing.Size(256, 23);
            this.isoCreationProgressBar.TabIndex = 2;
            // 
            // uploadProgess
            // 
            this.uploadProgess.GUID = null;
            this.uploadProgess.Location = new System.Drawing.Point(0, 58);
            this.uploadProgess.Name = "uploadProgess";
            this.uploadProgess.Size = new System.Drawing.Size(572, 176);
            this.uploadProgess.TabIndex = 0;
            // 
            // UploadDiscDriveProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.isoCreationProgressBar);
            this.Controls.Add(this.isoProgressLabel);
            this.Controls.Add(this.uploadProgess);
            this.Name = "UploadDiscDriveProgress";
            this.Size = new System.Drawing.Size(572, 331);
            this.Load += new System.EventHandler(this.UploadDiscDriveProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.UploadProgress uploadProgess;
        private System.Windows.Forms.Label isoProgressLabel;
        private System.Windows.Forms.ProgressBar isoCreationProgressBar;
        private System.ComponentModel.BackgroundWorker isoCreationThread;
    }
}
