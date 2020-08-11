using System.IO;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecureMedMail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders(); /*Remove any other appenders*/

            RollingFileAppender fileAppender = new RollingFileAppender();
            fileAppender.AppendToFile = true;
            fileAppender.LockingModel = new FileAppender.MinimalLock();

            String systemAppData = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.LocalApplicationData);

            String applicationLogDirectory = Path.Combine("SecureMedMail", "Logs");

            String loggingDirectory = Path.Combine(systemAppData, applicationLogDirectory);

            if (Directory.Exists(loggingDirectory) == false)
            {
                Directory.CreateDirectory(loggingDirectory);
            }

            fileAppender.File = Path.Combine(loggingDirectory, "SecureMedMail.log");
            PatternLayout pl = new PatternLayout();
            pl.ConversionPattern = "%d [%2t] %-5p [%-10c]   %m%n";
            pl.ActivateOptions();
            fileAppender.Layout = pl;
            fileAppender.ActivateOptions();
            fileAppender.MaxSizeRollBackups = 0;
            fileAppender.Threshold = Level.Debug;

            log4net.Config.BasicConfigurator.Configure(fileAppender);

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
