using System;
using System.Drawing;
using System.Windows.Forms;

namespace _
{
    public class LoginForm : Form
    {
        private Label lblTitle, lblUsername, lblPassword;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin;
        private CheckBox chkShowPassword;

        public LoginForm()
        {
            // Configure Form
            this.Text = "Login";
            this.Size = new Size(350, 300);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Title Label
            lblTitle = new Label()
            {
                Text = "Login",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(130, 20)
            };

            // Username Label & TextBox
            lblUsername = new Label() { Text = "Username", Location = new Point(40, 70), AutoSize = true };
            txtUsername = new TextBox() { Location = new Point(130, 70), Width = 150 };

            // Password Label & TextBox
            lblPassword = new Label() { Text = "Password", Location = new Point(40, 110), AutoSize = true };
            txtPassword = new TextBox() { Location = new Point(130, 110), Width = 150, PasswordChar = '*' };

            // Show Password Checkbox
            chkShowPassword = new CheckBox() { Text = "Show Password", Location = new Point(130, 140), AutoSize = true };
            chkShowPassword.CheckedChanged += (sender, e) =>
            {
                txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
            };

            // Login Button
            btnLogin = new Button()
            {
                Text = "Login",
                Location = new Point(130, 180),
                Size = new Size(100, 30),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.Click += BtnLogin_Click;

            // Add Controls to Form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(chkShowPassword);
            this.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (Database.CheckLogin(username, password)) // Example check
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                AdminForm mainForm = new AdminForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
