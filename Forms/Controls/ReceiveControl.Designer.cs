namespace XpressShare.Forms.Controls
{
    partial class ReceiveControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelAccent;

        private System.Windows.Forms.TableLayoutPanel tableTopLayout;

        // Pending Group
        private System.Windows.Forms.GroupBox groupPending;
        private System.Windows.Forms.Panel panelPendingBanner;
        private System.Windows.Forms.TableLayoutPanel tablePendingDetails;
        private System.Windows.Forms.Label lblPendingPeer;
        private System.Windows.Forms.Label lblPendingPeerVal;
        private System.Windows.Forms.Label lblPendingFile;
        private System.Windows.Forms.Label lblPendingFileVal;
        private System.Windows.Forms.Label lblPendingSize;
        private System.Windows.Forms.Label lblPendingSizeVal;
        private System.Windows.Forms.Label lblPendingDest;
        private System.Windows.Forms.Label lblPendingDestVal;
        private System.Windows.Forms.Panel panelPendingButtons;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblNoPending;

        // Settings Group
        private System.Windows.Forms.GroupBox groupConfig;
        private System.Windows.Forms.Label lblDownloadPath;
        private System.Windows.Forms.TextBox txtDownloadPath;
        private System.Windows.Forms.Button btnBrowseDownload;
        private System.Windows.Forms.CheckBox chkAutoAccept;
        private System.Windows.Forms.CheckBox chkEnableListener;

        // History Group
        private System.Windows.Forms.GroupBox groupHistory;
        private System.Windows.Forms.DataGridView dgvReceivedHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistStatus;
        private System.Windows.Forms.Panel panelHistoryToolbar;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnClearHistory;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelAccent = new System.Windows.Forms.Panel();
            this.tableTopLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupPending = new System.Windows.Forms.GroupBox();
            this.panelPendingBanner = new System.Windows.Forms.Panel();
            this.panelPendingButtons = new System.Windows.Forms.Panel();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tablePendingDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblPendingPeer = new System.Windows.Forms.Label();
            this.lblPendingPeerVal = new System.Windows.Forms.Label();
            this.lblPendingFile = new System.Windows.Forms.Label();
            this.lblPendingFileVal = new System.Windows.Forms.Label();
            this.lblPendingSize = new System.Windows.Forms.Label();
            this.lblPendingSizeVal = new System.Windows.Forms.Label();
            this.lblPendingDest = new System.Windows.Forms.Label();
            this.lblPendingDestVal = new System.Windows.Forms.Label();
            this.lblNoPending = new System.Windows.Forms.Label();
            this.groupConfig = new System.Windows.Forms.GroupBox();
            this.chkEnableListener = new System.Windows.Forms.CheckBox();
            this.chkAutoAccept = new System.Windows.Forms.CheckBox();
            this.btnBrowseDownload = new System.Windows.Forms.Button();
            this.txtDownloadPath = new System.Windows.Forms.TextBox();
            this.lblDownloadPath = new System.Windows.Forms.Label();
            this.groupHistory = new System.Windows.Forms.GroupBox();
            this.dgvReceivedHistory = new System.Windows.Forms.DataGridView();
            this.colHistFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHistoryToolbar = new System.Windows.Forms.Panel();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.tableTopLayout.SuspendLayout();
            this.groupPending.SuspendLayout();
            this.panelPendingBanner.SuspendLayout();
            this.panelPendingButtons.SuspendLayout();
            this.tablePendingDetails.SuspendLayout();
            this.groupConfig.SuspendLayout();
            this.groupHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivedHistory)).BeginInit();
            this.panelHistoryToolbar.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(252, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Receive Files && Incoming Requests";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblSubtitle.Location = new System.Drawing.Point(15, 31);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(374, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Approve incoming peer transfers and review recently accepted documents";
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
            // tableTopLayout
            // 
            this.tableTopLayout.ColumnCount = 2;
            this.tableTopLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableTopLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableTopLayout.Controls.Add(this.groupPending, 0, 0);
            this.tableTopLayout.Controls.Add(this.groupConfig, 1, 0);
            this.tableTopLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableTopLayout.Location = new System.Drawing.Point(0, 54);
            this.tableTopLayout.Name = "tableTopLayout";
            this.tableTopLayout.Padding = new System.Windows.Forms.Padding(8, 6, 8, 4);
            this.tableTopLayout.RowCount = 1;
            this.tableTopLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTopLayout.Size = new System.Drawing.Size(950, 185);
            this.tableTopLayout.TabIndex = 1;
            // 
            // groupPending
            // 
            this.groupPending.BackColor = System.Drawing.Color.White;
            this.groupPending.Controls.Add(this.panelPendingBanner);
            this.groupPending.Controls.Add(this.lblNoPending);
            this.groupPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPending.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupPending.Location = new System.Drawing.Point(11, 9);
            this.groupPending.Name = "groupPending";
            this.groupPending.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.groupPending.Size = new System.Drawing.Size(507, 168);
            this.groupPending.TabIndex = 0;
            this.groupPending.TabStop = false;
            this.groupPending.Text = "Pending Incoming Transfer Approval";
            // 
            // panelPendingBanner
            // 
            this.panelPendingBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelPendingBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPendingBanner.Controls.Add(this.panelPendingButtons);
            this.panelPendingBanner.Controls.Add(this.tablePendingDetails);
            this.panelPendingBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPendingBanner.Location = new System.Drawing.Point(10, 24);
            this.panelPendingBanner.Name = "panelPendingBanner";
            this.panelPendingBanner.Padding = new System.Windows.Forms.Padding(8);
            this.panelPendingBanner.Size = new System.Drawing.Size(487, 136);
            this.panelPendingBanner.TabIndex = 0;
            this.panelPendingBanner.Visible = false;
            // 
            // panelPendingButtons
            // 
            this.panelPendingButtons.Controls.Add(this.btnReject);
            this.panelPendingButtons.Controls.Add(this.btnAccept);
            this.panelPendingButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPendingButtons.Location = new System.Drawing.Point(8, 86);
            this.panelPendingButtons.Name = "panelPendingButtons";
            this.panelPendingButtons.Size = new System.Drawing.Size(469, 38);
            this.panelPendingButtons.TabIndex = 1;
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.btnReject.Location = new System.Drawing.Point(369, 4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(95, 30);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "✕ Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.BtnReject_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(244, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 30);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "✔ Accept File";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // tablePendingDetails
            // 
            this.tablePendingDetails.ColumnCount = 2;
            this.tablePendingDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tablePendingDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePendingDetails.Controls.Add(this.lblPendingPeer, 0, 0);
            this.tablePendingDetails.Controls.Add(this.lblPendingPeerVal, 1, 0);
            this.tablePendingDetails.Controls.Add(this.lblPendingFile, 0, 1);
            this.tablePendingDetails.Controls.Add(this.lblPendingFileVal, 1, 1);
            this.tablePendingDetails.Controls.Add(this.lblPendingSize, 0, 2);
            this.tablePendingDetails.Controls.Add(this.lblPendingSizeVal, 1, 2);
            this.tablePendingDetails.Controls.Add(this.lblPendingDest, 0, 3);
            this.tablePendingDetails.Controls.Add(this.lblPendingDestVal, 1, 3);
            this.tablePendingDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePendingDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablePendingDetails.Location = new System.Drawing.Point(8, 8);
            this.tablePendingDetails.Name = "tablePendingDetails";
            this.tablePendingDetails.RowCount = 4;
            this.tablePendingDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tablePendingDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tablePendingDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tablePendingDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tablePendingDetails.Size = new System.Drawing.Size(469, 72);
            this.tablePendingDetails.TabIndex = 0;
            // 
            // lblPendingPeer
            // 
            this.lblPendingPeer.AutoSize = true;
            this.lblPendingPeer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingPeer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lblPendingPeer.Location = new System.Drawing.Point(3, 0);
            this.lblPendingPeer.Name = "lblPendingPeer";
            this.lblPendingPeer.Size = new System.Drawing.Size(37, 13);
            this.lblPendingPeer.TabIndex = 0;
            this.lblPendingPeer.Text = "From:";
            // 
            // lblPendingPeerVal
            // 
            this.lblPendingPeerVal.AutoSize = true;
            this.lblPendingPeerVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingPeerVal.Location = new System.Drawing.Point(93, 0);
            this.lblPendingPeerVal.Name = "lblPendingPeerVal";
            this.lblPendingPeerVal.Size = new System.Drawing.Size(65, 13);
            this.lblPendingPeerVal.TabIndex = 1;
            this.lblPendingPeerVal.Text = "Michael-PC";
            // 
            // lblPendingFile
            // 
            this.lblPendingFile.AutoSize = true;
            this.lblPendingFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblPendingFile.Location = new System.Drawing.Point(3, 18);
            this.lblPendingFile.Name = "lblPendingFile";
            this.lblPendingFile.Size = new System.Drawing.Size(28, 13);
            this.lblPendingFile.TabIndex = 2;
            this.lblPendingFile.Text = "File:";
            // 
            // lblPendingFileVal
            // 
            this.lblPendingFileVal.AutoSize = true;
            this.lblPendingFileVal.Location = new System.Drawing.Point(93, 18);
            this.lblPendingFileVal.Name = "lblPendingFileVal";
            this.lblPendingFileVal.Size = new System.Drawing.Size(102, 13);
            this.lblPendingFileVal.TabIndex = 3;
            this.lblPendingFileVal.Text = "presentation.pptx";
            // 
            // lblPendingSize
            // 
            this.lblPendingSize.AutoSize = true;
            this.lblPendingSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblPendingSize.Location = new System.Drawing.Point(3, 36);
            this.lblPendingSize.Name = "lblPendingSize";
            this.lblPendingSize.Size = new System.Drawing.Size(30, 13);
            this.lblPendingSize.TabIndex = 4;
            this.lblPendingSize.Text = "Size:";
            // 
            // lblPendingSizeVal
            // 
            this.lblPendingSizeVal.AutoSize = true;
            this.lblPendingSizeVal.Location = new System.Drawing.Point(93, 36);
            this.lblPendingSizeVal.Name = "lblPendingSizeVal";
            this.lblPendingSizeVal.Size = new System.Drawing.Size(46, 13);
            this.lblPendingSizeVal.TabIndex = 5;
            this.lblPendingSizeVal.Text = "4.2 MB";
            // 
            // lblPendingDest
            // 
            this.lblPendingDest.AutoSize = true;
            this.lblPendingDest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblPendingDest.Location = new System.Drawing.Point(3, 54);
            this.lblPendingDest.Name = "lblPendingDest";
            this.lblPendingDest.Size = new System.Drawing.Size(70, 13);
            this.lblPendingDest.TabIndex = 6;
            this.lblPendingDest.Text = "Destination:";
            // 
            // lblPendingDestVal
            // 
            this.lblPendingDestVal.AutoSize = true;
            this.lblPendingDestVal.Location = new System.Drawing.Point(93, 54);
            this.lblPendingDestVal.Name = "lblPendingDestVal";
            this.lblPendingDestVal.Size = new System.Drawing.Size(65, 13);
            this.lblPendingDestVal.TabIndex = 7;
            this.lblPendingDestVal.Text = "Downloads";
            // 
            // lblNoPending
            // 
            this.lblNoPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoPending.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblNoPending.Location = new System.Drawing.Point(10, 24);
            this.lblNoPending.Name = "lblNoPending";
            this.lblNoPending.Size = new System.Drawing.Size(487, 136);
            this.lblNoPending.TabIndex = 1;
            this.lblNoPending.Text = "No pending transfer approvals.\r\n\r\nIncoming requests from peer computers will app" +
                "ear here for confirmation.";
            this.lblNoPending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupConfig
            // 
            this.groupConfig.BackColor = System.Drawing.Color.White;
            this.groupConfig.Controls.Add(this.chkEnableListener);
            this.groupConfig.Controls.Add(this.chkAutoAccept);
            this.groupConfig.Controls.Add(this.btnBrowseDownload);
            this.groupConfig.Controls.Add(this.txtDownloadPath);
            this.groupConfig.Controls.Add(this.lblDownloadPath);
            this.groupConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupConfig.Location = new System.Drawing.Point(524, 9);
            this.groupConfig.Name = "groupConfig";
            this.groupConfig.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupConfig.Size = new System.Drawing.Size(415, 168);
            this.groupConfig.TabIndex = 1;
            this.groupConfig.TabStop = false;
            this.groupConfig.Text = "Receiver Configuration";
            // 
            // chkEnableListener
            // 
            this.chkEnableListener.AutoSize = true;
            this.chkEnableListener.Checked = true;
            this.chkEnableListener.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableListener.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableListener.Location = new System.Drawing.Point(15, 126);
            this.chkEnableListener.Name = "chkEnableListener";
            this.chkEnableListener.Size = new System.Drawing.Size(262, 17);
            this.chkEnableListener.TabIndex = 4;
            this.chkEnableListener.Text = "Enable LAN transfer listener socket (Port 15001)";
            this.chkEnableListener.UseVisualStyleBackColor = true;
            this.chkEnableListener.CheckedChanged += new System.EventHandler(this.ChkEnableListener_CheckedChanged);
            // 
            // chkAutoAccept
            // 
            this.chkAutoAccept.AutoSize = true;
            this.chkAutoAccept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoAccept.Location = new System.Drawing.Point(15, 95);
            this.chkAutoAccept.Name = "chkAutoAccept";
            this.chkAutoAccept.Size = new System.Drawing.Size(287, 17);
            this.chkAutoAccept.TabIndex = 3;
            this.chkAutoAccept.Text = "Automatically accept files from trusted/paired devices";
            this.chkAutoAccept.UseVisualStyleBackColor = true;
            this.chkAutoAccept.CheckedChanged += new System.EventHandler(this.ChkAutoAccept_CheckedChanged);
            // 
            // btnBrowseDownload
            // 
            this.btnBrowseDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDownload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnBrowseDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDownload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDownload.Location = new System.Drawing.Point(326, 49);
            this.btnBrowseDownload.Name = "btnBrowseDownload";
            this.btnBrowseDownload.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDownload.TabIndex = 2;
            this.btnBrowseDownload.Text = "Browse...";
            this.btnBrowseDownload.UseVisualStyleBackColor = true;
            this.btnBrowseDownload.Click += new System.EventHandler(this.BtnBrowseDownload_Click);
            // 
            // txtDownloadPath
            // 
            this.txtDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownloadPath.Location = new System.Drawing.Point(15, 50);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.ReadOnly = false;
            this.txtDownloadPath.Size = new System.Drawing.Size(305, 22);
            this.txtDownloadPath.TabIndex = 1;
            // 
            // lblDownloadPath
            // 
            this.lblDownloadPath.AutoSize = true;
            this.lblDownloadPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblDownloadPath.Location = new System.Drawing.Point(12, 28);
            this.lblDownloadPath.Name = "lblDownloadPath";
            this.lblDownloadPath.Size = new System.Drawing.Size(147, 13);
            this.lblDownloadPath.TabIndex = 0;
            this.lblDownloadPath.Text = "Default Download Location:";
            // 
            // groupHistory
            // 
            this.groupHistory.BackColor = System.Drawing.Color.White;
            this.groupHistory.Controls.Add(this.dgvReceivedHistory);
            this.groupHistory.Controls.Add(this.panelHistoryToolbar);
            this.groupHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupHistory.Location = new System.Drawing.Point(0, 239);
            this.groupHistory.Name = "groupHistory";
            this.groupHistory.Padding = new System.Windows.Forms.Padding(8);
            this.groupHistory.Size = new System.Drawing.Size(950, 381);
            this.groupHistory.TabIndex = 2;
            this.groupHistory.TabStop = false;
            this.groupHistory.Text = "Received Files History";
            // 
            // dgvReceivedHistory
            // 
            this.dgvReceivedHistory.AllowUserToAddRows = false;
            this.dgvReceivedHistory.AllowUserToDeleteRows = false;
            this.dgvReceivedHistory.AllowUserToResizeRows = false;
            this.dgvReceivedHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvReceivedHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReceivedHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReceivedHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgvCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dgvCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            dgvCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceivedHistory.ColumnHeadersDefaultCellStyle = dgvCellStyle1;
            this.dgvReceivedHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceivedHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHistFile,
            this.colHistSender,
            this.colHistSize,
            this.colHistDate,
            this.colHistStatus});
            dgvCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dgvCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            dgvCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dgvCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceivedHistory.DefaultCellStyle = dgvCellStyle2;
            this.dgvReceivedHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceivedHistory.EnableHeadersVisualStyles = false;
            this.dgvReceivedHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.dgvReceivedHistory.Location = new System.Drawing.Point(8, 24);
            this.dgvReceivedHistory.MultiSelect = false;
            this.dgvReceivedHistory.Name = "dgvReceivedHistory";
            this.dgvReceivedHistory.ReadOnly = true;
            this.dgvReceivedHistory.RowHeadersVisible = false;
            this.dgvReceivedHistory.RowTemplate.Height = 24;
            this.dgvReceivedHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceivedHistory.Size = new System.Drawing.Size(934, 317);
            this.dgvReceivedHistory.TabIndex = 0;
            this.dgvReceivedHistory.SelectionChanged += new System.EventHandler(this.DgvReceivedHistory_SelectionChanged);
            // 
            // colHistFile
            // 
            this.colHistFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHistFile.FillWeight = 160F;
            this.colHistFile.HeaderText = "File Name";
            this.colHistFile.Name = "colHistFile";
            this.colHistFile.ReadOnly = true;
            // 
            // colHistSender
            // 
            this.colHistSender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHistSender.FillWeight = 100F;
            this.colHistSender.HeaderText = "Sender (Peer)";
            this.colHistSender.Name = "colHistSender";
            this.colHistSender.ReadOnly = true;
            // 
            // colHistSize
            // 
            this.colHistSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHistSize.HeaderText = "Size";
            this.colHistSize.Name = "colHistSize";
            this.colHistSize.ReadOnly = true;
            this.colHistSize.Width = 55;
            // 
            // colHistDate
            // 
            this.colHistDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHistDate.HeaderText = "Received At";
            this.colHistDate.Name = "colHistDate";
            this.colHistDate.ReadOnly = true;
            this.colHistDate.Width = 93;
            // 
            // colHistStatus
            // 
            this.colHistStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHistStatus.HeaderText = "Status";
            this.colHistStatus.Name = "colHistStatus";
            this.colHistStatus.ReadOnly = true;
            this.colHistStatus.Width = 66;
            // 
            // panelHistoryToolbar
            // 
            this.panelHistoryToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelHistoryToolbar.Controls.Add(this.btnClearHistory);
            this.panelHistoryToolbar.Controls.Add(this.btnOpenFolder);
            this.panelHistoryToolbar.Controls.Add(this.btnOpenFile);
            this.panelHistoryToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHistoryToolbar.Location = new System.Drawing.Point(8, 341);
            this.panelHistoryToolbar.Name = "panelHistoryToolbar";
            this.panelHistoryToolbar.Padding = new System.Windows.Forms.Padding(4);
            this.panelHistoryToolbar.Size = new System.Drawing.Size(934, 32);
            this.panelHistoryToolbar.TabIndex = 1;
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearHistory.Location = new System.Drawing.Point(838, 4);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(90, 24);
            this.btnClearHistory.TabIndex = 2;
            this.btnClearHistory.Text = "Clear History";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.BtnClearHistory_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolder.Location = new System.Drawing.Point(100, 4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(145, 24);
            this.btnOpenFolder.TabIndex = 1;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Enabled = false;
            this.btnOpenFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(4, 4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(90, 24);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // ReceiveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupHistory);
            this.Controls.Add(this.tableTopLayout);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReceiveControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableTopLayout.ResumeLayout(false);
            this.groupPending.ResumeLayout(false);
            this.panelPendingBanner.ResumeLayout(false);
            this.panelPendingButtons.ResumeLayout(false);
            this.tablePendingDetails.ResumeLayout(false);
            this.tablePendingDetails.PerformLayout();
            this.groupConfig.ResumeLayout(false);
            this.groupConfig.PerformLayout();
            this.groupHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivedHistory)).EndInit();
            this.panelHistoryToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
