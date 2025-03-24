using System;
using System.Data;
using System.Windows.Forms;

namespace _
{
    public class AdminForm : Form
    {
        private TabControl tabControl;
        private TabPage tabUsers;
        private DataGridView dgvUsers;
        private TextBox txtUsername, txtPassword;
        private ComboBox cbRole;
        private Button btnAdd, btnEdit, btnDelete;
        private Database db = new Database();

        public AdminForm()
        {
            this.Text = "Quản Lý Trường Học";
            this.Size = new System.Drawing.Size(800, 500);

            tabControl = new TabControl() { Dock = DockStyle.Fill };

            // Tab Quản lý Người dùng
            tabUsers = new TabPage("Người Dùng");
            InitializeUserTab();
            tabControl.TabPages.Add(tabUsers);

            this.Controls.Add(tabControl);
        }

        private void InitializeUserTab()
        {
            dgvUsers = new DataGridView() { Location = new System.Drawing.Point(20, 20), Width = 740, Height = 200 };
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;

            txtUsername = new TextBox() { Location = new System.Drawing.Point(20, 240), Width = 200, PlaceholderText = "Tên đăng nhập" };
            txtPassword = new TextBox() { Location = new System.Drawing.Point(240, 240), Width = 200, PlaceholderText = "Mật khẩu" };
            cbRole = new ComboBox() { Location = new System.Drawing.Point(460, 240), Width = 150 };
            cbRole.Items.AddRange(new string[] { "Admin", "Teacher", "Student", "Parent" });

            btnAdd = new Button() { Text = "Thêm", Location = new System.Drawing.Point(20, 280) };
            btnEdit = new Button() { Text = "Sửa", Location = new System.Drawing.Point(100, 280) };
            btnDelete = new Button() { Text = "Xóa", Location = new System.Drawing.Point(180, 280) };

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;

            tabUsers.Controls.Add(dgvUsers);
            tabUsers.Controls.Add(txtUsername);
            tabUsers.Controls.Add(txtPassword);
            tabUsers.Controls.Add(cbRole);
            tabUsers.Controls.Add(btnAdd);
            tabUsers.Controls.Add(btnEdit);
            tabUsers.Controls.Add(btnDelete);

            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = db.ExecuteQuery("SELECT Id, Username, Role FROM Users");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = $"INSERT INTO Users (Username, Password, Role) VALUES ('{username}', '{password}', '{role}')";
            db.ExecuteNonQuery(query);
            MessageBox.Show("Thêm thành công!");
            LoadUsers();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn một người dùng để sửa!");
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string query = $"UPDATE Users SET Username='{username}', Password='{password}', Role='{role}' WHERE Id={id}";
            db.ExecuteNonQuery(query);
            MessageBox.Show("Cập nhật thành công!");
            LoadUsers();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn một người dùng để xóa!");
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = $"DELETE FROM Users WHERE Id={id}";
                db.ExecuteNonQuery(query);
                MessageBox.Show("Xóa thành công!");
                LoadUsers();
            }
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                txtUsername.Text = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();
                cbRole.SelectedItem = dgvUsers.SelectedRows[0].Cells["Role"].Value.ToString();
            }
        }
    }
}
