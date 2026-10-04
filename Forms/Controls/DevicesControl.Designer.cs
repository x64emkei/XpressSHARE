namespace XpressShare.Forms.Controls
{
    partial class DevicesControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelAccent;

        private System.Windows.Forms.Panel panelTopActions;
        private System.Windows.Forms.Button btnDiscover;
        private System.Windows.Forms.Button btnPairTop;
        private System.Windows.Forms.Button btnRefreshTop;
        private System.Windows.Forms.Label lblDeviceCount;

        private System.Windows.Forms.GroupBox groupDevices;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevTrust;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevSeen;

        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnPair;
        private System.Windows.Forms.Button btnUnpair;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnProperties;

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
            this.panelTopActions = new System.Windows.Forms.Panel();
            this.lblDeviceCount = new System.Windows.Forms.Label();
            this.btnRefreshTop = new System.Windows.Forms.Button();
            this.btnPairTop = new System.Windows.Forms.Button();
            this.btnDiscover = new System.Windows.Forms.Button();
            this.groupDevices = new System.Windows.Forms.GroupBox();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.colDevStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevTrust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnUnpair = new System.Windows.Forms.Button();
            this.btnPair = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelTopActions.SuspendLayout();
            this.groupDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.panelActions.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(236, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Network Devices && Discovery";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblSubtitle.Location = new System.Drawing.Point(15, 31);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(378, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage authorized peer nodes and discover local subnet endpoints via UDP";
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
            // panelTopActions
            // 
            this.panelTopActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.panelTopActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopActions.Controls.Add(this.lblDeviceCount);
            this.panelTopActions.Controls.Add(this.btnRefreshTop);
            this.panelTopActions.Controls.Add(this.btnPairTop);
            this.panelTopActions.Controls.Add(this.btnDiscover);
            this.panelTopActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopActions.Location = new System.Drawing.Point(0, 54);
            this.panelTopActions.Name = "panelTopActions";
            this.panelTopActions.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.panelTopActions.Size = new System.Drawing.Size(950, 42);
            this.panelTopActions.TabIndex = 1;
            // 
            // lblDeviceCount
            // 
            this.lblDeviceCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeviceCount.AutoSize = true;
            this.lblDeviceCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblDeviceCount.Location = new System.Drawing.Point(680, 13);
            this.lblDeviceCount.Name = "lblDeviceCount";
            this.lblDeviceCount.Size = new System.Drawing.Size(248, 13);
            this.lblDeviceCount.TabIndex = 3;
            this.lblDeviceCount.Text = "0 registered & discovered device(s) on network";
            this.lblDeviceCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefreshTop
            // 
            this.btnRefreshTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnRefreshTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTop.Location = new System.Drawing.Point(280, 6);
            this.btnRefreshTop.Name = "btnRefreshTop";
            this.btnRefreshTop.Size = new System.Drawing.Size(100, 28);
            this.btnRefreshTop.TabIndex = 2;
            this.btnRefreshTop.Text = "🔄 Refresh List";
            this.btnRefreshTop.UseVisualStyleBackColor = true;
            this.btnRefreshTop.Click += new System.EventHandler(this.BtnDiscover_Click);
            // 
            // btnPairTop
            // 
            this.btnPairTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnPairTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPairTop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPairTop.Location = new System.Drawing.Point(165, 6);
            this.btnPairTop.Name = "btnPairTop";
            this.btnPairTop.Size = new System.Drawing.Size(108, 28);
            this.btnPairTop.TabIndex = 1;
            this.btnPairTop.Text = "🔗 Pair Device...";
            this.btnPairTop.UseVisualStyleBackColor = true;
            this.btnPairTop.Click += new System.EventHandler(this.BtnPair_Click);
            // 
            // btnDiscover
            // 
            this.btnDiscover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDiscover.FlatAppearance.BorderSize = 0;
            this.btnDiscover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscover.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscover.ForeColor = System.Drawing.Color.White;
            this.btnDiscover.Location = new System.Drawing.Point(10, 6);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(148, 28);
            this.btnDiscover.TabIndex = 0;
            this.btnDiscover.Text = "🔍 Discover Devices";
            this.btnDiscover.UseVisualStyleBackColor = false;
            this.btnDiscover.Click += new System.EventHandler(this.BtnDiscover_Click);
            // 
            // groupDevices
            // 
            this.groupDevices.BackColor = System.Drawing.Color.White;
            this.groupDevices.Controls.Add(this.dgvDevices);
            this.groupDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDevices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDevices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupDevices.Location = new System.Drawing.Point(0, 96);
            this.groupDevices.Name = "groupDevices";
            this.groupDevices.Padding = new System.Windows.Forms.Padding(8);
            this.groupDevices.Size = new System.Drawing.Size(950, 480);
            this.groupDevices.TabIndex = 2;
            this.groupDevices.TabStop = false;
            this.groupDevices.Text = "Peer Nodes Directory";
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.AllowUserToDeleteRows = false;
            this.dgvDevices.AllowUserToResizeRows = false;
            this.dgvDevices.BackgroundColor = System.Drawing.Color.White;
            this.dgvDevices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDevices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgvCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dgvCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            dgvCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevices.ColumnHeadersDefaultCellStyle = dgvCellStyle1;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDevStatus,
            this.colDevName,
            this.colDevIp,
            this.colDevPort,
            this.colDevType,
            this.colDevTrust,
            this.colDevSeen});
            dgvCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dgvCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            dgvCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dgvCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevices.DefaultCellStyle = dgvCellStyle2;
            this.dgvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevices.EnableHeadersVisualStyles = false;
            this.dgvDevices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.dgvDevices.Location = new System.Drawing.Point(8, 24);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.ReadOnly = true;
            this.dgvDevices.RowHeadersVisible = false;
            this.dgvDevices.RowTemplate.Height = 24;
            this.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevices.Size = new System.Drawing.Size(934, 448);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.SelectionChanged += new System.EventHandler(this.DgvDevices_SelectionChanged);
            // 
            // colDevStatus
            // 
            this.colDevStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDevStatus.HeaderText = "Status";
            this.colDevStatus.Name = "colDevStatus";
            this.colDevStatus.ReadOnly = true;
            this.colDevStatus.Width = 66;
            // 
            // colDevName
            // 
            this.colDevName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDevName.FillWeight = 140F;
            this.colDevName.HeaderText = "Device Name";
            this.colDevName.Name = "colDevName";
            this.colDevName.ReadOnly = true;
            // 
            // colDevIp
            // 
            this.colDevIp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDevIp.FillWeight = 100F;
            this.colDevIp.HeaderText = "IP Address";
            this.colDevIp.Name = "colDevIp";
            this.colDevIp.ReadOnly = true;
            // 
            // colDevPort
            // 
            this.colDevPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDevPort.HeaderText = "Port";
            this.colDevPort.Name = "colDevPort";
            this.colDevPort.ReadOnly = true;
            this.colDevPort.Width = 53;
            // 
            // colDevType
            // 
            this.colDevType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDevType.HeaderText = "Connection";
            this.colDevType.Name = "colDevType";
            this.colDevType.ReadOnly = true;
            this.colDevType.Width = 92;
            // 
            // colDevTrust
            // 
            this.colDevTrust.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDevTrust.FillWeight = 90F;
            this.colDevTrust.HeaderText = "Trust / Pairing";
            this.colDevTrust.Name = "colDevTrust";
            this.colDevTrust.ReadOnly = true;
            // 
            // colDevSeen
            // 
            this.colDevSeen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDevSeen.HeaderText = "Last Seen";
            this.colDevSeen.Name = "colDevSeen";
            this.colDevSeen.ReadOnly = true;
            this.colDevSeen.Width = 80;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelActions.Controls.Add(this.btnProperties);
            this.panelActions.Controls.Add(this.btnSendFile);
            this.panelActions.Controls.Add(this.btnUnpair);
            this.panelActions.Controls.Add(this.btnPair);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 576);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.panelActions.Size = new System.Drawing.Size(950, 44);
            this.panelActions.TabIndex = 3;
            // 
            // btnProperties
            // 
            this.btnProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProperties.Enabled = false;
            this.btnProperties.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProperties.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProperties.Location = new System.Drawing.Point(828, 7);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(110, 28);
            this.btnProperties.TabIndex = 3;
            this.btnProperties.Text = "ℹ Properties";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.BtnProperties_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Enabled = false;
            this.btnSendFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendFile.Location = new System.Drawing.Point(220, 7);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(130, 28);
            this.btnSendFile.TabIndex = 2;
            this.btnSendFile.Text = "📤 Send File to Peer...";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.BtnSendFile_Click);
            // 
            // btnUnpair
            // 
            this.btnUnpair.Enabled = false;
            this.btnUnpair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnUnpair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnpair.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnpair.Location = new System.Drawing.Point(120, 7);
            this.btnUnpair.Name = "btnUnpair";
            this.btnUnpair.Size = new System.Drawing.Size(90, 28);
            this.btnUnpair.TabIndex = 1;
            this.btnUnpair.Text = "🔓 Unpair";
            this.btnUnpair.UseVisualStyleBackColor = true;
            this.btnUnpair.Click += new System.EventHandler(this.BtnUnpair_Click);
            // 
            // btnPair
            // 
            this.btnPair.Enabled = false;
            this.btnPair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnPair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPair.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPair.Location = new System.Drawing.Point(10, 7);
            this.btnPair.Name = "btnPair";
            this.btnPair.Size = new System.Drawing.Size(100, 28);
            this.btnPair.TabIndex = 0;
            this.btnPair.Text = "🔗 Pair Selected";
            this.btnPair.UseVisualStyleBackColor = true;
            this.btnPair.Click += new System.EventHandler(this.BtnPair_Click);
            // 
            // DevicesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupDevices);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelTopActions);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DevicesControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelTopActions.ResumeLayout(false);
            this.panelTopActions.PerformLayout();
            this.groupDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
