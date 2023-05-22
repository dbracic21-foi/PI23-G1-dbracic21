using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaulationManager {
    public class StudentReportView {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string K1 { get; set; }
        public string K2 { get; set; }
        public string Z1 { get; set; }
        public string Z2 { get; set; }
        public string Z3 { get; set; }
        public string HasSignature { get; set; }
        public string HasGrade { get; set; }
        public int TotalPoints { get; set; }
        public int Grade { get; set; }

        public StudentReportView(Student student) { 
         FirstName = student.firstName;
        LastName = student.lastName;
            HasSignature = student.HasSignature() == true ? "DA" : "NE";
            HasGrade = student.HasGrade() == true ? "DA" : "NE";

            TotalPoints = student.CalculateTotalPoints();
            Grade = student.Grade;

            var evaluations = student.GetEvaluations();
            var kolokvij1 = evaluations.FirstOrDefault(e => e.Activity.Name == "Kolokvij1");
            var kolokvij2 = evaluations.FirstOrDefault(e => e.Activity.Name == "Kolokvij2");
            var zadaca1 = evaluations.FirstOrDefault(e => e.Activity.Name == "Zadaca1");
            var zadaca2 = evaluations.FirstOrDefault(e => e.Activity.Name == "Zadaca2");
            var zadaca3 = evaluations.FirstOrDefault(e => e.Activity.Name == "Zadaca3");

            K1 = kolokvij1 == null ? "-" : kolokvij1.Points.ToString();
            K2 = kolokvij2 == null ? "-" : kolokvij2.Points.ToString();
            Z1 = zadaca1 == null ? "-" : zadaca1.Points.ToString();
            Z2 = zadaca2 == null ? "-" : zadaca2.Points.ToString();
            Z3 = zadaca3 == null ? "-" : zadaca3.Points.ToString();

            






        }
        private List<StudentReportView> GenerateStudentReport() {

            var allStudents = StudentRepository.GetStudents();
            var examReports = new List<StudentReportView>();
            foreach (var student in allStudents) {
                if (student.HasSignature() == true) {
                    var examReport = new StudentReportView(student);
                    examReports.Add(examReport);
                }
            }
            return examReports;
        }


    }
}
