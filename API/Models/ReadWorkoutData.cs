using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using API.Models.Interfaces;
using Microsoft.Build.Experimental.ProjectCache;



namespace API.Models
{
    public class ReadWorkoutData : IGetAllWorkouts, IGetWorkout
    {
        public List<Workout> GetAllWorkouts()
        {
          string cs = @"C:\\Users\\shali\\OneDrive - The University of Alabama\\MIS321\\source\\repos\\mis321-PA4\\test.db";
          using var con = new SQLiteConnection(cs);
          con.Open();

          string sqlSTM = "SELECT * FROM workouts";
          using var cmd = new SQLiteCommand(sqlSTM, con);

          using SQLiteDataReader reader = cmd.ExecuteReader();

          List<Workout> allWorkouts = new List<Workout>();

          while(reader.Read()) {
            allWorkouts.Add(new Workout(){Id=reader.GetInt32(0), Activity=reader.GetString(1), Distance=reader.GetDouble(3)});//, Date=reader.GetString(4)});
          }
       // allWorkouts.Add(new Workout(){Id=19, Activity="Running", Distance=3.0});//, Date=reader.GetString(4)});


          return allWorkouts;
        }

        public Workout GetWorkout(int id)
        {
          string cs = @"C:\\Users\\shali\\OneDrive - The University of Alabama\\MIS321\\source\\repos\\mis321-PA4\\test.db";
          using var con = new SQLiteConnection(cs);
          con.Open();

          string stm = @"SELECT * FROM workouts WHERE id=@id";
          using var cmd = new SQLiteCommand(stm, con);
          cmd.Parameters.AddWithValue("@id",id);
          cmd.Prepare();
          using SQLiteDataReader reader = cmd.ExecuteReader();

          reader.Read();
        
          return new Workout(){Id=reader.GetInt32(0), Activity=reader.GetString(1), Distance=reader.GetDouble(3)};
        }
    }
}