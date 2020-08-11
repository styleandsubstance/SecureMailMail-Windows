namespace SecureMedMail.Components
{
    partial class UploadProgress
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
            this.uploadProgressLabel = new System.Windows.Forms.Label();
            this.uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.encryptionLabel = new System.Windows.Forms.Label();
            this.encryptionProgressBar = new System.Windows.Forms.ProgressBar();
            this.encryptionThread = new System.ComponentModel.BackgroundWorker();
            this.uploadWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.compressionLabel = new System.Windows.Forms.Label();
            this.compressionProgressBar = new System.Windows.Forms.ProgressBar();
            this.compressionWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // uploadProgressLabel
            // 
            this.uploadProgressLabel.AutoSize = true;
            this.uploadProgressLabel.Location = new System.Drawing.Point(40, 140);
            this.uploadProgressLabel.Name = "uploadProgressLabel";
            this.uploadProgressLabel.Size = new System.Drawing.Size(88, 13);
            this.uploadProgressLabel.TabIndex = 14;
            this.uploadProgressLabel.Text = "Upload Progress:";
            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.Location = new System.Drawing.Point(176, 130);
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new System.Drawing.Size(253, 23);
            this.uploadProgressBar.TabIndex = 13;
            // 
            // encryptionLabel
            // 
            this.encryptionLabel.AutoSize = true;
            this.encryptionLabel.Location = new System.Drawing.Point(40, 85);
            this.encryptionLabel.Name = "encryptionLabel";
            this.encryptionLabel.Size = new System.Drawing.Size(104, 13);
            this.encryptionLabel.TabIndex = 12;
            this.encryptionLabel.Text = "Encryption Progress:";
            // 
            // encryptionProgressBar
            // 
            this.encryptionProgressBar.Location = new System.Drawing.Point(176, 75);
            this.encryptionProgressBar.Name = "encryptionProgressBar";
            this.encryptionProgressBar.Size = new System.Drawing.Size(253, 23);
            this.encryptionProgressBar.TabIndex = 11;
            // 
            // compressionLabel
            // 
            this.compressionLabel.AutoSize = true;
            this.compressionLabel.Location = new System.Drawing.Point(43, 33);
            this.compressionLabel.Name = "compressionLabel";
            this.compressionLabel.Size = new System.Drawing.Size(114, 13);
            this.compressionLabel.TabIndex = 15;
            this.compressionLabel.Text = "Compression Progress:";
            // 
            // compressionProgressBar
            // 
            this.compressionProgressBar.Location = new System.Drawing.Point(176, 23);
            this.compressionProgressBar.Name = "compressionProgressBar";
            this.compressionProgressBar.Size = new System.Drawing.Size(253, 23);
            this.compressionProgressBar.TabIndex = 16;
            // 
            // UploadProgess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.compressionProgressBar);
            this.Controls.Add(this.compressionLabel);
            this.Controls.Add(this.uploadProgressLabel);
            this.Controls.Add(this.uploadProgressBar);
            this.Controls.Add(this.encryptionLabel);
            this.Controls.Add(this.encryptionProgressBar);
            this.Name = "UploadProgess";
            this.Size = new System.Drawing.Size(572, 185);
            this.Load += new System.EventHandler(this.UploadProgess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uploadProgressLabel;
        private System.Windows.Forms.ProgressBar uploadProgressBar;
        private System.Windows.Forms.Label encryptionLabel;
        private System.Windows.Forms.ProgressBar encryptionProgressBar;
        private System.ComponentModel.BackgroundWorker encryptionThread;
        private System.ComponentModel.BackgroundWorker uploadWorkerThread;
        private System.Windows.Forms.Label compressionLabel;
        private System.Windows.Forms.ProgressBar compressionProgressBar;
        private System.ComponentModel.BackgroundWorker compressionWorkerThread;
    }
}
