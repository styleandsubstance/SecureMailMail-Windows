using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using log4net;
using SecureMedMail.Components;
using SecureMedMail.Components.Dialog;
using SecureMedMail.Util.Exceptions;

namespace SecureMedMail
{
    public partial class MainMenu : Form
    {

        enum SelectedPanel
        {
            NavigationHome,
            UploadFileForm,
            UploadFileProgress,
            DownloadFileForm,
            DownloadFileProgress,
            UploadDiscDrive,
            UploadDiscDriveProgress,
            UploadFolder
        }


        enum AnimateWindowFlags : uint
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, AnimateWindowFlags flags);


        private ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private SelectedPanel selectedPanel;
        private UserControl currentPanel;


        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            selectedPanel = SelectedPanel.NavigationHome;
            NavigationHome navigationHome = new NavigationHome();
            currentPanel = navigationHome;

            panel1.Controls.Add(navigationHome);
            nextButton.Enabled = true;
            backButton.Enabled = false;
        }


        private void MainMenu_Shown(object sender, EventArgs e)
        {
            log.Info("SecureMedMail Application Starting...");
//            if (SecureMedMailHttpSession.getSession().Authenticated() == false)
//            {
//                Login login = new Login();
//                login.StartPosition = FormStartPosition.CenterParent;
//                login.ShowDialog();
//                if (login.DialogResult == DialogResult.OK)
//                {
//                    //this.session = login.session;
//                }
//                else
//                {
//                    this.Close();
//                }
//            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPanel == SelectedPanel.NavigationHome)
                {
                    NavigationHome navigationPanel = (NavigationHome) currentPanel;

                    if (navigationPanel.IsUploadChecked())
                    {
                        selectedPanel = SelectedPanel.UploadFileForm;

                        UploadFile uploadFile = new UploadFile();

                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(uploadFile);

                        nextButton.Enabled = true;
                        backButton.Enabled = true;
                        currentPanel = uploadFile;

                    }
                    else if (navigationPanel.IsDownloadChecked())
                    {
                        selectedPanel = SelectedPanel.DownloadFileForm;

                        DownloadFile downloadFile = new DownloadFile();

                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(downloadFile);

                        nextButton.Enabled = true;
                        backButton.Enabled = true;
                        currentPanel = downloadFile;

                    }
                    else if (navigationPanel.IsUploadDiscDriveChecked())
                    {
                        selectedPanel = SelectedPanel.UploadDiscDrive;

                        UploadDiscDrive uploadDiscDrive = new UploadDiscDrive();
                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(uploadDiscDrive);

                        nextButton.Enabled = true;
                        backButton.Enabled = true;
                        currentPanel = uploadDiscDrive;
                    }
                    else if (navigationPanel.isUploadFolderChecked())
                    {
                        selectedPanel = SelectedPanel.UploadFolder;

                        UploadFolder uploadFolder = new UploadFolder();
                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(uploadFolder);

                        nextButton.Enabled = true;
                        backButton.Enabled = true;
                        currentPanel = uploadFolder;
                    }
                }
                else if (selectedPanel == SelectedPanel.UploadFileForm)
                {
                    UploadFile uploadFile = (UploadFile) currentPanel;

                    if (uploadFile.Validate() == true)
                    {
                        selectedPanel = SelectedPanel.UploadFileProgress;

                        UploadFileProgress uploadProgress = new UploadFileProgress(uploadFile.buildUploadForm());
                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(uploadProgress);

                        nextButton.Enabled = false;
                        backButton.Enabled = true;
                        currentPanel = uploadProgress;
                    }
                }
                else if (selectedPanel == SelectedPanel.DownloadFileForm)
                {
                    DownloadFile downloadFile = (DownloadFile) currentPanel;

                    if (downloadFile.ValidateForm() == true)
                    {
                        selectedPanel = SelectedPanel.DownloadFileProgress;

                        DownloadProgress downloadProgress = new DownloadProgress(downloadFile.buildDownloadForm());

                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(downloadProgress);

                        nextButton.Enabled = false;
                        backButton.Enabled = true;
                        currentPanel = downloadProgress;
                    }
                }
                else if (selectedPanel == SelectedPanel.UploadDiscDrive)
                {
                    UploadDiscDrive uploadDiscDrive = (UploadDiscDrive) currentPanel;
                    if (uploadDiscDrive.ValidateForm() == true)
                    {
                        selectedPanel = SelectedPanel.UploadDiscDriveProgress;

                        UploadDiscDriveProgress uploadDiscDriveProgress = new UploadDiscDriveProgress();
                        uploadDiscDriveProgress.uploadDiscDriveForm = uploadDiscDrive.buildUploadForm();

                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(uploadDiscDriveProgress);

                        nextButton.Enabled = false;
                        backButton.Enabled = true;
                        currentPanel = uploadDiscDriveProgress;
                    }
                }
                else if ((selectedPanel == SelectedPanel.UploadFolder))
                {
                    UploadFolder uploadFolder = (UploadFolder) currentPanel;
                    if (uploadFolder.ValidateForm())
                    {
                        UploadFileProgress uploadProgress = new UploadFileProgress(uploadFolder.buildUploadForm());
                        panel1.Controls.RemoveAt(0);
                        panel1.Controls.Add(uploadProgress);

                        nextButton.Enabled = false;
                        backButton.Enabled = true;
                        currentPanel = uploadProgress;
                    }
                }

            }
            catch (ValidationException v)
            {
                log.Info("Validation Exception", v);
                ShowErrorDialog(v.Message);
            }
            catch (UnrecoverableErrorException uee)
            {
                log.Info("UnrecoverableErrorException caught", uee);
                ReturnToNavigationHome();
                ShowErrorDialog(uee.Message);
            }
            catch (Exception ex)
            {
                log.Warn("Unexpected exception caught", ex);
                ShowErrorDialog(ex.Message);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (selectedPanel == SelectedPanel.DownloadFileForm || selectedPanel == SelectedPanel.UploadFileForm 
                || selectedPanel == SelectedPanel.DownloadFileProgress || selectedPanel == SelectedPanel.UploadFileProgress 
                || selectedPanel == SelectedPanel.UploadDiscDrive || selectedPanel == SelectedPanel.UploadDiscDriveProgress
                || selectedPanel == SelectedPanel.UploadFolder)
            {
                ReturnToNavigationHome();
            }
        }

        public void ReturnToNavigationHome()
        {
            selectedPanel = SelectedPanel.NavigationHome;
            NavigationHome navigationHome = new NavigationHome();
            currentPanel = navigationHome;

            panel1.Controls.RemoveAt(0);
            panel1.Controls.Add(navigationHome);
            nextButton.Enabled = true;
            backButton.Enabled = false;
        }

        public void ShowErrorDialog(String errorMessage)
        {
            ErrorDialog errorDialog = new ErrorDialog(errorMessage);
            errorDialog.StartPosition = FormStartPosition.CenterParent;
            errorDialog.ShowDialog(this);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
