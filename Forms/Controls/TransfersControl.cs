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
    public partial class TransfersControl : UserControl
    {
        public event Action<string> StatusMessageChanged;

        private Services.TransferManager _transferManager;

        public TransfersControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(dgvTransfers);

            _transferManager = ServiceRegistry.Resolve<Services.TransferManager>("TransferManager");
            RefreshTransfers();
        }

        public void ApplyDensity(int rowHeight)
        {
            try
            {
                dgvTransfers.SuspendLayout();
                dgvTransfers.RowTemplate.Height = rowHeight;
                foreach (DataGridViewRow r in dgvTransfers.Rows)
                {
                    r.Height = rowHeight;
                }
                dgvTransfers.ResumeLayout();
            }
            catch { }
        }

        public void RefreshTransfers()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(RefreshTransfers));
                return;
            }

            dgvTransfers.Rows.Clear();

            int activeCount = 0;
            int queuedCount = 0;
            double totalSpeed = 0;

            if (_transferManager != null)
            {
                // 1. Pending Approvals
                var pendings = _transferManager.GetPendingApprovals();
                foreach (var p in pendings)
                {
                    int r = dgvTransfers.Rows.Add(
                        "↓ Receive",
                        p.FileName,
                        FormatSize(p.TotalBytes),
                        p.RemoteDeviceName,
                        "This Computer",
                        "Pending Approval",
                        "0%",
                        "0 B/s",
                        DateTime.Now.ToString("HH:mm:ss")
                    );
                    dgvTransfers.Rows[r].Tag = p.SessionId.ToString();
                    dgvTransfers.Rows[r].Cells[5].Style.ForeColor = Color.FromArgb(224, 0, 0);
                    queuedCount++;
                }

                // 2. Active Transfers
                var actives = _transferManager.GetActiveTransfers();
                foreach (var a in actives)
                {
                    double speedKb = a.TransferRate / 1024.0;
                    string speedText = speedKb >= 1024.0 ? string.Format("{0:0.0} MB/s", speedKb / 1024.0) : string.Format("{0:0.0} KB/s", speedKb);

                    int r = dgvTransfers.Rows.Add(
                        a.IsUpload ? "↑ Send" : "↓ Receive",
                        a.FileName,
                        FormatSize(a.TotalBytes),
                        a.IsUpload ? "This Computer" : a.RemoteDeviceName,
                        a.IsUpload ? a.RemoteDeviceName : "This Computer",
                        a.State.ToString(),
                        string.Format("{0:0.0}%", a.Progress),
                        speedText,
                        DateTime.Now.ToString("HH:mm:ss")
                    );
                    dgvTransfers.Rows[r].Tag = a.SessionId.ToString();
                    dgvTransfers.Rows[r].Cells[5].Style.ForeColor = Color.FromArgb(16, 185, 129);

                    activeCount++;
                    totalSpeed += a.TransferRate;
                }

                // 3. Queued items
                var queued = _transferManager.GetPendingTransfers();
                foreach (var q in queued)
                {
                    int r = dgvTransfers.Rows.Add(
                        q.Direction == Models.TransferDirection.Upload ? "↑ Send" : "↓ Receive",
                        Path.GetFileName(q.FilePath),
                        FormatSize(q.TotalBytes),
                        q.Direction == Models.TransferDirection.Upload ? "This Computer" : q.RemoteDeviceName,
                        q.Direction == Models.TransferDirection.Upload ? q.RemoteDeviceName : "This Computer",
                        q.Status.ToString(),
                        "0%",
                        "0 B/s",
                        "--"
                    );
                    dgvTransfers.Rows[r].Tag = q.Id;
                    dgvTransfers.Rows[r].Cells[5].Style.ForeColor = Color.FromArgb(111, 118, 125);
                    queuedCount++;
                }
            }

            // Summary metrics
            lblActiveCountVal.Text = activeCount.ToString();
            lblQueuedCountVal.Text = queuedCount.ToString();

            double totalSpeedKb = totalSpeed / 1024.0;
            string totalSpeedText = totalSpeedKb >= 1024.0 ? string.Format("{0:0.0} MB/s", totalSpeedKb / 1024.0) : string.Format("{0:0.0} KB/s", totalSpeedKb);
            lblSpeedVal.Text = totalSpeedText;

            if (dgvTransfers.Rows.Count == 0)
            {
                dgvTransfers.Rows.Add("--", "(No active or queued transfers)", "--", "--", "--", "Idle", "--", "--", "--");
                dgvTransfers.Rows[0].Cells[1].Style.ForeColor = Color.Gray;
            }

            UpdateActionButtonStates();
        }

        private void UpdateActionButtonStates()
        {
            bool hasSelection = dgvTransfers.SelectedRows.Count > 0 && dgvTransfers.SelectedRows[0].Tag != null;
            btnPause.Enabled = hasSelection;
            btnResume.Enabled = hasSelection;
            btnCancel.Enabled = hasSelection;
        }

        private void DgvTransfers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateActionButtonStates();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && dgvTransfers.SelectedRows.Count > 0)
            {
                string id = dgvTransfers.SelectedRows[0].Tag as string;
                if (!string.IsNullOrEmpty(id))
                {
                    _transferManager.PauseTransfer(id);
                    NotifyStatus("Paused transfer.");
                    RefreshTransfers();
                }
            }
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && dgvTransfers.SelectedRows.Count > 0)
            {
                string id = dgvTransfers.SelectedRows[0].Tag as string;
                if (!string.IsNullOrEmpty(id))
                {
                    _transferManager.ResumeTransfer(id);
                    NotifyStatus("Resumed transfer.");
                    RefreshTransfers();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && dgvTransfers.SelectedRows.Count > 0)
            {
                string id = dgvTransfers.SelectedRows[0].Tag as string;
                if (!string.IsNullOrEmpty(id))
                {
                    _transferManager.CancelTransfer(id);
                    NotifyStatus("Cancelled transfer.");
                    RefreshTransfers();
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            RefreshTransfers();
            NotifyStatus("Refreshed transfer console.");
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            string down = AppSettings.Instance.SelectedDownloadFolder;
            if (Directory.Exists(down))
            {
                try { Process.Start("explorer.exe", down); } catch { }
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
}
