using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Forms.Controls;
using XpressShare.Models;
using XpressShare.Services;
using XpressShare.Transfers;
using XpressShare.Utilities;
using TransferOptimizer = XpressShare.Services.TransferOptimizer;

namespace XpressShare.Forms
{
    public partial class MainForm : Form
    {
        public enum NavView
        {
            Home,
            Explorer,
            Send,
            Receive,
            Transfers,
            Devices,
            Settings
        }

        #region Helper DeviceItem Class

        public class DeviceItem
        {
            public string DeviceId { get; set; }
            public string DeviceName { get; set; }
            public string IpAddress { get; set; }
            public int Port { get; set; }
            public string ConnectionType { get; set; }
            public bool IsTrusted { get; set; }

            public override string ToString()
            {
                if (!string.IsNullOrEmpty(IpAddress))
                {
                    return string.Format("{0} ({1})", DeviceName, IpAddress);
                }
                return DeviceName ?? "Unknown Device";
            }
        }

        #endregion

        #region Private Fields & Services

        private DeviceIdentity _localIdentity;
        private TrustedDeviceService _trustedDeviceService;
        private LanDiscoveryService _discoveryService;
        private Services.TransferManager _transferManager;
        private TransferListenerService _listenerService;
        private TransferHistoryService _historyService;

        // View Controls
        private HomeControl _homeControl;
        private ExplorerControl _explorerControl;
        private SendControl _sendControl;
        private ReceiveControl _receiveControl;
        private TransfersControl _transfersControl;
        private DevicesControl _devicesControl;
        private SettingsControl _settingsControl;

        private NavView _currentView = NavView.Home;
        private UserControl _activeViewControl;
        private Button _activeNavButton;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED: Double-buffers all child windows from bottom to top
                return cp;
            }
        }

        // Drawer State
        private bool _isDrawerExpanded = false;
        private const int DrawerCollapsedHeight = 28;
        private const int DrawerExpandedHeight = 180;

        // Discovered Devices Cache
        private readonly List<DeviceItem> _discoveredDevices = new List<DeviceItem>();
        private readonly object _deviceLock = new object();

        private bool IsInDesignMode
        {
            get
            {
                return DesignMode || (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            }
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
            if (IsInDesignMode) return;
            InitializeViews();
        }

        private void InitializeViews()
        {
            this.Text = string.Format("XpressSHARE — {0}", SystemEnvironmentInfo.ProcessArchitecture);

            // Double buffer container panels and queues
            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(panelSidebar);
            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(panelSidebarMenu);
            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(panelWorkspaceWrapper);
            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(panelContentContainer);
            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(panelTransferDrawer);
            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(panelDrawerBody);
            XpressShare.Controls.BufferedPanel.EnableDoubleBuffering(listTransferQueue);

            // Instantiate major UserControls
            _homeControl = new HomeControl();
            _homeControl.Dock = DockStyle.Fill;
            _homeControl.SendFileRequested += delegate { NavigateToView(NavView.Send); };
            _homeControl.ReceiveRequested += delegate { NavigateToView(NavView.Receive); };
            _homeControl.BrowseDevicesRequested += delegate { NavigateToView(NavView.Devices); };
            _homeControl.OpenExplorerRequested += delegate { NavigateToView(NavView.Explorer); };

            _explorerControl = new ExplorerControl();
            _explorerControl.Dock = DockStyle.Fill;
            _explorerControl.SendFilesRequested += delegate(string[] files)
            {
                NavigateToView(NavView.Send);
                _sendControl.AddFiles(files);
            };
            _explorerControl.StatusMessageChanged += delegate(string msg) { UpdateStatus(msg); };

            _sendControl = new SendControl();
            _sendControl.Dock = DockStyle.Fill;
            _sendControl.ExecuteSendRequested += SendControl_ExecuteSendRequested;
            _sendControl.StatusMessageChanged += delegate(string msg) { UpdateStatus(msg); };

            _receiveControl = new ReceiveControl();
            _receiveControl.Dock = DockStyle.Fill;
            _receiveControl.TransferApproved += ReceiveControl_TransferApproved;
            _receiveControl.TransferRejected += ReceiveControl_TransferRejected;
            _receiveControl.StatusMessageChanged += delegate(string msg) { UpdateStatus(msg); };

            _transfersControl = new TransfersControl();
            _transfersControl.Dock = DockStyle.Fill;
            _transfersControl.StatusMessageChanged += delegate(string msg) { UpdateStatus(msg); };

            _devicesControl = new DevicesControl();
            _devicesControl.Dock = DockStyle.Fill;
            _devicesControl.SendFileToDeviceRequested += delegate(DeviceItem dev)
            {
                NavigateToView(NavView.Send);
                _sendControl.RefreshPeersList();
            };
            _devicesControl.StatusMessageChanged += delegate(string msg) { UpdateStatus(msg); };

            _settingsControl = new SettingsControl();
            _settingsControl.Dock = DockStyle.Fill;
            _settingsControl.StatusMessageChanged += delegate(string msg) { UpdateStatus(msg); };
            _settingsControl.ThemeToggleRequested += delegate { ApplyCurrentTheme(); };
            _settingsControl.DensityChanged += delegate(string d) { ApplyUiDensity(d); };

            // Hide inactive controls initially
            _explorerControl.Visible = false;
            _sendControl.Visible = false;
            _receiveControl.Visible = false;
            _transfersControl.Visible = false;
            _devicesControl.Visible = false;
            _settingsControl.Visible = false;
            _homeControl.Visible = true;
            _activeViewControl = _homeControl;
            _activeNavButton = btnNavHome;

            // Add all controls to content container
            panelContentContainer.Controls.Add(_homeControl);
            panelContentContainer.Controls.Add(_explorerControl);
            panelContentContainer.Controls.Add(_sendControl);
            panelContentContainer.Controls.Add(_receiveControl);
            panelContentContainer.Controls.Add(_transfersControl);
            panelContentContainer.Controls.Add(_devicesControl);
            panelContentContainer.Controls.Add(_settingsControl);

            // Wire custom paint on sidebar buttons for active red accent bar
            btnNavHome.Paint += SidebarButton_Paint;
            btnNavExplorer.Paint += SidebarButton_Paint;
            btnNavSend.Paint += SidebarButton_Paint;
            btnNavReceive.Paint += SidebarButton_Paint;
            btnNavTransfers.Paint += SidebarButton_Paint;
            btnNavDevices.Paint += SidebarButton_Paint;
            btnNavSettings.Paint += SidebarButton_Paint;
        }

        #region Form Lifecycle & Service Initialization

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (IsInDesignMode) return;

            try
            {
                _trustedDeviceService = ServiceRegistry.Resolve<TrustedDeviceService>("TrustedDeviceService");
                if (_trustedDeviceService == null)
                {
                    _trustedDeviceService = new TrustedDeviceService();
                    ServiceRegistry.Register("TrustedDeviceService", _trustedDeviceService);
                }

                _localIdentity = ServiceRegistry.Resolve<DeviceIdentity>("DeviceIdentity");
                if (_localIdentity == null)
                {
                    MessageBox.Show("Device identity not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                lblBrandSubtitle.Text = string.Format("{0} • {1} • Online", Environment.MachineName, SystemEnvironmentInfo.ProcessArchitecture);

                _transferManager = ServiceRegistry.Resolve<Services.TransferManager>("TransferManager");
                if (_transferManager == null)
                {
                    _transferManager = new Services.TransferManager();
                    ServiceRegistry.Register("TransferManager", _transferManager);
                }

                _historyService = new TransferHistoryService();

                // Wire TransferManager events
                _transferManager.TransferRequested += TransferManager_TransferRequested;
                _transferManager.TransferProgress += TransferManager_TransferProgress;
                _transferManager.TransferCompleted += TransferManager_TransferCompleted;

                // Transfer listener service
                _listenerService = new TransferListenerService(_transferManager);
                ServiceRegistry.Register("TransferListenerService", _listenerService);

                // LAN discovery service
                _discoveryService = new LanDiscoveryService();
                _discoveryService.DeviceDiscovered += DiscoveryService_DeviceDiscovered;

                // Theme
                ThemeManager.ThemeChanged += OnThemeChanged;
                ApplyCurrentTheme();
                ApplyUiDensity(AppSettings.Instance.UiDensity);

                // Start LAN discovery and listener if enabled
                bool receiveEnabled = AppSettings.Instance.ReceiveEnabled;
                ApplyReceiveState(receiveEnabled);

                // Start on Home view
                NavigateToView(NavView.Home);

                // Refresh initial data
                RefreshDrawerTransfers();

                // Tray icon
                try
                {
                    trayIcon.Icon = this.Icon;
                    trayIcon.Visible = true;
                }
                catch { }

                // Update Status Bar
                statusLabelState.Text = "Ready";
                statusLabelSpeed.Text = "0 B/s";
                UpdateStatus("XpressSHARE Enterprise Ready.");
                UpdateConnectionStatus("● Connected • " + TransferOptimizer.GetActiveConnectionType());
                AppLogger.Log("MainForm Redesign initialized successfully");
            }
            catch (Exception ex)
            {
                AppLogger.Log("MainForm.OnLoad error: " + ex);
                MessageBox.Show("Failed to initialize MainForm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #endregion

        #region Navigation Architecture

        public void NavigateToView(NavView view)
        {
            if (_currentView == view && _activeViewControl != null && _activeViewControl.Visible)
            {
                return; // Already on this view, prevent redraw
            }

            _currentView = view;

            UserControl targetControl = null;
            Button targetButton = null;
            string statusMsg = string.Empty;

            switch (view)
            {
                case NavView.Home:
                    targetControl = _homeControl;
                    targetButton = btnNavHome;
                    statusMsg = "Workspace: Home Dashboard";
                    break;

                case NavView.Explorer:
                    targetControl = _explorerControl;
                    targetButton = btnNavExplorer;
                    statusMsg = "Workspace: File Explorer (SOURCE / DESTINATION)";
                    break;

                case NavView.Send:
                    targetControl = _sendControl;
                    targetButton = btnNavSend;
                    statusMsg = "Transfer: Send Files";
                    break;

                case NavView.Receive:
                    targetControl = _receiveControl;
                    targetButton = btnNavReceive;
                    statusMsg = "Transfer: Receive Files & Approvals";
                    break;

                case NavView.Transfers:
                    targetControl = _transfersControl;
                    targetButton = btnNavTransfers;
                    statusMsg = "Transfer: Stream Pipeline Management";
                    break;

                case NavView.Devices:
                    targetControl = _devicesControl;
                    targetButton = btnNavDevices;
                    statusMsg = "Network: Device Discovery & Directory";
                    break;

                case NavView.Settings:
                    targetControl = _settingsControl;
                    targetButton = btnNavSettings;
                    statusMsg = "System: Application Settings";
                    break;
            }

            if (targetControl == null) return;

            // Suspend layout on content container during transition
            panelContentContainer.SuspendLayout();

            UserControl previousControl = _activeViewControl;

            // Make target visible and frontmost FIRST to prevent white/empty frame flashes
            targetControl.Visible = true;
            targetControl.BringToFront();
            _activeViewControl = targetControl;

            // Hide previous control after new page is frontmost
            if (previousControl != null && previousControl != targetControl)
            {
                previousControl.Visible = false;
            }

            panelContentContainer.ResumeLayout(false);

            // Update only the two sidebar buttons whose states changed
            if (_activeNavButton != null && _activeNavButton != targetButton)
            {
                SetSidebarButtonInactive(_activeNavButton);
            }

            if (targetButton != null)
            {
                SetSidebarButtonActive(targetButton);
                _activeNavButton = targetButton;
            }

            if (!string.IsNullOrEmpty(statusMsg))
            {
                UpdateStatus(statusMsg);
            }
        }

        private void ResetSidebarButtonStyles()
        {
            Button[] buttons = new Button[]
            {
                btnNavHome, btnNavExplorer, btnNavSend, btnNavReceive, btnNavTransfers, btnNavDevices, btnNavSettings
            };

            foreach (Button b in buttons)
            {
                SetSidebarButtonInactive(b);
            }
        }

        private void SetSidebarButtonActive(Button b)
        {
            if (b == null) return;
            b.BackColor = Color.FromArgb(50, 57, 66);
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", b.Font.Size, FontStyle.Bold);
            b.Tag = "ACTIVE";
            b.Invalidate();
        }

        private void SetSidebarButtonInactive(Button b)
        {
            if (b == null) return;
            b.BackColor = Color.Transparent;
            b.ForeColor = Color.FromArgb(210, 215, 220);
            b.Font = new Font("Segoe UI", b.Font.Size, FontStyle.Regular);
            b.Tag = null;
            b.Invalidate();
        }

        public void ApplyUiDensity(string density)
        {
            if (string.IsNullOrEmpty(density)) density = "Standard";
            AppSettings.Instance.UiDensity = density;

            this.SuspendLayout();

            int sidebarBtnHeight = 36;
            int sidebarPaddingLeft = 22;
            float sidebarFontSize = 9.75f;
            int gridRowHeight = 28;

            if (density.Equals("Compact", StringComparison.OrdinalIgnoreCase))
            {
                sidebarBtnHeight = 30;
                sidebarPaddingLeft = 18;
                sidebarFontSize = 9f;
                gridRowHeight = 22;
            }
            else if (density.Equals("Comfortable", StringComparison.OrdinalIgnoreCase))
            {
                sidebarBtnHeight = 42;
                sidebarPaddingLeft = 26;
                sidebarFontSize = 10.25f;
                gridRowHeight = 34;
            }

            // Adjust sidebar button heights and padding
            Button[] navButtons = new Button[]
            {
                btnNavHome, btnNavExplorer, btnNavSend, btnNavReceive, btnNavTransfers, btnNavDevices, btnNavSettings
            };

            foreach (Button btn in navButtons)
            {
                btn.Height = sidebarBtnHeight;
                btn.Padding = new Padding(sidebarPaddingLeft, 0, 0, 0);
                FontStyle style = "ACTIVE".Equals(btn.Tag) ? FontStyle.Bold : FontStyle.Regular;
                btn.Font = new Font("Segoe UI", sidebarFontSize, style);
            }

            // Adjust row heights on active data grids
            if (_homeControl != null) _homeControl.ApplyDensity(gridRowHeight);
            if (_transfersControl != null) _transfersControl.ApplyDensity(gridRowHeight);
            if (_devicesControl != null) _devicesControl.ApplyDensity(gridRowHeight);

            this.ResumeLayout(true);
            UpdateStatus("UI Density set to " + density + ".");
        }

        private void SidebarButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && "ACTIVE".Equals(btn.Tag))
            {
                // Draw 4px crisp primary red accent indicator on the left
                using (Brush redBrush = new SolidBrush(Color.FromArgb(224, 0, 0)))
                {
                    e.Graphics.FillRectangle(redBrush, 0, 0, 4, btn.Height);
                }
            }
        }

        private void BtnNavHome_Click(object sender, EventArgs e) { NavigateToView(NavView.Home); }
        private void BtnNavExplorer_Click(object sender, EventArgs e) { NavigateToView(NavView.Explorer); }
        private void BtnNavSend_Click(object sender, EventArgs e) { NavigateToView(NavView.Send); }
        private void BtnNavReceive_Click(object sender, EventArgs e) { NavigateToView(NavView.Receive); }
        private void BtnNavTransfers_Click(object sender, EventArgs e) { NavigateToView(NavView.Transfers); }
        private void BtnNavDevices_Click(object sender, EventArgs e) { NavigateToView(NavView.Devices); }
        private void BtnNavSettings_Click(object sender, EventArgs e) { NavigateToView(NavView.Settings); }

        #endregion

        #region Transfer & Service Execution

        private void SendControl_ExecuteSendRequested(object sender, SendExecutionEventArgs e)
        {
            if (e.FilePaths == null || e.FilePaths.Length == 0 || e.TargetPeer == null) return;

            ExpandDrawer();

            int sentCount = 0;
            foreach (string path in e.FilePaths)
            {
                if (!File.Exists(path) && !Directory.Exists(path)) continue;

                long fileSize = 0;
                if (File.Exists(path)) fileSize = new FileInfo(path).Length;

                Models.TransferItem item = new Models.TransferItem
                {
                    RemoteDeviceId = e.TargetPeer.DeviceId,
                    RemoteDeviceName = e.TargetPeer.DeviceName,
                    RemoteIpAddress = e.TargetPeer.IpAddress,
                    RemotePort = e.TargetPeer.Port > 0 ? e.TargetPeer.Port : 15001,
                    FilePath = path,
                    TotalBytes = fileSize,
                    Status = Models.TransferStatus.Pending,
                    Direction = Models.TransferDirection.Upload
                };

                _transferManager.EnqueueTransfer(item);

                _transferManager.StartSendFile(
                    e.TargetPeer.DeviceId,
                    e.TargetPeer.DeviceName,
                    e.TargetPeer.IpAddress,
                    e.TargetPeer.Port > 0 ? e.TargetPeer.Port : 15001,
                    path,
                    _localIdentity,
                    delegate(Models.TransferSession s)
                    {
                        if (InvokeRequired)
                        {
                            BeginInvoke(new Action(RefreshDrawerTransfers));
                        }
                        else
                        {
                            RefreshDrawerTransfers();
                        }
                    });

                sentCount++;
            }

            UpdateStatus(string.Format("Queued {0} file(s) for transfer to {1}.", sentCount, e.TargetPeer.DeviceName));
            RefreshDrawerTransfers();
            if (_currentView == NavView.Transfers) _transfersControl.RefreshTransfers();
        }

        private void ReceiveControl_TransferApproved(object sender, TransferApprovalEventArgs e)
        {
            if (e.Session != null)
            {
                _transferManager.ApproveTransfer(e.Session.SessionId);
                UpdateStatus("Approved incoming transfer: " + e.Session.FileName);
                RefreshDrawerTransfers();
                btnNavReceive.Text = "Receive";
            }
        }

        private void ReceiveControl_TransferRejected(object sender, TransferApprovalEventArgs e)
        {
            if (e.Session != null)
            {
                _transferManager.RejectTransfer(e.Session.SessionId);
                UpdateStatus("Rejected incoming transfer: " + e.Session.FileName);
                RefreshDrawerTransfers();
                btnNavReceive.Text = "Receive";
            }
        }

        private void TransferManager_TransferRequested(object sender, TransferSessionEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<TransferSessionEventArgs>(OnIncomingTransferRequestedUI), e);
            }
            else
            {
                OnIncomingTransferRequestedUI(e);
            }
        }

        private void OnIncomingTransferRequestedUI(TransferSessionEventArgs e)
        {
            if (e == null || e.Session == null) return;

            // Auto-accept if configured
            if (AppSettings.Instance.AutoAcceptTransfers)
            {
                _transferManager.ApproveTransfer(e.Session.SessionId);
                UpdateStatus("Auto-accepted incoming transfer: " + e.Session.FileName);
                RefreshDrawerTransfers();
                return;
            }

            // Update ReceiveControl pending session
            _receiveControl.SetPendingTransfer(e.Session);
            btnNavReceive.Text = "Receive (1)";
            ExpandDrawer();
            RefreshDrawerTransfers();
            UpdateStatus("Incoming transfer requested from " + e.Session.RemoteDeviceName);
        }

        private void TransferManager_TransferProgress(object sender, TransferProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(RefreshDrawerTransfers));
            }
            else
            {
                RefreshDrawerTransfers();
            }
        }

        private void TransferManager_TransferCompleted(object sender, TransferCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<TransferCompleteEventArgs>(OnTransferCompletedUI), e);
            }
            else
            {
                OnTransferCompletedUI(e);
            }
        }

        private void OnTransferCompletedUI(TransferCompleteEventArgs e)
        {
            RefreshDrawerTransfers();
            if (_currentView == NavView.Home) _homeControl.RefreshRecentTransfers();
            if (_currentView == NavView.Receive) _receiveControl.RefreshReceivedHistory();
            if (_currentView == NavView.Transfers) _transfersControl.RefreshTransfers();

            string fileName = Path.GetFileName(e.FilePath);
            if (e.Success)
            {
                UpdateStatus("Transfer completed successfully: " + fileName);
            }
            else
            {
                UpdateStatus("Transfer ended or failed: " + fileName);
            }
        }

        private void DiscoveryService_DeviceDiscovered(object sender, DeviceDiscoveredEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DeviceDiscoveredEventArgs>(OnDeviceDiscoveredUI), e);
            }
            else
            {
                OnDeviceDiscoveredUI(e);
            }
        }

        private void OnDeviceDiscoveredUI(DeviceDiscoveredEventArgs e)
        {
            int defaultPort = AppSettings.Instance.TransferPort > 0 ? AppSettings.Instance.TransferPort : 15001;
            lock (_deviceLock)
            {
                bool exists = false;
                foreach (var d in _discoveredDevices)
                {
                    if (d.DeviceId == e.DeviceId || d.IpAddress == e.IpAddress)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    _discoveredDevices.Add(new DeviceItem
                    {
                        DeviceId = e.DeviceId,
                        DeviceName = e.DeviceName,
                        IpAddress = e.IpAddress,
                        Port = defaultPort,
                        ConnectionType = "LAN",
                        IsTrusted = false
                    });
                }
            }

            if (_currentView == NavView.Home) _homeControl.RefreshDevicesOnline();
            if (_currentView == NavView.Devices) _devicesControl.RefreshDevicesGrid();
            if (_currentView == NavView.Explorer) _explorerControl.PopulateRemotePeers();
            if (_currentView == NavView.Send) _sendControl.RefreshPeersList();

            UpdateStatus("Discovered device: " + e.DeviceName + " (" + e.IpAddress + ")");
        }

        #endregion

        #region Collapsible Transfer Drawer & Queue

        private void BtnDrawerToggle_Click(object sender, EventArgs e)
        {
            ToggleDrawer();
        }

        private void ToggleDrawer()
        {
            if (_isDrawerExpanded) CollapseDrawer();
            else ExpandDrawer();
        }

        private void ExpandDrawer()
        {
            panelTransferDrawer.Height = DrawerExpandedHeight;
            btnDrawerToggle.Text = "▼";
            _isDrawerExpanded = true;
        }

        private void CollapseDrawer()
        {
            panelTransferDrawer.Height = DrawerCollapsedHeight;
            btnDrawerToggle.Text = "▲";
            _isDrawerExpanded = false;
        }

        private void RefreshDrawerTransfers()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(RefreshDrawerTransfers));
                return;
            }

            listTransferQueue.BeginUpdate();
            listTransferQueue.Items.Clear();

            int activeCount = 0;
            double totalSpeed = 0;

            if (_transferManager != null)
            {
                // 1. Pending approvals
                var pendings = _transferManager.GetPendingApprovals();
                foreach (var p in pendings)
                {
                    ListViewItem item = new ListViewItem("↓");
                    item.SubItems.Add(p.FileName);
                    item.SubItems.Add(p.RemoteDeviceName);
                    item.SubItems.Add(FormatSize(p.TotalBytes));
                    item.SubItems.Add("Approval Needed");
                    item.SubItems.Add("0 B/s");
                    item.SubItems.Add("Pending");
                    item.ForeColor = Color.FromArgb(224, 0, 0);
                    item.Tag = p.SessionId.ToString();
                    listTransferQueue.Items.Add(item);
                }

                // 2. Active transfers
                var actives = _transferManager.GetActiveTransfers();
                foreach (var a in actives)
                {
                    ListViewItem item = new ListViewItem(a.IsUpload ? "↑" : "↓");
                    item.SubItems.Add(a.FileName);
                    item.SubItems.Add(a.RemoteDeviceName);
                    item.SubItems.Add(FormatSize(a.TotalBytes));
                    item.SubItems.Add(string.Format("{0:0.0}%", a.Progress));

                    double speedKb = a.TransferRate / 1024.0;
                    string speedText = speedKb >= 1024.0 ? string.Format("{0:0.0} MB/s", speedKb / 1024.0) : string.Format("{0:0.0} KB/s", speedKb);
                    item.SubItems.Add(speedText);
                    item.SubItems.Add(a.State.ToString());

                    item.ForeColor = Color.FromArgb(16, 185, 129);
                    item.Tag = a.SessionId.ToString();
                    listTransferQueue.Items.Add(item);

                    activeCount++;
                    totalSpeed += a.TransferRate;
                }

                // 3. Queued pending transfers
                var queued = _transferManager.GetPendingTransfers();
                foreach (var q in queued)
                {
                    ListViewItem item = new ListViewItem("↑");
                    item.SubItems.Add(Path.GetFileName(q.FilePath));
                    item.SubItems.Add(q.RemoteDeviceName);
                    item.SubItems.Add(FormatSize(q.TotalBytes));
                    item.SubItems.Add("Queued");
                    item.SubItems.Add("0 B/s");
                    item.SubItems.Add(q.Status.ToString());
                    item.ForeColor = Color.FromArgb(111, 118, 125);
                    item.Tag = q.Id;
                    listTransferQueue.Items.Add(item);
                }
            }

            listTransferQueue.EndUpdate();

            // Update sidebar badge
            btnNavTransfers.Text = activeCount > 0 ? string.Format("Transfers ({0})", activeCount) : "Transfers";

            // Update drawer status text
            if (activeCount > 0)
            {
                double speedKb = totalSpeed / 1024.0;
                string speedText = speedKb >= 1024.0 ? string.Format("{0:0.0} MB/s", speedKb / 1024.0) : string.Format("{0:0.0} KB/s", speedKb);
                lblDrawerStatus.Text = string.Format("Transferring {0} active streams • {1}", activeCount, speedText);
                statusLabelSpeed.Text = speedText;
            }
            else
            {
                lblDrawerStatus.Text = "Idle • 0 Active Transfers";
                statusLabelSpeed.Text = "0 B/s";
            }

            if (_currentView == NavView.Transfers)
            {
                _transfersControl.RefreshTransfers();
            }
        }

        private void BtnQueuePause_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && listTransferQueue.SelectedItems.Count > 0)
            {
                string id = listTransferQueue.SelectedItems[0].Tag as string;
                if (!string.IsNullOrEmpty(id)) _transferManager.PauseTransfer(id);
            }
            RefreshDrawerTransfers();
        }

        private void BtnQueueResume_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && listTransferQueue.SelectedItems.Count > 0)
            {
                string id = listTransferQueue.SelectedItems[0].Tag as string;
                if (!string.IsNullOrEmpty(id)) _transferManager.ResumeTransfer(id);
            }
            RefreshDrawerTransfers();
        }

        private void BtnQueueCancel_Click(object sender, EventArgs e)
        {
            if (_transferManager != null && listTransferQueue.SelectedItems.Count > 0)
            {
                string id = listTransferQueue.SelectedItems[0].Tag as string;
                if (!string.IsNullOrEmpty(id)) _transferManager.CancelTransfer(id);
            }
            RefreshDrawerTransfers();
        }

        private void BtnQueueClear_Click(object sender, EventArgs e)
        {
            RefreshDrawerTransfers();
            UpdateStatus("Transfer queue refreshed.");
        }

        private void BtnQueueOpenFolder_Click(object sender, EventArgs e)
        {
            string down = AppSettings.Instance.SelectedDownloadFolder;
            if (Directory.Exists(down))
            {
                try { Process.Start("explorer.exe", down); } catch { }
            }
        }

        #endregion

        #region Theme & Appearance

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyCurrentTheme();
        }

        private void ApplyCurrentTheme()
        {
            this.SuspendLayout();

            ThemeManager.ApplyTheme(this);

            bool isDark = ThemeManager.IsDarkMode;
            menuItemThemeLight.Checked = !isDark;
            menuItemThemeDark.Checked = isDark;

            Color sidebarBg = isDark ? Color.FromArgb(24, 27, 31) : Color.FromArgb(37, 42, 48);
            panelSidebar.BackColor = sidebarBg;
            panelSidebarMenu.BackColor = sidebarBg;
            panelSidebarBrand.BackColor = isDark ? Color.FromArgb(18, 20, 24) : Color.FromArgb(28, 32, 37);

            Color listBg = isDark ? Color.FromArgb(30, 34, 39) : Color.White;
            Color listFg = isDark ? Color.FromArgb(243, 244, 246) : Color.FromArgb(37, 42, 48);
            listTransferQueue.BackColor = listBg;
            listTransferQueue.ForeColor = listFg;

            if (_activeNavButton != null)
            {
                SetSidebarButtonActive(_activeNavButton);
            }

            this.ResumeLayout(true);
        }

        private void MenuItemThemeLight_Click(object sender, EventArgs e)
        {
            ThemeManager.SetTheme(false);
            AppSettings.Instance.DarkMode = false;
            AppSettings.Instance.Save();
            UpdateStatus("Appearance changed to Light Mode.");
        }

        private void MenuItemThemeDark_Click(object sender, EventArgs e)
        {
            ThemeManager.SetTheme(true);
            AppSettings.Instance.DarkMode = true;
            AppSettings.Instance.Save();
            UpdateStatus("Appearance changed to Dark Mode.");
        }

        #endregion

        #region Status Updates

        public void UpdateStatus(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateStatus), message);
                return;
            }
            statusLabelAction.Text = "Last action: " + message;
            AppLogger.Log("Status: " + message);
        }

        public void UpdateConnectionStatus(string status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateConnectionStatus), status);
                return;
            }
            statusLabelConnection.Text = status;
        }

        private void ApplyReceiveState(bool enabled)
        {
            AppSettings.Instance.ReceiveEnabled = enabled;
            AppSettings.Instance.Save();

            if (enabled)
            {
                if (_discoveryService != null) _discoveryService.Start(_localIdentity);
                if (_listenerService != null) _listenerService.Start();
                UpdateConnectionStatus("● Connected • " + TransferOptimizer.GetActiveConnectionType());
            }
            else
            {
                if (_discoveryService != null) _discoveryService.Stop();
                if (_listenerService != null) _listenerService.Stop();
                UpdateConnectionStatus("○ Offline • Receiving Disabled");
            }
        }

        #endregion

        #region MenuStrip & Actions

        private void MenuItemSendFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select File(s) to Send - XpressSHARE";
                dlg.Multiselect = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    NavigateToView(NavView.Send);
                    _sendControl.AddFiles(dlg.FileNames);
                }
            }
        }

        private void MenuItemSendFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select Folder to Send - XpressSHARE";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    NavigateToView(NavView.Send);
                    _sendControl.AddFiles(new string[] { dlg.SelectedPath });
                }
            }
        }

        private void BtnQuickClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                string tempFile = null;
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    tempFile = Path.Combine(Path.GetTempPath(), "clipboard_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt");
                    File.WriteAllText(tempFile, text);
                    UpdateStatus("Captured clipboard text.");
                }
                else if (Clipboard.ContainsImage())
                {
                    Image img = Clipboard.GetImage();
                    tempFile = Path.Combine(Path.GetTempPath(), "clipboard_image_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
                    img.Save(tempFile, System.Drawing.Imaging.ImageFormat.Png);
                    UpdateStatus("Captured clipboard image.");
                }
                else
                {
                    MessageBox.Show("No text or image found on clipboard.", "Quick Send", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                NavigateToView(NavView.Send);
                _sendControl.AddFiles(new string[] { tempFile });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clipboard error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuickScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle bounds = Screen.PrimaryScreen.Bounds;
                using (Bitmap bmp = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    string tempFile = Path.Combine(Path.GetTempPath(), "screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
                    bmp.Save(tempFile, System.Drawing.Imaging.ImageFormat.Png);
                    UpdateStatus("Captured screenshot.");
                    NavigateToView(NavView.Send);
                    _sendControl.AddFiles(new string[] { tempFile });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Screenshot error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuickText_Click(object sender, EventArgs e)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), "note_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt");
            File.WriteAllText(tempFile, "XpressSHARE Quick Note\r\nSent at: " + DateTime.Now.ToString() + "\r\nDevice: " + Environment.MachineName);
            UpdateStatus("Created quick text note.");
            NavigateToView(NavView.Send);
            _sendControl.AddFiles(new string[] { tempFile });
        }

        private void MenuItemPreferences_Click(object sender, EventArgs e)
        {
            NavigateToView(NavView.Settings);
        }

        private void MenuItemLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out of XpressSHARE?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppSettings.Instance.AuthSessionToken = string.Empty;
                AppSettings.Instance.RememberMe = false;
                AppSettings.Instance.Save();
                DialogResult = DialogResult.Retry;
                Close();
            }
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void MenuItemSinglePane_Click(object sender, EventArgs e)
        {
            NavigateToView(NavView.Explorer);
            menuItemSinglePane.Checked = true;
            menuItemDualPane.Checked = false;
        }

        private void MenuItemDualPane_Click(object sender, EventArgs e)
        {
            NavigateToView(NavView.Explorer);
            menuItemSinglePane.Checked = false;
            menuItemDualPane.Checked = true;
        }

        private void BtnNavRefresh_Click(object sender, EventArgs e)
        {
            RefreshDrawerTransfers();
            if (_currentView == NavView.Home) _homeControl.RefreshRecentTransfers();
            if (_currentView == NavView.Explorer) _explorerControl.PopulateRemotePeers();
            if (_currentView == NavView.Devices) _devicesControl.RefreshDevicesGrid();
            if (_currentView == NavView.Transfers) _transfersControl.RefreshTransfers();
            UpdateStatus("Refreshed active view.");
        }

        private void BtnDevDiscover_Click(object sender, EventArgs e)
        {
            NavigateToView(NavView.Devices);
        }

        private void BtnPairNewDevice_Click(object sender, EventArgs e)
        {
            NavigateToView(NavView.Devices);
        }

        private void MenuItemCheckConn_Click(object sender, EventArgs e)
        {
            string connType = TransferOptimizer.GetActiveConnectionType().ToString();
            string localIp = _localIdentity != null ? _localIdentity.LocalIpAddress : "127.0.0.1";
            string msg = string.Format("Network Status: Connected\r\nActive Interface: {0}\r\nLocal IP: {1}\r\nTransfer Port: {2}\r\nDiscovery Port: {3}",
                connType, localIp, AppSettings.Instance.TransferPort, AppSettings.Instance.DevicePort);

            MessageBox.Show(msg, "Connection Diagnostics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateStatus("Connection checked: " + connType);
        }

        private void MenuItemDiagnostics_Click(object sender, EventArgs e)
        {
            string report = TransferOptimizer.GetDiagnosticReport();
            MessageBox.Show(report, "Hardware & Network Diagnostics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateStatus("Displayed hardware & network diagnostics.");
        }

        private void MenuItemOptimization_Click(object sender, EventArgs e)
        {
            MenuItemDiagnostics_Click(sender, e);
        }

        private void MenuItemHelpContents_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("XpressSHARE Enterprise Guide");
            sb.AppendLine("============================");
            sb.AppendLine();
            sb.AppendLine("• WORKSPACE:");
            sb.AppendLine("  - Home: Host information, online devices, and quick launch buttons.");
            sb.AppendLine("  - Explorer: Dual-pane or single-pane file manager with drag-and-drop.");
            sb.AppendLine("• TRANSFER:");
            sb.AppendLine("  - Send: Queue files and transmit securely over AES-256 encrypted sockets.");
            sb.AppendLine("  - Receive: Review pending incoming transfers, accept or decline.");
            sb.AppendLine("  - Transfers: WebSphere-style pipeline management table.");
            sb.AppendLine("• NETWORK:");
            sb.AppendLine("  - Devices: Discover and pair peer nodes on the LAN.");
            sb.AppendLine("• SYSTEM:");
            sb.AppendLine("  - Settings: Configure network ports, download directory, and visual theme.");

            MessageBox.Show(sb.ToString(), "XpressSHARE Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItemTroubleshooting_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Troubleshooting Guide");
            sb.AppendLine("=====================");
            sb.AppendLine();
            sb.AppendLine("1. Ensure both devices are connected to the same LAN or Wi-Fi network.");
            sb.AppendLine("2. Confirm Windows Firewall permits TCP port 15001 and UDP port 15000.");
            sb.AppendLine("3. Verify that receiving is enabled on the target device.");
            sb.AppendLine("4. If AP isolation is enabled on the Wi-Fi router, connect via Ethernet or standard Wi-Fi.");

            MessageBox.Show(sb.ToString(), "Troubleshooting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItemAboutComputer_Click(object sender, EventArgs e)
        {
            string report = TransferOptimizer.GetDiagnosticReport();
            MessageBox.Show(report, "About This Computer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItemAboutApp_Click(object sender, EventArgs e)
        {
            using (AboutForm about = new AboutForm())
            {
                about.ShowDialog(this);
            }
        }

        #endregion

        #region Tray & Shutdown

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Visible)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }

        private void TrayMenuOpen_Click(object sender, EventArgs e)
        {
            if (!Visible)
            {
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppSettings.Instance.TrayMinimizePreference && e.CloseReason == CloseReason.UserClosing && DialogResult != DialogResult.Retry)
            {
                e.Cancel = true;
                Hide();
                WindowState = FormWindowState.Minimized;
                trayIcon.ShowBalloonTip(2000, "XpressSHARE", "Application minimized to system notification tray.", ToolTipIcon.Info);
                return;
            }

            if (_discoveryService != null) _discoveryService.Stop();
            if (_listenerService != null) _listenerService.Stop();
            trayIcon.Visible = false;
            ThemeManager.ThemeChanged -= OnThemeChanged;
            AppLogger.Log("MainForm closed");
        }

        #endregion

        #region Utility Methods

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

        #endregion
    }
}
