namespace XpressShare.Forms
{
    partial class SplashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureSplash;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressStartup;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureSplash = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressStartup = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureSplash
            // 
            this.pictureSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSplash.Location = new System.Drawing.Point(0, 0);
            this.pictureSplash.Name = "pictureSplash";
            this.pictureSplash.Size = new System.Drawing.Size(500, 300);
            this.pictureSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.pictureSplash.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(18, 276);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 13);
            this.lblStatus.Text = "Starting...";
            // 
            // progressStartup
            // 
            this.progressStartup.Location = new System.Drawing.Point(255, 277);
            this.progressStartup.Maximum = 100;
            this.progressStartup.Name = "progressStartup";
            this.progressStartup.Size = new System.Drawing.Size(225, 8);
            this.progressStartup.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressStartup.TabStop = false;
            // 
            // SplashForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.ControlBox = false;
            this.Controls.Add(this.pictureSplash);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
