namespace XpressShare.Forms.Controls
{
    partial class TransfersControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelAccent;

        // Metric Summary Bar
        private System.Windows.Forms.Panel panelMetrics;
        private System.Windows.Forms.TableLayoutPanel tableMetrics;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.Label lblActiveCountVal;
        private System.Windows.Forms.Label lblQueuedCount;
        private System.Windows.Forms.Label lblQueuedCountVal;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblSpeedVal;

        // Grid & Actions
        private System.Windows.Forms.GroupBox groupTransfers;
        private System.Windows.Forms.DataGridView dgvTransfers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;

        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpenFolder;

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
            this.panelMetrics = new System.Windows.Forms.Panel();
            this.tableMetrics = new System.Windows.Forms.TableLayoutPanel();
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.lblActiveCountVal = new System.Windows.Forms.Label();
            this.lblQueuedCount = new System.Windows.Forms.Label();
            this.lblQueuedCountVal = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblSpeedVal = new System.Windows.Forms.Label();
            this.groupTransfers = new System.Windows.Forms.GroupBox();
            this.dgvTransfers = new System.Windows.Forms.DataGridView();
            this.colDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMetrics.SuspendLayout();
            this.tableMetrics.SuspendLayout();
            this.groupTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(237, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Transfer Management Console";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblSubtitle.Location = new System.Drawing.Point(15, 31);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(378, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Real-time socket pipeline status, active streams, and queued transmissions";
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
            // panelMetrics
            // 
            this.panelMetrics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.panelMetrics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMetrics.Controls.Add(this.tableMetrics);
            this.panelMetrics.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMetrics.Location = new System.Drawing.Point(0, 54);
            this.panelMetrics.Name = "panelMetrics";
            this.panelMetrics.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.panelMetrics.Size = new System.Drawing.Size(950, 42);
            this.panelMetrics.TabIndex = 1;
            // 
            // tableMetrics
            // 
            this.tableMetrics.ColumnCount = 6;
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableMetrics.Controls.Add(this.lblActiveCount, 0, 0);
            this.tableMetrics.Controls.Add(this.lblActiveCountVal, 1, 0);
            this.tableMetrics.Controls.Add(this.lblQueuedCount, 2, 0);
            this.tableMetrics.Controls.Add(this.lblQueuedCountVal, 3, 0);
            this.tableMetrics.Controls.Add(this.lblSpeed, 4, 0);
            this.tableMetrics.Controls.Add(this.lblSpeedVal, 5, 0);
            this.tableMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMetrics.Location = new System.Drawing.Point(12, 4);
            this.tableMetrics.Name = "tableMetrics";
            this.tableMetrics.RowCount = 1;
            this.tableMetrics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMetrics.Size = new System.Drawing.Size(924, 32);
            this.tableMetrics.TabIndex = 0;
            // 
            // lblActiveCount
            // 
            this.lblActiveCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblActiveCount.AutoSize = true;
            this.lblActiveCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblActiveCount.Location = new System.Drawing.Point(3, 9);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new System.Drawing.Size(89, 13);
            this.lblActiveCount.TabIndex = 0;
            this.lblActiveCount.Text = "Active Transfers:";
            // 
            // lblActiveCountVal
            // 
            this.lblActiveCountVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblActiveCountVal.AutoSize = true;
            this.lblActiveCountVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveCountVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblActiveCountVal.Location = new System.Drawing.Point(113, 8);
            this.lblActiveCountVal.Name = "lblActiveCountVal";
            this.lblActiveCountVal.Size = new System.Drawing.Size(14, 15);
            this.lblActiveCountVal.TabIndex = 1;
            this.lblActiveCountVal.Text = "0";
            // 
            // lblQueuedCount
            // 
            this.lblQueuedCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQueuedCount.AutoSize = true;
            this.lblQueuedCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueuedCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblQueuedCount.Location = new System.Drawing.Point(311, 9);
            this.lblQueuedCount.Name = "lblQueuedCount";
            this.lblQueuedCount.Size = new System.Drawing.Size(95, 13);
            this.lblQueuedCount.TabIndex = 2;
            this.lblQueuedCount.Text = "Queued Transfers:";
            // 
            // lblQueuedCountVal
            // 
            this.lblQueuedCountVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQueuedCountVal.AutoSize = true;
            this.lblQueuedCountVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueuedCountVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.lblQueuedCountVal.Location = new System.Drawing.Point(421, 8);
            this.lblQueuedCountVal.Name = "lblQueuedCountVal";
            this.lblQueuedCountVal.Size = new System.Drawing.Size(14, 15);
            this.lblQueuedCountVal.TabIndex = 3;
            this.lblQueuedCountVal.Text = "0";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.lblSpeed.Location = new System.Drawing.Point(619, 9);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(76, 13);
            this.lblSpeed.TabIndex = 4;
            this.lblSpeed.Text = "Current Rate:";
            // 
            // lblSpeedVal
            // 
            this.lblSpeedVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSpeedVal.AutoSize = true;
            this.lblSpeedVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSpeedVal.Location = new System.Drawing.Point(729, 8);
            this.lblSpeedVal.Name = "lblSpeedVal";
            this.lblSpeedVal.Size = new System.Drawing.Size(39, 15);
            this.lblSpeedVal.TabIndex = 5;
            this.lblSpeedVal.Text = "0 B/s";
            // 
            // groupTransfers
            // 
            this.groupTransfers.BackColor = System.Drawing.Color.White;
            this.groupTransfers.Controls.Add(this.dgvTransfers);
            this.groupTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTransfers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTransfers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.groupTransfers.Location = new System.Drawing.Point(0, 96);
            this.groupTransfers.Name = "groupTransfers";
            this.groupTransfers.Padding = new System.Windows.Forms.Padding(8);
            this.groupTransfers.Size = new System.Drawing.Size(950, 480);
            this.groupTransfers.TabIndex = 2;
            this.groupTransfers.TabStop = false;
            this.groupTransfers.Text = "Active & Recent Stream Pipeline";
            // 
            // dgvTransfers
            // 
            this.dgvTransfers.AllowUserToAddRows = false;
            this.dgvTransfers.AllowUserToDeleteRows = false;
            this.dgvTransfers.AllowUserToResizeRows = false;
            this.dgvTransfers.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransfers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransfers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransfers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgvCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dgvCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            dgvCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransfers.ColumnHeadersDefaultCellStyle = dgvCellStyle1;
            this.dgvTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransfers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDir,
            this.colFile,
            this.colSize,
            this.colSource,
            this.colDest,
            this.colStatus,
            this.colProgress,
            this.colSpeed,
            this.colTime});
            dgvCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dgvCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            dgvCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            dgvCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dgvCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransfers.DefaultCellStyle = dgvCellStyle2;
            this.dgvTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransfers.EnableHeadersVisualStyles = false;
            this.dgvTransfers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.dgvTransfers.Location = new System.Drawing.Point(8, 24);
            this.dgvTransfers.MultiSelect = false;
            this.dgvTransfers.Name = "dgvTransfers";
            this.dgvTransfers.ReadOnly = true;
            this.dgvTransfers.RowHeadersVisible = false;
            this.dgvTransfers.RowTemplate.Height = 24;
            this.dgvTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransfers.Size = new System.Drawing.Size(934, 448);
            this.dgvTransfers.TabIndex = 0;
            this.dgvTransfers.SelectionChanged += new System.EventHandler(this.DgvTransfers_SelectionChanged);
            // 
            // colDir
            // 
            this.colDir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDir.HeaderText = "Direction";
            this.colDir.Name = "colDir";
            this.colDir.ReadOnly = true;
            this.colDir.Width = 83;
            // 
            // colFile
            // 
            this.colFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFile.FillWeight = 140F;
            this.colFile.HeaderText = "File Name";
            this.colFile.Name = "colFile";
            this.colFile.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 55;
            // 
            // colSource
            // 
            this.colSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSource.FillWeight = 85F;
            this.colSource.HeaderText = "Source";
            this.colSource.Name = "colSource";
            this.colSource.ReadOnly = true;
            // 
            // colDest
            // 
            this.colDest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDest.FillWeight = 85F;
            this.colDest.HeaderText = "Destination";
            this.colDest.Name = "colDest";
            this.colDest.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 66;
            // 
            // colProgress
            // 
            this.colProgress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProgress.HeaderText = "Progress";
            this.colProgress.Name = "colProgress";
            this.colProgress.ReadOnly = true;
            this.colProgress.Width = 79;
            // 
            // colSpeed
            // 
            this.colSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSpeed.HeaderText = "Speed";
            this.colSpeed.Name = "colSpeed";
            this.colSpeed.ReadOnly = true;
            this.colSpeed.Width = 66;
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 58;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelActions.Controls.Add(this.btnOpenFolder);
            this.panelActions.Controls.Add(this.btnClear);
            this.panelActions.Controls.Add(this.btnCancel);
            this.panelActions.Controls.Add(this.btnResume);
            this.panelActions.Controls.Add(this.btnPause);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 576);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.panelActions.Size = new System.Drawing.Size(950, 44);
            this.panelActions.TabIndex = 3;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolder.Location = new System.Drawing.Point(778, 7);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(160, 28);
            this.btnOpenFolder.TabIndex = 4;
            this.btnOpenFolder.Text = "📁 Open Download Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(268, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 28);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "🔄 Refresh List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(182, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnResume
            // 
            this.btnResume.Enabled = false;
            this.btnResume.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResume.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Location = new System.Drawing.Point(96, 7);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(80, 28);
            this.btnResume.TabIndex = 1;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(10, 7);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 28);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // TransfersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupTransfers);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelMetrics);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TransfersControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMetrics.ResumeLayout(false);
            this.tableMetrics.ResumeLayout(false);
            this.tableMetrics.PerformLayout();
            this.groupTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
