using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace SecureMedMail.Components.Dialog
{
    public partial class DownloadSuccess : Form
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private String folderPath = null;

        public DownloadSuccess(String folderPath)
        {
            this.folderPath = folderPath;

            InitializeComponent();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            log.Debug("Opening folder " + this.folderPath + " after successful download");
            if (this.folderPath != null && Directory.Exists(this.folderPath))
            {
                Process.Start(this.folderPath);
            }

            this.Hide();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
