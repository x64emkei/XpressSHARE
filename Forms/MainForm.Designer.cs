namespace XpressShare.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Top Menu
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSendFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSendFolder;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuickSendMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuickClipboard;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuickScreenshot;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuickText;
        private System.Windows.Forms.ToolStripSeparator menuItemFileSep1;
        private System.Windows.Forms.ToolStripMenuItem menuItemPreferences;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
        private System.Windows.Forms.ToolStripSeparator menuItemFileSep2;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;

        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewHome;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewExplorer;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewSend;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewReceive;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewTransfers;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewDevices;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewSettings;
        private System.Windows.Forms.ToolStripSeparator menuItemViewSep1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSinglePane;
        private System.Windows.Forms.ToolStripMenuItem menuItemDualPane;
        private System.Windows.Forms.ToolStripSeparator menuItemViewSep2;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuItemAppearance;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeLight;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeDark;

        private System.Windows.Forms.ToolStripMenuItem menuItemTransfer;
        private System.Windows.Forms.ToolStripMenuItem menuItemPauseTransfer;
        private System.Windows.Forms.ToolStripMenuItem menuItemResumeTransfer;
        private System.Windows.Forms.ToolStripMenuItem menuItemCancelTransfer;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearCompleted;
        private System.Windows.Forms.ToolStripSeparator menuItemTransferSep1;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenDownloadFolder;

        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemDiscover;
        private System.Windows.Forms.ToolStripMenuItem menuItemPairDevice;
        private System.Windows.Forms.ToolStripMenuItem menuItemCheckConn;
        private System.Windows.Forms.ToolStripSeparator menuItemToolsSep1;
        private System.Windows.Forms.ToolStripMenuItem menuItemDiagnostics;
        private System.Windows.Forms.ToolStripMenuItem menuItemOptimization;

        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelpContents;
        private System.Windows.Forms.ToolStripMenuItem menuItemTroubleshooting;
        private System.Windows.Forms.ToolStripSeparator menuItemHelpSep1;
        private System.Windows.Forms.ToolStripMenuItem menuItemAboutComputer;
        private System.Windows.Forms.ToolStripMenuItem menuItemAboutApp;

        // Main Shell Layout
        private System.Windows.Forms.Panel panelMainContainer;

        // Sidebar
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelSidebarBrand;
        private System.Windows.Forms.Panel panelBrandRedAccent;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblBrandSubtitle;
        private System.Windows.Forms.Panel panelSidebarMenu;

        private System.Windows.Forms.Label lblHeaderWorkspace;
        private System.Windows.Forms.Button btnNavHome;
        private System.Windows.Forms.Button btnNavExplorer;

        private System.Windows.Forms.Label lblHeaderTransfer;
        private System.Windows.Forms.Button btnNavSend;
        private System.Windows.Forms.Button btnNavReceive;
        private System.Windows.Forms.Button btnNavTransfers;

        private System.Windows.Forms.Label lblHeaderNetwork;
        private System.Windows.Forms.Button btnNavDevices;

        private System.Windows.Forms.Panel panelSidebarDivider;
        private System.Windows.Forms.Label lblHeaderSystem;
        private System.Windows.Forms.Button btnNavSettings;

        // Workspace Container
        private System.Windows.Forms.Panel panelWorkspaceWrapper;
        private System.Windows.Forms.Panel panelContentContainer;

        // Collapsible Bottom Transfer Drawer
        private System.Windows.Forms.Panel panelTransferDrawer;
        private System.Windows.Forms.Panel panelDrawerHeader;
        private System.Windows.Forms.Label lblDrawerTitle;
        private System.Windows.Forms.Label lblDrawerStatus;
        private System.Windows.Forms.Button btnDrawerToggle;
        private System.Windows.Forms.Panel panelDrawerBody;
        private System.Windows.Forms.ListView listTransferQueue;
        private System.Windows.Forms.ColumnHeader colQueueDir;
        private System.Windows.Forms.ColumnHeader colQueueName;
        private System.Windows.Forms.ColumnHeader colQueuePeer;
        private System.Windows.Forms.ColumnHeader colQueueSize;
        private System.Windows.Forms.ColumnHeader colQueueProgress;
        private System.Windows.Forms.ColumnHeader colQueueSpeed;
        private System.Windows.Forms.ColumnHeader colQueueStatus;
        private System.Windows.Forms.Panel panelDrawerActions;
        private System.Windows.Forms.Button btnQueuePause;
        private System.Windows.Forms.Button btnQueueResume;
        private System.Windows.Forms.Button btnQueueCancel;
        private System.Windows.Forms.Button btnQueueClear;
        private System.Windows.Forms.Button btnQueueOpenFolder;

        // Status Bar
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelState;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelAction;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelConnection;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelSpeed;

        // Notification Tray
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem trayMenuQuickSend;
        private System.Windows.Forms.ToolStripMenuItem trayMenuSettings;
        private System.Windows.Forms.ToolStripSeparator trayMenuSep1;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSendFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuickSendMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuickClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuickScreenshot = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuickText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFileSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewSend = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewReceive = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewTransfers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewDevices = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSinglePane = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDualPane = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAppearance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeLight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeDark = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPauseTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemResumeTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCancelTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransferSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemOpenDownloadFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDiscover = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPairDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCheckConn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemDiagnostics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOptimization = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTroubleshooting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAboutComputer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAboutApp = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.panelWorkspaceWrapper = new System.Windows.Forms.Panel();
            this.panelContentContainer = new System.Windows.Forms.Panel();
            this.panelTransferDrawer = new System.Windows.Forms.Panel();
            this.panelDrawerBody = new System.Windows.Forms.Panel();
            this.listTransferQueue = new System.Windows.Forms.ListView();
            this.colQueueDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueuePeer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDrawerActions = new System.Windows.Forms.Panel();
            this.btnQueueOpenFolder = new System.Windows.Forms.Button();
            this.btnQueueClear = new System.Windows.Forms.Button();
            this.btnQueueCancel = new System.Windows.Forms.Button();
            this.btnQueueResume = new System.Windows.Forms.Button();
            this.btnQueuePause = new System.Windows.Forms.Button();
            this.panelDrawerHeader = new System.Windows.Forms.Panel();
            this.lblDrawerStatus = new System.Windows.Forms.Label();
            this.btnDrawerToggle = new System.Windows.Forms.Button();
            this.lblDrawerTitle = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebarMenu = new System.Windows.Forms.Panel();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.lblHeaderSystem = new System.Windows.Forms.Label();
            this.panelSidebarDivider = new System.Windows.Forms.Panel();
            this.btnNavDevices = new System.Windows.Forms.Button();
            this.lblHeaderNetwork = new System.Windows.Forms.Label();
            this.btnNavTransfers = new System.Windows.Forms.Button();
            this.btnNavReceive = new System.Windows.Forms.Button();
            this.btnNavSend = new System.Windows.Forms.Button();
            this.lblHeaderTransfer = new System.Windows.Forms.Label();
            this.btnNavExplorer = new System.Windows.Forms.Button();
            this.btnNavHome = new System.Windows.Forms.Button();
            this.lblHeaderWorkspace = new System.Windows.Forms.Label();
            this.panelSidebarBrand = new System.Windows.Forms.Panel();
            this.lblBrandSubtitle = new System.Windows.Forms.Label();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.panelBrandRedAccent = new System.Windows.Forms.Panel();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusLabelState = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuQuickSend = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.panelWorkspaceWrapper.SuspendLayout();
            this.panelTransferDrawer.SuspendLayout();
            this.panelDrawerBody.SuspendLayout();
            this.panelDrawerActions.SuspendLayout();
            this.panelDrawerHeader.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarMenu.SuspendLayout();
            this.panelSidebarBrand.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemTransfer,
            this.menuItemTools,
            this.menuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStripMain.Size = new System.Drawing.Size(1160, 24);
            this.menuStripMain.TabIndex = 0;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSendFile,
            this.menuItemSendFolder,
            this.menuItemQuickSendMenu,
            this.menuItemFileSep1,
            this.menuItemPreferences,
            this.menuItemLogout,
            this.menuItemFileSep2,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemSendFile
            // 
            this.menuItemSendFile.Name = "menuItemSendFile";
            this.menuItemSendFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemSendFile.Size = new System.Drawing.Size(176, 22);
            this.menuItemSendFile.Text = "Send &File...";
            this.menuItemSendFile.Click += new System.EventHandler(this.MenuItemSendFile_Click);
            // 
            // menuItemSendFolder
            // 
            this.menuItemSendFolder.Name = "menuItemSendFolder";
            this.menuItemSendFolder.Size = new System.Drawing.Size(176, 22);
            this.menuItemSendFolder.Text = "Send F&older...";
            this.menuItemSendFolder.Click += new System.EventHandler(this.MenuItemSendFolder_Click);
            // 
            // menuItemQuickSendMenu
            // 
            this.menuItemQuickSendMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemQuickClipboard,
            this.menuItemQuickScreenshot,
            this.menuItemQuickText});
            this.menuItemQuickSendMenu.Name = "menuItemQuickSendMenu";
            this.menuItemQuickSendMenu.Size = new System.Drawing.Size(176, 22);
            this.menuItemQuickSendMenu.Text = "&Quick Send";
            // 
            // menuItemQuickClipboard
            // 
            this.menuItemQuickClipboard.Name = "menuItemQuickClipboard";
            this.menuItemQuickClipboard.Size = new System.Drawing.Size(163, 22);
            this.menuItemQuickClipboard.Text = "Send &Clipboard";
            this.menuItemQuickClipboard.Click += new System.EventHandler(this.BtnQuickClipboard_Click);
            // 
            // menuItemQuickScreenshot
            // 
            this.menuItemQuickScreenshot.Name = "menuItemQuickScreenshot";
            this.menuItemQuickScreenshot.Size = new System.Drawing.Size(163, 22);
            this.menuItemQuickScreenshot.Text = "Send &Screenshot";
            this.menuItemQuickScreenshot.Click += new System.EventHandler(this.BtnQuickScreenshot_Click);
            // 
            // menuItemQuickText
            // 
            this.menuItemQuickText.Name = "menuItemQuickText";
            this.menuItemQuickText.Size = new System.Drawing.Size(163, 22);
            this.menuItemQuickText.Text = "Send Quick &Note";
            this.menuItemQuickText.Click += new System.EventHandler(this.BtnQuickText_Click);
            // 
            // menuItemFileSep1
            // 
            this.menuItemFileSep1.Name = "menuItemFileSep1";
            this.menuItemFileSep1.Size = new System.Drawing.Size(173, 6);
            // 
            // menuItemPreferences
            // 
            this.menuItemPreferences.Name = "menuItemPreferences";
            this.menuItemPreferences.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuItemPreferences.Size = new System.Drawing.Size(176, 22);
            this.menuItemPreferences.Text = "&Preferences";
            this.menuItemPreferences.Click += new System.EventHandler(this.MenuItemPreferences_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(176, 22);
            this.menuItemLogout.Text = "&Log Out...";
            this.menuItemLogout.Click += new System.EventHandler(this.MenuItemLogout_Click);
            // 
            // menuItemFileSep2
            // 
            this.menuItemFileSep2.Name = "menuItemFileSep2";
            this.menuItemFileSep2.Size = new System.Drawing.Size(173, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemExit.Size = new System.Drawing.Size(176, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemViewHome,
            this.menuItemViewExplorer,
            this.menuItemViewSend,
            this.menuItemViewReceive,
            this.menuItemViewTransfers,
            this.menuItemViewDevices,
            this.menuItemViewSettings,
            this.menuItemViewSep1,
            this.menuItemSinglePane,
            this.menuItemDualPane,
            this.menuItemViewSep2,
            this.menuItemRefresh,
            this.menuItemAppearance});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(44, 20);
            this.menuItemView.Text = "&View";
            // 
            // menuItemViewHome
            // 
            this.menuItemViewHome.Name = "menuItemViewHome";
            this.menuItemViewHome.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.menuItemViewHome.Size = new System.Drawing.Size(240, 22);
            this.menuItemViewHome.Text = "&Home";
            this.menuItemViewHome.Click += new System.EventHandler(this.BtnNavHome_Click);
            // 
            // menuItemViewExplorer
            // 
            this.menuItemViewExplorer.Name = "menuItemViewExplorer";
            this.menuItemViewExplorer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuItemViewExplorer.Size = new System.Drawing.Size(240, 22);
            this.menuItemViewExplorer.Text = "&Explorer";
            this.menuItemViewExplorer.Click += new System.EventHandler(this.BtnNavExplorer_Click);
            // 
            // menuItemViewSend
            // 
            this.menuItemViewSend.Name = "menuItemViewSend";
            this.menuItemViewSend.Size = new System.Drawing.Size(240, 22);
            this.menuItemViewSend.Text = "&Send";
            this.menuItemViewSend.Click += new System.EventHandler(this.BtnNavSend_Click);
            // 
            // menuItemViewReceive
            // 
            this.menuItemViewReceive.Name = "menuItemViewReceive";
            this.menuItemViewReceive.Size = new System.Drawing.Size(240, 22);
            this.menuItemViewReceive.Text = "&Receive";
            this.menuItemViewReceive.Click += new System.EventHandler(this.BtnNavReceive_Click);
            // 
            // menuItemViewTransfers
            // 
            this.menuItemViewTransfers.Name = "menuItemViewTransfers";
            this.menuItemViewTransfers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuItemViewTransfers.Size = new System.Drawing.Size(240, 22);
            this.menuItemViewTransfers.Text = "&Transfers";
            this.menuItemViewTransfers.Click += new System.EventHandler(this.BtnNavTransfers_Click);
            // 
            // menuItemViewDevices
            // 
            this.menuItemViewDevices.Name = "menuItemViewDevices";
            this.menuItemViewDevices.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuItemViewDevices.Size = new System.Drawing.Size(240, 22);
            this.menuItemViewDevices.Text = "&Devices";
            this.menuItemViewDevices.Click += new System.EventHandler(this.BtnNavDevices_Click);
            // 
            // menuItemViewSettings
            // 
            this.menuItemViewSettings.Name = "menuItemViewSettings";
            this.menuItemViewSettings.Size = new System.Drawing.Size(240, 22);
            this.menuItemViewSettings.Text = "&Settings";
            this.menuItemViewSettings.Click += new System.EventHandler(this.BtnNavSettings_Click);
            // 
            // menuItemViewSep1
            // 
            this.menuItemViewSep1.Name = "menuItemViewSep1";
            this.menuItemViewSep1.Size = new System.Drawing.Size(237, 6);
            // 
            // menuItemSinglePane
            // 
            this.menuItemSinglePane.Checked = true;
            this.menuItemSinglePane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemSinglePane.Name = "menuItemSinglePane";
            this.menuItemSinglePane.Size = new System.Drawing.Size(240, 22);
            this.menuItemSinglePane.Text = "Single Pane (Source Only)";
            this.menuItemSinglePane.Click += new System.EventHandler(this.MenuItemSinglePane_Click);
            // 
            // menuItemDualPane
            // 
            this.menuItemDualPane.Name = "menuItemDualPane";
            this.menuItemDualPane.Size = new System.Drawing.Size(240, 22);
            this.menuItemDualPane.Text = "Dual Pane (Source & Destination)";
            this.menuItemDualPane.Click += new System.EventHandler(this.MenuItemDualPane_Click);
            // 
            // menuItemViewSep2
            // 
            this.menuItemViewSep2.Name = "menuItemViewSep2";
            this.menuItemViewSep2.Size = new System.Drawing.Size(237, 6);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuItemRefresh.Size = new System.Drawing.Size(240, 22);
            this.menuItemRefresh.Text = "&Refresh";
            this.menuItemRefresh.Click += new System.EventHandler(this.BtnNavRefresh_Click);
            // 
            // menuItemAppearance
            // 
            this.menuItemAppearance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemThemeLight,
            this.menuItemThemeDark});
            this.menuItemAppearance.Name = "menuItemAppearance";
            this.menuItemAppearance.Size = new System.Drawing.Size(240, 22);
            this.menuItemAppearance.Text = "&Appearance";
            // 
            // menuItemThemeLight
            // 
            this.menuItemThemeLight.Checked = true;
            this.menuItemThemeLight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemThemeLight.Name = "menuItemThemeLight";
            this.menuItemThemeLight.Size = new System.Drawing.Size(135, 22);
            this.menuItemThemeLight.Text = "&Light Mode";
            this.menuItemThemeLight.Click += new System.EventHandler(this.MenuItemThemeLight_Click);
            // 
            // menuItemThemeDark
            // 
            this.menuItemThemeDark.Name = "menuItemThemeDark";
            this.menuItemThemeDark.Size = new System.Drawing.Size(135, 22);
            this.menuItemThemeDark.Text = "&Dark Mode";
            this.menuItemThemeDark.Click += new System.EventHandler(this.MenuItemThemeDark_Click);
            // 
            // menuItemTransfer
            // 
            this.menuItemTransfer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPauseTransfer,
            this.menuItemResumeTransfer,
            this.menuItemCancelTransfer,
            this.menuItemClearCompleted,
            this.menuItemTransferSep1,
            this.menuItemOpenDownloadFolder});
            this.menuItemTransfer.Name = "menuItemTransfer";
            this.menuItemTransfer.Size = new System.Drawing.Size(66, 20);
            this.menuItemTransfer.Text = "&Transfers";
            // 
            // menuItemPauseTransfer
            // 
            this.menuItemPauseTransfer.Name = "menuItemPauseTransfer";
            this.menuItemPauseTransfer.Size = new System.Drawing.Size(202, 22);
            this.menuItemPauseTransfer.Text = "&Pause Active Transfer";
            this.menuItemPauseTransfer.Click += new System.EventHandler(this.BtnQueuePause_Click);
            // 
            // menuItemResumeTransfer
            // 
            this.menuItemResumeTransfer.Name = "menuItemResumeTransfer";
            this.menuItemResumeTransfer.Size = new System.Drawing.Size(202, 22);
            this.menuItemResumeTransfer.Text = "&Resume Active Transfer";
            this.menuItemResumeTransfer.Click += new System.EventHandler(this.BtnQueueResume_Click);
            // 
            // menuItemCancelTransfer
            // 
            this.menuItemCancelTransfer.Name = "menuItemCancelTransfer";
            this.menuItemCancelTransfer.Size = new System.Drawing.Size(202, 22);
            this.menuItemCancelTransfer.Text = "&Cancel Selected Transfer";
            this.menuItemCancelTransfer.Click += new System.EventHandler(this.BtnQueueCancel_Click);
            // 
            // menuItemClearCompleted
            // 
            this.menuItemClearCompleted.Name = "menuItemClearCompleted";
            this.menuItemClearCompleted.Size = new System.Drawing.Size(202, 22);
            this.menuItemClearCompleted.Text = "C&lear Completed";
            this.menuItemClearCompleted.Click += new System.EventHandler(this.BtnQueueClear_Click);
            // 
            // menuItemTransferSep1
            // 
            this.menuItemTransferSep1.Name = "menuItemTransferSep1";
            this.menuItemTransferSep1.Size = new System.Drawing.Size(199, 6);
            // 
            // menuItemOpenDownloadFolder
            // 
            this.menuItemOpenDownloadFolder.Name = "menuItemOpenDownloadFolder";
            this.menuItemOpenDownloadFolder.Size = new System.Drawing.Size(202, 22);
            this.menuItemOpenDownloadFolder.Text = "&Open Downloads Folder";
            this.menuItemOpenDownloadFolder.Click += new System.EventHandler(this.BtnQueueOpenFolder_Click);
            // 
            // menuItemTools
            // 
            this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDiscover,
            this.menuItemPairDevice,
            this.menuItemCheckConn,
            this.menuItemToolsSep1,
            this.menuItemDiagnostics,
            this.menuItemOptimization});
            this.menuItemTools.Name = "menuItemTools";
            this.menuItemTools.Size = new System.Drawing.Size(47, 20);
            this.menuItemTools.Text = "&Tools";
            // 
            // menuItemDiscover
            // 
            this.menuItemDiscover.Name = "menuItemDiscover";
            this.menuItemDiscover.Size = new System.Drawing.Size(220, 22);
            this.menuItemDiscover.Text = "&Discover Local Devices";
            this.menuItemDiscover.Click += new System.EventHandler(this.BtnDevDiscover_Click);
            // 
            // menuItemPairDevice
            // 
            this.menuItemPairDevice.Name = "menuItemPairDevice";
            this.menuItemPairDevice.Size = new System.Drawing.Size(220, 22);
            this.menuItemPairDevice.Text = "&Pair New Device...";
            this.menuItemPairDevice.Click += new System.EventHandler(this.BtnPairNewDevice_Click);
            // 
            // menuItemCheckConn
            // 
            this.menuItemCheckConn.Name = "menuItemCheckConn";
            this.menuItemCheckConn.Size = new System.Drawing.Size(220, 22);
            this.menuItemCheckConn.Text = "&Check Network Connection";
            this.menuItemCheckConn.Click += new System.EventHandler(this.MenuItemCheckConn_Click);
            // 
            // menuItemToolsSep1
            // 
            this.menuItemToolsSep1.Name = "menuItemToolsSep1";
            this.menuItemToolsSep1.Size = new System.Drawing.Size(217, 6);
            // 
            // menuItemDiagnostics
            // 
            this.menuItemDiagnostics.Name = "menuItemDiagnostics";
            this.menuItemDiagnostics.Size = new System.Drawing.Size(220, 22);
            this.menuItemDiagnostics.Text = "System &Diagnostics...";
            this.menuItemDiagnostics.Click += new System.EventHandler(this.MenuItemDiagnostics_Click);
            // 
            // menuItemOptimization
            // 
            this.menuItemOptimization.Name = "menuItemOptimization";
            this.menuItemOptimization.Size = new System.Drawing.Size(220, 22);
            this.menuItemOptimization.Text = "Transfer &Optimization...";
            this.menuItemOptimization.Click += new System.EventHandler(this.MenuItemOptimization_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelpContents,
            this.menuItemTroubleshooting,
            this.menuItemHelpSep1,
            this.menuItemAboutComputer,
            this.menuItemAboutApp});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemHelpContents
            // 
            this.menuItemHelpContents.Name = "menuItemHelpContents";
            this.menuItemHelpContents.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuItemHelpContents.Size = new System.Drawing.Size(189, 22);
            this.menuItemHelpContents.Text = "&Help Contents";
            this.menuItemHelpContents.Click += new System.EventHandler(this.MenuItemHelpContents_Click);
            // 
            // menuItemTroubleshooting
            // 
            this.menuItemTroubleshooting.Name = "menuItemTroubleshooting";
            this.menuItemTroubleshooting.Size = new System.Drawing.Size(189, 22);
            this.menuItemTroubleshooting.Text = "&Troubleshooting";
            this.menuItemTroubleshooting.Click += new System.EventHandler(this.MenuItemTroubleshooting_Click);
            // 
            // menuItemHelpSep1
            // 
            this.menuItemHelpSep1.Name = "menuItemHelpSep1";
            this.menuItemHelpSep1.Size = new System.Drawing.Size(186, 6);
            // 
            // menuItemAboutComputer
            // 
            this.menuItemAboutComputer.Name = "menuItemAboutComputer";
            this.menuItemAboutComputer.Size = new System.Drawing.Size(189, 22);
            this.menuItemAboutComputer.Text = "About &This Computer";
            this.menuItemAboutComputer.Click += new System.EventHandler(this.MenuItemAboutComputer_Click);
            // 
            // menuItemAboutApp
            // 
            this.menuItemAboutApp.Name = "menuItemAboutApp";
            this.menuItemAboutApp.Size = new System.Drawing.Size(189, 22);
            this.menuItemAboutApp.Text = "&About XpressSHARE";
            this.menuItemAboutApp.Click += new System.EventHandler(this.MenuItemAboutApp_Click);
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.panelWorkspaceWrapper);
            this.panelMainContainer.Controls.Add(this.panelSidebar);
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(0, 24);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(1160, 686);
            this.panelMainContainer.TabIndex = 1;
            // 
            // panelWorkspaceWrapper
            // 
            this.panelWorkspaceWrapper.Controls.Add(this.panelContentContainer);
            this.panelWorkspaceWrapper.Controls.Add(this.panelTransferDrawer);
            this.panelWorkspaceWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkspaceWrapper.Location = new System.Drawing.Point(205, 0);
            this.panelWorkspaceWrapper.Name = "panelWorkspaceWrapper";
            this.panelWorkspaceWrapper.Size = new System.Drawing.Size(955, 686);
            this.panelWorkspaceWrapper.TabIndex = 1;
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.BackColor = System.Drawing.Color.White;
            this.panelContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContentContainer.Name = "panelContentContainer";
            this.panelContentContainer.Size = new System.Drawing.Size(955, 658);
            this.panelContentContainer.TabIndex = 0;
            // 
            // panelTransferDrawer
            // 
            this.panelTransferDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelTransferDrawer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTransferDrawer.Controls.Add(this.panelDrawerBody);
            this.panelTransferDrawer.Controls.Add(this.panelDrawerHeader);
            this.panelTransferDrawer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTransferDrawer.Location = new System.Drawing.Point(0, 658);
            this.panelTransferDrawer.Name = "panelTransferDrawer";
            this.panelTransferDrawer.Size = new System.Drawing.Size(955, 28);
            this.panelTransferDrawer.TabIndex = 1;
            // 
            // panelDrawerBody
            // 
            this.panelDrawerBody.Controls.Add(this.listTransferQueue);
            this.panelDrawerBody.Controls.Add(this.panelDrawerActions);
            this.panelDrawerBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawerBody.Location = new System.Drawing.Point(0, 26);
            this.panelDrawerBody.Name = "panelDrawerBody";
            this.panelDrawerBody.Size = new System.Drawing.Size(953, 0);
            this.panelDrawerBody.TabIndex = 1;
            // 
            // listTransferQueue
            // 
            this.listTransferQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listTransferQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colQueueDir,
            this.colQueueName,
            this.colQueuePeer,
            this.colQueueSize,
            this.colQueueProgress,
            this.colQueueSpeed,
            this.colQueueStatus});
            this.listTransferQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTransferQueue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTransferQueue.FullRowSelect = true;
            this.listTransferQueue.GridLines = true;
            this.listTransferQueue.HideSelection = false;
            this.listTransferQueue.Location = new System.Drawing.Point(0, 0);
            this.listTransferQueue.Name = "listTransferQueue";
            this.listTransferQueue.Size = new System.Drawing.Size(953, 0);
            this.listTransferQueue.TabIndex = 0;
            this.listTransferQueue.UseCompatibleStateImageBehavior = false;
            this.listTransferQueue.View = System.Windows.Forms.View.Details;
            // 
            // colQueueDir
            // 
            this.colQueueDir.Text = "Dir";
            this.colQueueDir.Width = 40;
            // 
            // colQueueName
            // 
            this.colQueueName.Text = "File Name";
            this.colQueueName.Width = 240;
            // 
            // colQueuePeer
            // 
            this.colQueuePeer.Text = "Peer";
            this.colQueuePeer.Width = 140;
            // 
            // colQueueSize
            // 
            this.colQueueSize.Text = "Size";
            this.colQueueSize.Width = 80;
            // 
            // colQueueProgress
            // 
            this.colQueueProgress.Text = "Progress";
            this.colQueueProgress.Width = 80;
            // 
            // colQueueSpeed
            // 
            this.colQueueSpeed.Text = "Rate";
            this.colQueueSpeed.Width = 80;
            // 
            // colQueueStatus
            // 
            this.colQueueStatus.Text = "Status";
            this.colQueueStatus.Width = 90;
            // 
            // panelDrawerActions
            // 
            this.panelDrawerActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.panelDrawerActions.Controls.Add(this.btnQueueOpenFolder);
            this.panelDrawerActions.Controls.Add(this.btnQueueClear);
            this.panelDrawerActions.Controls.Add(this.btnQueueCancel);
            this.panelDrawerActions.Controls.Add(this.btnQueueResume);
            this.panelDrawerActions.Controls.Add(this.btnQueuePause);
            this.panelDrawerActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDrawerActions.Location = new System.Drawing.Point(0, -32);
            this.panelDrawerActions.Name = "panelDrawerActions";
            this.panelDrawerActions.Size = new System.Drawing.Size(953, 32);
            this.panelDrawerActions.TabIndex = 1;
            // 
            // btnQueueOpenFolder
            // 
            this.btnQueueOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQueueOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQueueOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueueOpenFolder.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueueOpenFolder.Location = new System.Drawing.Point(823, 4);
            this.btnQueueOpenFolder.Name = "btnQueueOpenFolder";
            this.btnQueueOpenFolder.Size = new System.Drawing.Size(120, 24);
            this.btnQueueOpenFolder.TabIndex = 4;
            this.btnQueueOpenFolder.Text = "Open Downloads";
            this.btnQueueOpenFolder.UseVisualStyleBackColor = true;
            this.btnQueueOpenFolder.Click += new System.EventHandler(this.BtnQueueOpenFolder_Click);
            // 
            // btnQueueClear
            // 
            this.btnQueueClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQueueClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueueClear.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueueClear.Location = new System.Drawing.Point(212, 4);
            this.btnQueueClear.Name = "btnQueueClear";
            this.btnQueueClear.Size = new System.Drawing.Size(70, 24);
            this.btnQueueClear.TabIndex = 3;
            this.btnQueueClear.Text = "Refresh";
            this.btnQueueClear.UseVisualStyleBackColor = true;
            this.btnQueueClear.Click += new System.EventHandler(this.BtnQueueClear_Click);
            // 
            // btnQueueCancel
            // 
            this.btnQueueCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQueueCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueueCancel.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueueCancel.Location = new System.Drawing.Point(140, 4);
            this.btnQueueCancel.Name = "btnQueueCancel";
            this.btnQueueCancel.Size = new System.Drawing.Size(65, 24);
            this.btnQueueCancel.TabIndex = 2;
            this.btnQueueCancel.Text = "Cancel";
            this.btnQueueCancel.UseVisualStyleBackColor = true;
            this.btnQueueCancel.Click += new System.EventHandler(this.BtnQueueCancel_Click);
            // 
            // btnQueueResume
            // 
            this.btnQueueResume.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQueueResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueueResume.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueueResume.Location = new System.Drawing.Point(72, 4);
            this.btnQueueResume.Name = "btnQueueResume";
            this.btnQueueResume.Size = new System.Drawing.Size(62, 24);
            this.btnQueueResume.TabIndex = 1;
            this.btnQueueResume.Text = "Resume";
            this.btnQueueResume.UseVisualStyleBackColor = true;
            this.btnQueueResume.Click += new System.EventHandler(this.BtnQueueResume_Click);
            // 
            // btnQueuePause
            // 
            this.btnQueuePause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQueuePause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueuePause.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueuePause.Location = new System.Drawing.Point(4, 4);
            this.btnQueuePause.Name = "btnQueuePause";
            this.btnQueuePause.Size = new System.Drawing.Size(62, 24);
            this.btnQueuePause.TabIndex = 0;
            this.btnQueuePause.Text = "Pause";
            this.btnQueuePause.UseVisualStyleBackColor = true;
            this.btnQueuePause.Click += new System.EventHandler(this.BtnQueuePause_Click);
            // 
            // panelDrawerHeader
            // 
            this.panelDrawerHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.panelDrawerHeader.Controls.Add(this.lblDrawerStatus);
            this.panelDrawerHeader.Controls.Add(this.btnDrawerToggle);
            this.panelDrawerHeader.Controls.Add(this.lblDrawerTitle);
            this.panelDrawerHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelDrawerHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDrawerHeader.Location = new System.Drawing.Point(0, 0);
            this.panelDrawerHeader.Name = "panelDrawerHeader";
            this.panelDrawerHeader.Size = new System.Drawing.Size(953, 26);
            this.panelDrawerHeader.TabIndex = 0;
            this.panelDrawerHeader.Click += new System.EventHandler(this.BtnDrawerToggle_Click);
            // 
            // lblDrawerStatus
            // 
            this.lblDrawerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDrawerStatus.AutoSize = true;
            this.lblDrawerStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawerStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblDrawerStatus.Location = new System.Drawing.Point(740, 6);
            this.lblDrawerStatus.Name = "lblDrawerStatus";
            this.lblDrawerStatus.Size = new System.Drawing.Size(123, 13);
            this.lblDrawerStatus.TabIndex = 2;
            this.lblDrawerStatus.Text = "Idle • 0 Active Transfers";
            // 
            // btnDrawerToggle
            // 
            this.btnDrawerToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawerToggle.FlatAppearance.BorderSize = 0;
            this.btnDrawerToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawerToggle.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawerToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.btnDrawerToggle.Location = new System.Drawing.Point(920, 2);
            this.btnDrawerToggle.Name = "btnDrawerToggle";
            this.btnDrawerToggle.Size = new System.Drawing.Size(25, 21);
            this.btnDrawerToggle.TabIndex = 1;
            this.btnDrawerToggle.Text = "▲";
            this.btnDrawerToggle.UseVisualStyleBackColor = true;
            this.btnDrawerToggle.Click += new System.EventHandler(this.BtnDrawerToggle_Click);
            // 
            // lblDrawerTitle
            // 
            this.lblDrawerTitle.AutoSize = true;
            this.lblDrawerTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblDrawerTitle.Location = new System.Drawing.Point(8, 6);
            this.lblDrawerTitle.Name = "lblDrawerTitle";
            this.lblDrawerTitle.Size = new System.Drawing.Size(131, 13);
            this.lblDrawerTitle.TabIndex = 0;
            this.lblDrawerTitle.Text = "Quick Transfers Monitor";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.panelSidebar.Controls.Add(this.panelSidebarMenu);
            this.panelSidebar.Controls.Add(this.panelSidebarBrand);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(205, 686);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelSidebarMenu
            // 
            this.panelSidebarMenu.AutoScroll = true;
            this.panelSidebarMenu.Controls.Add(this.btnNavSettings);
            this.panelSidebarMenu.Controls.Add(this.lblHeaderSystem);
            this.panelSidebarMenu.Controls.Add(this.panelSidebarDivider);
            this.panelSidebarMenu.Controls.Add(this.btnNavDevices);
            this.panelSidebarMenu.Controls.Add(this.lblHeaderNetwork);
            this.panelSidebarMenu.Controls.Add(this.btnNavTransfers);
            this.panelSidebarMenu.Controls.Add(this.btnNavReceive);
            this.panelSidebarMenu.Controls.Add(this.btnNavSend);
            this.panelSidebarMenu.Controls.Add(this.lblHeaderTransfer);
            this.panelSidebarMenu.Controls.Add(this.btnNavExplorer);
            this.panelSidebarMenu.Controls.Add(this.btnNavHome);
            this.panelSidebarMenu.Controls.Add(this.lblHeaderWorkspace);
            this.panelSidebarMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebarMenu.Location = new System.Drawing.Point(0, 54);
            this.panelSidebarMenu.Name = "panelSidebarMenu";
            this.panelSidebarMenu.Padding = new System.Windows.Forms.Padding(0, 6, 0, 12);
            this.panelSidebarMenu.Size = new System.Drawing.Size(205, 632);
            this.panelSidebarMenu.TabIndex = 1;
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavSettings.FlatAppearance.BorderSize = 0;
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnNavSettings.Location = new System.Drawing.Point(0, 342);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNavSettings.Size = new System.Drawing.Size(205, 36);
            this.btnNavSettings.TabIndex = 11;
            this.btnNavSettings.Text = "Settings";
            this.btnNavSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSettings.UseVisualStyleBackColor = true;
            this.btnNavSettings.Click += new System.EventHandler(this.BtnNavSettings_Click);
            // 
            // lblHeaderSystem
            // 
            this.lblHeaderSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderSystem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(166)))), ((int)(((byte)(173)))));
            this.lblHeaderSystem.Location = new System.Drawing.Point(0, 314);
            this.lblHeaderSystem.Name = "lblHeaderSystem";
            this.lblHeaderSystem.Padding = new System.Windows.Forms.Padding(18, 8, 0, 2);
            this.lblHeaderSystem.Size = new System.Drawing.Size(205, 28);
            this.lblHeaderSystem.TabIndex = 10;
            this.lblHeaderSystem.Text = "SYSTEM";
            // 
            // panelSidebarDivider
            // 
            this.panelSidebarDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.panelSidebarDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarDivider.Location = new System.Drawing.Point(0, 306);
            this.panelSidebarDivider.Name = "panelSidebarDivider";
            this.panelSidebarDivider.Size = new System.Drawing.Size(205, 8);
            this.panelSidebarDivider.TabIndex = 9;
            // 
            // btnNavDevices
            // 
            this.btnNavDevices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDevices.FlatAppearance.BorderSize = 0;
            this.btnNavDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDevices.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDevices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnNavDevices.Location = new System.Drawing.Point(0, 270);
            this.btnNavDevices.Name = "btnNavDevices";
            this.btnNavDevices.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNavDevices.Size = new System.Drawing.Size(205, 36);
            this.btnNavDevices.TabIndex = 8;
            this.btnNavDevices.Text = "Devices";
            this.btnNavDevices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDevices.UseVisualStyleBackColor = true;
            this.btnNavDevices.Click += new System.EventHandler(this.BtnNavDevices_Click);
            // 
            // lblHeaderNetwork
            // 
            this.lblHeaderNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderNetwork.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderNetwork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(166)))), ((int)(((byte)(173)))));
            this.lblHeaderNetwork.Location = new System.Drawing.Point(0, 242);
            this.lblHeaderNetwork.Name = "lblHeaderNetwork";
            this.lblHeaderNetwork.Padding = new System.Windows.Forms.Padding(18, 8, 0, 2);
            this.lblHeaderNetwork.Size = new System.Drawing.Size(205, 28);
            this.lblHeaderNetwork.TabIndex = 7;
            this.lblHeaderNetwork.Text = "NETWORK";
            // 
            // btnNavTransfers
            // 
            this.btnNavTransfers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTransfers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavTransfers.FlatAppearance.BorderSize = 0;
            this.btnNavTransfers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTransfers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavTransfers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnNavTransfers.Location = new System.Drawing.Point(0, 206);
            this.btnNavTransfers.Name = "btnNavTransfers";
            this.btnNavTransfers.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNavTransfers.Size = new System.Drawing.Size(205, 36);
            this.btnNavTransfers.TabIndex = 6;
            this.btnNavTransfers.Text = "Transfers";
            this.btnNavTransfers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTransfers.UseVisualStyleBackColor = true;
            this.btnNavTransfers.Click += new System.EventHandler(this.BtnNavTransfers_Click);
            // 
            // btnNavReceive
            // 
            this.btnNavReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavReceive.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavReceive.FlatAppearance.BorderSize = 0;
            this.btnNavReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReceive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnNavReceive.Location = new System.Drawing.Point(0, 170);
            this.btnNavReceive.Name = "btnNavReceive";
            this.btnNavReceive.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNavReceive.Size = new System.Drawing.Size(205, 36);
            this.btnNavReceive.TabIndex = 5;
            this.btnNavReceive.Text = "Receive";
            this.btnNavReceive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavReceive.UseVisualStyleBackColor = true;
            this.btnNavReceive.Click += new System.EventHandler(this.BtnNavReceive_Click);
            // 
            // btnNavSend
            // 
            this.btnNavSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavSend.FlatAppearance.BorderSize = 0;
            this.btnNavSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnNavSend.Location = new System.Drawing.Point(0, 134);
            this.btnNavSend.Name = "btnNavSend";
            this.btnNavSend.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNavSend.Size = new System.Drawing.Size(205, 36);
            this.btnNavSend.TabIndex = 4;
            this.btnNavSend.Text = "Send";
            this.btnNavSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSend.UseVisualStyleBackColor = true;
            this.btnNavSend.Click += new System.EventHandler(this.BtnNavSend_Click);
            // 
            // lblHeaderTransfer
            // 
            this.lblHeaderTransfer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderTransfer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(166)))), ((int)(((byte)(173)))));
            this.lblHeaderTransfer.Location = new System.Drawing.Point(0, 106);
            this.lblHeaderTransfer.Name = "lblHeaderTransfer";
            this.lblHeaderTransfer.Padding = new System.Windows.Forms.Padding(18, 8, 0, 2);
            this.lblHeaderTransfer.Size = new System.Drawing.Size(205, 28);
            this.lblHeaderTransfer.TabIndex = 3;
            this.lblHeaderTransfer.Text = "TRANSFER";
            // 
            // btnNavExplorer
            // 
            this.btnNavExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavExplorer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavExplorer.FlatAppearance.BorderSize = 0;
            this.btnNavExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavExplorer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnNavExplorer.Location = new System.Drawing.Point(0, 70);
            this.btnNavExplorer.Name = "btnNavExplorer";
            this.btnNavExplorer.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNavExplorer.Size = new System.Drawing.Size(205, 36);
            this.btnNavExplorer.TabIndex = 2;
            this.btnNavExplorer.Text = "Explorer";
            this.btnNavExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavExplorer.UseVisualStyleBackColor = true;
            this.btnNavExplorer.Click += new System.EventHandler(this.BtnNavExplorer_Click);
            // 
            // btnNavHome
            // 
            this.btnNavHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavHome.FlatAppearance.BorderSize = 0;
            this.btnNavHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnNavHome.Location = new System.Drawing.Point(0, 34);
            this.btnNavHome.Name = "btnNavHome";
            this.btnNavHome.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNavHome.Size = new System.Drawing.Size(205, 36);
            this.btnNavHome.TabIndex = 1;
            this.btnNavHome.Text = "Home";
            this.btnNavHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavHome.UseVisualStyleBackColor = true;
            this.btnNavHome.Click += new System.EventHandler(this.BtnNavHome_Click);
            // 
            // lblHeaderWorkspace
            // 
            this.lblHeaderWorkspace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderWorkspace.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderWorkspace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(166)))), ((int)(((byte)(173)))));
            this.lblHeaderWorkspace.Location = new System.Drawing.Point(0, 6);
            this.lblHeaderWorkspace.Name = "lblHeaderWorkspace";
            this.lblHeaderWorkspace.Padding = new System.Windows.Forms.Padding(18, 8, 0, 2);
            this.lblHeaderWorkspace.Size = new System.Drawing.Size(205, 28);
            this.lblHeaderWorkspace.TabIndex = 0;
            this.lblHeaderWorkspace.Text = "WORKSPACE";
            // 
            // panelSidebarBrand
            // 
            this.panelSidebarBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.panelSidebarBrand.Controls.Add(this.lblBrandSubtitle);
            this.panelSidebarBrand.Controls.Add(this.lblBrandName);
            this.panelSidebarBrand.Controls.Add(this.panelBrandRedAccent);
            this.panelSidebarBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarBrand.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarBrand.Name = "panelSidebarBrand";
            this.panelSidebarBrand.Size = new System.Drawing.Size(205, 54);
            this.panelSidebarBrand.TabIndex = 0;
            // 
            // lblBrandSubtitle
            // 
            this.lblBrandSubtitle.AutoSize = true;
            this.lblBrandSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.lblBrandSubtitle.Location = new System.Drawing.Point(14, 30);
            this.lblBrandSubtitle.Name = "lblBrandSubtitle";
            this.lblBrandSubtitle.Size = new System.Drawing.Size(93, 12);
            this.lblBrandSubtitle.TabIndex = 2;
            this.lblBrandSubtitle.Text = "P2P Transfer && Sync";
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandName.ForeColor = System.Drawing.Color.White;
            this.lblBrandName.Location = new System.Drawing.Point(12, 8);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(110, 21);
            this.lblBrandName.TabIndex = 1;
            this.lblBrandName.Text = "XpressSHARE";
            // 
            // panelBrandRedAccent
            // 
            this.panelBrandRedAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelBrandRedAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBrandRedAccent.Location = new System.Drawing.Point(0, 0);
            this.panelBrandRedAccent.Name = "panelBrandRedAccent";
            this.panelBrandRedAccent.Size = new System.Drawing.Size(4, 54);
            this.panelBrandRedAccent.TabIndex = 0;
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelState,
            this.statusLabelAction,
            this.statusLabelConnection,
            this.statusLabelSpeed});
            this.statusStripMain.Location = new System.Drawing.Point(0, 710);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1160, 22);
            this.statusStripMain.TabIndex = 2;
            // 
            // statusLabelState
            // 
            this.statusLabelState.Name = "statusLabelState";
            this.statusLabelState.Size = new System.Drawing.Size(39, 17);
            this.statusLabelState.Text = "Ready";
            // 
            // statusLabelAction
            // 
            this.statusLabelAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.statusLabelAction.Name = "statusLabelAction";
            this.statusLabelAction.Size = new System.Drawing.Size(941, 17);
            this.statusLabelAction.Spring = true;
            this.statusLabelAction.Text = "XpressSHARE Enterprise Ready";
            this.statusLabelAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabelConnection
            // 
            this.statusLabelConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.statusLabelConnection.Name = "statusLabelConnection";
            this.statusLabelConnection.Size = new System.Drawing.Size(130, 17);
            this.statusLabelConnection.Text = "● Connected • Ethernet";
            // 
            // statusLabelSpeed
            // 
            this.statusLabelSpeed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabelSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.statusLabelSpeed.Name = "statusLabelSpeed";
            this.statusLabelSpeed.Size = new System.Drawing.Size(35, 17);
            this.statusLabelSpeed.Text = "0 B/s";
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Text = "XpressSHARE";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuOpen,
            this.trayMenuQuickSend,
            this.trayMenuSettings,
            this.trayMenuSep1,
            this.trayMenuExit});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(183, 98);
            // 
            // trayMenuOpen
            // 
            this.trayMenuOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trayMenuOpen.Name = "trayMenuOpen";
            this.trayMenuOpen.Size = new System.Drawing.Size(182, 22);
            this.trayMenuOpen.Text = "Open XpressSHARE";
            this.trayMenuOpen.Click += new System.EventHandler(this.TrayMenuOpen_Click);
            // 
            // trayMenuQuickSend
            // 
            this.trayMenuQuickSend.Name = "trayMenuQuickSend";
            this.trayMenuQuickSend.Size = new System.Drawing.Size(182, 22);
            this.trayMenuQuickSend.Text = "Quick Send...";
            this.trayMenuQuickSend.Click += new System.EventHandler(this.MenuItemSendFile_Click);
            // 
            // trayMenuSettings
            // 
            this.trayMenuSettings.Name = "trayMenuSettings";
            this.trayMenuSettings.Size = new System.Drawing.Size(182, 22);
            this.trayMenuSettings.Text = "Settings...";
            this.trayMenuSettings.Click += new System.EventHandler(this.MenuItemPreferences_Click);
            // 
            // trayMenuSep1
            // 
            this.trayMenuSep1.Name = "trayMenuSep1";
            this.trayMenuSep1.Size = new System.Drawing.Size(179, 6);
            // 
            // trayMenuExit
            // 
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(182, 22);
            this.trayMenuExit.Text = "Exit";
            this.trayMenuExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1160, 732);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XpressSHARE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panelMainContainer.ResumeLayout(false);
            this.panelWorkspaceWrapper.ResumeLayout(false);
            this.panelTransferDrawer.ResumeLayout(false);
            this.panelDrawerBody.ResumeLayout(false);
            this.panelDrawerActions.ResumeLayout(false);
            this.panelDrawerHeader.ResumeLayout(false);
            this.panelDrawerHeader.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebarMenu.ResumeLayout(false);
            this.panelSidebarBrand.ResumeLayout(false);
            this.panelSidebarBrand.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
