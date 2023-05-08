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
        private Student selectedStudent = null;

        public FrmEvalution() {
            this.selectedStudent = selectedStudent;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label2_Click_1(object sender, EventArgs e) {

        }

        private void FrmEvalution_Load(object sender, EventArgs e) {
            SetFormTitle();
            PopulateActivities();
        }
        private void SetFormTitle() {
            this.Text = $"{selectedStudent.firstName} {selectedStudent.lastName}";
        }
        private void PopulateActivities() {
            cboActivites.DataSource = ActivityRepository.GetActivities();
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
