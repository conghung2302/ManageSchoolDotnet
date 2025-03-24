using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _
{



    public partial class StudentScore : Form
    {
        private List<Student> students = new List<Student>();
        private DataGridView dataGridView1;
        private TextBox txtName, txtMath, txtPhysics, txtChemistry, txtEnglish;
        private Button btnAdd, btnUpdate, btnDelete;

        public StudentScore()
        {
            SetupUI();
            UpdateGrid();
        }

        private void SetupUI()
        {
            this.Text = "Student Score Management";
            this.Size = new System.Drawing.Size(700, 400);

            Label lblName = new Label { Text = "Name", Left = 10, Top = 10 };
            txtName = new TextBox { Left = 100, Top = 10, Width = 200 };

            Label lblMath = new Label { Text = "Math", Left = 10, Top = 40 };
            txtMath = new TextBox { Left = 100, Top = 40, Width = 200 };

            Label lblPhysics = new Label { Text = "Physics", Left = 10, Top = 70 };
            txtPhysics = new TextBox { Left = 100, Top = 70, Width = 200 };

            Label lblChemistry = new Label { Text = "Chemistry", Left = 10, Top = 100 };
            txtChemistry = new TextBox { Left = 100, Top = 100, Width = 200 };

            Label lblEnglish = new Label { Text = "English", Left = 10, Top = 130 };
            txtEnglish = new TextBox { Left = 100, Top = 130, Width = 200 };

            btnAdd = new Button { Text = "Add", Left = 320, Top = 10, Width = 80 };
            btnUpdate = new Button { Text = "Update", Left = 320, Top = 40, Width = 80 };
            btnDelete = new Button { Text = "Delete", Left = 320, Top = 70, Width = 80 };

            dataGridView1 = new DataGridView { Left = 10, Top = 180, Width = 660, Height = 180 };

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblMath);
            this.Controls.Add(txtMath);
            this.Controls.Add(lblPhysics);
            this.Controls.Add(txtPhysics);
            this.Controls.Add(lblChemistry);
            this.Controls.Add(txtChemistry);
            this.Controls.Add(lblEnglish);
            this.Controls.Add(txtEnglish);
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
                Math = double.Parse(txtMath.Text),
                Physics = double.Parse(txtPhysics.Text),
                Chemistry = double.Parse(txtChemistry.Text),
                English = double.Parse(txtEnglish.Text)
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
                students[index].Math = double.Parse(txtMath.Text);
                students[index].Physics = double.Parse(txtPhysics.Text);
                students[index].Chemistry = double.Parse(txtChemistry.Text);
                students[index].English = double.Parse(txtEnglish.Text);
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
                txtMath.Text = students[e.RowIndex].Math.ToString();
                txtPhysics.Text = students[e.RowIndex].Physics.ToString();
                txtChemistry.Text = students[e.RowIndex].Chemistry.ToString();
                txtEnglish.Text = students[e.RowIndex].English.ToString();
            }
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students.Select(s => new
            {
                s.Name,
                s.Math,
                s.Physics,
                s.Chemistry,
                s.English,
                Average = (s.Math + s.Physics + s.Chemistry + s.English) / 4
            }).ToList();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtMath.Clear();
            txtPhysics.Clear();
            txtChemistry.Clear();
            txtEnglish.Clear();
        }
    }


}