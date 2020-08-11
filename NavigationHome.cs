using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SecureMedMail
{
    public partial class NavigationHome : UserControl
    {
        public NavigationHome()
        {
            InitializeComponent();
        }


        public bool IsDownloadChecked()
        {
            return downloadRadioButton.Checked;
        }

        public bool IsUploadChecked()
        {
            return uploadRadioButton.Checked;
        }

        public bool IsUploadDiscDriveChecked()
        {
            return uploadDiscDriveRadioButton.Checked;
        }

        public bool isUploadFolderChecked()
        {
            return uploadFolderRadioButton.Checked;
        }

        private void NavigationHome_Load(object sender, EventArgs e)
        {

        }
    }

}
