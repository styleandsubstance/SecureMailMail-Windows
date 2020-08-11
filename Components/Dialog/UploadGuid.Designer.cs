namespace SecureMedMail.Dialog
{
    partial class UploadGuid
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
            this.guidLabel = new System.Windows.Forms.Label();
            this.guidTextBox = new System.Windows.Forms.TextBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // guidLabel
            // 
            this.guidLabel.AutoSize = true;
            this.guidLabel.Location = new System.Drawing.Point(122, 33);
            this.guidLabel.Name = "guidLabel";
            this.guidLabel.Size = new System.Drawing.Size(37, 13);
            this.guidLabel.TabIndex = 0;
            this.guidLabel.Text = "GUID:";
            // 
            // guidTextBox
            // 
            this.guidTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.guidTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guidTextBox.Location = new System.Drawing.Point(175, 33);
            this.guidTextBox.Name = "guidTextBox";
            this.guidTextBox.ReadOnly = true;
            this.guidTextBox.Size = new System.Drawing.Size(112, 13);
            this.guidTextBox.TabIndex = 1;
            this.guidTextBox.TabStop = false;
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.errorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorTextBox.Location = new System.Drawing.Point(77, 53);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(228, 40);
            this.errorTextBox.TabIndex = 9;
            this.errorTextBox.TabStop = false;
            this.errorTextBox.Text = "Please record this GUID.  This unique identifier and the password you set in the " +
    "previous screen will be required for anyone to download this file.";
            this.errorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UploadGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 118);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.guidTextBox);
            this.Controls.Add(this.guidLabel);
            this.Name = "UploadGuid";
            this.Text = "Upload Successful";
            this.Load += new System.EventHandler(this.UploadGuid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guidLabel;
        private System.Windows.Forms.TextBox guidTextBox;
        private System.Windows.Forms.TextBox errorTextBox;
    }
}