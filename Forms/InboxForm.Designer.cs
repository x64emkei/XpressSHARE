namespace XpressShare.Forms
{
    partial class InboxForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTopBanner;
        private System.Windows.Forms.PictureBox picHeaderIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblDeviceTitle;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblFileTitle;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblSizeTitle;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblSecurityNote;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;

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
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblDeviceTitle = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblFileTitle = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblSizeTitle = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblSecurityNote = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.panelTopBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            this.panelCard.SuspendLayout();
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
            this.panelTopBanner.Size = new System.Drawing.Size(444, 72);
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(193, 23);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Incoming File Transfer";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(64, 40);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(251, 13);
            this.lblHeaderSub.TabIndex = 2;
            this.lblHeaderSub.Text = "A nearby device is requesting to send a file to you";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.lblDeviceTitle);
            this.panelCard.Controls.Add(this.lblDevice);
            this.panelCard.Controls.Add(this.lblFileTitle);
            this.panelCard.Controls.Add(this.lblFileName);
            this.panelCard.Controls.Add(this.lblSizeTitle);
            this.panelCard.Controls.Add(this.lblFileSize);
            this.panelCard.Controls.Add(this.lblSecurityNote);
            this.panelCard.Location = new System.Drawing.Point(20, 88);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(404, 164);
            this.panelCard.TabIndex = 1;
            // 
            // lblDeviceTitle
            // 
            this.lblDeviceTitle.AutoSize = true;
            this.lblDeviceTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDeviceTitle.Location = new System.Drawing.Point(16, 14);
            this.lblDeviceTitle.Name = "lblDeviceTitle";
            this.lblDeviceTitle.Size = new System.Drawing.Size(46, 12);
            this.lblDeviceTitle.TabIndex = 0;
            this.lblDeviceTitle.Text = "SENDER:";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDevice.Location = new System.Drawing.Point(16, 28);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(107, 17);
            this.lblDevice.TabIndex = 1;
            this.lblDevice.Text = "Unknown Device";
            // 
            // lblFileTitle
            // 
            this.lblFileTitle.AutoSize = true;
            this.lblFileTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFileTitle.Location = new System.Drawing.Point(16, 56);
            this.lblFileTitle.Name = "lblFileTitle";
            this.lblFileTitle.Size = new System.Drawing.Size(59, 12);
            this.lblFileTitle.TabIndex = 2;
            this.lblFileTitle.Text = "FILE NAME:";
            // 
            // lblFileName
            // 
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblFileName.Location = new System.Drawing.Point(16, 70);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(370, 20);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "document.pdf";
            // 
            // lblSizeTitle
            // 
            this.lblSizeTitle.AutoSize = true;
            this.lblSizeTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSizeTitle.Location = new System.Drawing.Point(16, 98);
            this.lblSizeTitle.Name = "lblSizeTitle";
            this.lblSizeTitle.Size = new System.Drawing.Size(30, 12);
            this.lblSizeTitle.TabIndex = 4;
            this.lblSizeTitle.Text = "SIZE:";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFileSize.Location = new System.Drawing.Point(16, 112);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(27, 15);
            this.lblFileSize.TabIndex = 5;
            this.lblFileSize.Text = "0 KB";
            // 
            // lblSecurityNote
            // 
            this.lblSecurityNote.AutoSize = true;
            this.lblSecurityNote.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurityNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSecurityNote.Location = new System.Drawing.Point(16, 138);
            this.lblSecurityNote.Name = "lblSecurityNote";
            this.lblSecurityNote.Size = new System.Drawing.Size(263, 12);
            this.lblSecurityNote.TabIndex = 6;
            this.lblSecurityNote.Text = "File transfer will stream directly and verify with SHA1 digest.";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(274, 266);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(150, 36);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "  Accept File";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnReject.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnReject.Location = new System.Drawing.Point(158, 266);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(108, 36);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "  Decline";
            this.btnReject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.BtnReject_Click);
            // 
            // InboxForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.CancelButton = this.btnReject;
            this.ClientSize = new System.Drawing.Size(444, 320);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelTopBanner);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InboxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XpressSHARE - Incoming Request";
            this.panelTopBanner.ResumeLayout(false);
            this.panelTopBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).EndInit();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
