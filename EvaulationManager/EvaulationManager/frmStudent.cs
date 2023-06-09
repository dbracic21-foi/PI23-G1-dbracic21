﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaulationManager
{
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            ShowStudents();
        }
        private void ShowStudents() {
            List<Student> students = StudentRepository.GetStudents();
            dgvStudents.DataSource = students;

            dgvStudents.Columns["Id"].DisplayIndex = 0;
            dgvStudents.Columns["FirstName"].DisplayIndex = 1;
            dgvStudents.Columns["LastName"].DisplayIndex = 2;
            dgvStudents.Columns["Grade"].DisplayIndex = 3;




        }

        private void button1_Click(object sender, EventArgs e) {
            if (dgvStudents.SelectedRows.Count > 0) {
                Student selectedStudent = dgvStudents.CurrentRow.DataBoundItem as Student;
                if(selectedStudent != null) {
                    FrmEvalution frmEvaluation = new FrmEvalution(selectedStudent);
                    frmEvaluation.ShowDialog();
                }
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
