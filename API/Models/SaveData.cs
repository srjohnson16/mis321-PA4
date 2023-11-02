// using System;
// using System.Runtime.CompilerServices;
// using System.Security.Cryptography;
// using System.Data.SQLite;
// using System.Diagnostics.Eventing.Reader;
// using API.Models.Interfaces;
// using Microsoft.Build.Experimental.ProjectCache;



// namespace API.Models
// {
//     public class SaveData : ISeedData, ISaveData
//     { 
//         public void SeedData()  //get old data out, initializes database ou
//         {
//             //SQLite database connection
//          string connectionString = @"URI=file:C:\\Users\\shali\\OneDrive - The University of Alabama\\MIS321\\source\\repos\\mis321-pa2-srjohnson16\\test.db";

//             //create connection to database
//             using var conToDB = new SQLiteConnection(connectionString);
//             conToDB.Open(); //open connection to database

//             //create command
//             using var command = new SQLiteCommand(connectionString, conToDB);

//             //1. Drop existing table
//             command.CommandText = @"DROP TABLE IF EXISTS workouts"; //SQL statement
//             command.ExecuteNonQuery(); //WE DO NOT WANT A RESULT SET BACK 

//             //2. Create new table, workouts, with field names activity, distance
//             command.CommandText = @"CREATE TABLE workouts(id INTEGER PRIMARY KEY, activity TEXT, distance NUMERIC)";
//             command.ExecuteNonQuery(); //WE DO NOT WANT A RESULT SET BACK when inserting. Drop, Insert, Delete

//             //3. insert data into table
//             command.CommandText = @"INSERT INTO workouts(activity, distance) VALUES(@activity,@distance)";
//             command.Parameters.AddWithValue("@activity","Running");
//             command.Parameters.AddWithValue("@distance","100.0");
//             command.Prepare();
//             command.ExecuteNonQuery();

//             command.CommandText = @"INSERT INTO workouts(activity, distance) VALUES(@activity,@distance)";
//             command.Parameters.AddWithValue("@activity","Swimming");
//             command.Parameters.AddWithValue("@distance","100.0");
//             command.Prepare();
//             command.ExecuteNonQuery();

//             command.CommandText = @"INSERT INTO workouts(activity, distance) VALUES(@activity,@distance)";
//             command.Parameters.AddWithValue("@activity","Jogging");
//             command.Parameters.AddWithValue("@distance","100.0");
//             command.Prepare();
//             command.ExecuteNonQuery();
            
//             //conToDB.Close(); //close database connection
//         }

//         public void SaveWorkout(Workout value)
//         {
//              string connectionString = @"URI=file:C:\\Users\\shali\\OneDrive - The University of Alabama\\MIS321\\source\\repos\\mis321-pa2-srjohnson16\\test.db";

//             //create connection to database
//             using var conToDB = new SQLiteConnection(connectionString);
//             conToDB.Open(); //open connection to database

//             //create command
//             using var command = new SQLiteCommand(connectionString, conToDB);

//             //1. Drop existing table
//             command.CommandText = @"UPDATE workouts set activity = @activity, distance = @distance WHERE id = @id"; //SQL statement
//             command.Parameters.AddWithValue("@id", value.Id);
//             command.Parameters.AddWithValue("@activity", value.Activity);
//             command.Parameters.AddWithValue("@distance", value.Distance);
//             command.Prepare();
//             command.ExecuteNonQuery();

           
//         }

//     }
// }