using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaulationManager
{
    public class StudentRepository
    {
        private Student CreateObject(SqlDataReader reader)
        {
          int id = int.Parse(reader["ID"].ToString());
            string firstName = reader["firstName"].ToString();
            string lastName = reader["lastName"].ToString();
            int.TryParse(reader["Grade"].ToString(), out int grade);

            var student = new Student { 
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Grade = grade        
            };
            return student;
           
        }
        public  Student GetStudent(int id)
        {
            Student student = null;
            string sql = $"SELECT * From Studentss WHERE Id={id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                student = CreateObject(reader);
                reader.Close();

            }
            DB.CloseConnection();
            return student;
        }
        public   List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string sql = "SELECT * FROM Students";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Student student = CreateObject(reader);
            }
            reader.Close();
            DB.CloseConnection();

            return students;
        }


    }
}