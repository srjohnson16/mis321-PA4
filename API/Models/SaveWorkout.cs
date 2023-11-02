using  System.Data.SQLite;
using API.Models.Interfaces;

namespace API.Models
{
    public class SaveWorkout: IInsertWorkout
    {
        public void InsertWorkout(Workout value)
        {
            string connectionString = @"URI=file:C:\\Users\\shali\\OneDrive - The University of Alabama\\MIS321\\source\\repos\\mis321-pa2-srjohnson16\\test.db";

            //create connection to database
            using var conToDB = new SQLiteConnection(connectionString);
            conToDB.Open(); //open connection to database

            //create command
            using var command = new SQLiteCommand(connectionString, conToDB);

            //1. Drop existing table
            command.CommandText = @"UPDATE workouts set activity = @activity, distance = @distance WHERE id = @id"; //SQL statement
            command.Parameters.AddWithValue("@id", value.Id);
            command.Parameters.AddWithValue("@activity", value.Activity);
            command.Parameters.AddWithValue("@distance", value.Distance);
            command.Prepare();
            command.ExecuteNonQuery();
        }



    }
}