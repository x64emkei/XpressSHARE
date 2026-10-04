using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Services;

namespace XpressShare.Forms.Controls
{
    public partial class SettingsControl : UserControl
    {
        public event Action<string> StatusMessageChanged;
        public event EventHandler ThemeToggleRequested;
        public event Action<string> DensityChanged;

        private bool _isWiringEvents = false;

        public SettingsControl()
        {
            InitializeComponent();
            WireDensityEvents();
        }

        private void WireDensityEvents()
        {
            rbDensityCompact.CheckedChanged += delegate
            {
                if (!_isWiringEvents && rbDensityCompact.Checked && DensityChanged != null)
                {
                    DensityChanged("Compact");
                }
            };
            rbDensityStandard.CheckedChanged += delegate
            {
                if (!_isWiringEvents && rbDensityStandard.Checked && DensityChanged != null)
                {
                    DensityChanged("Standard");
                }
            };
            rbDensityComfortable.CheckedChanged += delegate
            {
                if (!_isWiringEvents && rbDensityComfortable.Checked && DensityChanged != null)
                {
                    DensityChanged("Comfortable");
                }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            LoadSettings();
        }

        public void LoadSettings()
        {
            try
            {
                _isWiringEvents = true;

                txtDownloadPath.Text = AppSettings.Instance.SelectedDownloadFolder;
                chkMinimizeToTray.Checked = AppSettings.Instance.TrayMinimizePreference;

                chkOptimizeTransfers.Checked = true;
                chkAutoAccept.Checked = AppSettings.Instance.AutoAcceptTransfers;
                chkRetryDisconnects.Checked = true;
                numMaxConcurrent.Value = 3;

                numUdpPort.Value = AppSettings.Instance.DevicePort > 0 ? AppSettings.Instance.DevicePort : 15000;
                numTcpPort.Value = AppSettings.Instance.TransferPort > 0 ? AppSettings.Instance.TransferPort : 15001;
                cboInterface.SelectedIndex = 0;

                chkRememberPaired.Checked = true;

                if (AppSettings.Instance.DarkMode)
                {
                    rbThemeDark.Checked = true;
                }
                else
                {
                    rbThemeLight.Checked = true;
                }

                string density = AppSettings.Instance.UiDensity;
                if ("Compact".Equals(density, StringComparison.OrdinalIgnoreCase))
                {
                    rbDensityCompact.Checked = true;
                }
                else if ("Comfortable".Equals(density, StringComparison.OrdinalIgnoreCase))
                {
                    rbDensityComfortable.Checked = true;
                }
                else
                {
                    rbDensityStandard.Checked = true;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("SettingsControl.LoadSettings error: " + ex.Message);
            }
            finally
            {
                _isWiringEvents = false;
            }
        }

        private void BtnBrowseDownload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select Default Download Folder";
                dlg.SelectedPath = txtDownloadPath.Text;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtDownloadPath.Text = dlg.SelectedPath;
                }
            }
        }

        private void BtnRevokePaired_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to revoke all paired devices? You will need to pair again to transfer securely without confirmation.";
            if (MessageBox.Show(msg, "Revoke All Paired Devices", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                TrustedDeviceService trustedService = ServiceRegistry.Resolve<TrustedDeviceService>("TrustedDeviceService");
                if (trustedService != null)
                {
                    var all = trustedService.GetTrustedDevices();
                    foreach (var d in all)
                    {
                        trustedService.RemoveTrustedDevice(d.DeviceId);
                    }
                }
                MessageBox.Show("All trusted device pairings have been revoked.", "Revocation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NotifyStatus("Revoked all trusted pairings.");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string customFolder = txtDownloadPath.Text.Trim();
                if (!string.IsNullOrEmpty(customFolder))
                {
                    try
                    {
                        if (!Directory.Exists(customFolder))
                        {
                            Directory.CreateDirectory(customFolder);
                        }
                    }
                    catch { }
                    AppSettings.Instance.SelectedDownloadFolder = customFolder;
                }

                AppSettings.Instance.TrayMinimizePreference = chkMinimizeToTray.Checked;
                AppSettings.Instance.AutoAcceptTransfers = chkAutoAccept.Checked;
                AppSettings.Instance.DevicePort = (int)numUdpPort.Value;
                AppSettings.Instance.TransferPort = (int)numTcpPort.Value;

                bool wasDark = AppSettings.Instance.DarkMode;
                bool newDark = rbThemeDark.Checked;
                AppSettings.Instance.DarkMode = newDark;

                AppSettings.Instance.UiDensity = rbDensityCompact.Checked ? "Compact" : (rbDensityComfortable.Checked ? "Comfortable" : "Standard");
                AppSettings.Instance.Save();

                if (wasDark != newDark && ThemeToggleRequested != null)
                {
                    ThemeToggleRequested(this, EventArgs.Empty);
                }

                MessageBox.Show("Settings saved successfully.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NotifyStatus("Application settings saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResetDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset all settings to default values?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtDownloadPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                chkMinimizeToTray.Checked = true;
                chkOptimizeTransfers.Checked = true;
                chkAutoAccept.Checked = false;
                chkRetryDisconnects.Checked = true;
                numUdpPort.Value = 15000;
                numTcpPort.Value = 15001;
                cboInterface.SelectedIndex = 0;
                rbThemeLight.Checked = true;
                rbDensityStandard.Checked = true;
                NotifyStatus("Restored default settings.");
            }
        }

        private void NotifyStatus(string message)
        {
            if (StatusMessageChanged != null) StatusMessageChanged(message);
        }
    }
}
