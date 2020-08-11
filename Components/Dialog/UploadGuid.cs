using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SecureMedMail.Dialog
{
    public partial class UploadGuid : Form
    {
        public UploadGuid()
        {
            InitializeComponent();
        }

        private void UploadGuid_Load(object sender, EventArgs e)
        {

        }

        public void SetGuid(String guid)
        {
            this.guidTextBox.Text = guid;
        }

    }
}
