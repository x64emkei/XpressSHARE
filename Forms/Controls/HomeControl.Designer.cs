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
        private System.Windows.Forms.Label lblColIp;
        private System.Windows.Forms.Label lblValIp;
        private System.Windows.Forms.Label lblColOs;
        private System.Windows.Forms.Label lblValOs;
        private System.Windows.Forms.Label lblColConnection;
        private System.Windows.Forms.Label lblValConnection;
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
            this.lblColIp = new System.Windows.Forms.Label();
            this.lblValIp = new System.Windows.Forms.Label();
            this.lblColOs = new System.Windows.Forms.Label();
            this.lblValOs = new System.Windows.Forms.Label();
            this.lblColConnection = new System.Windows.Forms.Label();
            this.lblValConnection = new System.Windows.Forms.Label();
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
            this.panelHeader.Size = new System.Drawing.Size(950, 54);
            this.panelHeader.TabIndex = 0;
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.AutoSize = true;
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblWelcomeTitle.Location = new System.Drawing.Point(14, 8);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(193, 21);
            this.lblWelcomeTitle.TabIndex = 0;
            this.lblWelcomeTitle.Text = "Welcome to XpressSHARE";
            // 
            // lblWelcomeSubtitle
            // 
            this.lblWelcomeSubtitle.AutoSize = true;
            this.lblWelcomeSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblWelcomeSubtitle.Location = new System.Drawing.Point(15, 31);
            this.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            this.lblWelcomeSubtitle.Size = new System.Drawing.Size(350, 13);
            this.lblWelcomeSubtitle.TabIndex = 1;
            this.lblWelcomeSubtitle.Text = "High-speed encrypted peer-to-peer file sharing and network workspace";
            // 
            // panelAccentBar
            // 
            this.panelAccentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelAccentBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAccentBar.Location = new System.Drawing.Point(0, 0);
            this.panelAccentBar.Name = "panelAccentBar";
            this.panelAccentBar.Size = new System.Drawing.Size(4, 54);
            this.panelAccentBar.TabIndex = 2;
            // 
            // tableMainLayout
            // 
            this.tableMainLayout.ColumnCount = 2;
            this.tableMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tableMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableMainLayout.Controls.Add(this.groupThisComputer, 0, 0);
            this.tableMainLayout.Controls.Add(this.groupQuickActions, 1, 0);
            this.tableMainLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableMainLayout.Location = new System.Drawing.Point(0, 54);
            this.tableMainLayout.Name = "tableMainLayout";
            this.tableMainLayout.Padding = new System.Windows.Forms.Padding(8, 6, 8, 4);
            this.tableMainLayout.RowCount = 1;
            this.tableMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMainLayout.Size = new System.Drawing.Size(950, 160);
            this.tableMainLayout.TabIndex = 1;
            // 
            // groupThisComputer
            // 
            this.groupThisComputer.BackColor = System.Drawing.Color.White;
            this.groupThisComputer.Controls.Add(this.tableComputerInfo);
            this.groupThisComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThisComputer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThisComputer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupThisComputer.Location = new System.Drawing.Point(11, 9);
            this.groupThisComputer.Name = "groupThisComputer";
            this.groupThisComputer.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.groupThisComputer.Size = new System.Drawing.Size(535, 144);
            this.groupThisComputer.TabIndex = 0;
            this.groupThisComputer.TabStop = false;
            this.groupThisComputer.Text = "This Computer";
            // 
            // tableComputerInfo
            // 
            this.tableComputerInfo.ColumnCount = 4;
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableComputerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableComputerInfo.Controls.Add(this.lblColComputer, 0, 0);
            this.tableComputerInfo.Controls.Add(this.lblValComputer, 1, 0);
            this.tableComputerInfo.Controls.Add(this.lblColUser, 0, 1);
            this.tableComputerInfo.Controls.Add(this.lblValUser, 1, 1);
            this.tableComputerInfo.Controls.Add(this.lblColIp, 0, 2);
            this.tableComputerInfo.Controls.Add(this.lblValIp, 1, 2);
            this.tableComputerInfo.Controls.Add(this.lblColOs, 2, 0);
            this.tableComputerInfo.Controls.Add(this.lblValOs, 3, 0);
            this.tableComputerInfo.Controls.Add(this.lblColConnection, 2, 1);
            this.tableComputerInfo.Controls.Add(this.lblValConnection, 3, 1);
            this.tableComputerInfo.Controls.Add(this.lblColStatus, 2, 2);
            this.tableComputerInfo.Controls.Add(this.lblValStatus, 3, 2);
            this.tableComputerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableComputerInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableComputerInfo.Location = new System.Drawing.Point(10, 24);
            this.tableComputerInfo.Name = "tableComputerInfo";
            this.tableComputerInfo.RowCount = 3;
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableComputerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableComputerInfo.Size = new System.Drawing.Size(515, 112);
            this.tableComputerInfo.TabIndex = 0;
            // 
            // lblColComputer
            // 
            this.lblColComputer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColComputer.AutoSize = true;
            this.lblColComputer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColComputer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblColComputer.Location = new System.Drawing.Point(3, 12);
            this.lblColComputer.Name = "lblColComputer";
            this.lblColComputer.Size = new System.Drawing.Size(92, 13);
            this.lblColComputer.TabIndex = 0;
            this.lblColComputer.Text = "Computer Name:";
            // 
            // lblValComputer
            // 
            this.lblValComputer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValComputer.AutoSize = true;
            this.lblValComputer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValComputer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblValComputer.Location = new System.Drawing.Point(113, 12);
            this.lblValComputer.Name = "lblValComputer";
            this.lblValComputer.Size = new System.Drawing.Size(19, 13);
            this.lblValComputer.TabIndex = 1;
            this.lblValComputer.Text = "PC";
            // 
            // lblColUser
            // 
            this.lblColUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColUser.AutoSize = true;
            this.lblColUser.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblColUser.Location = new System.Drawing.Point(3, 49);
            this.lblColUser.Name = "lblColUser";
            this.lblColUser.Size = new System.Drawing.Size(73, 13);
            this.lblColUser.TabIndex = 2;
            this.lblColUser.Text = "Current User:";
            // 
            // lblValUser
            // 
            this.lblValUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValUser.AutoSize = true;
            this.lblValUser.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblValUser.Location = new System.Drawing.Point(113, 49);
            this.lblValUser.Name = "lblValUser";
            this.lblValUser.Size = new System.Drawing.Size(30, 13);
            this.lblValUser.TabIndex = 3;
            this.lblValUser.Text = "User";
            // 
            // lblColIp
            // 
            this.lblColIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColIp.AutoSize = true;
            this.lblColIp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblColIp.Location = new System.Drawing.Point(3, 86);
            this.lblColIp.Name = "lblColIp";
            this.lblColIp.Size = new System.Drawing.Size(63, 13);
            this.lblColIp.TabIndex = 4;
            this.lblColIp.Text = "IP Address:";
            // 
            // lblValIp
            // 
            this.lblValIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValIp.AutoSize = true;
            this.lblValIp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblValIp.Location = new System.Drawing.Point(113, 86);
            this.lblValIp.Name = "lblValIp";
            this.lblValIp.Size = new System.Drawing.Size(52, 13);
            this.lblValIp.TabIndex = 5;
            this.lblValIp.Text = "127.0.0.1";
            // 
            // lblColOs
            // 
            this.lblColOs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColOs.AutoSize = true;
            this.lblColOs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColOs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblColOs.Location = new System.Drawing.Point(265, 12);
            this.lblColOs.Name = "lblColOs";
            this.lblColOs.Size = new System.Drawing.Size(25, 13);
            this.lblColOs.TabIndex = 6;
            this.lblColOs.Text = "OS:";
            // 
            // lblValOs
            // 
            this.lblValOs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValOs.AutoSize = true;
            this.lblValOs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValOs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblValOs.Location = new System.Drawing.Point(365, 12);
            this.lblValOs.Name = "lblValOs";
            this.lblValOs.Size = new System.Drawing.Size(55, 13);
            this.lblValOs.TabIndex = 7;
            this.lblValOs.Text = "Windows";
            // 
            // lblColConnection
            // 
            this.lblColConnection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColConnection.AutoSize = true;
            this.lblColConnection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblColConnection.Location = new System.Drawing.Point(265, 49);
            this.lblColConnection.Name = "lblColConnection";
            this.lblColConnection.Size = new System.Drawing.Size(70, 13);
            this.lblColConnection.TabIndex = 8;
            this.lblColConnection.Text = "Connection:";
            // 
            // lblValConnection
            // 
            this.lblValConnection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValConnection.AutoSize = true;
            this.lblValConnection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblValConnection.Location = new System.Drawing.Point(365, 49);
            this.lblValConnection.Name = "lblValConnection";
            this.lblValConnection.Size = new System.Drawing.Size(50, 13);
            this.lblValConnection.TabIndex = 9;
            this.lblValConnection.Text = "Ethernet";
            // 
            // lblColStatus
            // 
            this.lblColStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColStatus.AutoSize = true;
            this.lblColStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblColStatus.Location = new System.Drawing.Point(265, 86);
            this.lblColStatus.Name = "lblColStatus";
            this.lblColStatus.Size = new System.Drawing.Size(42, 13);
            this.lblColStatus.TabIndex = 10;
            this.lblColStatus.Text = "Status:";
            // 
            // lblValStatus
            // 
            this.lblValStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValStatus.AutoSize = true;
            this.lblValStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblValStatus.Location = new System.Drawing.Point(365, 86);
            this.lblValStatus.Name = "lblValStatus";
            this.lblValStatus.Size = new System.Drawing.Size(53, 13);
            this.lblValStatus.TabIndex = 11;
            this.lblValStatus.Text = "● Online";
            // 
            // groupQuickActions
            // 
            this.groupQuickActions.BackColor = System.Drawing.Color.White;
            this.groupQuickActions.Controls.Add(this.flowQuickActions);
            this.groupQuickActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupQuickActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupQuickActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupQuickActions.Location = new System.Drawing.Point(552, 9);
            this.groupQuickActions.Name = "groupQuickActions";
            this.groupQuickActions.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.groupQuickActions.Size = new System.Drawing.Size(387, 144);
            this.groupQuickActions.TabIndex = 1;
            this.groupQuickActions.TabStop = false;
            this.groupQuickActions.Text = "Get Started";
            // 
            // flowQuickActions
            // 
            this.flowQuickActions.Controls.Add(this.btnQuickSend);
            this.flowQuickActions.Controls.Add(this.btnQuickReceive);
            this.flowQuickActions.Controls.Add(this.btnQuickDevices);
            this.flowQuickActions.Controls.Add(this.btnQuickExplorer);
            this.flowQuickActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowQuickActions.Location = new System.Drawing.Point(10, 24);
            this.flowQuickActions.Name = "flowQuickActions";
            this.flowQuickActions.Size = new System.Drawing.Size(367, 112);
            this.flowQuickActions.TabIndex = 0;
            // 
            // btnQuickSend
            // 
            this.btnQuickSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuickSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickSend.FlatAppearance.BorderSize = 0;
            this.btnQuickSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickSend.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickSend.ForeColor = System.Drawing.Color.White;
            this.btnQuickSend.Location = new System.Drawing.Point(4, 4);
            this.btnQuickSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuickSend.Name = "btnQuickSend";
            this.btnQuickSend.Size = new System.Drawing.Size(170, 46);
            this.btnQuickSend.TabIndex = 0;
            this.btnQuickSend.Text = "📤  Send Files...";
            this.btnQuickSend.UseVisualStyleBackColor = false;
            this.btnQuickSend.Click += new System.EventHandler(this.BtnQuickSend_Click);
            // 
            // btnQuickReceive
            // 
            this.btnQuickReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.btnQuickReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReceive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQuickReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReceive.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.btnQuickReceive.Location = new System.Drawing.Point(182, 4);
            this.btnQuickReceive.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuickReceive.Name = "btnQuickReceive";
            this.btnQuickReceive.Size = new System.Drawing.Size(170, 46);
            this.btnQuickReceive.TabIndex = 1;
            this.btnQuickReceive.Text = "📥  Receive Files";
            this.btnQuickReceive.UseVisualStyleBackColor = false;
            this.btnQuickReceive.Click += new System.EventHandler(this.BtnQuickReceive_Click);
            // 
            // btnQuickDevices
            // 
            this.btnQuickDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.btnQuickDevices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickDevices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQuickDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickDevices.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickDevices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.btnQuickDevices.Location = new System.Drawing.Point(4, 58);
            this.btnQuickDevices.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuickDevices.Name = "btnQuickDevices";
            this.btnQuickDevices.Size = new System.Drawing.Size(170, 46);
            this.btnQuickDevices.TabIndex = 2;
            this.btnQuickDevices.Text = "🔍  Browse Devices";
            this.btnQuickDevices.UseVisualStyleBackColor = false;
            this.btnQuickDevices.Click += new System.EventHandler(this.BtnQuickDevices_Click);
            // 
            // btnQuickExplorer
            // 
            this.btnQuickExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.btnQuickExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickExplorer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnQuickExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickExplorer.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.btnQuickExplorer.Location = new System.Drawing.Point(182, 58);
            this.btnQuickExplorer.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuickExplorer.Name = "btnQuickExplorer";
            this.btnQuickExplorer.Size = new System.Drawing.Size(170, 46);
            this.btnQuickExplorer.TabIndex = 3;
            this.btnQuickExplorer.Text = "📁  Open Explorer";
            this.btnQuickExplorer.UseVisualStyleBackColor = false;
            this.btnQuickExplorer.Click += new System.EventHandler(this.BtnQuickExplorer_Click);
            // 
            // splitRecentAndDevices
            // 
            this.splitRecentAndDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRecentAndDevices.Location = new System.Drawing.Point(0, 214);
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
            this.splitRecentAndDevices.Size = new System.Drawing.Size(950, 406);
            this.splitRecentAndDevices.SplitterDistance = 580;
            this.splitRecentAndDevices.TabIndex = 2;
            // 
            // groupRecentTransfers
            // 
            this.groupRecentTransfers.BackColor = System.Drawing.Color.White;
            this.groupRecentTransfers.Controls.Add(this.dgvRecentTransfers);
            this.groupRecentTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRecentTransfers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRecentTransfers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupRecentTransfers.Location = new System.Drawing.Point(8, 4);
            this.groupRecentTransfers.Name = "groupRecentTransfers";
            this.groupRecentTransfers.Padding = new System.Windows.Forms.Padding(8);
            this.groupRecentTransfers.Size = new System.Drawing.Size(568, 394);
            this.groupRecentTransfers.TabIndex = 0;
            this.groupRecentTransfers.TabStop = false;
            this.groupRecentTransfers.Text = "Recent Transfers";
            // 
            // dgvRecentTransfers
            // 
            this.dgvRecentTransfers.AllowUserToAddRows = false;
            this.dgvRecentTransfers.AllowUserToDeleteRows = false;
            this.dgvRecentTransfers.AllowUserToResizeRows = false;
            this.dgvRecentTransfers.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentTransfers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentTransfers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentTransfers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgvCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dgvCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            dgvCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentTransfers.ColumnHeadersDefaultCellStyle = dgvCellStyle1;
            this.dgvRecentTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentTransfers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecentFile,
            this.colRecentPeer,
            this.colRecentSize,
            this.colRecentStatus,
            this.colRecentDate});
            dgvCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dgvCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            dgvCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dgvCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentTransfers.DefaultCellStyle = dgvCellStyle2;
            this.dgvRecentTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentTransfers.EnableHeadersVisualStyles = false;
            this.dgvRecentTransfers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.dgvRecentTransfers.Location = new System.Drawing.Point(8, 24);
            this.dgvRecentTransfers.MultiSelect = false;
            this.dgvRecentTransfers.Name = "dgvRecentTransfers";
            this.dgvRecentTransfers.ReadOnly = true;
            this.dgvRecentTransfers.RowHeadersVisible = false;
            this.dgvRecentTransfers.RowTemplate.Height = 24;
            this.dgvRecentTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentTransfers.Size = new System.Drawing.Size(552, 362);
            this.dgvRecentTransfers.TabIndex = 0;
            this.dgvRecentTransfers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecentTransfers_CellDoubleClick);
            // 
            // colRecentFile
            // 
            this.colRecentFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRecentFile.FillWeight = 140F;
            this.colRecentFile.HeaderText = "File Name";
            this.colRecentFile.Name = "colRecentFile";
            this.colRecentFile.ReadOnly = true;
            // 
            // colRecentPeer
            // 
            this.colRecentPeer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRecentPeer.FillWeight = 90F;
            this.colRecentPeer.HeaderText = "Peer";
            this.colRecentPeer.Name = "colRecentPeer";
            this.colRecentPeer.ReadOnly = true;
            // 
            // colRecentSize
            // 
            this.colRecentSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRecentSize.HeaderText = "Size";
            this.colRecentSize.Name = "colRecentSize";
            this.colRecentSize.ReadOnly = true;
            this.colRecentSize.Width = 55;
            // 
            // colRecentStatus
            // 
            this.colRecentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRecentStatus.HeaderText = "Status";
            this.colRecentStatus.Name = "colRecentStatus";
            this.colRecentStatus.ReadOnly = true;
            this.colRecentStatus.Width = 66;
            // 
            // colRecentDate
            // 
            this.colRecentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRecentDate.HeaderText = "Date";
            this.colRecentDate.Name = "colRecentDate";
            this.colRecentDate.ReadOnly = true;
            this.colRecentDate.Width = 57;
            // 
            // groupDevicesOnline
            // 
            this.groupDevicesOnline.BackColor = System.Drawing.Color.White;
            this.groupDevicesOnline.Controls.Add(this.listDevicesOnline);
            this.groupDevicesOnline.Controls.Add(this.panelDevicesHeader);
            this.groupDevicesOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDevicesOnline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDevicesOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupDevicesOnline.Location = new System.Drawing.Point(4, 4);
            this.groupDevicesOnline.Name = "groupDevicesOnline";
            this.groupDevicesOnline.Padding = new System.Windows.Forms.Padding(8);
            this.groupDevicesOnline.Size = new System.Drawing.Size(354, 394);
            this.groupDevicesOnline.TabIndex = 0;
            this.groupDevicesOnline.TabStop = false;
            this.groupDevicesOnline.Text = "Devices Online";
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
            this.listDevicesOnline.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDevicesOnline.FullRowSelect = true;
            this.listDevicesOnline.GridLines = true;
            this.listDevicesOnline.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listDevicesOnline.Location = new System.Drawing.Point(8, 50);
            this.listDevicesOnline.MultiSelect = false;
            this.listDevicesOnline.Name = "listDevicesOnline";
            this.listDevicesOnline.Size = new System.Drawing.Size(338, 336);
            this.listDevicesOnline.TabIndex = 0;
            this.listDevicesOnline.UseCompatibleStateImageBehavior = false;
            this.listDevicesOnline.View = System.Windows.Forms.View.Details;
            // 
            // colDevName
            // 
            this.colDevName.Text = "Device Name";
            this.colDevName.Width = 120;
            // 
            // colDevIp
            // 
            this.colDevIp.Text = "IP Address";
            this.colDevIp.Width = 90;
            // 
            // colDevType
            // 
            this.colDevType.Text = "Network";
            this.colDevType.Width = 65;
            // 
            // colDevState
            // 
            this.colDevState.Text = "State";
            this.colDevState.Width = 60;
            // 
            // panelDevicesHeader
            // 
            this.panelDevicesHeader.Controls.Add(this.lblDevicesCount);
            this.panelDevicesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDevicesHeader.Location = new System.Drawing.Point(8, 24);
            this.panelDevicesHeader.Name = "panelDevicesHeader";
            this.panelDevicesHeader.Size = new System.Drawing.Size(338, 26);
            this.panelDevicesHeader.TabIndex = 1;
            // 
            // lblDevicesCount
            // 
            this.lblDevicesCount.AutoSize = true;
            this.lblDevicesCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevicesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblDevicesCount.Location = new System.Drawing.Point(4, 6);
            this.lblDevicesCount.Name = "lblDevicesCount";
            this.lblDevicesCount.Size = new System.Drawing.Size(91, 13);
            this.lblDevicesCount.TabIndex = 0;
            this.lblDevicesCount.Text = "0 device(s) online";
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitRecentAndDevices);
            this.Controls.Add(this.tableMainLayout);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
