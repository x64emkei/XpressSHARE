namespace XpressShare.Forms
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTopBanner;
        private System.Windows.Forms.Label lblHeaderBrand;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblTechStack;
        private System.Windows.Forms.Button btnClose;

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
            this.panelTopBanner = new System.Windows.Forms.Panel();
            this.lblHeaderBrand = new System.Windows.Forms.Label();
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblTechStack = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTopBanner.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopBanner
            // 
            this.panelTopBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelTopBanner.Controls.Add(this.lblHeaderBrand);
            this.panelTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBanner.Location = new System.Drawing.Point(0, 0);
            this.panelTopBanner.Name = "panelTopBanner";
            this.panelTopBanner.Size = new System.Drawing.Size(420, 56);
            this.panelTopBanner.TabIndex = 0;
            this.panelTopBanner.Tag = "Header";
            // 
            // lblHeaderBrand
            // 
            this.lblHeaderBrand.AutoSize = true;
            this.lblHeaderBrand.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderBrand.ForeColor = System.Drawing.Color.White;
            this.lblHeaderBrand.Location = new System.Drawing.Point(18, 14);
            this.lblHeaderBrand.Name = "lblHeaderBrand";
            this.lblHeaderBrand.Size = new System.Drawing.Size(133, 28);
            this.lblHeaderBrand.TabIndex = 0;
            this.lblHeaderBrand.Tag = "HeaderTitle";
            this.lblHeaderBrand.Text = "XpressSHARE";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.lblAppTitle);
            this.panelCard.Controls.Add(this.lblVersion);
            this.panelCard.Controls.Add(this.lblDescription);
            this.panelCard.Controls.Add(this.lblDeveloper);
            this.panelCard.Controls.Add(this.lblTechStack);
            this.panelCard.Controls.Add(this.btnClose);
            this.panelCard.Location = new System.Drawing.Point(20, 74);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(380, 240);
            this.panelCard.TabIndex = 1;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(38)))));
            this.lblAppTitle.Location = new System.Drawing.Point(18, 16);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(122, 25);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "XpressSHARE";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVersion.Location = new System.Drawing.Point(20, 44);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(125, 15);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "XpressSHARE V1.0.0";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblDescription.Location = new System.Drawing.Point(20, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(340, 46);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "A local network file transfer application designed for fast, simple, and secure file sharing between trusted devices.";
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblDeveloper.Location = new System.Drawing.Point(20, 126);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(258, 15);
            this.lblDeveloper.TabIndex = 3;
            this.lblDeveloper.Text = "Developer: Developed by x64emkei (Michael Ordenes)";
            // 
            // lblTechStack
            // 
            this.lblTechStack.AutoSize = true;
            this.lblTechStack.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechStack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTechStack.Location = new System.Drawing.Point(20, 150);
            this.lblTechStack.Name = "lblTechStack";
            this.lblTechStack.Size = new System.Drawing.Size(236, 12);
            this.lblTechStack.TabIndex = 4;
            this.lblTechStack.Text = "Engineered on C# / .NET 3.5 Framework (x86 & x64)";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(38)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(260, 184);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 34);
            this.btnClose.TabIndex = 5;
            this.btnClose.Tag = "PrimaryAction";
            this.btnClose.Text = "OK";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(420, 334);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelTopBanner);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About XpressSHARE";
            this.panelTopBanner.ResumeLayout(false);
            this.panelTopBanner.PerformLayout();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
