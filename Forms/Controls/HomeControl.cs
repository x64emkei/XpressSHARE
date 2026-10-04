using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Services;
using XpressShare.Transfers;
using XpressShare.Utilities;
using TransferOptimizer = XpressShare.Services.TransferOptimizer;

namespace XpressShare.Forms.Controls
{
    public partial class HomeControl : UserControl
    {
        public event EventHandler SendFileRequested;
        public event EventHandler ReceiveRequested;
        public event EventHandler BrowseDevicesRequested;
        public event EventHandler OpenExplorerRequested;

        private TransferHistoryService _historyService;

        public HomeControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(dgvRecentTransfers);

            RefreshComputerInfo();
            RefreshRecentTransfers();
            RefreshDevicesOnline();
        }

        public void ApplyDensity(int rowHeight)
        {
            try
            {
                dgvRecentTransfers.SuspendLayout();
                dgvRecentTransfers.RowTemplate.Height = rowHeight;
                foreach (DataGridViewRow r in dgvRecentTransfers.Rows)
                {
                    r.Height = rowHeight;
                }
                dgvRecentTransfers.ResumeLayout();
            }
            catch { }
        }

        public void RefreshComputerInfo()
        {
            try
            {
                lblValComputer.Text = Environment.MachineName;
                lblValUser.Text = Environment.UserName;

                lblValOs.Text = SystemEnvironmentInfo.OperatingSystemFriendlyName;
                lblValBuild.Text = SystemEnvironmentInfo.BuildNumber;
                lblValOsArch.Text = SystemEnvironmentInfo.OsArchitecture;

                lblValAppArch.Text = SystemEnvironmentInfo.ProcessArchitecture;
                lblValAppVersion.Text = SystemEnvironmentInfo.AppVersion;

                lblValConnection.Text = TransferOptimizer.GetActiveConnectionType().ToString();

                DeviceIdentity identity = ServiceRegistry.Resolve<DeviceIdentity>("DeviceIdentity");
                if (identity != null && !string.IsNullOrEmpty(identity.LocalIpAddress))
                {
                    lblValIp.Text = identity.LocalIpAddress;
                }
                else
                {
                    lblValIp.Text = "127.0.0.1";
                }

                lblValStatus.Text = "Online (Ready to Share)";
                lblValStatus.ForeColor = Color.FromArgb(16, 185, 129);
            }
            catch (Exception ex)
            {
                AppLogger.Log("HomeControl.RefreshComputerInfo error: " + ex.Message);
            }
        }

        public void RefreshRecentTransfers()
        {
            try
            {
                if (_historyService == null)
                {
                    _historyService = new TransferHistoryService();
                }

                dgvRecentTransfers.Rows.Clear();
                var history = _historyService.GetHistory();
                int count = 0;

                for (int i = history.Count - 1; i >= 0 && count < 8; i--)
                {
                    var entry = history[i];
                    if (string.IsNullOrEmpty(entry.FilePath)) continue;

                    string fileName = Path.GetFileName(entry.FilePath);
                    string target = !string.IsNullOrEmpty(entry.RemoteDeviceName) ? entry.RemoteDeviceName : "Local Device";
                    string status = entry.Success ? "Completed" : "Failed";
                    string size = FormatSize(entry.FileSize);
                    string date = entry.Timestamp.ToString("yyyy-MM-dd HH:mm");

                    int rowIndex = dgvRecentTransfers.Rows.Add(fileName, target, size, status, date);
                    dgvRecentTransfers.Rows[rowIndex].Tag = entry.FilePath;

                    if (entry.Success)
                    {
                        dgvRecentTransfers.Rows[rowIndex].Cells[3].Style.ForeColor = Color.FromArgb(16, 185, 129);
                    }
                    else
                    {
                        dgvRecentTransfers.Rows[rowIndex].Cells[3].Style.ForeColor = Color.FromArgb(224, 0, 0);
                    }

                    count++;
                }

                if (count == 0)
                {
                    dgvRecentTransfers.Rows.Add("(No recent file transfers)", "--", "--", "--", "--");
                    dgvRecentTransfers.Rows[0].Cells[0].Style.ForeColor = Color.FromArgb(128, 128, 128);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("HomeControl.RefreshRecentTransfers error: " + ex.Message);
            }
        }

        public void RefreshDevicesOnline()
        {
            try
            {
                listDevicesOnline.Items.Clear();

                TrustedDeviceService trustedService = ServiceRegistry.Resolve<TrustedDeviceService>("TrustedDeviceService");
                int onlineCount = 0;

                if (trustedService != null)
                {
                    var trusted = trustedService.GetTrustedDevices();
                    foreach (var t in trusted)
                    {
                        ListViewItem item = new ListViewItem(t.Name);
                        item.SubItems.Add(!string.IsNullOrEmpty(t.IpAddress) ? t.IpAddress : "LAN");
                        item.SubItems.Add(string.IsNullOrEmpty(t.ConnectionType) ? "Ethernet" : t.ConnectionType);
                        item.SubItems.Add("Online");
                        item.ForeColor = Color.FromArgb(32, 32, 32);
                        listDevicesOnline.Items.Add(item);
                        onlineCount++;
                    }
                }

                if (onlineCount == 0)
                {
                    lblDevicesCount.Text = "Scanning local network for devices...";
                    lblDevicesCount.ForeColor = Color.FromArgb(80, 80, 80);
                }
                else
                {
                    lblDevicesCount.Text = string.Format("{0} peer device(s) online", onlineCount);
                    lblDevicesCount.ForeColor = Color.FromArgb(16, 185, 129);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("HomeControl.RefreshDevicesOnline error: " + ex.Message);
            }
        }

        private void BtnQuickSend_Click(object sender, EventArgs e)
        {
            if (SendFileRequested != null) SendFileRequested(this, EventArgs.Empty);
        }

        private void BtnQuickReceive_Click(object sender, EventArgs e)
        {
            if (ReceiveRequested != null) ReceiveRequested(this, EventArgs.Empty);
        }

        private void BtnQuickDevices_Click(object sender, EventArgs e)
        {
            if (BrowseDevicesRequested != null) BrowseDevicesRequested(this, EventArgs.Empty);
        }

        private void BtnQuickExplorer_Click(object sender, EventArgs e)
        {
            if (OpenExplorerRequested != null) OpenExplorerRequested(this, EventArgs.Empty);
        }

        private void DgvRecentTransfers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRecentTransfers.Rows.Count) return;
            string filePath = dgvRecentTransfers.Rows[e.RowIndex].Tag as string;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + filePath + "\"");
                }
                catch { }
            }
        }

        private string FormatSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
