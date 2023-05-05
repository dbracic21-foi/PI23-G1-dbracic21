using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaulationManager {
    public class StudentRepository 
    {
        private Student CreateObject(SqlDataReader reader) {
          //implementirat createObject do kraja
        }
        public Student GetStudent(int id) {
            Student student = null;
            SqlDataReader reader = DB.GetDataReader($"SELECT * FROM Students where Id = {id}");
            if (reader.HasRows) {
                reader.Read();
                student = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return student;
        }
        public List<Student> GetAllStudents() {
            return null;
        }
    }

}
