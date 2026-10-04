namespace XpressShare.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTopBanner;
        private System.Windows.Forms.PictureBox picHeaderIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelStorageCard;
        private System.Windows.Forms.Label lblStorageSection;
        private System.Windows.Forms.Label lblDownloadFolder;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.Panel panelNetworkCard;
        private System.Windows.Forms.Label lblNetworkSection;
        private System.Windows.Forms.Label lblNetworkNote;
        private System.Windows.Forms.Label lblDevicePort;
        private System.Windows.Forms.NumericUpDown numDevicePort;
        private System.Windows.Forms.Label lblTransferPort;
        private System.Windows.Forms.NumericUpDown numTransferPort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTopBanner = new System.Windows.Forms.Panel();
            this.picHeaderIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.panelStorageCard = new System.Windows.Forms.Panel();
            this.lblStorageSection = new System.Windows.Forms.Label();
            this.lblDownloadFolder = new System.Windows.Forms.Label();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.panelNetworkCard = new System.Windows.Forms.Panel();
            this.lblNetworkSection = new System.Windows.Forms.Label();
            this.lblNetworkNote = new System.Windows.Forms.Label();
            this.lblDevicePort = new System.Windows.Forms.Label();
            this.numDevicePort = new System.Windows.Forms.NumericUpDown();
            this.lblTransferPort = new System.Windows.Forms.Label();
            this.numTransferPort = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTopBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            this.panelStorageCard.SuspendLayout();
            this.panelNetworkCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDevicePort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransferPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTopBanner
            // 
            this.panelTopBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelTopBanner.Controls.Add(this.picHeaderIcon);
            this.panelTopBanner.Controls.Add(this.lblHeaderTitle);
            this.panelTopBanner.Controls.Add(this.lblHeaderSub);
            this.panelTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBanner.Location = new System.Drawing.Point(0, 0);
            this.panelTopBanner.Name = "panelTopBanner";
            this.panelTopBanner.Size = new System.Drawing.Size(480, 72);
            this.panelTopBanner.TabIndex = 0;
            // 
            // picHeaderIcon
            // 
            this.picHeaderIcon.Location = new System.Drawing.Point(20, 16);
            this.picHeaderIcon.Name = "picHeaderIcon";
            this.picHeaderIcon.Size = new System.Drawing.Size(36, 36);
            this.picHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHeaderIcon.TabIndex = 0;
            this.picHeaderIcon.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(62, 14);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(206, 23);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Settings & Configuration";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(64, 40);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(328, 13);
            this.lblHeaderSub.TabIndex = 2;
            this.lblHeaderSub.Text = "Configure storage paths, tray behavior, and network communication";
            // 
            // panelStorageCard
            // 
            this.panelStorageCard.BackColor = System.Drawing.Color.White;
            this.panelStorageCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStorageCard.Controls.Add(this.lblStorageSection);
            this.panelStorageCard.Controls.Add(this.lblDownloadFolder);
            this.panelStorageCard.Controls.Add(this.txtDownloadFolder);
            this.panelStorageCard.Controls.Add(this.btnBrowse);
            this.panelStorageCard.Controls.Add(this.chkMinimizeToTray);
            this.panelStorageCard.Location = new System.Drawing.Point(18, 88);
            this.panelStorageCard.Name = "panelStorageCard";
            this.panelStorageCard.Size = new System.Drawing.Size(444, 120);
            this.panelStorageCard.TabIndex = 1;
            // 
            // lblStorageSection
            // 
            this.lblStorageSection.AutoSize = true;
            this.lblStorageSection.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorageSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStorageSection.Location = new System.Drawing.Point(14, 12);
            this.lblStorageSection.Name = "lblStorageSection";
            this.lblStorageSection.Size = new System.Drawing.Size(193, 13);
            this.lblStorageSection.TabIndex = 0;
            this.lblStorageSection.Text = "STORAGE && APP PREFERENCES";
            // 
            // lblDownloadFolder
            // 
            this.lblDownloadFolder.AutoSize = true;
            this.lblDownloadFolder.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDownloadFolder.Location = new System.Drawing.Point(14, 32);
            this.lblDownloadFolder.Name = "lblDownloadFolder";
            this.lblDownloadFolder.Size = new System.Drawing.Size(124, 12);
            this.lblDownloadFolder.TabIndex = 1;
            this.lblDownloadFolder.Text = "DEFAULT DOWNLOAD PATH";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.BackColor = System.Drawing.Color.White;
            this.txtDownloadFolder.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownloadFolder.Location = new System.Drawing.Point(16, 48);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.ReadOnly = false;
            this.txtDownloadFolder.Size = new System.Drawing.Size(316, 23);
            this.txtDownloadFolder.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnBrowse.Location = new System.Drawing.Point(340, 47);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(88, 25);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "  Browse...";
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // chkMinimizeToTray
            // 
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMinimizeToTray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.chkMinimizeToTray.Location = new System.Drawing.Point(16, 84);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.Size = new System.Drawing.Size(268, 19);
            this.chkMinimizeToTray.TabIndex = 4;
            this.chkMinimizeToTray.Text = "Minimize to system tray when window is closed";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // panelNetworkCard
            // 
            this.panelNetworkCard.BackColor = System.Drawing.Color.White;
            this.panelNetworkCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNetworkCard.Controls.Add(this.lblNetworkSection);
            this.panelNetworkCard.Controls.Add(this.lblNetworkNote);
            this.panelNetworkCard.Controls.Add(this.lblDevicePort);
            this.panelNetworkCard.Controls.Add(this.numDevicePort);
            this.panelNetworkCard.Controls.Add(this.lblTransferPort);
            this.panelNetworkCard.Controls.Add(this.numTransferPort);
            this.panelNetworkCard.Location = new System.Drawing.Point(18, 222);
            this.panelNetworkCard.Name = "panelNetworkCard";
            this.panelNetworkCard.Size = new System.Drawing.Size(444, 126);
            this.panelNetworkCard.TabIndex = 2;
            // 
            // lblNetworkSection
            // 
            this.lblNetworkSection.AutoSize = true;
            this.lblNetworkSection.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNetworkSection.Location = new System.Drawing.Point(14, 12);
            this.lblNetworkSection.Name = "lblNetworkSection";
            this.lblNetworkSection.Size = new System.Drawing.Size(161, 13);
            this.lblNetworkSection.TabIndex = 0;
            this.lblNetworkSection.Text = "NETWORK PORTS && PROTOCOL";
            // 
            // lblNetworkNote
            // 
            this.lblNetworkNote.AutoSize = true;
            this.lblNetworkNote.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNetworkNote.Location = new System.Drawing.Point(14, 28);
            this.lblNetworkNote.Name = "lblNetworkNote";
            this.lblNetworkNote.Size = new System.Drawing.Size(360, 12);
            this.lblNetworkNote.TabIndex = 1;
            this.lblNetworkNote.Text = "Standard default ports are 15000 (UDP Discovery) and 15001 (TCP Transfer).";
            // 
            // lblDevicePort
            // 
            this.lblDevicePort.AutoSize = true;
            this.lblDevicePort.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevicePort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDevicePort.Location = new System.Drawing.Point(14, 56);
            this.lblDevicePort.Name = "lblDevicePort";
            this.lblDevicePort.Size = new System.Drawing.Size(117, 12);
            this.lblDevicePort.TabIndex = 2;
            this.lblDevicePort.Text = "UDP DISCOVERY PORT:";
            // 
            // numDevicePort
            // 
            this.numDevicePort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDevicePort.Location = new System.Drawing.Point(16, 74);
            this.numDevicePort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numDevicePort.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            this.numDevicePort.Name = "numDevicePort";
            this.numDevicePort.Size = new System.Drawing.Size(180, 23);
            this.numDevicePort.TabIndex = 3;
            this.numDevicePort.Value = new decimal(new int[] { 15000, 0, 0, 0 });
            // 
            // lblTransferPort
            // 
            this.lblTransferPort.AutoSize = true;
            this.lblTransferPort.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTransferPort.Location = new System.Drawing.Point(232, 56);
            this.lblTransferPort.Name = "lblTransferPort";
            this.lblTransferPort.Size = new System.Drawing.Size(107, 12);
            this.lblTransferPort.TabIndex = 4;
            this.lblTransferPort.Text = "TCP TRANSFER PORT:";
            // 
            // numTransferPort
            // 
            this.numTransferPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTransferPort.Location = new System.Drawing.Point(234, 74);
            this.numTransferPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numTransferPort.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            this.numTransferPort.Name = "numTransferPort";
            this.numTransferPort.Size = new System.Drawing.Size(180, 23);
            this.numTransferPort.TabIndex = 5;
            this.numTransferPort.Value = new decimal(new int[] { 15001, 0, 0, 0 });
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(344, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "  Save Settings";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancel.Location = new System.Drawing.Point(248, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(480, 416);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelNetworkCard);
            this.Controls.Add(this.panelStorageCard);
            this.Controls.Add(this.panelTopBanner);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XpressSHARE - Settings";
            this.panelTopBanner.ResumeLayout(false);
            this.panelTopBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).EndInit();
            this.panelStorageCard.ResumeLayout(false);
            this.panelStorageCard.PerformLayout();
            this.panelNetworkCard.ResumeLayout(false);
            this.panelNetworkCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDevicePort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransferPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
