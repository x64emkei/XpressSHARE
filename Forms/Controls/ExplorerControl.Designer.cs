namespace XpressShare.Forms.Controls
{
    partial class ExplorerControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTopBars;
        private System.Windows.Forms.ToolStrip toolStripNav;
        private System.Windows.Forms.ToolStripButton btnNavBack;
        private System.Windows.Forms.ToolStripButton btnNavForward;
        private System.Windows.Forms.ToolStripButton btnNavUp;
        private System.Windows.Forms.ToolStripButton btnNavRefresh;
        private System.Windows.Forms.ToolStripSeparator navSep1;
        private System.Windows.Forms.ToolStripTextBox txtAddress;
        private System.Windows.Forms.ToolStripSeparator navSep2;
        private System.Windows.Forms.ToolStripTextBox txtSearch;

        private System.Windows.Forms.ToolStrip toolStripActions;
        private System.Windows.Forms.ToolStripButton btnActNewFolder;
        private System.Windows.Forms.ToolStripButton btnActSend;
        private System.Windows.Forms.ToolStripButton btnActCopy;
        private System.Windows.Forms.ToolStripButton btnActDelete;
        private System.Windows.Forms.ToolStripSeparator actSep1;
        private System.Windows.Forms.ToolStripButton btnActToggleDual;
        private System.Windows.Forms.ToolStripDropDownButton btnActViewMode;
        private System.Windows.Forms.ToolStripMenuItem menuDetails;
        private System.Windows.Forms.ToolStripMenuItem menuList;
        private System.Windows.Forms.ToolStripMenuItem menuIcons;

        private System.Windows.Forms.SplitContainer splitPanes;

        // Left Pane (Local)
        private System.Windows.Forms.Panel panelLocal;
        private System.Windows.Forms.Panel panelLocalHeader;
        private System.Windows.Forms.Label lblLocalHeaderTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLocalShortcuts;
        private System.Windows.Forms.Button btnJumpThisPc;
        private System.Windows.Forms.Button btnJumpDesktop;
        private System.Windows.Forms.Button btnJumpDocuments;
        private System.Windows.Forms.Button btnJumpDownloads;
        private System.Windows.Forms.Button btnJumpPictures;
        private System.Windows.Forms.ListView listLocal;
        private System.Windows.Forms.ColumnHeader colLocalName;
        private System.Windows.Forms.ColumnHeader colLocalModified;
        private System.Windows.Forms.ColumnHeader colLocalType;
        private System.Windows.Forms.ColumnHeader colLocalSize;
        private System.Windows.Forms.ColumnHeader colLocalStatus;

        // Right Pane (Remote/Target)
        private System.Windows.Forms.Panel panelRemote;
        private System.Windows.Forms.Panel panelRemoteHeader;
        private System.Windows.Forms.Label lblRemoteHeaderTitle;
        private System.Windows.Forms.ComboBox cboRemotePeer;
        private System.Windows.Forms.ListView listRemote;
        private System.Windows.Forms.ColumnHeader colRemoteName;
        private System.Windows.Forms.ColumnHeader colRemoteModified;
        private System.Windows.Forms.ColumnHeader colRemoteType;
        private System.Windows.Forms.ColumnHeader colRemoteSize;
        private System.Windows.Forms.ColumnHeader colRemoteStatus;

        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblStatusInfo;

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
            this.panelTopBars = new System.Windows.Forms.Panel();
            this.toolStripActions = new System.Windows.Forms.ToolStrip();
            this.btnActNewFolder = new System.Windows.Forms.ToolStripButton();
            this.btnActSend = new System.Windows.Forms.ToolStripButton();
            this.btnActCopy = new System.Windows.Forms.ToolStripButton();
            this.btnActDelete = new System.Windows.Forms.ToolStripButton();
            this.actSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActToggleDual = new System.Windows.Forms.ToolStripButton();
            this.btnActViewMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNav = new System.Windows.Forms.ToolStrip();
            this.btnNavBack = new System.Windows.Forms.ToolStripButton();
            this.btnNavForward = new System.Windows.Forms.ToolStripButton();
            this.btnNavUp = new System.Windows.Forms.ToolStripButton();
            this.btnNavRefresh = new System.Windows.Forms.ToolStripButton();
            this.navSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtAddress = new System.Windows.Forms.ToolStripTextBox();
            this.navSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.splitPanes = new System.Windows.Forms.SplitContainer();
            this.panelLocal = new System.Windows.Forms.Panel();
            this.listLocal = new System.Windows.Forms.ListView();
            this.colLocalName = new System.Windows.Forms.ColumnHeader();
            this.colLocalModified = new System.Windows.Forms.ColumnHeader();
            this.colLocalType = new System.Windows.Forms.ColumnHeader();
            this.colLocalSize = new System.Windows.Forms.ColumnHeader();
            this.colLocalStatus = new System.Windows.Forms.ColumnHeader();
            this.panelLocalHeader = new System.Windows.Forms.Panel();
            this.flowLocalShortcuts = new System.Windows.Forms.FlowLayoutPanel();
            this.btnJumpThisPc = new System.Windows.Forms.Button();
            this.btnJumpDesktop = new System.Windows.Forms.Button();
            this.btnJumpDocuments = new System.Windows.Forms.Button();
            this.btnJumpDownloads = new System.Windows.Forms.Button();
            this.btnJumpPictures = new System.Windows.Forms.Button();
            this.lblLocalHeaderTitle = new System.Windows.Forms.Label();
            this.panelRemote = new System.Windows.Forms.Panel();
            this.listRemote = new System.Windows.Forms.ListView();
            this.colRemoteName = new System.Windows.Forms.ColumnHeader();
            this.colRemoteModified = new System.Windows.Forms.ColumnHeader();
            this.colRemoteType = new System.Windows.Forms.ColumnHeader();
            this.colRemoteSize = new System.Windows.Forms.ColumnHeader();
            this.colRemoteStatus = new System.Windows.Forms.ColumnHeader();
            this.panelRemoteHeader = new System.Windows.Forms.Panel();
            this.cboRemotePeer = new System.Windows.Forms.ComboBox();
            this.lblRemoteHeaderTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.panelTopBars.SuspendLayout();
            this.toolStripActions.SuspendLayout();
            this.toolStripNav.SuspendLayout();
            this.splitPanes.Panel1.SuspendLayout();
            this.splitPanes.Panel2.SuspendLayout();
            this.splitPanes.SuspendLayout();
            this.panelLocal.SuspendLayout();
            this.panelLocalHeader.SuspendLayout();
            this.flowLocalShortcuts.SuspendLayout();
            this.panelRemote.SuspendLayout();
            this.panelRemoteHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopBars
            // 
            this.panelTopBars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelTopBars.Controls.Add(this.toolStripActions);
            this.panelTopBars.Controls.Add(this.toolStripNav);
            this.panelTopBars.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBars.Location = new System.Drawing.Point(0, 0);
            this.panelTopBars.Name = "panelTopBars";
            this.panelTopBars.Size = new System.Drawing.Size(950, 60);
            this.panelTopBars.TabIndex = 0;
            // 
            // toolStripActions
            // 
            this.toolStripActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.toolStripActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActNewFolder,
            this.btnActSend,
            this.btnActCopy,
            this.btnActDelete,
            this.actSep1,
            this.btnActToggleDual,
            this.btnActViewMode});
            this.toolStripActions.Location = new System.Drawing.Point(0, 30);
            this.toolStripActions.Name = "toolStripActions";
            this.toolStripActions.Padding = new System.Windows.Forms.Padding(6, 1, 6, 1);
            this.toolStripActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripActions.Size = new System.Drawing.Size(950, 27);
            this.toolStripActions.TabIndex = 1;
            // 
            // btnActNewFolder
            // 
            this.btnActNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActNewFolder.Name = "btnActNewFolder";
            this.btnActNewFolder.Size = new System.Drawing.Size(89, 22);
            this.btnActNewFolder.Text = "📁 New Folder";
            this.btnActNewFolder.Click += new System.EventHandler(this.BtnActNewFolder_Click);
            // 
            // btnActSend
            // 
            this.btnActSend.Enabled = false;
            this.btnActSend.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnActSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActSend.Name = "btnActSend";
            this.btnActSend.Size = new System.Drawing.Size(89, 22);
            this.btnActSend.Text = "📤 Send To...";
            this.btnActSend.Click += new System.EventHandler(this.BtnActSend_Click);
            // 
            // btnActCopy
            // 
            this.btnActCopy.Enabled = false;
            this.btnActCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActCopy.Name = "btnActCopy";
            this.btnActCopy.Size = new System.Drawing.Size(55, 22);
            this.btnActCopy.Text = "📋 Copy";
            this.btnActCopy.Click += new System.EventHandler(this.BtnActCopy_Click);
            // 
            // btnActDelete
            // 
            this.btnActDelete.Enabled = false;
            this.btnActDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActDelete.Name = "btnActDelete";
            this.btnActDelete.Size = new System.Drawing.Size(61, 22);
            this.btnActDelete.Text = "🗑 Delete";
            this.btnActDelete.Click += new System.EventHandler(this.BtnActDelete_Click);
            // 
            // actSep1
            // 
            this.actSep1.Name = "actSep1";
            this.actSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActToggleDual
            // 
            this.btnActToggleDual.CheckOnClick = true;
            this.btnActToggleDual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActToggleDual.Name = "btnActToggleDual";
            this.btnActToggleDual.Size = new System.Drawing.Size(107, 22);
            this.btnActToggleDual.Text = "◫ Dual Pane (WinSCP)";
            this.btnActToggleDual.Click += new System.EventHandler(this.BtnActToggleDual_Click);
            // 
            // btnActViewMode
            // 
            this.btnActViewMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDetails,
            this.menuList,
            this.menuIcons});
            this.btnActViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActViewMode.Name = "btnActViewMode";
            this.btnActViewMode.Size = new System.Drawing.Size(68, 22);
            this.btnActViewMode.Text = "👁 View";
            // 
            // menuDetails
            // 
            this.menuDetails.Name = "menuDetails";
            this.menuDetails.Size = new System.Drawing.Size(130, 22);
            this.menuDetails.Text = "Details";
            this.menuDetails.Click += new System.EventHandler(this.MenuDetails_Click);
            // 
            // menuList
            // 
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(130, 22);
            this.menuList.Text = "List";
            this.menuList.Click += new System.EventHandler(this.MenuList_Click);
            // 
            // menuIcons
            // 
            this.menuIcons.Name = "menuIcons";
            this.menuIcons.Size = new System.Drawing.Size(130, 22);
            this.menuIcons.Text = "Large Icons";
            this.menuIcons.Click += new System.EventHandler(this.MenuIcons_Click);
            // 
            // toolStripNav
            // 
            this.toolStripNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.toolStripNav.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNavBack,
            this.btnNavForward,
            this.btnNavUp,
            this.btnNavRefresh,
            this.navSep1,
            this.txtAddress,
            this.navSep2,
            this.txtSearch});
            this.toolStripNav.Location = new System.Drawing.Point(0, 0);
            this.toolStripNav.Name = "toolStripNav";
            this.toolStripNav.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.toolStripNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripNav.Size = new System.Drawing.Size(950, 30);
            this.toolStripNav.TabIndex = 0;
            // 
            // btnNavBack
            // 
            this.btnNavBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavBack.Enabled = false;
            this.btnNavBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavBack.Name = "btnNavBack";
            this.btnNavBack.Size = new System.Drawing.Size(23, 23);
            this.btnNavBack.Text = "◀";
            this.btnNavBack.ToolTipText = "Back";
            this.btnNavBack.Click += new System.EventHandler(this.BtnNavBack_Click);
            // 
            // btnNavForward
            // 
            this.btnNavForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavForward.Enabled = false;
            this.btnNavForward.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavForward.Name = "btnNavForward";
            this.btnNavForward.Size = new System.Drawing.Size(23, 23);
            this.btnNavForward.Text = "▶";
            this.btnNavForward.ToolTipText = "Forward";
            this.btnNavForward.Click += new System.EventHandler(this.BtnNavForward_Click);
            // 
            // btnNavUp
            // 
            this.btnNavUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavUp.Name = "btnNavUp";
            this.btnNavUp.Size = new System.Drawing.Size(23, 23);
            this.btnNavUp.Text = "⬆";
            this.btnNavUp.ToolTipText = "Up to Parent Directory";
            this.btnNavUp.Click += new System.EventHandler(this.BtnNavUp_Click);
            // 
            // btnNavRefresh
            // 
            this.btnNavRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNavRefresh.Name = "btnNavRefresh";
            this.btnNavRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnNavRefresh.Text = "🔄";
            this.btnNavRefresh.ToolTipText = "Refresh";
            this.btnNavRefresh.Click += new System.EventHandler(this.BtnNavRefresh_Click);
            // 
            // navSep1
            // 
            this.navSep1.Name = "navSep1";
            this.navSep1.Size = new System.Drawing.Size(6, 26);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(460, 26);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddress_KeyDown);
            // 
            // navSep2
            // 
            this.navSep2.Name = "navSep2";
            this.navSep2.Size = new System.Drawing.Size(6, 26);
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 26);
            this.txtSearch.Text = "Search files...";
            this.txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // splitPanes
            // 
            this.splitPanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanes.Location = new System.Drawing.Point(0, 60);
            this.splitPanes.Name = "splitPanes";
            // 
            // splitPanes.Panel1
            // 
            this.splitPanes.Panel1.Controls.Add(this.listLocal);
            this.splitPanes.Panel1.Controls.Add(this.panelLocalHeader);
            // 
            // splitPanes.Panel2
            // 
            this.splitPanes.Panel2.Controls.Add(this.listRemote);
            this.splitPanes.Panel2.Controls.Add(this.panelRemoteHeader);
            this.splitPanes.Panel2Collapsed = true;
            this.splitPanes.Size = new System.Drawing.Size(950, 536);
            this.splitPanes.SplitterDistance = 475;
            this.splitPanes.TabIndex = 1;
            // 
            // panelLocal
            // 
            this.panelLocal.Location = new System.Drawing.Point(0, 0);
            this.panelLocal.Name = "panelLocal";
            this.panelLocal.Size = new System.Drawing.Size(200, 100);
            this.panelLocal.TabIndex = 0;
            // 
            // listLocal
            // 
            this.listLocal.AllowDrop = true;
            this.listLocal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLocalName,
            this.colLocalModified,
            this.colLocalType,
            this.colLocalSize,
            this.colLocalStatus});
            this.listLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLocal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLocal.FullRowSelect = true;
            this.listLocal.GridLines = true;
            this.listLocal.HideSelection = false;
            this.listLocal.Location = new System.Drawing.Point(0, 32);
            this.listLocal.Name = "listLocal";
            this.listLocal.Size = new System.Drawing.Size(950, 504);
            this.listLocal.TabIndex = 1;
            this.listLocal.UseCompatibleStateImageBehavior = false;
            this.listLocal.View = System.Windows.Forms.View.Details;
            this.listLocal.ItemActivate += new System.EventHandler(this.ListLocal_ItemActivate);
            this.listLocal.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListLocal_ItemDrag);
            this.listLocal.SelectedIndexChanged += new System.EventHandler(this.ListLocal_SelectedIndexChanged);
            // 
            // colLocalName
            // 
            this.colLocalName.Text = "Name";
            this.colLocalName.Width = 260;
            // 
            // colLocalModified
            // 
            this.colLocalModified.Text = "Date Modified";
            this.colLocalModified.Width = 130;
            // 
            // colLocalType
            // 
            this.colLocalType.Text = "Type";
            this.colLocalType.Width = 100;
            // 
            // colLocalSize
            // 
            this.colLocalSize.Text = "Size";
            this.colLocalSize.Width = 85;
            // 
            // colLocalStatus
            // 
            this.colLocalStatus.Text = "Status";
            this.colLocalStatus.Width = 80;
            // 
            // panelLocalHeader
            // 
            this.panelLocalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.panelLocalHeader.Controls.Add(this.flowLocalShortcuts);
            this.panelLocalHeader.Controls.Add(this.lblLocalHeaderTitle);
            this.panelLocalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLocalHeader.Location = new System.Drawing.Point(0, 0);
            this.panelLocalHeader.Name = "panelLocalHeader";
            this.panelLocalHeader.Size = new System.Drawing.Size(950, 32);
            this.panelLocalHeader.TabIndex = 0;
            // 
            // flowLocalShortcuts
            // 
            this.flowLocalShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLocalShortcuts.Controls.Add(this.btnJumpThisPc);
            this.flowLocalShortcuts.Controls.Add(this.btnJumpDesktop);
            this.flowLocalShortcuts.Controls.Add(this.btnJumpDocuments);
            this.flowLocalShortcuts.Controls.Add(this.btnJumpDownloads);
            this.flowLocalShortcuts.Controls.Add(this.btnJumpPictures);
            this.flowLocalShortcuts.Location = new System.Drawing.Point(520, 2);
            this.flowLocalShortcuts.Name = "flowLocalShortcuts";
            this.flowLocalShortcuts.Size = new System.Drawing.Size(425, 28);
            this.flowLocalShortcuts.TabIndex = 1;
            // 
            // btnJumpThisPc
            // 
            this.btnJumpThisPc.FlatAppearance.BorderSize = 0;
            this.btnJumpThisPc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpThisPc.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJumpThisPc.Location = new System.Drawing.Point(2, 2);
            this.btnJumpThisPc.Margin = new System.Windows.Forms.Padding(2);
            this.btnJumpThisPc.Name = "btnJumpThisPc";
            this.btnJumpThisPc.Size = new System.Drawing.Size(65, 23);
            this.btnJumpThisPc.TabIndex = 0;
            this.btnJumpThisPc.Text = "💻 This PC";
            this.btnJumpThisPc.UseVisualStyleBackColor = true;
            this.btnJumpThisPc.Click += new System.EventHandler(this.BtnJumpThisPc_Click);
            // 
            // btnJumpDesktop
            // 
            this.btnJumpDesktop.FlatAppearance.BorderSize = 0;
            this.btnJumpDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpDesktop.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJumpDesktop.Location = new System.Drawing.Point(71, 2);
            this.btnJumpDesktop.Margin = new System.Windows.Forms.Padding(2);
            this.btnJumpDesktop.Name = "btnJumpDesktop";
            this.btnJumpDesktop.Size = new System.Drawing.Size(65, 23);
            this.btnJumpDesktop.TabIndex = 1;
            this.btnJumpDesktop.Text = "Desktop";
            this.btnJumpDesktop.UseVisualStyleBackColor = true;
            this.btnJumpDesktop.Click += new System.EventHandler(this.BtnJumpDesktop_Click);
            // 
            // btnJumpDocuments
            // 
            this.btnJumpDocuments.FlatAppearance.BorderSize = 0;
            this.btnJumpDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpDocuments.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJumpDocuments.Location = new System.Drawing.Point(140, 2);
            this.btnJumpDocuments.Margin = new System.Windows.Forms.Padding(2);
            this.btnJumpDocuments.Name = "btnJumpDocuments";
            this.btnJumpDocuments.Size = new System.Drawing.Size(75, 23);
            this.btnJumpDocuments.TabIndex = 2;
            this.btnJumpDocuments.Text = "Documents";
            this.btnJumpDocuments.UseVisualStyleBackColor = true;
            this.btnJumpDocuments.Click += new System.EventHandler(this.BtnJumpDocuments_Click);
            // 
            // btnJumpDownloads
            // 
            this.btnJumpDownloads.FlatAppearance.BorderSize = 0;
            this.btnJumpDownloads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpDownloads.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJumpDownloads.Location = new System.Drawing.Point(219, 2);
            this.btnJumpDownloads.Margin = new System.Windows.Forms.Padding(2);
            this.btnJumpDownloads.Name = "btnJumpDownloads";
            this.btnJumpDownloads.Size = new System.Drawing.Size(75, 23);
            this.btnJumpDownloads.TabIndex = 3;
            this.btnJumpDownloads.Text = "Downloads";
            this.btnJumpDownloads.UseVisualStyleBackColor = true;
            this.btnJumpDownloads.Click += new System.EventHandler(this.BtnJumpDownloads_Click);
            // 
            // btnJumpPictures
            // 
            this.btnJumpPictures.FlatAppearance.BorderSize = 0;
            this.btnJumpPictures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpPictures.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJumpPictures.Location = new System.Drawing.Point(298, 2);
            this.btnJumpPictures.Margin = new System.Windows.Forms.Padding(2);
            this.btnJumpPictures.Name = "btnJumpPictures";
            this.btnJumpPictures.Size = new System.Drawing.Size(65, 23);
            this.btnJumpPictures.TabIndex = 4;
            this.btnJumpPictures.Text = "Pictures";
            this.btnJumpPictures.UseVisualStyleBackColor = true;
            this.btnJumpPictures.Click += new System.EventHandler(this.BtnJumpPictures_Click);
            // 
            // lblLocalHeaderTitle
            // 
            this.lblLocalHeaderTitle.AutoSize = true;
            this.lblLocalHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblLocalHeaderTitle.Location = new System.Drawing.Point(10, 8);
            this.lblLocalHeaderTitle.Name = "lblLocalHeaderTitle";
            this.lblLocalHeaderTitle.Size = new System.Drawing.Size(107, 15);
            this.lblLocalHeaderTitle.TabIndex = 0;
            this.lblLocalHeaderTitle.Text = "Local Workstation";
            // 
            // panelRemote
            // 
            this.panelRemote.Location = new System.Drawing.Point(0, 0);
            this.panelRemote.Name = "panelRemote";
            this.panelRemote.Size = new System.Drawing.Size(200, 100);
            this.panelRemote.TabIndex = 0;
            // 
            // listRemote
            // 
            this.listRemote.AllowDrop = true;
            this.listRemote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRemoteName,
            this.colRemoteModified,
            this.colRemoteType,
            this.colRemoteSize,
            this.colRemoteStatus});
            this.listRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRemote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listRemote.FullRowSelect = true;
            this.listRemote.GridLines = true;
            this.listRemote.HideSelection = false;
            this.listRemote.Location = new System.Drawing.Point(0, 32);
            this.listRemote.Name = "listRemote";
            this.listRemote.Size = new System.Drawing.Size(96, 68);
            this.listRemote.TabIndex = 1;
            this.listRemote.UseCompatibleStateImageBehavior = false;
            this.listRemote.View = System.Windows.Forms.View.Details;
            this.listRemote.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListRemote_DragDrop);
            this.listRemote.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListRemote_DragEnter);
            // 
            // colRemoteName
            // 
            this.colRemoteName.Text = "Name";
            this.colRemoteName.Width = 240;
            // 
            // colRemoteModified
            // 
            this.colRemoteModified.Text = "Date Modified";
            this.colRemoteModified.Width = 120;
            // 
            // colRemoteType
            // 
            this.colRemoteType.Text = "Type";
            this.colRemoteType.Width = 90;
            // 
            // colRemoteSize
            // 
            this.colRemoteSize.Text = "Size";
            this.colRemoteSize.Width = 80;
            // 
            // colRemoteStatus
            // 
            this.colRemoteStatus.Text = "Status";
            this.colRemoteStatus.Width = 80;
            // 
            // panelRemoteHeader
            // 
            this.panelRemoteHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.panelRemoteHeader.Controls.Add(this.cboRemotePeer);
            this.panelRemoteHeader.Controls.Add(this.lblRemoteHeaderTitle);
            this.panelRemoteHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRemoteHeader.Location = new System.Drawing.Point(0, 0);
            this.panelRemoteHeader.Name = "panelRemoteHeader";
            this.panelRemoteHeader.Size = new System.Drawing.Size(96, 32);
            this.panelRemoteHeader.TabIndex = 0;
            // 
            // cboRemotePeer
            // 
            this.cboRemotePeer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRemotePeer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRemotePeer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRemotePeer.FormattingEnabled = true;
            this.cboRemotePeer.Location = new System.Drawing.Point(-134, 5);
            this.cboRemotePeer.Name = "cboRemotePeer";
            this.cboRemotePeer.Size = new System.Drawing.Size(220, 21);
            this.cboRemotePeer.TabIndex = 1;
            this.cboRemotePeer.SelectedIndexChanged += new System.EventHandler(this.CboRemotePeer_SelectedIndexChanged);
            // 
            // lblRemoteHeaderTitle
            // 
            this.lblRemoteHeaderTitle.AutoSize = true;
            this.lblRemoteHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoteHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblRemoteHeaderTitle.Location = new System.Drawing.Point(10, 8);
            this.lblRemoteHeaderTitle.Name = "lblRemoteHeaderTitle";
            this.lblRemoteHeaderTitle.Size = new System.Drawing.Size(120, 15);
            this.lblRemoteHeaderTitle.TabIndex = 0;
            this.lblRemoteHeaderTitle.Text = "Remote Peer / Target";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelFooter.Controls.Add(this.lblStatusInfo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 596);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(950, 24);
            this.panelFooter.TabIndex = 2;
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.AutoSize = true;
            this.lblStatusInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblStatusInfo.Location = new System.Drawing.Point(8, 5);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(43, 13);
            this.lblStatusInfo.TabIndex = 0;
            this.lblStatusInfo.Text = "0 items";
            // 
            // ExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitPanes);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelTopBars);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ExplorerControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.panelTopBars.ResumeLayout(false);
            this.panelTopBars.PerformLayout();
            this.toolStripActions.ResumeLayout(false);
            this.toolStripActions.PerformLayout();
            this.toolStripNav.ResumeLayout(false);
            this.toolStripNav.PerformLayout();
            this.splitPanes.Panel1.ResumeLayout(false);
            this.splitPanes.Panel2.ResumeLayout(false);
            this.splitPanes.ResumeLayout(false);
            this.panelLocal.ResumeLayout(false);
            this.panelLocalHeader.ResumeLayout(false);
            this.panelLocalHeader.PerformLayout();
            this.flowLocalShortcuts.ResumeLayout(false);
            this.panelRemote.ResumeLayout(false);
            this.panelRemoteHeader.ResumeLayout(false);
            this.panelRemoteHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
