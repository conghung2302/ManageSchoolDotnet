using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolManagement
{
    public class StudentForm : Form
    {
        private DataGridView dgvStudents;
        private TextBox txtName, txtAge, txtClass;
        private Button btnAdd, btnEdit, btnDelete, btnManageScores;
        private string connectionString = "server=localhost;database=SchoolDB;user=root;password=yourpassword";

        public StudentForm()
        {
            // Thiết lập Form
            this.Text = "Quản lý Học sinh";
            this.Size = new Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView
            dgvStudents = new DataGridView() { Location = new Point(20, 20), Size = new Size(540, 200) };
            dgvStudents.SelectionChanged += DgvStudents_SelectionChanged;

            // TextBox
            txtName = new TextBox() { Location = new Point(120, 240), Width = 150, PlaceholderText = "Tên học sinh" };
            txtAge = new TextBox() { Location = new Point(120, 270), Width = 150, PlaceholderText = "Tuổi" };
            txtClass = new TextBox() { Location = new Point(120, 300), Width = 150, PlaceholderText = "Lớp" };

            // Button
            btnAdd = new Button() { Text = "Thêm", Location = new Point(300, 240), Width = 100 };
            btnEdit = new Button() { Text = "Sửa", Location = new Point(300, 270), Width = 100 };
            btnDelete = new Button() { Text = "Xóa", Location = new Point(300, 300), Width = 100 };
            btnManageScores = new Button() { Text = "Quản lý điểm", Location = new Point(420, 240), Width = 120 };

            // Sự kiện Button
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnManageScores.Click += BtnManageScores_Click;

            // Thêm vào Form
            this.Controls.Add(dgvStudents);
            this.Controls.Add(txtName);
            this.Controls.Add(txtAge);
            this.Controls.Add(txtClass);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnManageScores);

            // LoadStudents();
        }

        private void LoadStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Students", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvStudents.DataSource = dt;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Students (Name, Age, Class) VALUES (@Name, @Age, @Class)", conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                cmd.ExecuteNonQuery();
            }
            LoadStudents();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Students SET Name=@Name, Age=@Age, Class=@Class WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                cmd.ExecuteNonQuery();
            }
            LoadStudents();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Students WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            LoadStudents();
        }

        private void BtnManageScores_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0) return;
            int studentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);
            // ScoreForm scoreForm = new ScoreForm(studentId);
            // scoreForm.ShowDialog();
        }

        private void DgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                txtName.Text = dgvStudents.SelectedRows[0].Cells["Name"].Value.ToString();
                txtAge.Text = dgvStudents.SelectedRows[0].Cells["Age"].Value.ToString();
                txtClass.Text = dgvStudents.SelectedRows[0].Cells["Class"].Value.ToString();
            }
        }
    }
    
}
