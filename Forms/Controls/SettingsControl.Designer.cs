namespace XpressShare.Forms.Controls
{
    partial class SettingsControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelAccent;

        private System.Windows.Forms.TabControl tabSettings;

        // General Tab
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox groupGeneralStorage;
        private System.Windows.Forms.Label lblDownloadPath;
        private System.Windows.Forms.TextBox txtDownloadPath;
        private System.Windows.Forms.Button btnBrowseDownload;
        private System.Windows.Forms.GroupBox groupGeneralBehavior;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;

        // Transfers Tab
        private System.Windows.Forms.TabPage tabTransfers;
        private System.Windows.Forms.GroupBox groupTransferOptions;
        private System.Windows.Forms.CheckBox chkOptimizeTransfers;
        private System.Windows.Forms.CheckBox chkAutoAccept;
        private System.Windows.Forms.CheckBox chkRetryDisconnects;
        private System.Windows.Forms.Label lblMaxConcurrent;
        private System.Windows.Forms.NumericUpDown numMaxConcurrent;

        // Network Tab
        private System.Windows.Forms.TabPage tabNetwork;
        private System.Windows.Forms.GroupBox groupNetworkPorts;
        private System.Windows.Forms.Label lblUdpPort;
        private System.Windows.Forms.NumericUpDown numUdpPort;
        private System.Windows.Forms.Label lblTcpPort;
        private System.Windows.Forms.NumericUpDown numTcpPort;
        private System.Windows.Forms.Label lblInterface;
        private System.Windows.Forms.ComboBox cboInterface;

        // Security Tab
        private System.Windows.Forms.TabPage tabSecurity;
        private System.Windows.Forms.GroupBox groupSecurityOptions;
        private System.Windows.Forms.CheckBox chkRememberPaired;
        private System.Windows.Forms.Button btnRevokePaired;

        // Appearance Tab
        private System.Windows.Forms.TabPage tabAppearance;
        private System.Windows.Forms.GroupBox groupTheme;
        private System.Windows.Forms.RadioButton rbThemeLight;
        private System.Windows.Forms.RadioButton rbThemeDark;
        private System.Windows.Forms.GroupBox groupDensity;
        private System.Windows.Forms.RadioButton rbDensityCompact;
        private System.Windows.Forms.RadioButton rbDensityStandard;
        private System.Windows.Forms.RadioButton rbDensityComfortable;

        // Footer Actions
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnResetDefaults;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelAccent = new System.Windows.Forms.Panel();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupGeneralBehavior = new System.Windows.Forms.GroupBox();
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.groupGeneralStorage = new System.Windows.Forms.GroupBox();
            this.btnBrowseDownload = new System.Windows.Forms.Button();
            this.txtDownloadPath = new System.Windows.Forms.TextBox();
            this.lblDownloadPath = new System.Windows.Forms.Label();
            this.tabTransfers = new System.Windows.Forms.TabPage();
            this.groupTransferOptions = new System.Windows.Forms.GroupBox();
            this.numMaxConcurrent = new System.Windows.Forms.NumericUpDown();
            this.lblMaxConcurrent = new System.Windows.Forms.Label();
            this.chkRetryDisconnects = new System.Windows.Forms.CheckBox();
            this.chkAutoAccept = new System.Windows.Forms.CheckBox();
            this.chkOptimizeTransfers = new System.Windows.Forms.CheckBox();
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.groupNetworkPorts = new System.Windows.Forms.GroupBox();
            this.cboInterface = new System.Windows.Forms.ComboBox();
            this.lblInterface = new System.Windows.Forms.Label();
            this.numTcpPort = new System.Windows.Forms.NumericUpDown();
            this.lblTcpPort = new System.Windows.Forms.Label();
            this.numUdpPort = new System.Windows.Forms.NumericUpDown();
            this.lblUdpPort = new System.Windows.Forms.Label();
            this.tabSecurity = new System.Windows.Forms.TabPage();
            this.groupSecurityOptions = new System.Windows.Forms.GroupBox();
            this.btnRevokePaired = new System.Windows.Forms.Button();
            this.chkRememberPaired = new System.Windows.Forms.CheckBox();
            this.tabAppearance = new System.Windows.Forms.TabPage();
            this.groupDensity = new System.Windows.Forms.GroupBox();
            this.rbDensityComfortable = new System.Windows.Forms.RadioButton();
            this.rbDensityStandard = new System.Windows.Forms.RadioButton();
            this.rbDensityCompact = new System.Windows.Forms.RadioButton();
            this.groupTheme = new System.Windows.Forms.GroupBox();
            this.rbThemeDark = new System.Windows.Forms.RadioButton();
            this.rbThemeLight = new System.Windows.Forms.RadioButton();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnResetDefaults = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupGeneralBehavior.SuspendLayout();
            this.groupGeneralStorage.SuspendLayout();
            this.tabTransfers.SuspendLayout();
            this.groupTransferOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConcurrent)).BeginInit();
            this.tabNetwork.SuspendLayout();
            this.groupNetworkPorts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTcpPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdpPort)).BeginInit();
            this.tabSecurity.SuspendLayout();
            this.groupSecurityOptions.SuspendLayout();
            this.tabAppearance.SuspendLayout();
            this.groupDensity.SuspendLayout();
            this.groupTheme.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.panelAccent);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 54);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblTitle.Location = new System.Drawing.Point(14, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Settings";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblSubtitle.Location = new System.Drawing.Point(15, 31);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(370, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Configure default folders, network ports, transfer policy, and appearance";
            // 
            // panelAccent
            // 
            this.panelAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAccent.Location = new System.Drawing.Point(0, 0);
            this.panelAccent.Name = "panelAccent";
            this.panelAccent.Size = new System.Drawing.Size(4, 54);
            this.panelAccent.TabIndex = 2;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabGeneral);
            this.tabSettings.Controls.Add(this.tabTransfers);
            this.tabSettings.Controls.Add(this.tabNetwork);
            this.tabSettings.Controls.Add(this.tabSecurity);
            this.tabSettings.Controls.Add(this.tabAppearance);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSettings.Location = new System.Drawing.Point(0, 54);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Drawing.Point(12, 6);
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(950, 516);
            this.tabSettings.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.White;
            this.tabGeneral.Controls.Add(this.groupGeneralBehavior);
            this.tabGeneral.Controls.Add(this.groupGeneralStorage);
            this.tabGeneral.Location = new System.Drawing.Point(4, 28);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(12);
            this.tabGeneral.Size = new System.Drawing.Size(942, 484);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // groupGeneralBehavior
            // 
            this.groupGeneralBehavior.Controls.Add(this.chkMinimizeToTray);
            this.groupGeneralBehavior.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupGeneralBehavior.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupGeneralBehavior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupGeneralBehavior.Location = new System.Drawing.Point(12, 112);
            this.groupGeneralBehavior.Name = "groupGeneralBehavior";
            this.groupGeneralBehavior.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupGeneralBehavior.Size = new System.Drawing.Size(918, 90);
            this.groupGeneralBehavior.TabIndex = 1;
            this.groupGeneralBehavior.TabStop = false;
            this.groupGeneralBehavior.Text = "Window & System Behavior";
            // 
            // chkMinimizeToTray
            // 
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMinimizeToTray.Location = new System.Drawing.Point(15, 34);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.Size = new System.Drawing.Size(269, 17);
            this.chkMinimizeToTray.TabIndex = 0;
            this.chkMinimizeToTray.Text = "Minimize to system notification tray when closed";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // groupGeneralStorage
            // 
            this.groupGeneralStorage.Controls.Add(this.btnBrowseDownload);
            this.groupGeneralStorage.Controls.Add(this.txtDownloadPath);
            this.groupGeneralStorage.Controls.Add(this.lblDownloadPath);
            this.groupGeneralStorage.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupGeneralStorage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupGeneralStorage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupGeneralStorage.Location = new System.Drawing.Point(12, 12);
            this.groupGeneralStorage.Name = "groupGeneralStorage";
            this.groupGeneralStorage.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupGeneralStorage.Size = new System.Drawing.Size(918, 100);
            this.groupGeneralStorage.TabIndex = 0;
            this.groupGeneralStorage.TabStop = false;
            this.groupGeneralStorage.Text = "Default Storage Path";
            // 
            // btnBrowseDownload
            // 
            this.btnBrowseDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDownload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnBrowseDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDownload.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDownload.Location = new System.Drawing.Point(825, 48);
            this.btnBrowseDownload.Name = "btnBrowseDownload";
            this.btnBrowseDownload.Size = new System.Drawing.Size(75, 24);
            this.btnBrowseDownload.TabIndex = 2;
            this.btnBrowseDownload.Text = "Browse...";
            this.btnBrowseDownload.UseVisualStyleBackColor = true;
            this.btnBrowseDownload.Click += new System.EventHandler(this.BtnBrowseDownload_Click);
            // 
            // txtDownloadPath
            // 
            this.txtDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadPath.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownloadPath.Location = new System.Drawing.Point(15, 49);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.Size = new System.Drawing.Size(804, 23);
            this.txtDownloadPath.TabIndex = 1;
            // 
            // lblDownloadPath
            // 
            this.lblDownloadPath.AutoSize = true;
            this.lblDownloadPath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblDownloadPath.Location = new System.Drawing.Point(12, 28);
            this.lblDownloadPath.Name = "lblDownloadPath";
            this.lblDownloadPath.Size = new System.Drawing.Size(126, 13);
            this.lblDownloadPath.TabIndex = 0;
            this.lblDownloadPath.Text = "Default Download Path:";
            // 
            // tabTransfers
            // 
            this.tabTransfers.BackColor = System.Drawing.Color.White;
            this.tabTransfers.Controls.Add(this.groupTransferOptions);
            this.tabTransfers.Location = new System.Drawing.Point(4, 28);
            this.tabTransfers.Name = "tabTransfers";
            this.tabTransfers.Padding = new System.Windows.Forms.Padding(12);
            this.tabTransfers.Size = new System.Drawing.Size(942, 484);
            this.tabTransfers.TabIndex = 1;
            this.tabTransfers.Text = "Transfers";
            // 
            // groupTransferOptions
            // 
            this.groupTransferOptions.Controls.Add(this.numMaxConcurrent);
            this.groupTransferOptions.Controls.Add(this.lblMaxConcurrent);
            this.groupTransferOptions.Controls.Add(this.chkRetryDisconnects);
            this.groupTransferOptions.Controls.Add(this.chkAutoAccept);
            this.groupTransferOptions.Controls.Add(this.chkOptimizeTransfers);
            this.groupTransferOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupTransferOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTransferOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupTransferOptions.Location = new System.Drawing.Point(12, 12);
            this.groupTransferOptions.Name = "groupTransferOptions";
            this.groupTransferOptions.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupTransferOptions.Size = new System.Drawing.Size(918, 190);
            this.groupTransferOptions.TabIndex = 0;
            this.groupTransferOptions.TabStop = false;
            this.groupTransferOptions.Text = "Transfer Behavior";
            // 
            // numMaxConcurrent
            // 
            this.numMaxConcurrent.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxConcurrent.Location = new System.Drawing.Point(180, 137);
            this.numMaxConcurrent.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMaxConcurrent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxConcurrent.Name = "numMaxConcurrent";
            this.numMaxConcurrent.Size = new System.Drawing.Size(65, 22);
            this.numMaxConcurrent.TabIndex = 4;
            this.numMaxConcurrent.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblMaxConcurrent
            // 
            this.lblMaxConcurrent.AutoSize = true;
            this.lblMaxConcurrent.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxConcurrent.Location = new System.Drawing.Point(12, 141);
            this.lblMaxConcurrent.Name = "lblMaxConcurrent";
            this.lblMaxConcurrent.Size = new System.Drawing.Size(147, 13);
            this.lblMaxConcurrent.TabIndex = 3;
            this.lblMaxConcurrent.Text = "Max Concurrent Transfers:";
            // 
            // chkRetryDisconnects
            // 
            this.chkRetryDisconnects.AutoSize = true;
            this.chkRetryDisconnects.Checked = true;
            this.chkRetryDisconnects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRetryDisconnects.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetryDisconnects.Location = new System.Drawing.Point(15, 98);
            this.chkRetryDisconnects.Name = "chkRetryDisconnects";
            this.chkRetryDisconnects.Size = new System.Drawing.Size(262, 17);
            this.chkRetryDisconnects.TabIndex = 2;
            this.chkRetryDisconnects.Text = "Automatically retry temporary disconnects";
            this.chkRetryDisconnects.UseVisualStyleBackColor = true;
            // 
            // chkAutoAccept
            // 
            this.chkAutoAccept.AutoSize = true;
            this.chkAutoAccept.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoAccept.Location = new System.Drawing.Point(15, 65);
            this.chkAutoAccept.Name = "chkAutoAccept";
            this.chkAutoAccept.Size = new System.Drawing.Size(268, 17);
            this.chkAutoAccept.TabIndex = 1;
            this.chkAutoAccept.Text = "Automatically accept files from paired devices";
            this.chkAutoAccept.UseVisualStyleBackColor = true;
            // 
            // chkOptimizeTransfers
            // 
            this.chkOptimizeTransfers.AutoSize = true;
            this.chkOptimizeTransfers.Checked = true;
            this.chkOptimizeTransfers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOptimizeTransfers.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOptimizeTransfers.Location = new System.Drawing.Point(15, 32);
            this.chkOptimizeTransfers.Name = "chkOptimizeTransfers";
            this.chkOptimizeTransfers.Size = new System.Drawing.Size(277, 17);
            this.chkOptimizeTransfers.TabIndex = 0;
            this.chkOptimizeTransfers.Text = "Optimize socket buffers and TCP flow automatically";
            this.chkOptimizeTransfers.UseVisualStyleBackColor = true;
            // 
            // tabNetwork
            // 
            this.tabNetwork.BackColor = System.Drawing.Color.White;
            this.tabNetwork.Controls.Add(this.groupNetworkPorts);
            this.tabNetwork.Location = new System.Drawing.Point(4, 28);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Padding = new System.Windows.Forms.Padding(12);
            this.tabNetwork.Size = new System.Drawing.Size(942, 484);
            this.tabNetwork.TabIndex = 2;
            this.tabNetwork.Text = "Network";
            // 
            // groupNetworkPorts
            // 
            this.groupNetworkPorts.Controls.Add(this.cboInterface);
            this.groupNetworkPorts.Controls.Add(this.lblInterface);
            this.groupNetworkPorts.Controls.Add(this.numTcpPort);
            this.groupNetworkPorts.Controls.Add(this.lblTcpPort);
            this.groupNetworkPorts.Controls.Add(this.numUdpPort);
            this.groupNetworkPorts.Controls.Add(this.lblUdpPort);
            this.groupNetworkPorts.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupNetworkPorts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNetworkPorts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupNetworkPorts.Location = new System.Drawing.Point(12, 12);
            this.groupNetworkPorts.Name = "groupNetworkPorts";
            this.groupNetworkPorts.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupNetworkPorts.Size = new System.Drawing.Size(918, 175);
            this.groupNetworkPorts.TabIndex = 0;
            this.groupNetworkPorts.TabStop = false;
            this.groupNetworkPorts.Text = "Ports & Interface Binding";
            // 
            // cboInterface
            // 
            this.cboInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterface.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInterface.FormattingEnabled = true;
            this.cboInterface.Items.AddRange(new object[] {
            "All Active Adapters (Auto)",
            "Ethernet Only",
            "Wi-Fi Only"});
            this.cboInterface.Location = new System.Drawing.Point(170, 115);
            this.cboInterface.Name = "cboInterface";
            this.cboInterface.Size = new System.Drawing.Size(210, 21);
            this.cboInterface.TabIndex = 5;
            // 
            // lblInterface
            // 
            this.lblInterface.AutoSize = true;
            this.lblInterface.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterface.Location = new System.Drawing.Point(15, 118);
            this.lblInterface.Name = "lblInterface";
            this.lblInterface.Size = new System.Drawing.Size(107, 13);
            this.lblInterface.TabIndex = 4;
            this.lblInterface.Text = "Preferred Interface:";
            // 
            // numTcpPort
            // 
            this.numTcpPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTcpPort.Location = new System.Drawing.Point(170, 75);
            this.numTcpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numTcpPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numTcpPort.Name = "numTcpPort";
            this.numTcpPort.Size = new System.Drawing.Size(95, 22);
            this.numTcpPort.TabIndex = 3;
            this.numTcpPort.Value = new decimal(new int[] {
            15001,
            0,
            0,
            0});
            // 
            // lblTcpPort
            // 
            this.lblTcpPort.AutoSize = true;
            this.lblTcpPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTcpPort.Location = new System.Drawing.Point(15, 77);
            this.lblTcpPort.Name = "lblTcpPort";
            this.lblTcpPort.Size = new System.Drawing.Size(99, 13);
            this.lblTcpPort.TabIndex = 2;
            this.lblTcpPort.Text = "TCP Transfer Port:";
            // 
            // numUdpPort
            // 
            this.numUdpPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUdpPort.Location = new System.Drawing.Point(170, 36);
            numUdpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numUdpPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numUdpPort.Name = "numUdpPort";
            this.numUdpPort.Size = new System.Drawing.Size(95, 22);
            this.numUdpPort.TabIndex = 1;
            this.numUdpPort.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            // 
            // lblUdpPort
            // 
            this.lblUdpPort.AutoSize = true;
            this.lblUdpPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUdpPort.Location = new System.Drawing.Point(15, 38);
            this.lblUdpPort.Name = "lblUdpPort";
            this.lblUdpPort.Size = new System.Drawing.Size(113, 13);
            this.lblUdpPort.TabIndex = 0;
            this.lblUdpPort.Text = "UDP Discovery Port:";
            // 
            // tabSecurity
            // 
            this.tabSecurity.BackColor = System.Drawing.Color.White;
            this.tabSecurity.Controls.Add(this.groupSecurityOptions);
            this.tabSecurity.Location = new System.Drawing.Point(4, 28);
            this.tabSecurity.Name = "tabSecurity";
            this.tabSecurity.Padding = new System.Windows.Forms.Padding(12);
            this.tabSecurity.Size = new System.Drawing.Size(942, 484);
            this.tabSecurity.TabIndex = 3;
            this.tabSecurity.Text = "Security";
            // 
            // groupSecurityOptions
            // 
            this.groupSecurityOptions.Controls.Add(this.btnRevokePaired);
            this.groupSecurityOptions.Controls.Add(this.chkRememberPaired);
            this.groupSecurityOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSecurityOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSecurityOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupSecurityOptions.Location = new System.Drawing.Point(12, 12);
            this.groupSecurityOptions.Name = "groupSecurityOptions";
            this.groupSecurityOptions.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupSecurityOptions.Size = new System.Drawing.Size(918, 140);
            this.groupSecurityOptions.TabIndex = 0;
            this.groupSecurityOptions.TabStop = false;
            this.groupSecurityOptions.Text = "Pairing & Trust Management";
            // 
            // btnRevokePaired
            // 
            this.btnRevokePaired.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnRevokePaired.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevokePaired.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevokePaired.Location = new System.Drawing.Point(15, 78);
            this.btnRevokePaired.Name = "btnRevokePaired";
            this.btnRevokePaired.Size = new System.Drawing.Size(220, 30);
            this.btnRevokePaired.TabIndex = 1;
            this.btnRevokePaired.Text = "Revoke All Paired Devices";
            this.btnRevokePaired.UseVisualStyleBackColor = true;
            this.btnRevokePaired.Click += new System.EventHandler(this.BtnRevokePaired_Click);
            // 
            // chkRememberPaired
            // 
            this.chkRememberPaired.AutoSize = true;
            this.chkRememberPaired.Checked = true;
            this.chkRememberPaired.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRememberPaired.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberPaired.Location = new System.Drawing.Point(15, 36);
            this.chkRememberPaired.Name = "chkRememberPaired";
            this.chkRememberPaired.Size = new System.Drawing.Size(161, 17);
            this.chkRememberPaired.TabIndex = 0;
            this.chkRememberPaired.Text = "Remember paired devices";
            this.chkRememberPaired.UseVisualStyleBackColor = true;
            // 
            // tabAppearance
            // 
            this.tabAppearance.BackColor = System.Drawing.Color.White;
            this.tabAppearance.Controls.Add(this.groupDensity);
            this.tabAppearance.Controls.Add(this.groupTheme);
            this.tabAppearance.Location = new System.Drawing.Point(4, 28);
            this.tabAppearance.Name = "tabAppearance";
            this.tabAppearance.Padding = new System.Windows.Forms.Padding(12);
            this.tabAppearance.Size = new System.Drawing.Size(942, 484);
            this.tabAppearance.TabIndex = 4;
            this.tabAppearance.Text = "Appearance";
            // 
            // groupDensity
            // 
            this.groupDensity.Controls.Add(this.rbDensityComfortable);
            this.groupDensity.Controls.Add(this.rbDensityStandard);
            this.groupDensity.Controls.Add(this.rbDensityCompact);
            this.groupDensity.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDensity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDensity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupDensity.Location = new System.Drawing.Point(12, 107);
            this.groupDensity.Name = "groupDensity";
            this.groupDensity.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupDensity.Size = new System.Drawing.Size(918, 95);
            this.groupDensity.TabIndex = 1;
            this.groupDensity.TabStop = false;
            this.groupDensity.Text = "UI Density";
            // 
            // rbDensityComfortable
            // 
            this.rbDensityComfortable.AutoSize = true;
            this.rbDensityComfortable.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDensityComfortable.Location = new System.Drawing.Point(220, 36);
            this.rbDensityComfortable.Name = "rbDensityComfortable";
            this.rbDensityComfortable.Size = new System.Drawing.Size(88, 17);
            this.rbDensityComfortable.TabIndex = 2;
            this.rbDensityComfortable.Text = "Comfortable";
            this.rbDensityComfortable.UseVisualStyleBackColor = true;
            // 
            // rbDensityStandard
            // 
            this.rbDensityStandard.AutoSize = true;
            this.rbDensityStandard.Checked = true;
            this.rbDensityStandard.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDensityStandard.Location = new System.Drawing.Point(115, 36);
            this.rbDensityStandard.Name = "rbDensityStandard";
            this.rbDensityStandard.Size = new System.Drawing.Size(70, 17);
            this.rbDensityStandard.TabIndex = 1;
            this.rbDensityStandard.TabStop = true;
            this.rbDensityStandard.Text = "Standard";
            this.rbDensityStandard.UseVisualStyleBackColor = true;
            // 
            // rbDensityCompact
            // 
            this.rbDensityCompact.AutoSize = true;
            this.rbDensityCompact.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDensityCompact.Location = new System.Drawing.Point(15, 36);
            this.rbDensityCompact.Name = "rbDensityCompact";
            this.rbDensityCompact.Size = new System.Drawing.Size(69, 17);
            this.rbDensityCompact.TabIndex = 0;
            this.rbDensityCompact.Text = "Compact";
            this.rbDensityCompact.UseVisualStyleBackColor = true;
            // 
            // groupTheme
            // 
            this.groupTheme.Controls.Add(this.rbThemeDark);
            this.groupTheme.Controls.Add(this.rbThemeLight);
            this.groupTheme.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupTheme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupTheme.Location = new System.Drawing.Point(12, 12);
            this.groupTheme.Name = "groupTheme";
            this.groupTheme.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupTheme.Size = new System.Drawing.Size(918, 95);
            this.groupTheme.TabIndex = 0;
            this.groupTheme.TabStop = false;
            this.groupTheme.Text = "Visual Theme";
            // 
            // rbThemeDark
            // 
            this.rbThemeDark.AutoSize = true;
            this.rbThemeDark.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThemeDark.Location = new System.Drawing.Point(115, 36);
            this.rbThemeDark.Name = "rbThemeDark";
            this.rbThemeDark.Size = new System.Drawing.Size(81, 17);
            this.rbThemeDark.TabIndex = 1;
            this.rbThemeDark.Text = "Dark Theme";
            this.rbThemeDark.UseVisualStyleBackColor = true;
            // 
            // rbThemeLight
            // 
            this.rbThemeLight.AutoSize = true;
            this.rbThemeLight.Checked = true;
            this.rbThemeLight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThemeLight.Location = new System.Drawing.Point(15, 36);
            this.rbThemeLight.Name = "rbThemeLight";
            this.rbThemeLight.Size = new System.Drawing.Size(84, 17);
            this.rbThemeLight.TabIndex = 0;
            this.rbThemeLight.TabStop = true;
            this.rbThemeLight.Text = "Light Theme";
            this.rbThemeLight.UseVisualStyleBackColor = true;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelFooter.Controls.Add(this.btnResetDefaults);
            this.panelFooter.Controls.Add(this.btnSave);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 570);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(12, 10, 16, 10);
            this.panelFooter.Size = new System.Drawing.Size(950, 50);
            this.panelFooter.TabIndex = 2;
            // 
            // btnResetDefaults
            // 
            this.btnResetDefaults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnResetDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetDefaults.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetDefaults.Location = new System.Drawing.Point(16, 10);
            this.btnResetDefaults.Name = "btnResetDefaults";
            this.btnResetDefaults.Size = new System.Drawing.Size(120, 30);
            this.btnResetDefaults.TabIndex = 1;
            this.btnResetDefaults.Text = "Reset Defaults";
            this.btnResetDefaults.UseVisualStyleBackColor = true;
            this.btnResetDefaults.Click += new System.EventHandler(this.BtnResetDefaults_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(800, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Save Settings";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupGeneralBehavior.ResumeLayout(false);
            this.groupGeneralBehavior.PerformLayout();
            this.groupGeneralStorage.ResumeLayout(false);
            this.groupGeneralStorage.PerformLayout();
            this.tabTransfers.ResumeLayout(false);
            this.groupTransferOptions.ResumeLayout(false);
            this.groupTransferOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConcurrent)).EndInit();
            this.tabNetwork.ResumeLayout(false);
            this.groupNetworkPorts.ResumeLayout(false);
            this.groupNetworkPorts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTcpPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdpPort)).EndInit();
            this.tabSecurity.ResumeLayout(false);
            this.groupSecurityOptions.ResumeLayout(false);
            this.groupSecurityOptions.PerformLayout();
            this.tabAppearance.ResumeLayout(false);
            this.groupDensity.ResumeLayout(false);
            this.groupDensity.PerformLayout();
            this.groupTheme.ResumeLayout(false);
            this.groupTheme.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
