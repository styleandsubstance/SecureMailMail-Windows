using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SecureMedMail.Components.Dialog
{
    public partial class ErrorDialog : Form
    {
        public ErrorDialog(String helpMessage)
        {
            InitializeComponent();

            this.errorTextBox.Text = helpMessage;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
