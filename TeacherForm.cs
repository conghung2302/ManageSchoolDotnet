using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _
{
    public partial class TeacherForm : Form
    {
        private List<Student> students = new List<Student>();
        private DataGridView dataGridView1;
        private TextBox txtName, txtEmail, txtAge, txtAddress;
        private Button btnAdd, btnUpdate, btnDelete;

        public TeacherForm()
        {
            // InitializeComponent();
            SetupUI();
            UpdateGrid();
        }

        private void SetupUI()
        {
            this.Text = "Student Management";
            this.Size = new System.Drawing.Size(600, 400);

            Label lblName = new Label { Text = "Name", Left = 10, Top = 10 };
            txtName = new TextBox { Left = 100, Top = 10, Width = 200 };

            Label lblEmail = new Label { Text = "Email", Left = 10, Top = 40 };
            txtEmail = new TextBox { Left = 100, Top = 40, Width = 200 };

            Label lblAge = new Label { Text = "Age", Left = 10, Top = 70 };
            txtAge = new TextBox { Left = 100, Top = 70, Width = 200 };

            Label lblAddress = new Label { Text = "Address", Left = 10, Top = 100 };
            txtAddress = new TextBox { Left = 100, Top = 100, Width = 200 };

            btnAdd = new Button { Text = "Add", Left = 320, Top = 10, Width = 80 };
            btnUpdate = new Button { Text = "Update", Left = 320, Top = 40, Width = 80 };
            btnDelete = new Button { Text = "Delete", Left = 320, Top = 70, Width = 80 };

            dataGridView1 = new DataGridView { Left = 10, Top = 140, Width = 560, Height = 200 };

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblAge);
            this.Controls.Add(txtAge);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(dataGridView1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            students.Add(new Student
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Age = int.Parse(txtAge.Text),
                Address = txtAddress.Text
            });
            UpdateGrid();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                students[index].Name = txtName.Text;
                students[index].Email = txtEmail.Text;
                students[index].Age = int.Parse(txtAge.Text);
                students[index].Address = txtAddress.Text;
                UpdateGrid();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                students.RemoveAt(dataGridView1.CurrentRow.Index);
                UpdateGrid();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = students[e.RowIndex].Name;
                txtEmail.Text = students[e.RowIndex].Email;
                txtAge.Text = students[e.RowIndex].Age.ToString();
                txtAddress.Text = students[e.RowIndex].Address;
            }
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            txtAddress.Clear();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }


        
        public double Math { get; set; }
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double English { get; set; }
    }
}
