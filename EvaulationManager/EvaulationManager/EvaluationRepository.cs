using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaulationManager
{
    public class EvaluationRepository
    {
        public static Evaluation GetEvaluation(Student student, Activity activity)
        {
            Evaluation evaluation = null;
            string sql = $"SELECT * FROM Evaluations WHERE IdStudents = {student.Id} AND
 IdActivities = { activity.Id}
            ";
 DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                evaluation = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return evaluation;

        }
        public static List<Evaluation> GetEvaluations(Student student)
        {
            List<Evaluation> evaluations = new List<Evaluation>();
            string sql = $"SELECT * FROM Evaluations WHERE IdStudents = {student.Id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Evaluation evaluation = CreateObject(reader);
                evaluations.Add(evaluation);
            }
            reader.Close();
            DB.CloseConnection();
            return evaluations;
        }

    }
}
