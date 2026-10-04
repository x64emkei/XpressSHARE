using System;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Services;

namespace XpressShare.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly LocalAccountService _accounts;

        public RegistrationForm()
        {
            InitializeComponent();
            _accounts = new LocalAccountService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ThemeManager.ApplyTheme(this);
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string displayName = txtDisplayName.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;

            // Validation
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.Length < 3 || username.Length > 20)
            {
                MessageBox.Show("Username must be between 3 and 20 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(displayName))
                displayName = username;

            bool success = _accounts.Register(username, displayName, password);
            if (success)
            {
                MessageBox.Show("Registration successful! Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Username may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
