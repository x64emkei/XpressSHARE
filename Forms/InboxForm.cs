using System;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Services;

namespace XpressShare.Forms
{
    public partial class InboxForm : Form
    {
        private TransferManager _transferManager;
        private Guid _sessionId;

        public Guid SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }

        public string PendingFilePath { get; set; }
        public long PendingFileSize { get; set; }
        public string RemoteDeviceName { get; set; }
        public string RemoteDeviceId { get; set; }

        public InboxForm()
            : this(null, null)
        {
        }

        public InboxForm(TransferSession session, TransferManager transferManager)
        {
            InitializeComponent();
            _transferManager = transferManager ?? ServiceRegistry.Resolve<TransferManager>("TransferManager");

            if (session != null)
            {
                _sessionId = session.SessionId;
                RemoteDeviceId = session.RemoteDeviceId;
                RemoteDeviceName = session.RemoteDeviceName;
                PendingFilePath = session.FileName;
                PendingFileSize = session.TotalBytes;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)) return;

            try
            {
                picHeaderIcon.Image = IconHelper.GetInboxIcon(26, System.Drawing.Color.White);
                btnAccept.Image = IconHelper.GetCheckIcon(16, System.Drawing.Color.White);
                btnReject.Image = IconHelper.GetCrossIcon(14, System.Drawing.Color.FromArgb(100, 116, 139));
            }
            catch { }

            if (!string.IsNullOrEmpty(RemoteDeviceName))
            {
                lblDevice.Text = RemoteDeviceName;
            }
            else
            {
                lblDevice.Text = "Unknown Device";
            }

            if (!string.IsNullOrEmpty(PendingFilePath))
            {
                lblFileName.Text = System.IO.Path.GetFileName(PendingFilePath);
            }
            else
            {
                lblFileName.Text = "(Unknown File)";
            }

            if (PendingFileSize > 0)
            {
                lblFileSize.Text = FormatFileSize(PendingFileSize);
            }
            else
            {
                lblFileSize.Text = "0 B";
            }
        }

        private string FormatFileSize(long bytes)
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

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && _sessionId != Guid.Empty)
            {
                _transferManager.ApproveTransfer(_sessionId);
            }

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && _sessionId != Guid.Empty)
            {
                _transferManager.RejectTransfer(_sessionId);
            }

            DialogResult = DialogResult.No;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (DialogResult != DialogResult.Yes && DialogResult != DialogResult.No && DialogResult != DialogResult.OK)
            {
                // Closed via X button or Alt+F4: treat as Reject
                if (_transferManager != null && _sessionId != Guid.Empty)
                {
                    _transferManager.RejectTransfer(_sessionId);
                }
            }
        }
    }
}
