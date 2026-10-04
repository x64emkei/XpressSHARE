namespace XpressShare.Forms.Controls
{
    partial class HomeControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Label lblWelcomeSubtitle;
        private System.Windows.Forms.Panel panelAccentBar;

        private System.Windows.Forms.TableLayoutPanel tableMainLayout;
        private System.Windows.Forms.GroupBox groupThisComputer;
        private System.Windows.Forms.TableLayoutPanel tableComputerInfo;
        private System.Windows.Forms.Label lblColComputer;
        private System.Windows.Forms.Label lblValComputer;
        private System.Windows.Forms.Label lblColUser;
        private System.Windows.Forms.Label lblValUser;
        private System.Windows.Forms.Label lblColOs;
        private System.Windows.Forms.Label lblValOs;
        private System.Windows.Forms.Label lblColBuild;
        private System.Windows.Forms.Label lblValBuild;
        private System.Windows.Forms.Label lblColOsArch;
        private System.Windows.Forms.Label lblValOsArch;

        private System.Windows.Forms.Label lblColAppArch;
        private System.Windows.Forms.Label lblValAppArch;
        private System.Windows.Forms.Label lblColAppVersion;
        private System.Windows.Forms.Label lblValAppVersion;
        private System.Windows.Forms.Label lblColConnection;
        private System.Windows.Forms.Label lblValConnection;
        private System.Windows.Forms.Label lblColIp;
        private System.Windows.Forms.Label lblValIp;
        private System.Windows.Forms.Label lblColStatus;
        private System.Windows.Forms.Label lblValStatus;

        private System.Windows.Forms.GroupBox groupQuickActions;
        private System.Windows.Forms.FlowLayoutPanel flowQuickActions;
        private System.Windows.Forms.Button btnQuickSend;
        private System.Windows.Forms.Button btnQuickReceive;
        private System.Windows.Forms.Button btnQuickDevices;
        private System.Windows.Forms.Button btnQuickExplorer;

        private System.Windows.Forms.SplitContainer splitRecentAndDevices;
        private System.Windows.Forms.GroupBox groupRecentTransfers;
        private System.Windows.Forms.DataGridView dgvRecentTransfers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentPeer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentDate;

        private System.Windows.Forms.GroupBox groupDevicesOnline;
        private System.Windows.Forms.Panel panelDevicesHeader;
        private System.Windows.Forms.Label lblDevicesCount;
        private System.Windows.Forms.ListView listDevicesOnline;
        private System.Windows.Forms.ColumnHeader colDevName;
        private System.Windows.Forms.ColumnHeader colDevIp;
        private System.Windows.Forms.ColumnHeader colDevType;
        private System.Windows.Forms.ColumnHeader colDevState;

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
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.lblWelcomeSubtitle = new System.Windows.Forms.Label();
            this.panelAccentBar = new System.Windows.Forms.Panel();
            this.tableMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupThisComputer = new System.Windows.Forms.GroupBox();
            this.tableComputerInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblColComputer = new System.Windows.Forms.Label();
            this.lblValComputer = new System.Windows.Forms.Label();
            this.lblColUser = new System.Windows.Forms.Label();
            this.lblValUser = new System.Windows.Forms.Label();
            this.lblColOs = new System.Windows.Forms.Label();
            this.lblValOs = new System.Windows.Forms.Label();
            this.lblColBuild = new System.Windows.Forms.Label();
            this.lblValBuild = new System.Windows.Forms.Label();
            this.lblColOsArch = new System.Windows.Forms.Label();
            this.lblValOsArch = new System.Windows.Forms.Label();
            this.lblColAppArch = new System.Windows.Forms.Label();
            this.lblValAppArch = new System.Windows.Forms.Label();
            this.lblColAppVersion = new System.Windows.Forms.Label();
            this.lblValAppVersion = new System.Windows.Forms.Label();
            this.lblColConnection = new System.Windows.Forms.Label();
            this.lblValConnection = new System.Windows.Forms.Label();
            this.lblColIp = new System.Windows.Forms.Label();
            this.lblValIp = new System.Windows.Forms.Label();
            this.lblColStatus = new System.Windows.Forms.Label();
            this.lblValStatus = new System.Windows.Forms.Label();
            this.groupQuickActions = new System.Windows.Forms.GroupBox();
            this.flowQuickActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuickSend = new System.Windows.Forms.Button();
            this.btnQuickReceive = new System.Windows.Forms.Button();
            this.btnQuickDevices = new System.Windows.Forms.Button();
            this.btnQuickExplorer = new System.Windows.Forms.Button();
            this.splitRecentAndDevices = new System.Windows.Forms.SplitContainer();
            this.groupRecentTransfers = new System.Windows.Forms.GroupBox();
            this.dgvRecentTransfers = new System.Windows.Forms.DataGridView();
            this.colRecentFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecentPeer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecentSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDevicesOnline = new System.Windows.Forms.GroupBox();
            this.listDevicesOnline = new System.Windows.Forms.ListView();
            this.colDevName = new System.Windows.Forms.ColumnHeader();
            this.colDevIp = new System.Windows.Forms.ColumnHeader();
            this.colDevType = new System.Windows.Forms.ColumnHeader();
            this.colDevState = new System.Windows.Forms.ColumnHeader();
            this.panelDevicesHeader = new System.Windows.Forms.Panel();
            this.lblDevicesCount = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.tableMainLayout.SuspendLayout();
            this.groupThisComputer.SuspendLayout();
            this.tableComputerInfo.SuspendLayout();
            this.groupQuickActions.SuspendLayout();
            this.flowQuickActions.SuspendLayout();
            this.splitRecentAndDevices.Panel1.SuspendLayout();
            this.splitRecentAndDevices.Panel2.SuspendLayout();
            this.splitRecentAndDevices.SuspendLayout();
            this.groupRecentTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransfers)).BeginInit();
            this.groupDevicesOnline.SuspendLayout();
            this.panelDevicesHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelHeader.Controls.Add(this.lblWelcomeTitle);
            this.panelHeader.Controls.Add(this.lblWelcomeSubtitle);
            this.panelHeader.Controls.Add(this.panelAccentBar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 56);
            this.panelHeader.TabIndex = 0;
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.AutoSize = true;
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.lblWelcomeTitle.Location = new System.Drawing.Point(14, 8);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(225, 25);
            this.lblWelcomeTitle.TabIndex = 0;
            this.lblWelcomeTitle.Text = "Welcome to XpressSHARE";
            // 
            // lblWelcomeSubtitle
            // 
            this.lblWelcomeSubtitle.AutoSize = true;
            this.lblWelcomeSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblWelcomeSubtitle.Location = new System.Drawing.Point(15, 33);
            this.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            this.lblWelcomeSubtitle.Size = new System.Drawing.Size(384, 15);
            this.lblWelcomeSubtitle.TabIndex = 1;
            this.lblWelcomeSubtitle.Text = "High-speed encrypted peer-to-peer file sharing and network workspace";
            // 
            // panelAccentBar
            // 
            this.panelAccentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelAccentBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAccentBar.Location = new System.Drawing.Point(0, 0);
            this.panelAccentBar.Name = "panelAccentBar";
            this.panelAccentBar.Size = new System.Drawing.Size(4, 56);
            this.panelAccentBar.TabIndex = 2;
            // 
            // tableMainLayout
            // 
            this.tableMainLayout.ColumnCount = 2;
            this.tableMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableMainLayout.Controls.Add(this.groupThisComputer, 0, 0);
            this.tableMainLayout.Controls.Add(this.groupQuickActions, 1, 0);
            this.tableMainLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableMainLayout.Location = new System.Drawing.Point(0, 56);
            this.tableMainLayout.Name = "tableMainLayout";
            this.tableMainLayout.Padding = new System.Windows.Forms.Padding(8, 6, 8, 4);
            this.tableMainLayout.RowCount = 1;
            this.tableMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMainLayout.Size = new System.Drawing.Size(950, 192);
            this.tableMainLayout.TabIndex = 1;
            // 
            // groupThisComputer
            // 
            this.groupThisComputer.BackColor = System.Drawing.Color.White;
            this.groupThisComputer.Controls.Add(this.tableComputerInfo);
            this.groupThisComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThisComputer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThisComputer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.groupThisComputer.Location = new System.Drawing.Point(11, 9);
            this.groupThisComputer.Name = "groupThisComputer";
            this.groupThisComputer.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.groupThisComputer.Size = new System.Drawing.Size(591, 176);
            this.groupThisComputer.TabIndex = 0;
            this.groupThisComputer.TabStop = false;
            this.groupThisComputer.Text = "THIS COMPUTER";
            // 
            // tableComputerInfo
            // 
            this.tableComputerInfo.ColumnCount = 4;
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableComputerInfo.Controls.Add(this.lblColComputer, 0, 0);
            this.tableComputerInfo.Controls.Add(this.lblValComputer, 1, 0);
            this.tableComputerInfo.Controls.Add(this.lblColUser, 0, 1);
            this.tableComputerInfo.Controls.Add(this.lblValUser, 1, 1);
            this.tableComputerInfo.Controls.Add(this.lblColOs, 0, 2);
            this.tableComputerInfo.Controls.Add(this.lblValOs, 1, 2);
            this.tableComputerInfo.Controls.Add(this.lblColBuild, 0, 3);
            this.tableComputerInfo.Controls.Add(this.lblValBuild, 1, 3);
            this.tableComputerInfo.Controls.Add(this.lblColOsArch, 0, 4);
            this.tableComputerInfo.Controls.Add(this.lblValOsArch, 1, 4);
            this.tableComputerInfo.Controls.Add(this.lblColAppArch, 2, 0);
            this.tableComputerInfo.Controls.Add(this.lblValAppArch, 3, 0);
            this.tableComputerInfo.Controls.Add(this.lblColAppVersion, 2, 1);
            this.tableComputerInfo.Controls.Add(this.lblValAppVersion, 3, 1);
            this.tableComputerInfo.Controls.Add(this.lblColConnection, 2, 2);
            this.tableComputerInfo.Controls.Add(this.lblValConnection, 3, 2);
            this.tableComputerInfo.Controls.Add(this.lblColIp, 2, 3);
            this.tableComputerInfo.Controls.Add(this.lblValIp, 3, 3);
            this.tableComputerInfo.Controls.Add(this.lblColStatus, 2, 4);
            this.tableComputerInfo.Controls.Add(this.lblValStatus, 3, 4);
            this.tableComputerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableComputerInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableComputerInfo.Location = new System.Drawing.Point(10, 26);
            this.tableComputerInfo.Name = "tableComputerInfo";
            this.tableComputerInfo.RowCount = 5;
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableComputerInfo.Size = new System.Drawing.Size(571, 142);
            this.tableComputerInfo.TabIndex = 0;
            // 
            // lblColComputer
            // 
            this.lblColComputer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColComputer.AutoSize = true;
            this.lblColComputer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColComputer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColComputer.Location = new System.Drawing.Point(3, 6);
            this.lblColComputer.Name = "lblColComputer";
            this.lblColComputer.Size = new System.Drawing.Size(99, 15);
            this.lblColComputer.TabIndex = 0;
            this.lblColComputer.Text = "Computer Name:";
            // 
            // lblValComputer
            // 
            this.lblValComputer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValComputer.AutoEllipsis = true;
            this.lblValComputer.AutoSize = true;
            this.lblValComputer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValComputer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValComputer.Location = new System.Drawing.Point(121, 6);
            this.lblValComputer.Name = "lblValComputer";
            this.lblValComputer.Size = new System.Drawing.Size(22, 15);
            this.lblValComputer.TabIndex = 1;
            this.lblValComputer.Text = "PC";
            // 
            // lblColUser
            // 
            this.lblColUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColUser.AutoSize = true;
            this.lblColUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColUser.Location = new System.Drawing.Point(3, 34);
            this.lblColUser.Name = "lblColUser";
            this.lblColUser.Size = new System.Drawing.Size(76, 15);
            this.lblColUser.TabIndex = 2;
            this.lblColUser.Text = "Current User:";
            // 
            // lblValUser
            // 
            this.lblValUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValUser.AutoEllipsis = true;
            this.lblValUser.AutoSize = true;
            this.lblValUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValUser.Location = new System.Drawing.Point(121, 34);
            this.lblValUser.Name = "lblValUser";
            this.lblValUser.Size = new System.Drawing.Size(33, 15);
            this.lblValUser.TabIndex = 3;
            this.lblValUser.Text = "User";
            // 
            // lblColOs
            // 
            this.lblColOs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColOs.AutoSize = true;
            this.lblColOs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColOs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColOs.Location = new System.Drawing.Point(3, 62);
            this.lblColOs.Name = "lblColOs";
            this.lblColOs.Size = new System.Drawing.Size(104, 15);
            this.lblColOs.TabIndex = 4;
            this.lblColOs.Text = "Operating System:";
            // 
            // lblValOs
            // 
            this.lblValOs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValOs.AutoEllipsis = true;
            this.lblValOs.AutoSize = true;
            this.lblValOs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValOs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValOs.Location = new System.Drawing.Point(121, 62);
            this.lblValOs.Name = "lblValOs";
            this.lblValOs.Size = new System.Drawing.Size(68, 15);
            this.lblValOs.TabIndex = 5;
            this.lblValOs.Text = "Windows 8";
            // 
            // lblColBuild
            // 
            this.lblColBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColBuild.AutoSize = true;
            this.lblColBuild.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColBuild.Location = new System.Drawing.Point(3, 90);
            this.lblColBuild.Name = "lblColBuild";
            this.lblColBuild.Size = new System.Drawing.Size(37, 15);
            this.lblColBuild.TabIndex = 6;
            this.lblColBuild.Text = "Build:";
            // 
            // lblValBuild
            // 
            this.lblValBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValBuild.AutoEllipsis = true;
            this.lblValBuild.AutoSize = true;
            this.lblValBuild.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValBuild.Location = new System.Drawing.Point(121, 90);
            this.lblValBuild.Name = "lblValBuild";
            this.lblValBuild.Size = new System.Drawing.Size(35, 15);
            this.lblValBuild.TabIndex = 7;
            this.lblValBuild.Text = "9200";
            // 
            // lblColOsArch
            // 
            this.lblColOsArch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColOsArch.AutoSize = true;
            this.lblColOsArch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColOsArch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColOsArch.Location = new System.Drawing.Point(3, 119);
            this.lblColOsArch.Name = "lblColOsArch";
            this.lblColOsArch.Size = new System.Drawing.Size(95, 15);
            this.lblColOsArch.TabIndex = 8;
            this.lblColOsArch.Text = "OS Architecture:";
            // 
            // lblValOsArch
            // 
            this.lblValOsArch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValOsArch.AutoEllipsis = true;
            this.lblValOsArch.AutoSize = true;
            this.lblValOsArch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValOsArch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValOsArch.Location = new System.Drawing.Point(121, 119);
            this.lblValOsArch.Name = "lblValOsArch";
            this.lblValOsArch.Size = new System.Drawing.Size(40, 15);
            this.lblValOsArch.TabIndex = 9;
            this.lblValOsArch.Text = "64-bit";
            // 
            // lblColAppArch
            // 
            this.lblColAppArch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColAppArch.AutoSize = true;
            this.lblColAppArch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColAppArch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColAppArch.Location = new System.Drawing.Point(308, 6);
            this.lblColAppArch.Name = "lblColAppArch";
            this.lblColAppArch.Size = new System.Drawing.Size(77, 15);
            this.lblColAppArch.TabIndex = 10;
            this.lblColAppArch.Text = "XpressSHARE:";
            // 
            // lblValAppArch
            // 
            this.lblValAppArch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValAppArch.AutoEllipsis = true;
            this.lblValAppArch.AutoSize = true;
            this.lblValAppArch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValAppArch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblValAppArch.Location = new System.Drawing.Point(413, 6);
            this.lblValAppArch.Name = "lblValAppArch";
            this.lblValAppArch.Size = new System.Drawing.Size(40, 15);
            this.lblValAppArch.TabIndex = 11;
            this.lblValAppArch.Text = "64-bit";
            // 
            // lblColAppVersion
            // 
            this.lblColAppVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColAppVersion.AutoSize = true;
            this.lblColAppVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColAppVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColAppVersion.Location = new System.Drawing.Point(308, 34);
            this.lblColAppVersion.Name = "lblColAppVersion";
            this.lblColAppVersion.Size = new System.Drawing.Size(49, 15);
            this.lblColAppVersion.TabIndex = 12;
            this.lblColAppVersion.Text = "Version:";
            // 
            // lblValAppVersion
            // 
            this.lblValAppVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValAppVersion.AutoEllipsis = true;
            this.lblValAppVersion.AutoSize = true;
            this.lblValAppVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValAppVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValAppVersion.Location = new System.Drawing.Point(413, 34);
            this.lblValAppVersion.Name = "lblValAppVersion";
            this.lblValAppVersion.Size = new System.Drawing.Size(34, 15);
            this.lblValAppVersion.TabIndex = 13;
            this.lblValAppVersion.Text = "0.5.0";
            // 
            // lblColConnection
            // 
            this.lblColConnection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColConnection.AutoSize = true;
            this.lblColConnection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColConnection.Location = new System.Drawing.Point(308, 62);
            this.lblColConnection.Name = "lblColConnection";
            this.lblColConnection.Size = new System.Drawing.Size(72, 15);
            this.lblColConnection.TabIndex = 14;
            this.lblColConnection.Text = "Connection:";
            // 
            // lblValConnection
            // 
            this.lblValConnection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValConnection.AutoEllipsis = true;
            this.lblValConnection.AutoSize = true;
            this.lblValConnection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValConnection.Location = new System.Drawing.Point(413, 62);
            this.lblValConnection.Name = "lblValConnection";
            this.lblValConnection.Size = new System.Drawing.Size(53, 15);
            this.lblValConnection.TabIndex = 15;
            this.lblValConnection.Text = "Ethernet";
            // 
            // lblColIp
            // 
            this.lblColIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColIp.AutoSize = true;
            this.lblColIp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColIp.Location = new System.Drawing.Point(308, 90);
            this.lblColIp.Name = "lblColIp";
            this.lblColIp.Size = new System.Drawing.Size(65, 15);
            this.lblColIp.TabIndex = 16;
            this.lblColIp.Text = "IP Address:";
            // 
            // lblValIp
            // 
            this.lblValIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValIp.AutoEllipsis = true;
            this.lblValIp.AutoSize = true;
            this.lblValIp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblValIp.Location = new System.Drawing.Point(413, 90);
            this.lblValIp.Name = "lblValIp";
            this.lblValIp.Size = new System.Drawing.Size(76, 15);
            this.lblValIp.TabIndex = 17;
            this.lblValIp.Text = "100.71.73.63";
            // 
            // lblColStatus
            // 
            this.lblColStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColStatus.AutoSize = true;
            this.lblColStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblColStatus.Location = new System.Drawing.Point(308, 119);
            this.lblColStatus.Name = "lblColStatus";
            this.lblColStatus.Size = new System.Drawing.Size(42, 15);
            this.lblColStatus.TabIndex = 18;
            this.lblColStatus.Text = "Status:";
            // 
            // lblValStatus
            // 
            this.lblValStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValStatus.AutoEllipsis = true;
            this.lblValStatus.AutoSize = true;
            this.lblValStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblValStatus.Location = new System.Drawing.Point(413, 119);
            this.lblValStatus.Name = "lblValStatus";
            this.lblValStatus.Size = new System.Drawing.Size(133, 15);
            this.lblValStatus.TabIndex = 19;
            this.lblValStatus.Text = "Online (Ready to Share)";
            // 
            // groupQuickActions
            // 
            this.groupQuickActions.BackColor = System.Drawing.Color.White;
            this.groupQuickActions.Controls.Add(this.flowQuickActions);
            this.groupQuickActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupQuickActions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupQuickActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.groupQuickActions.Location = new System.Drawing.Point(608, 9);
            this.groupQuickActions.Name = "groupQuickActions";
            this.groupQuickActions.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.groupQuickActions.Size = new System.Drawing.Size(331, 176);
            this.groupQuickActions.TabIndex = 1;
            this.groupQuickActions.TabStop = false;
            this.groupQuickActions.Text = "GET STARTED";
            // 
            // flowQuickActions
            // 
            this.flowQuickActions.Controls.Add(this.btnQuickSend);
            this.flowQuickActions.Controls.Add(this.btnQuickReceive);
            this.flowQuickActions.Controls.Add(this.btnQuickDevices);
            this.flowQuickActions.Controls.Add(this.btnQuickExplorer);
            this.flowQuickActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowQuickActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowQuickActions.Location = new System.Drawing.Point(10, 26);
            this.flowQuickActions.Name = "flowQuickActions";
            this.flowQuickActions.Size = new System.Drawing.Size(311, 142);
            this.flowQuickActions.TabIndex = 0;
            this.flowQuickActions.WrapContents = false;
            // 
            // btnQuickSend
            // 
            this.btnQuickSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuickSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickSend.FlatAppearance.BorderSize = 0;
            this.btnQuickSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickSend.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickSend.ForeColor = System.Drawing.Color.White;
            this.btnQuickSend.Location = new System.Drawing.Point(3, 2);
            this.btnQuickSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.btnQuickSend.Name = "btnQuickSend";
            this.btnQuickSend.Size = new System.Drawing.Size(304, 32);
            this.btnQuickSend.TabIndex = 0;
            this.btnQuickSend.Text = "Send Files...";
            this.btnQuickSend.UseVisualStyleBackColor = false;
            this.btnQuickSend.Click += new System.EventHandler(this.BtnQuickSend_Click);
            // 
            // btnQuickReceive
            // 
            this.btnQuickReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.btnQuickReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReceive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.btnQuickReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReceive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.btnQuickReceive.Location = new System.Drawing.Point(3, 39);
            this.btnQuickReceive.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnQuickReceive.Name = "btnQuickReceive";
            this.btnQuickReceive.Size = new System.Drawing.Size(304, 30);
            this.btnQuickReceive.TabIndex = 1;
            this.btnQuickReceive.Text = "Receive Files";
            this.btnQuickReceive.UseVisualStyleBackColor = false;
            this.btnQuickReceive.Click += new System.EventHandler(this.BtnQuickReceive_Click);
            // 
            // btnQuickDevices
            // 
            this.btnQuickDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.btnQuickDevices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickDevices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.btnQuickDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickDevices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickDevices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.btnQuickDevices.Location = new System.Drawing.Point(3, 73);
            this.btnQuickDevices.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnQuickDevices.Name = "btnQuickDevices";
            this.btnQuickDevices.Size = new System.Drawing.Size(304, 30);
            this.btnQuickDevices.TabIndex = 2;
            this.btnQuickDevices.Text = "Browse Devices";
            this.btnQuickDevices.UseVisualStyleBackColor = false;
            this.btnQuickDevices.Click += new System.EventHandler(this.BtnQuickDevices_Click);
            // 
            // btnQuickExplorer
            // 
            this.btnQuickExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.btnQuickExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickExplorer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.btnQuickExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickExplorer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.btnQuickExplorer.Location = new System.Drawing.Point(3, 107);
            this.btnQuickExplorer.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnQuickExplorer.Name = "btnQuickExplorer";
            this.btnQuickExplorer.Size = new System.Drawing.Size(304, 30);
            this.btnQuickExplorer.TabIndex = 3;
            this.btnQuickExplorer.Text = "Open Explorer";
            this.btnQuickExplorer.UseVisualStyleBackColor = false;
            this.btnQuickExplorer.Click += new System.EventHandler(this.BtnQuickExplorer_Click);
            // 
            // splitRecentAndDevices
            // 
            this.splitRecentAndDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRecentAndDevices.Location = new System.Drawing.Point(0, 248);
            this.splitRecentAndDevices.Name = "splitRecentAndDevices";
            // 
            // splitRecentAndDevices.Panel1
            // 
            this.splitRecentAndDevices.Panel1.Controls.Add(this.groupRecentTransfers);
            this.splitRecentAndDevices.Panel1.Padding = new System.Windows.Forms.Padding(8, 4, 4, 8);
            // 
            // splitRecentAndDevices.Panel2
            // 
            this.splitRecentAndDevices.Panel2.Controls.Add(this.groupDevicesOnline);
            this.splitRecentAndDevices.Panel2.Padding = new System.Windows.Forms.Padding(4, 4, 8, 8);
            this.splitRecentAndDevices.Size = new System.Drawing.Size(950, 372);
            this.splitRecentAndDevices.SplitterDistance = 580;
            this.splitRecentAndDevices.TabIndex = 2;
            // 
            // groupRecentTransfers
            // 
            this.groupRecentTransfers.BackColor = System.Drawing.Color.White;
            this.groupRecentTransfers.Controls.Add(this.dgvRecentTransfers);
            this.groupRecentTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRecentTransfers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRecentTransfers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.groupRecentTransfers.Location = new System.Drawing.Point(8, 4);
            this.groupRecentTransfers.Name = "groupRecentTransfers";
            this.groupRecentTransfers.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.groupRecentTransfers.Size = new System.Drawing.Size(568, 360);
            this.groupRecentTransfers.TabIndex = 0;
            this.groupRecentTransfers.TabStop = false;
            this.groupRecentTransfers.Text = "RECENT TRANSFERS";
            // 
            // dgvRecentTransfers
            // 
            this.dgvRecentTransfers.AllowUserToAddRows = false;
            this.dgvRecentTransfers.AllowUserToDeleteRows = false;
            this.dgvRecentTransfers.AllowUserToResizeRows = false;
            this.dgvRecentTransfers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentTransfers.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentTransfers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentTransfers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentTransfers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgvCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            dgvCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            dgvCellStyle1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            dgvCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentTransfers.ColumnHeadersDefaultCellStyle = dgvCellStyle1;
            this.dgvRecentTransfers.ColumnHeadersHeight = 30;
            this.dgvRecentTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentTransfers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecentFile,
            this.colRecentPeer,
            this.colRecentSize,
            this.colRecentStatus,
            this.colRecentDate});
            dgvCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dgvCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dgvCellStyle2.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            dgvCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dgvCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dgvCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentTransfers.DefaultCellStyle = dgvCellStyle2;
            this.dgvRecentTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentTransfers.EnableHeadersVisualStyles = false;
            this.dgvRecentTransfers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.dgvRecentTransfers.Location = new System.Drawing.Point(8, 26);
            this.dgvRecentTransfers.MultiSelect = false;
            this.dgvRecentTransfers.Name = "dgvRecentTransfers";
            this.dgvRecentTransfers.ReadOnly = true;
            this.dgvRecentTransfers.RowHeadersVisible = false;
            this.dgvRecentTransfers.RowTemplate.Height = 26;
            this.dgvRecentTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentTransfers.Size = new System.Drawing.Size(552, 326);
            this.dgvRecentTransfers.TabIndex = 0;
            this.dgvRecentTransfers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecentTransfers_CellDoubleClick);
            // 
            // colRecentFile
            // 
            this.colRecentFile.FillWeight = 36F;
            this.colRecentFile.HeaderText = "File Name";
            this.colRecentFile.MinimumWidth = 140;
            this.colRecentFile.Name = "colRecentFile";
            this.colRecentFile.ReadOnly = true;
            // 
            // colRecentPeer
            // 
            this.colRecentPeer.FillWeight = 24F;
            this.colRecentPeer.HeaderText = "Peer";
            this.colRecentPeer.MinimumWidth = 100;
            this.colRecentPeer.Name = "colRecentPeer";
            this.colRecentPeer.ReadOnly = true;
            // 
            // colRecentSize
            // 
            this.colRecentSize.FillWeight = 14F;
            this.colRecentSize.HeaderText = "Size";
            this.colRecentSize.MinimumWidth = 70;
            this.colRecentSize.Name = "colRecentSize";
            this.colRecentSize.ReadOnly = true;
            // 
            // colRecentStatus
            // 
            this.colRecentStatus.FillWeight = 14F;
            this.colRecentStatus.HeaderText = "Status";
            this.colRecentStatus.MinimumWidth = 80;
            this.colRecentStatus.Name = "colRecentStatus";
            this.colRecentStatus.ReadOnly = true;
            // 
            // colRecentDate
            // 
            this.colRecentDate.FillWeight = 20F;
            this.colRecentDate.HeaderText = "Date";
            this.colRecentDate.MinimumWidth = 110;
            this.colRecentDate.Name = "colRecentDate";
            this.colRecentDate.ReadOnly = true;
            // 
            // groupDevicesOnline
            // 
            this.groupDevicesOnline.BackColor = System.Drawing.Color.White;
            this.groupDevicesOnline.Controls.Add(this.listDevicesOnline);
            this.groupDevicesOnline.Controls.Add(this.panelDevicesHeader);
            this.groupDevicesOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDevicesOnline.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDevicesOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.groupDevicesOnline.Location = new System.Drawing.Point(4, 4);
            this.groupDevicesOnline.Name = "groupDevicesOnline";
            this.groupDevicesOnline.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.groupDevicesOnline.Size = new System.Drawing.Size(354, 360);
            this.groupDevicesOnline.TabIndex = 0;
            this.groupDevicesOnline.TabStop = false;
            this.groupDevicesOnline.Text = "DEVICES ONLINE";
            // 
            // listDevicesOnline
            // 
            this.listDevicesOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listDevicesOnline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDevName,
            this.colDevIp,
            this.colDevType,
            this.colDevState});
            this.listDevicesOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDevicesOnline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDevicesOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listDevicesOnline.FullRowSelect = true;
            this.listDevicesOnline.GridLines = true;
            this.listDevicesOnline.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listDevicesOnline.HideSelection = false;
            this.listDevicesOnline.Location = new System.Drawing.Point(8, 52);
            this.listDevicesOnline.MultiSelect = false;
            this.listDevicesOnline.Name = "listDevicesOnline";
            this.listDevicesOnline.Size = new System.Drawing.Size(338, 300);
            this.listDevicesOnline.TabIndex = 0;
            this.listDevicesOnline.UseCompatibleStateImageBehavior = false;
            this.listDevicesOnline.View = System.Windows.Forms.View.Details;
            // 
            // colDevName
            // 
            this.colDevName.Text = "Device Name";
            this.colDevName.Width = 140;
            // 
            // colDevIp
            // 
            this.colDevIp.Text = "IP Address";
            this.colDevIp.Width = 110;
            // 
            // colDevType
            // 
            this.colDevType.Text = "Network";
            this.colDevType.Width = 80;
            // 
            // colDevState
            // 
            this.colDevState.Text = "State";
            this.colDevState.Width = 80;
            // 
            // panelDevicesHeader
            // 
            this.panelDevicesHeader.Controls.Add(this.lblDevicesCount);
            this.panelDevicesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDevicesHeader.Location = new System.Drawing.Point(8, 26);
            this.panelDevicesHeader.Name = "panelDevicesHeader";
            this.panelDevicesHeader.Size = new System.Drawing.Size(338, 26);
            this.panelDevicesHeader.TabIndex = 1;
            // 
            // lblDevicesCount
            // 
            this.lblDevicesCount.AutoSize = true;
            this.lblDevicesCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevicesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblDevicesCount.Location = new System.Drawing.Point(2, 4);
            this.lblDevicesCount.Name = "lblDevicesCount";
            this.lblDevicesCount.Size = new System.Drawing.Size(155, 15);
            this.lblDevicesCount.TabIndex = 0;
            this.lblDevicesCount.Text = "Scanning local network...";
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitRecentAndDevices);
            this.Controls.Add(this.tableMainLayout);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableMainLayout.ResumeLayout(false);
            this.groupThisComputer.ResumeLayout(false);
            this.tableComputerInfo.ResumeLayout(false);
            this.tableComputerInfo.PerformLayout();
            this.groupQuickActions.ResumeLayout(false);
            this.flowQuickActions.ResumeLayout(false);
            this.splitRecentAndDevices.Panel1.ResumeLayout(false);
            this.splitRecentAndDevices.Panel2.ResumeLayout(false);
            this.splitRecentAndDevices.ResumeLayout(false);
            this.groupRecentTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransfers)).EndInit();
            this.groupDevicesOnline.ResumeLayout(false);
            this.panelDevicesHeader.ResumeLayout(false);
            this.panelDevicesHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
