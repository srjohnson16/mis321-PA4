namespace API.Models
{
    public class Workout
    {
   
        //this class is used so we can have a list of something! A class is a type of data structure, like in Matlab! Its a big variable with multiple attributes
        public int Id{get;set;}
        public string? Activity {get;set;}
        public double Distance{get;set;}

     //   public string Date{get;set;}

        public override string ToString() 
        {
            return Activity + " performed for " + Distance + " miles " ;//+ Date;
        }
    
    }
}