namespace XpressShare.Forms.Controls
{
    partial class SendControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelAccent;

        private System.Windows.Forms.TableLayoutPanel tableLayout;

        // Source Box
        private System.Windows.Forms.GroupBox groupSource;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colFilePath;
        private System.Windows.Forms.ColumnHeader colFileSize;
        private System.Windows.Forms.ColumnHeader colFileStatus;
        private System.Windows.Forms.Panel panelSourceToolbar;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblFileSummary;

        // Destination Box
        private System.Windows.Forms.GroupBox groupDestination;
        private System.Windows.Forms.Label lblDevicePrompt;
        private System.Windows.Forms.ComboBox cboTargetDevice;
        private System.Windows.Forms.Button btnScanDevices;
        private System.Windows.Forms.Label lblFolderPrompt;
        private System.Windows.Forms.ComboBox cboTargetFolder;

        // Options Box
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.CheckBox chkVerifyChecksum;
        private System.Windows.Forms.CheckBox chkCompress;

        // Action Panel
        private System.Windows.Forms.Panel panelActionFooter;
        private System.Windows.Forms.Button btnSendNow;
        private System.Windows.Forms.Label lblHintStatus;

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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupSource = new System.Windows.Forms.GroupBox();
            this.listFiles = new System.Windows.Forms.ListView();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colFilePath = new System.Windows.Forms.ColumnHeader();
            this.colFileSize = new System.Windows.Forms.ColumnHeader();
            this.colFileStatus = new System.Windows.Forms.ColumnHeader();
            this.panelSourceToolbar = new System.Windows.Forms.Panel();
            this.lblFileSummary = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.groupDestination = new System.Windows.Forms.GroupBox();
            this.cboTargetFolder = new System.Windows.Forms.ComboBox();
            this.lblFolderPrompt = new System.Windows.Forms.Label();
            this.btnScanDevices = new System.Windows.Forms.Button();
            this.cboTargetDevice = new System.Windows.Forms.ComboBox();
            this.lblDevicePrompt = new System.Windows.Forms.Label();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.chkCompress = new System.Windows.Forms.CheckBox();
            this.chkVerifyChecksum = new System.Windows.Forms.CheckBox();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.panelActionFooter = new System.Windows.Forms.Panel();
            this.lblHintStatus = new System.Windows.Forms.Label();
            this.btnSendNow = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.tableLayout.SuspendLayout();
            this.groupSource.SuspendLayout();
            this.panelSourceToolbar.SuspendLayout();
            this.groupDestination.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.panelActionFooter.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(168, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Send Files && Folders";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblSubtitle.Location = new System.Drawing.Point(15, 31);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(351, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Select items to package and securely transfer to a network recipient";
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
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayout.Controls.Add(this.groupSource, 0, 0);
            this.tableLayout.Controls.Add(this.groupDestination, 1, 0);
            this.tableLayout.Controls.Add(this.groupOptions, 1, 1);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 54);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.Padding = new System.Windows.Forms.Padding(8, 6, 8, 4);
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayout.Size = new System.Drawing.Size(950, 498);
            this.tableLayout.TabIndex = 1;
            // 
            // groupSource
            // 
            this.groupSource.BackColor = System.Drawing.Color.White;
            this.groupSource.Controls.Add(this.listFiles);
            this.groupSource.Controls.Add(this.panelSourceToolbar);
            this.groupSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSource.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupSource.Location = new System.Drawing.Point(11, 9);
            this.groupSource.Name = "groupSource";
            this.tableLayout.SetRowSpan(this.groupSource, 2);
            this.groupSource.Size = new System.Drawing.Size(554, 482);
            this.groupSource.TabIndex = 0;
            this.groupSource.TabStop = false;
            this.groupSource.Text = "Source Files to Send";
            // 
            // listFiles
            // 
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colFilePath,
            this.colFileSize,
            this.colFileStatus});
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFiles.FullRowSelect = true;
            this.listFiles.GridLines = true;
            this.listFiles.Location = new System.Drawing.Point(3, 55);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(548, 424);
            this.listFiles.TabIndex = 1;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.ListFiles_SelectedIndexChanged);
            // 
            // colFileName
            // 
            this.colFileName.Text = "File Name";
            this.colFileName.Width = 190;
            // 
            // colFilePath
            // 
            this.colFilePath.Text = "Folder Path";
            this.colFilePath.Width = 190;
            // 
            // colFileSize
            // 
            this.colFileSize.Text = "Size";
            this.colFileSize.Width = 80;
            // 
            // colFileStatus
            // 
            this.colFileStatus.Text = "Status";
            this.colFileStatus.Width = 70;
            // 
            // panelSourceToolbar
            // 
            this.panelSourceToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelSourceToolbar.Controls.Add(this.lblFileSummary);
            this.panelSourceToolbar.Controls.Add(this.btnClearAll);
            this.panelSourceToolbar.Controls.Add(this.btnRemoveSelected);
            this.panelSourceToolbar.Controls.Add(this.btnAddFolder);
            this.panelSourceToolbar.Controls.Add(this.btnAddFiles);
            this.panelSourceToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSourceToolbar.Location = new System.Drawing.Point(3, 19);
            this.panelSourceToolbar.Name = "panelSourceToolbar";
            this.panelSourceToolbar.Size = new System.Drawing.Size(548, 36);
            this.panelSourceToolbar.TabIndex = 0;
            // 
            // lblFileSummary
            // 
            this.lblFileSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileSummary.AutoSize = true;
            this.lblFileSummary.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblFileSummary.Location = new System.Drawing.Point(350, 11);
            this.lblFileSummary.Name = "lblFileSummary";
            this.lblFileSummary.Size = new System.Drawing.Size(125, 13);
            this.lblFileSummary.TabIndex = 4;
            this.lblFileSummary.Text = "0 items selected (0 B)";
            this.lblFileSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClearAll
            // 
            this.btnClearAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(268, 5);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(65, 26);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.Text = "Clear";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Enabled = false;
            this.btnRemoveSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnRemoveSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveSelected.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSelected.Location = new System.Drawing.Point(197, 5);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(65, 26);
            this.btnRemoveSelected.TabIndex = 2;
            this.btnRemoveSelected.Text = "Remove";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.BtnRemoveSelected_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFolder.Location = new System.Drawing.Point(96, 5);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(95, 26);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "📁 Add Folder...";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.BtnAddFolder_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFiles.Location = new System.Drawing.Point(6, 5);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(84, 26);
            this.btnAddFiles.TabIndex = 0;
            this.btnAddFiles.Text = "📄 Add Files...";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.BtnAddFiles_Click);
            // 
            // groupDestination
            // 
            this.groupDestination.BackColor = System.Drawing.Color.White;
            this.groupDestination.Controls.Add(this.cboTargetFolder);
            this.groupDestination.Controls.Add(this.lblFolderPrompt);
            this.groupDestination.Controls.Add(this.btnScanDevices);
            this.groupDestination.Controls.Add(this.cboTargetDevice);
            this.groupDestination.Controls.Add(this.lblDevicePrompt);
            this.groupDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDestination.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupDestination.Location = new System.Drawing.Point(571, 9);
            this.groupDestination.Name = "groupDestination";
            this.groupDestination.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupDestination.Size = new System.Drawing.Size(368, 296);
            this.groupDestination.TabIndex = 1;
            this.groupDestination.TabStop = false;
            this.groupDestination.Text = "Destination";
            // 
            // cboTargetFolder
            // 
            this.cboTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTargetFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetFolder.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTargetFolder.FormattingEnabled = true;
            this.cboTargetFolder.Items.AddRange(new object[] {
            "Downloads",
            "Desktop",
            "Documents",
            "Custom Path"});
            this.cboTargetFolder.Location = new System.Drawing.Point(15, 120);
            this.cboTargetFolder.Name = "cboTargetFolder";
            this.cboTargetFolder.Size = new System.Drawing.Size(335, 21);
            this.cboTargetFolder.TabIndex = 4;
            // 
            // lblFolderPrompt
            // 
            this.lblFolderPrompt.AutoSize = true;
            this.lblFolderPrompt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblFolderPrompt.Location = new System.Drawing.Point(12, 98);
            this.lblFolderPrompt.Name = "lblFolderPrompt";
            this.lblFolderPrompt.Size = new System.Drawing.Size(104, 13);
            this.lblFolderPrompt.TabIndex = 3;
            this.lblFolderPrompt.Text = "Destination Folder:";
            // 
            // btnScanDevices
            // 
            this.btnScanDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanDevices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnScanDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanDevices.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanDevices.Location = new System.Drawing.Point(275, 49);
            this.btnScanDevices.Name = "btnScanDevices";
            this.btnScanDevices.Size = new System.Drawing.Size(75, 24);
            this.btnScanDevices.TabIndex = 2;
            this.btnScanDevices.Text = "🔍 Scan";
            this.btnScanDevices.UseVisualStyleBackColor = true;
            this.btnScanDevices.Click += new System.EventHandler(this.BtnScanDevices_Click);
            // 
            // cboTargetDevice
            // 
            this.cboTargetDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTargetDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetDevice.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTargetDevice.FormattingEnabled = true;
            this.cboTargetDevice.Location = new System.Drawing.Point(15, 51);
            this.cboTargetDevice.Name = "cboTargetDevice";
            this.cboTargetDevice.Size = new System.Drawing.Size(254, 21);
            this.cboTargetDevice.TabIndex = 1;
            this.cboTargetDevice.SelectedIndexChanged += new System.EventHandler(this.CboTargetDevice_SelectedIndexChanged);
            // 
            // lblDevicePrompt
            // 
            this.lblDevicePrompt.AutoSize = true;
            this.lblDevicePrompt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevicePrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblDevicePrompt.Location = new System.Drawing.Point(12, 29);
            this.lblDevicePrompt.Name = "lblDevicePrompt";
            this.lblDevicePrompt.Size = new System.Drawing.Size(117, 13);
            this.lblDevicePrompt.TabIndex = 0;
            this.lblDevicePrompt.Text = "Target Device (Peer):";
            // 
            // groupOptions
            // 
            this.groupOptions.BackColor = System.Drawing.Color.White;
            this.groupOptions.Controls.Add(this.chkCompress);
            this.groupOptions.Controls.Add(this.chkVerifyChecksum);
            this.groupOptions.Controls.Add(this.chkEncrypt);
            this.groupOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupOptions.Location = new System.Drawing.Point(571, 311);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupOptions.Size = new System.Drawing.Size(368, 180);
            this.groupOptions.TabIndex = 2;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Transfer & Security Options";
            // 
            // chkCompress
            // 
            this.chkCompress.AutoSize = true;
            this.chkCompress.Checked = true;
            this.chkCompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompress.Location = new System.Drawing.Point(15, 87);
            this.chkCompress.Name = "chkCompress";
            this.chkCompress.Size = new System.Drawing.Size(268, 17);
            this.chkCompress.TabIndex = 2;
            this.chkCompress.Text = "Compress payload stream for increased bandwidth";
            this.chkCompress.UseVisualStyleBackColor = true;
            // 
            // chkVerifyChecksum
            // 
            this.chkVerifyChecksum.AutoSize = true;
            this.chkVerifyChecksum.Checked = true;
            this.chkVerifyChecksum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyChecksum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerifyChecksum.Location = new System.Drawing.Point(15, 58);
            this.chkVerifyChecksum.Name = "chkVerifyChecksum";
            this.chkVerifyChecksum.Size = new System.Drawing.Size(248, 17);
            this.chkVerifyChecksum.TabIndex = 1;
            this.chkVerifyChecksum.Text = "Verify integrity with CRC32/SHA256 checksum";
            this.chkVerifyChecksum.UseVisualStyleBackColor = true;
            // 
            // chkEncrypt
            // 
            this.chkEncrypt.AutoSize = true;
            this.chkEncrypt.Checked = true;
            this.chkEncrypt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncrypt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEncrypt.Location = new System.Drawing.Point(15, 29);
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.Size = new System.Drawing.Size(222, 17);
            this.chkEncrypt.TabIndex = 0;
            this.chkEncrypt.Text = "Encrypt session socket with AES-256-CBC";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // panelActionFooter
            // 
            this.panelActionFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelActionFooter.Controls.Add(this.lblHintStatus);
            this.panelActionFooter.Controls.Add(this.btnSendNow);
            this.panelActionFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActionFooter.Location = new System.Drawing.Point(0, 552);
            this.panelActionFooter.Name = "panelActionFooter";
            this.panelActionFooter.Padding = new System.Windows.Forms.Padding(12, 10, 16, 10);
            this.panelActionFooter.Size = new System.Drawing.Size(950, 68);
            this.panelActionFooter.TabIndex = 2;
            // 
            // lblHintStatus
            // 
            this.lblHintStatus.AutoSize = true;
            this.lblHintStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHintStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblHintStatus.Location = new System.Drawing.Point(14, 27);
            this.lblHintStatus.Name = "lblHintStatus";
            this.lblHintStatus.Size = new System.Drawing.Size(161, 15);
            this.lblHintStatus.TabIndex = 1;
            this.lblHintStatus.Text = "Add files or folders to begin.";
            // 
            // btnSendNow
            // 
            this.btnSendNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSendNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendNow.Enabled = false;
            this.btnSendNow.FlatAppearance.BorderSize = 0;
            this.btnSendNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendNow.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendNow.ForeColor = System.Drawing.Color.White;
            this.btnSendNow.Location = new System.Drawing.Point(744, 14);
            this.btnSendNow.Name = "btnSendNow";
            this.btnSendNow.Size = new System.Drawing.Size(185, 42);
            this.btnSendNow.TabIndex = 0;
            this.btnSendNow.Text = "📤  Send Files Now";
            this.btnSendNow.UseVisualStyleBackColor = false;
            this.btnSendNow.Click += new System.EventHandler(this.BtnSendNow_Click);
            // 
            // SendControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.panelActionFooter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SendControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayout.ResumeLayout(false);
            this.groupSource.ResumeLayout(false);
            this.panelSourceToolbar.ResumeLayout(false);
            this.panelSourceToolbar.PerformLayout();
            this.groupDestination.ResumeLayout(false);
            this.groupDestination.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.panelActionFooter.ResumeLayout(false);
            this.panelActionFooter.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
