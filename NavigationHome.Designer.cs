namespace SecureMedMail
{
    partial class NavigationHome
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
            this.downloadRadioButton = new System.Windows.Forms.RadioButton();
            this.uploadRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadDiscDriveRadioButton = new System.Windows.Forms.RadioButton();
            this.uploadFolderRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // downloadRadioButton
            // 
            this.downloadRadioButton.AutoSize = true;
            this.downloadRadioButton.Location = new System.Drawing.Point(58, 250);
            this.downloadRadioButton.Name = "downloadRadioButton";
            this.downloadRadioButton.Size = new System.Drawing.Size(101, 17);
            this.downloadRadioButton.TabIndex = 7;
            this.downloadRadioButton.TabStop = true;
            this.downloadRadioButton.Text = "Download a File";
            this.downloadRadioButton.UseVisualStyleBackColor = true;
            // 
            // uploadRadioButton
            // 
            this.uploadRadioButton.AutoSize = true;
            this.uploadRadioButton.Location = new System.Drawing.Point(58, 203);
            this.uploadRadioButton.Name = "uploadRadioButton";
            this.uploadRadioButton.Size = new System.Drawing.Size(87, 17);
            this.uploadRadioButton.TabIndex = 6;
            this.uploadRadioButton.TabStop = true;
            this.uploadRadioButton.Text = "Upload a File";
            this.uploadRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "What would you like to do?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 73);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome";
            // 
            // uploadDiscDriveRadioButton
            // 
            this.uploadDiscDriveRadioButton.AutoSize = true;
            this.uploadDiscDriveRadioButton.Location = new System.Drawing.Point(58, 180);
            this.uploadDiscDriveRadioButton.Name = "uploadDiscDriveRadioButton";
            this.uploadDiscDriveRadioButton.Size = new System.Drawing.Size(111, 17);
            this.uploadDiscDriveRadioButton.TabIndex = 8;
            this.uploadDiscDriveRadioButton.TabStop = true;
            this.uploadDiscDriveRadioButton.Text = "Upload Disc Drive";
            this.uploadDiscDriveRadioButton.UseVisualStyleBackColor = true;
            // 
            // uploadFolderRadioButton
            // 
            this.uploadFolderRadioButton.AutoSize = true;
            this.uploadFolderRadioButton.Location = new System.Drawing.Point(58, 226);
            this.uploadFolderRadioButton.Name = "uploadFolderRadioButton";
            this.uploadFolderRadioButton.Size = new System.Drawing.Size(100, 17);
            this.uploadFolderRadioButton.TabIndex = 9;
            this.uploadFolderRadioButton.TabStop = true;
            this.uploadFolderRadioButton.Text = "Upload a Folder";
            this.uploadFolderRadioButton.UseVisualStyleBackColor = true;
            // 
            // NavigationHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadFolderRadioButton);
            this.Controls.Add(this.uploadDiscDriveRadioButton);
            this.Controls.Add(this.downloadRadioButton);
            this.Controls.Add(this.uploadRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NavigationHome";
            this.Size = new System.Drawing.Size(572, 331);
            this.Load += new System.EventHandler(this.NavigationHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton downloadRadioButton;
        private System.Windows.Forms.RadioButton uploadRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton uploadDiscDriveRadioButton;
        private System.Windows.Forms.RadioButton uploadFolderRadioButton;
    }
}
