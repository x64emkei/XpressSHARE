using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Services;

namespace XpressShare.Forms.Controls
{
    public partial class ReceiveControl : UserControl
    {
        public event EventHandler<TransferApprovalEventArgs> TransferApproved;
        public event EventHandler<TransferApprovalEventArgs> TransferRejected;
        public event Action<string> StatusMessageChanged;

        private TransferSession _pendingSession;
        private TransferHistoryService _historyService;

        public ReceiveControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            txtDownloadPath.Text = AppSettings.Instance.SelectedDownloadFolder;
            chkAutoAccept.Checked = AppSettings.Instance.AutoAcceptTransfers;
            chkEnableListener.Checked = AppSettings.Instance.ReceiveEnabled;

            RefreshPendingApproval();
            RefreshReceivedHistory();
        }

        public void SetPendingTransfer(TransferSession session)
        {
            _pendingSession = session;
            RefreshPendingApproval();
        }

        public void ClearPendingTransfer()
        {
            _pendingSession = null;
            RefreshPendingApproval();
        }

        public void RefreshPendingApproval()
        {
            if (_pendingSession != null)
            {
                panelPendingBanner.Visible = true;
                lblPendingPeerVal.Text = _pendingSession.RemoteDeviceName;
                lblPendingFileVal.Text = _pendingSession.FileName;
                lblPendingSizeVal.Text = FormatSize(_pendingSession.TotalBytes);
                lblPendingDestVal.Text = AppSettings.Instance.SelectedDownloadFolder;
                lblNoPending.Visible = false;
            }
            else
            {
                panelPendingBanner.Visible = false;
                lblNoPending.Visible = true;
            }
        }

        public void RefreshReceivedHistory()
        {
            try
            {
                if (_historyService == null)
                {
                    _historyService = new TransferHistoryService();
                }

                dgvReceivedHistory.Rows.Clear();
                var history = _historyService.GetHistory();
                int count = 0;

                for (int i = history.Count - 1; i >= 0; i--)
                {
                    var entry = history[i];
                    if (string.IsNullOrEmpty(entry.FilePath)) continue;

                    string fileName = Path.GetFileName(entry.FilePath);
                    string sender = !string.IsNullOrEmpty(entry.RemoteDeviceName) ? entry.RemoteDeviceName : "Remote Peer";
                    string size = FormatSize(entry.FileSize);
                    string time = entry.Timestamp.ToString("yyyy-MM-dd HH:mm");
                    string status = entry.Success ? "Received" : "Incomplete";

                    int r = dgvReceivedHistory.Rows.Add(fileName, sender, size, time, status);
                    dgvReceivedHistory.Rows[r].Tag = entry.FilePath;

                    if (entry.Success)
                    {
                        dgvReceivedHistory.Rows[r].Cells[4].Style.ForeColor = Color.FromArgb(16, 185, 129);
                    }
                    else
                    {
                        dgvReceivedHistory.Rows[r].Cells[4].Style.ForeColor = Color.FromArgb(239, 68, 68);
                    }
                    count++;
                }

                if (count == 0)
                {
                    dgvReceivedHistory.Rows.Add("(No received files yet)", "--", "--", "--", "--");
                    dgvReceivedHistory.Rows[0].Cells[0].Style.ForeColor = Color.Gray;
                }

                UpdateHistoryButtonStates();
            }
            catch (Exception ex)
            {
                AppLogger.Log("ReceiveControl.RefreshReceivedHistory error: " + ex.Message);
            }
        }

        private void UpdateHistoryButtonStates()
        {
            bool hasSelection = dgvReceivedHistory.SelectedRows.Count > 0 && dgvReceivedHistory.SelectedRows[0].Tag != null;
            btnOpenFile.Enabled = hasSelection;
            btnOpenFolder.Enabled = hasSelection;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (_pendingSession != null && TransferApproved != null)
            {
                TransferApproved(this, new TransferApprovalEventArgs { Session = _pendingSession });
                ClearPendingTransfer();
                NotifyStatus("Approved transfer.");
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (_pendingSession != null && TransferRejected != null)
            {
                TransferRejected(this, new TransferApprovalEventArgs { Session = _pendingSession });
                ClearPendingTransfer();
                NotifyStatus("Rejected transfer.");
            }
        }

        private void BtnBrowseDownload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select Default Download Directory";
                dlg.SelectedPath = txtDownloadPath.Text;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtDownloadPath.Text = dlg.SelectedPath;
                    AppSettings.Instance.SelectedDownloadFolder = dlg.SelectedPath;
                    AppSettings.Instance.Save();
                    NotifyStatus("Download location updated.");
                }
            }
        }

        private void ChkAutoAccept_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Instance.AutoAcceptTransfers = chkAutoAccept.Checked;
            AppSettings.Instance.Save();
            NotifyStatus(chkAutoAccept.Checked ? "Auto-accept enabled for paired devices." : "Auto-accept disabled.");
        }

        private void ChkEnableListener_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Instance.ReceiveEnabled = chkEnableListener.Checked;
            AppSettings.Instance.Save();
            NotifyStatus(chkEnableListener.Checked ? "Receiver listener enabled on port 15001." : "Receiver listener stopped.");
        }

        private void DgvReceivedHistory_SelectionChanged(object sender, EventArgs e)
        {
            UpdateHistoryButtonStates();
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            if (dgvReceivedHistory.SelectedRows.Count == 0) return;
            string path = dgvReceivedHistory.SelectedRows[0].Tag as string;
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    Process.Start(path);
                    NotifyStatus("Opened: " + Path.GetFileName(path));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            if (dgvReceivedHistory.SelectedRows.Count == 0) return;
            string path = dgvReceivedHistory.SelectedRows[0].Tag as string;
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    Process.Start("explorer.exe", "/select,\"" + path + "\"");
                }
                catch { }
            }
            else
            {
                string down = AppSettings.Instance.SelectedDownloadFolder;
                if (Directory.Exists(down))
                {
                    try { Process.Start("explorer.exe", down); } catch { }
                }
            }
        }

        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            if (_historyService != null)
            {
                _historyService.ClearHistory();
                RefreshReceivedHistory();
                NotifyStatus("Received history cleared.");
            }
        }

        private void NotifyStatus(string message)
        {
            if (StatusMessageChanged != null) StatusMessageChanged(message);
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

    public class TransferApprovalEventArgs : EventArgs
    {
        public TransferSession Session { get; set; }
    }
}
