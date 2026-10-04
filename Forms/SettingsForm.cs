using System;
using System.Windows.Forms;
using XpressShare.Core;

namespace XpressShare.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)) return;

            try
            {
                picHeaderIcon.Image = IconHelper.GetGearIcon(24, System.Drawing.Color.White);
                btnBrowse.Image = IconHelper.GetFolderIcon(14, System.Drawing.Color.FromArgb(71, 85, 105));
                btnSave.Image = IconHelper.GetCheckIcon(14, System.Drawing.Color.White);
            }
            catch { }

            AppSettings settings = AppSettings.Instance;
            txtDownloadFolder.Text = settings.SelectedDownloadFolder;
            chkMinimizeToTray.Checked = settings.TrayMinimizePreference;
            numDevicePort.Value = settings.DevicePort;
            numTransferPort.Value = settings.TransferPort;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select download folder";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtDownloadFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AppSettings settings = AppSettings.Instance;
            string customFolder = txtDownloadFolder.Text.Trim();
            if (!string.IsNullOrEmpty(customFolder))
            {
                try
                {
                    if (!System.IO.Directory.Exists(customFolder))
                    {
                        System.IO.Directory.CreateDirectory(customFolder);
                    }
                }
                catch { }
                settings.SelectedDownloadFolder = customFolder;
            }
            settings.TrayMinimizePreference = chkMinimizeToTray.Checked;
            settings.DevicePort = (int)numDevicePort.Value;
            settings.TransferPort = (int)numTransferPort.Value;
            settings.Save();

            MessageBox.Show("Settings saved successfully.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
