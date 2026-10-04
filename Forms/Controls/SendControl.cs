using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Services;

namespace XpressShare.Forms.Controls
{
    public partial class SendControl : UserControl
    {
        public event EventHandler<SendExecutionEventArgs> ExecuteSendRequested;
        public event Action<string> StatusMessageChanged;

        private readonly List<string> _selectedFilePaths = new List<string>();

        public SendControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            RefreshPeersList();
            cboTargetFolder.SelectedIndex = 0;
            UpdateSelectionSummary();
        }

        public void AddFiles(string[] paths)
        {
            if (paths == null) return;
            foreach (string p in paths)
            {
                if ((File.Exists(p) || Directory.Exists(p)) && !_selectedFilePaths.Contains(p))
                {
                    _selectedFilePaths.Add(p);
                }
            }
            RefreshFilesList();
        }

        public void RefreshPeersList()
        {
            cboTargetDevice.Items.Clear();

            TrustedDeviceService trustedService = ServiceRegistry.Resolve<TrustedDeviceService>("TrustedDeviceService");
            if (trustedService != null)
            {
                var trusted = trustedService.GetTrustedDevices();
                foreach (var t in trusted)
                {
                    cboTargetDevice.Items.Add(new MainForm.DeviceItem
                    {
                        DeviceId = t.DeviceId,
                        DeviceName = t.Name,
                        IpAddress = t.IpAddress,
                        Port = AppSettings.Instance.TransferPort > 0 ? AppSettings.Instance.TransferPort : 15001,
                        ConnectionType = t.ConnectionType,
                        IsTrusted = true
                    });
                }
            }

            if (cboTargetDevice.Items.Count > 0 && cboTargetDevice.SelectedIndex < 0)
            {
                cboTargetDevice.SelectedIndex = 0;
            }
            else if (cboTargetDevice.Items.Count == 0)
            {
                cboTargetDevice.Text = "No paired devices found. Click 'Scan' or browse network.";
            }

            UpdateSendButtonState();
        }

        private void RefreshFilesList()
        {
            listFiles.BeginUpdate();
            listFiles.Items.Clear();

            long totalBytes = 0;
            foreach (string path in _selectedFilePaths)
            {
                if (File.Exists(path))
                {
                    FileInfo fi = new FileInfo(path);
                    ListViewItem item = new ListViewItem(fi.Name);
                    item.Tag = path;
                    item.SubItems.Add(fi.DirectoryName);
                    item.SubItems.Add(FormatSize(fi.Length));
                    item.SubItems.Add("Ready");
                    listFiles.Items.Add(item);
                    totalBytes += fi.Length;
                }
                else if (Directory.Exists(path))
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    ListViewItem item = new ListViewItem(di.Name + " (Folder)");
                    item.Tag = path;
                    item.SubItems.Add(di.Parent != null ? di.Parent.FullName : path);
                    item.SubItems.Add("Folder");
                    item.SubItems.Add("Ready");
                    listFiles.Items.Add(item);
                }
            }

            listFiles.EndUpdate();
            lblFileSummary.Text = string.Format("Total: {0} item(s) selected ({1})", _selectedFilePaths.Count, FormatSize(totalBytes));
            UpdateSendButtonState();
        }

        private void UpdateSendButtonState()
        {
            bool hasFiles = _selectedFilePaths.Count > 0;
            bool hasTarget = cboTargetDevice.SelectedItem is MainForm.DeviceItem;
            btnSendNow.Enabled = hasFiles && hasTarget;

            if (!hasFiles)
            {
                lblHintStatus.Text = "Add files or folders to begin.";
                lblHintStatus.ForeColor = Color.Gray;
            }
            else if (!hasTarget)
            {
                lblHintStatus.Text = "Select a recipient device above.";
                lblHintStatus.ForeColor = Color.FromArgb(224, 0, 0);
            }
            else
            {
                MainForm.DeviceItem dev = (MainForm.DeviceItem)cboTargetDevice.SelectedItem;
                lblHintStatus.Text = string.Format("Ready to transmit to {0} ({1}).", dev.DeviceName, dev.IpAddress);
                lblHintStatus.ForeColor = Color.FromArgb(16, 185, 129);
            }
        }

        private void UpdateSelectionSummary()
        {
            btnRemoveSelected.Enabled = listFiles.SelectedItems.Count > 0;
        }

        private void BtnAddFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select File(s) to Send - XpressSHARE";
                dlg.Multiselect = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AddFiles(dlg.FileNames);
                }
            }
        }

        private void BtnAddFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select Folder to Send - XpressSHARE";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AddFiles(new string[] { dlg.SelectedPath });
                }
            }
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFiles.SelectedItems)
            {
                string path = item.Tag as string;
                if (!string.IsNullOrEmpty(path)) _selectedFilePaths.Remove(path);
            }
            RefreshFilesList();
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            _selectedFilePaths.Clear();
            RefreshFilesList();
        }

        private void BtnScanDevices_Click(object sender, EventArgs e)
        {
            RefreshPeersList();
            if (StatusMessageChanged != null) StatusMessageChanged("Refreshed paired & active devices.");
        }

        private void CboTargetDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSendButtonState();
        }

        private void ListFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectionSummary();
        }

        private void BtnSendNow_Click(object sender, EventArgs e)
        {
            if (_selectedFilePaths.Count == 0 || !(cboTargetDevice.SelectedItem is MainForm.DeviceItem)) return;

            MainForm.DeviceItem target = (MainForm.DeviceItem)cboTargetDevice.SelectedItem;
            string destFolder = cboTargetFolder.Text;
            bool encrypt = chkEncrypt.Checked;
            bool checksum = chkVerifyChecksum.Checked;
            bool compress = chkCompress.Checked;

            if (ExecuteSendRequested != null)
            {
                ExecuteSendRequested(this, new SendExecutionEventArgs
                {
                    TargetPeer = target,
                    FilePaths = _selectedFilePaths.ToArray(),
                    DestinationFolder = destFolder,
                    EncryptSession = encrypt,
                    VerifyChecksum = checksum,
                    CompressPayload = compress
                });
            }

            _selectedFilePaths.Clear();
            RefreshFilesList();
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

    public class SendExecutionEventArgs : EventArgs
    {
        public MainForm.DeviceItem TargetPeer { get; set; }
        public string[] FilePaths { get; set; }
        public string DestinationFolder { get; set; }
        public bool EncryptSession { get; set; }
        public bool VerifyChecksum { get; set; }
        public bool CompressPayload { get; set; }
    }
}
