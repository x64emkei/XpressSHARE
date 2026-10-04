using System;
using System.Windows.Forms;
using XpressShare.Core;

namespace XpressShare.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ThemeManager.ApplyTheme(this);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
