function getWorkouts() {
    const allWorkoutsApiUrl = "http://localhost:5029/api/workout";

    fetch(allWorkoutsApiUrl).then(function(reponse){
        console.log(reponse);
        return reponse.json();
    }).then(function(json){

        let html = "<ul>";
        json.foreach((workout)=>{
            html+="<li>" +workout.activity+"Writtern by"+workout.distance+"</li>";
        });
        html += "</ul>";
        document.getElementById("workouts").innerHTML=html;
    }).catch(function(error){
        console.log(error);
    })
}

//inset data to base
function postWorkout() {
    const postWorkoutUrl = "http://localhost:5029/api/workout";
    const activityType = document.getElementById("activity").value;
    const distanceI = document.getElementById("distance").value; //dis
    const dateCompletedI = document.getElementById("completeDate").value; //datw

    //call backend
    fetch(postWorkoutUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Context-Type":'application/json'
        },
        body: JSON.stringify({
            activity: activityName,
            distance: distanceI,
            completeDate: dateCompletedI

        })

    })
    .then((response)=>{
        console.log(response);
        getWorkouts();
    })
}