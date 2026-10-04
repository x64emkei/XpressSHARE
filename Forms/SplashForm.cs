using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XpressShare.Core;

namespace XpressShare.Forms
{
    public partial class SplashForm : Form
    {
        private BackgroundWorker _startupWorker;
        private Image _splashImage;
        private DateTime _startupStartTime;
        private System.Windows.Forms.Timer _minDisplayTimer;
        private Exception _startupError;

        public SplashForm()
        {
            InitializeComponent();
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            LoadSplashImage();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            _startupStartTime = DateTime.UtcNow;
            StartInitialization();
        }

        private void LoadSplashImage()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            string imagePath = Path.Combine(Application.StartupPath, "splash.bmp");
            if (!File.Exists(imagePath))
            {
                return;
            }

            _splashImage = Image.FromFile(imagePath);
            pictureSplash.Image = _splashImage;
        }

        private void StartInitialization()
        {
            _startupWorker = new BackgroundWorker();
            _startupWorker.WorkerReportsProgress = true;
            _startupWorker.DoWork += StartupWorker_DoWork;
            _startupWorker.ProgressChanged += StartupWorker_ProgressChanged;
            _startupWorker.RunWorkerCompleted += StartupWorker_RunWorkerCompleted;
            _startupWorker.RunWorkerAsync();
        }

        private void StartupWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            try
            {
                StartupManager.Initialize(delegate(int percent, string status)
                {
                    worker.ReportProgress(percent, status);
                });
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void StartupWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string status = e.UserState as string;
            if (!string.IsNullOrEmpty(status))
            {
                progressStartup.Value = Math.Max(progressStartup.Minimum, Math.Min(progressStartup.Maximum, e.ProgressPercentage));
                lblStatus.Text = e.ProgressPercentage.ToString("00") + "%  " + status;
            }
        }

        private void StartupWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _startupError = e.Error ?? e.Result as Exception;

            // Ensure approximately 3 seconds have elapsed without blocking the UI thread
            TimeSpan elapsed = DateTime.UtcNow - _startupStartTime;
            int remainingMs = (int)(3000 - elapsed.TotalMilliseconds);

            if (remainingMs > 50)
            {
                _minDisplayTimer = new System.Windows.Forms.Timer();
                _minDisplayTimer.Interval = remainingMs;
                _minDisplayTimer.Tick += MinDisplayTimer_Tick;
                _minDisplayTimer.Start();
            }
            else
            {
                FinishSplashAndProceed();
            }
        }

        private void MinDisplayTimer_Tick(object sender, EventArgs e)
        {
            if (_minDisplayTimer != null)
            {
                _minDisplayTimer.Stop();
                _minDisplayTimer.Dispose();
                _minDisplayTimer = null;
            }

            FinishSplashAndProceed();
        }

        private void FinishSplashAndProceed()
        {
            if (_startupError != null)
            {
                AppLogger.Log("Startup failed: " + _startupError);
                MessageBox.Show(
                    "XpressSHARE could not start. Please check the application log and try again.",
                    "XpressSHARE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                return;
            }

            progressStartup.Value = progressStartup.Maximum;
            lblStatus.Text = "100%  Startup initialization complete.";
            Hide();

            // Check if first launch
            if (StartupManager.IsFirstLaunch())
            {
                using (RegistrationForm reg = new RegistrationForm())
                {
                    if (reg.ShowDialog(this) != DialogResult.OK)
                    {
                        Close();
                        return;
                    }
                }
                StartupManager.MarkFirstLaunchComplete();
            }

            // Authentication & Application Flow
            RunAppSessionLoop();

            Close();
        }

        private void RunAppSessionLoop()
        {
            bool stayInApp = true;

            while (stayInApp)
            {
                bool authenticated = false;

                // Check Remember Me auto-login
                if (AppSettings.Instance.RememberMe &&
                    !string.IsNullOrEmpty(AppSettings.Instance.CurrentUsername) &&
                    !string.IsNullOrEmpty(AppSettings.Instance.AuthSessionToken))
                {
                    authenticated = true;
                }
                else
                {
                    using (LoginForm login = new LoginForm())
                    {
                        if (login.ShowDialog(this) == DialogResult.OK)
                        {
                            authenticated = true;
                        }
                        else
                        {
                            // User cancelled login
                            stayInApp = false;
                            break;
                        }
                    }
                }

                if (authenticated)
                {
                    using (MainForm main = new MainForm())
                    {
                        DialogResult result = main.ShowDialog(this);
                        if (result == DialogResult.Retry)
                        {
                            // User logged out: loop back to login form
                            stayInApp = true;
                        }
                        else
                        {
                            // Normal close / Exit
                            stayInApp = false;
                        }
                    }
                }
                else
                {
                    stayInApp = false;
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_splashImage != null)
            {
                _splashImage.Dispose();
                _splashImage = null;
            }

            if (_minDisplayTimer != null)
            {
                _minDisplayTimer.Dispose();
                _minDisplayTimer = null;
            }

            base.OnFormClosed(e);
        }
    }
}
