using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaulationManager {
    public partial class FrmEvalution : Form {
        private Student student;

        public FrmEvalution(Student selectedStudent) {
           
            InitializeComponent();
            student = selectedStudent;
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label2_Click_1(object sender, EventArgs e) {

        }

        private void FrmEvalution_Load(object sender, EventArgs e) {
            SetFormText(student);
            var activities = ActivityRepository.GetActivities();
            cboActivities.DataSource = activities;
        }
        private void SetFormText(Student selectedStudent) {
            student = selectedStudent;
            this.Text = $"{selectedStudent.firstName} {selectedStudent.lastName}";
        }
        private void PopulateActivities() {
            cboActivites.DataSource = ActivityRepository.GetActivities();
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentActivity = cboActivities.SelectedItem as Activity;
            txtActivityDescription.Text = currentActivity.Description;
            txtMinForGrade.Text = currentActivity.MinPointsForGrade + "/" +
           currentActivity.MaxPoints;
            txtMinForSignature.Text = currentActivity.MinPointsForSignature + "/" +
           currentActivity.MaxPoints;
            numPoints.Minimum = 0;
            numPoints.Maximum = currentActivity.MaxPoints;
            var evaluation =
EvaluationRepository.GetEvaluation(SelectedStudent, currentActivity);
            if (evaluation != null)
            {
                txtTeacher.Text = evaluation.Evaluator.ToString();
                txtEvaluationDate.Text = evaluation.EvaluationDate.ToString();
                numPoints.Value = evaluation.Points;
            }
            else
            {
                txtTeacher.Text = FrmLogin.LoggedTeacher.ToString();
                txtEvaluationDate.Text = "-";
                numPoints.Value = 0;
            }


        }
    }
}
