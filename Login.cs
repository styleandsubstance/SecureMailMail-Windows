using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using SecureMedMail.WebService.Config;

namespace SecureMedMail
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void SetError(String error)
        {
            this.errorTextBox.Text = error;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool authenticated = SecureMedMailHttpSession.getSession().Authenticate(usernameTextBox.Text, passwordTextBox.Text);

            if (authenticated)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                passwordTextBox.Text = "";
                this.errorTextBox.Text = "Authentication failed.  Please try agiain.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void newAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = WebServicePaths.CreateNewAccount();
            Process.Start(url);
        }
    }
}
