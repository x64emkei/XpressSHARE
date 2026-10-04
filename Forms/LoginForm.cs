using System;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Services;

namespace XpressShare.Forms
{
    public partial class LoginForm : Form
    {
        private readonly LocalAccountService _accounts;

        public LoginForm()
        {
            InitializeComponent();
            _accounts = new LocalAccountService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ThemeManager.ApplyTheme(this);
            chkRememberMe.Checked = AppSettings.Instance.RememberMe;
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = _accounts.Authenticate(username, password);
            if (ok)
            {
                AppSettings.Instance.CurrentUsername = username;
                AppSettings.Instance.RememberMe = chkRememberMe.Checked;
                if (chkRememberMe.Checked)
                {
                    AppSettings.Instance.AuthSessionToken = Guid.NewGuid().ToString("N");
                }
                else
                {
                    AppSettings.Instance.AuthSessionToken = string.Empty;
                }
                AppSettings.Instance.Save();

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
