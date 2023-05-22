using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaulationManager {
    public static class ActivityRepository {
        private static Activity CreateObject(SqlDataReader reader) {
           Activity aktivnost= new Activity();
            aktivnost.Id = int.Parse(reader["ID"].ToString());
             aktivnost.Name = reader["Name"].ToString();
            aktivnost.Description = reader["Description"].ToString();
            int.TryParse(reader["MaxPoints"].ToString(), out int MaxPoints);
            int.TryParse(reader["MinPointsForGrade"].ToString(), out int minPointsForGrade);
            int.TryParse(reader["MinPointsForSignature"].ToString(), out int minPointsForSignature);
            aktivnost.MaxPoints=MaxPoints;
            aktivnost.minPointsForGrade=minPointsForGrade;
            aktivnost.MinPointsForSignature=minPointsForSignature;

            return aktivnost;


       
            }

        
        public static Activity  GetActivity(int id) {
            Activity aktivnost=new Activity();
            string sql = $"SELECT * From Aktivnost WHERE Id={id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) {
                reader.Read();
                aktivnost = CreateObject(reader);
                reader.Close();

            }
            DB.CloseConnection();
            return aktivnost;
        }
        public static List<Activity> GetActivities() {
            List<Activity> aktivnosti = new List<Activity>();
            string sql = "SELECT * FROM Activities";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read()) {
             Activity aktivnost = CreateObject(reader);
                aktivnosti.Add(aktivnost);
            }
            reader.Close();
            DB.CloseConnection();

            return aktivnosti;
        }
        private static Activity CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            string description = reader["Description"].ToString();
            int maxPoints = int.Parse(reader["MaxPoints"].ToString());
            int minPointsForGrade =
            int.Parse(reader["MinPointsForGrade"].ToString());
            int minPointsForSignature =
           int.Parse(reader["MinPointsForSignature"].ToString());
            var activity = new Activity
            {
                Id = id,
                Name = name,
                Description = description,
                MaxPoints = maxPoints,
                MinPointsForGrade = minPointsForGrade,
                MinPointsForSignature = minPointsForSignature
            };
            return activity;
        }

    }
}
