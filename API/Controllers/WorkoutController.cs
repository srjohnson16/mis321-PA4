using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        // GET: api/Workout
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "waorke", "value2" };
        // }

       public List<Workout> Get() 
        {
            IGetAllWorkouts readObj = new ReadWorkoutData();

            return readObj.GetAllWorkouts(); 
        }


        // GET: api/Workout/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Workout Get(int id)
        {
            IGetWorkout readObj = new ReadWorkoutData();
            return readObj.GetWorkout(id);
        }

        // POST: api/Workout
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Workout value)
        {
            IInsertWorkout insertObj = new SaveWorkout();
            insertObj.InsertWorkout(value);
        }

        // PUT: api/Workout/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Workout/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
