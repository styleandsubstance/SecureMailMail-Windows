namespace SecureMedMail
{
    partial class DownloadProgress
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
            this.downloadWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.decryptionProgressBar = new System.Windows.Forms.ProgressBar();
            this.decryptionWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.extractionProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.extractionWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.decompressionProgressLabel = new System.Windows.Forms.Label();
            this.decompressionProgressBar = new System.Windows.Forms.ProgressBar();
            this.decompressionWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.confirmationWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Download Progress:";
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(164, 58);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(277, 23);
            this.downloadProgressBar.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Decryption Progress:";
            // 
            // decryptionProgressBar
            // 
            this.decryptionProgressBar.Location = new System.Drawing.Point(164, 117);
            this.decryptionProgressBar.Name = "decryptionProgressBar";
            this.decryptionProgressBar.Size = new System.Drawing.Size(277, 23);
            this.decryptionProgressBar.TabIndex = 12;
            // 
            // extractionProgressBar
            // 
            this.extractionProgressBar.Location = new System.Drawing.Point(164, 234);
            this.extractionProgressBar.Name = "extractionProgressBar";
            this.extractionProgressBar.Size = new System.Drawing.Size(277, 23);
            this.extractionProgressBar.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Extraction Progress:";
            // 
            // decompressionProgressLabel
            // 
            this.decompressionProgressLabel.AutoSize = true;
            this.decompressionProgressLabel.Location = new System.Drawing.Point(59, 184);
            this.decompressionProgressLabel.Name = "decompressionProgressLabel";
            this.decompressionProgressLabel.Size = new System.Drawing.Size(83, 13);
            this.decompressionProgressLabel.TabIndex = 16;
            this.decompressionProgressLabel.Text = "Decompression:";
            // 
            // decompressionProgressBar
            // 
            this.decompressionProgressBar.Location = new System.Drawing.Point(164, 175);
            this.decompressionProgressBar.Name = "decompressionProgressBar";
            this.decompressionProgressBar.Size = new System.Drawing.Size(277, 23);
            this.decompressionProgressBar.TabIndex = 15;
            // 
            // DownloadProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.decompressionProgressLabel);
            this.Controls.Add(this.decompressionProgressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.extractionProgressBar);
            this.Controls.Add(this.decryptionProgressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.downloadProgressBar);
            this.Name = "DownloadProgress";
            this.Size = new System.Drawing.Size(572, 331);
            this.Load += new System.EventHandler(this.DownloadProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker downloadWorkerThread;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar decryptionProgressBar;
        private System.ComponentModel.BackgroundWorker decryptionWorkerThread;
        private System.Windows.Forms.ProgressBar extractionProgressBar;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker extractionWorkerThread;
        private System.Windows.Forms.Label decompressionProgressLabel;
        private System.Windows.Forms.ProgressBar decompressionProgressBar;
        private System.ComponentModel.BackgroundWorker decompressionWorkerThread;
        private System.ComponentModel.BackgroundWorker confirmationWorkerThread;
    }
}
