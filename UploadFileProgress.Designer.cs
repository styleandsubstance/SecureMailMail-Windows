namespace SecureMedMail
{
    partial class UploadFileProgress
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
            this.uploadProgess = new SecureMedMail.Components.UploadProgress();
            this.SuspendLayout();
            // 
            // uploadProgess
            // 
            this.uploadProgess.GUID = null;
            this.uploadProgess.Location = new System.Drawing.Point(-3, 21);
            this.uploadProgess.Name = "uploadProgess";
            this.uploadProgess.Size = new System.Drawing.Size(572, 176);
            this.uploadProgess.TabIndex = 1;
            // 
            // UploadFileProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadProgess);
            this.Name = "UploadFileProgress";
            this.Size = new System.Drawing.Size(572, 331);
            this.Load += new System.EventHandler(this.UploadProgress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.UploadProgress uploadProgess;

    }
}
