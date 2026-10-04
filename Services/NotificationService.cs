using System;
using System.Windows.Forms;

namespace XpressShare.Services
{
    public class NotificationService
    {
        private NotifyIcon _trayIcon;

        public NotificationService()
            : this(null)
        {
        }

        public NotificationService(NotifyIcon trayIcon)
        {
            _trayIcon = trayIcon;
        }

        public void SetTrayIcon(NotifyIcon trayIcon)
        {
            _trayIcon = trayIcon;
        }

        public void Show(string title, string message)
        {
            Show(title, message, ToolTipIcon.Info);
        }

        public void Show(string title, string message, ToolTipIcon icon)
        {
            if (_trayIcon == null)
                return;

            try
            {
                _trayIcon.ShowBalloonTip(5000, title, message, icon);
            }
            catch
            {
            }
        }

        public void ShowSuccess(string title, string message)
        {
            Show(title, message, ToolTipIcon.Info);
        }

        public void ShowError(string title, string message)
        {
            Show(title, message, ToolTipIcon.Error);
        }

        public void ShowWarning(string title, string message)
        {
            Show(title, message, ToolTipIcon.Warning);
        }

        public void ShowTransferStarted(string fileName, string remoteDevice)
        {
            Show("Transfer Started", "Receiving " + fileName + " from " + remoteDevice, ToolTipIcon.Info);
        }

        public void ShowTransferCompleted(string fileName, string remoteDevice)
        {
            Show("Transfer Complete", "Successfully received " + fileName + " from " + remoteDevice, ToolTipIcon.Info);
        }

        public void ShowTransferFailed(string fileName, string remoteDevice)
        {
            Show("Transfer Failed", "Failed to receive " + fileName + " from " + remoteDevice, ToolTipIcon.Error);
        }
    }
}
