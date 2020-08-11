using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace SecureMedMail.Components
{
    public partial class UploadDiscDriveProgress : Component
    {
        public UploadDiscDriveProgress()
        {
            InitializeComponent();
        }

        public UploadDiscDriveProgress(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
