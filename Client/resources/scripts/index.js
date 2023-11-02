// let count = 0;
// let myWorkouts = [];

// function handleOnLoad() {
//     myWorkouts = JSON.parse(localStorage.getItem('myWorkouts')) || [];
//     myWorkouts.push({ Activity: 'ex Running', Distance: 'ex 12', Date: 'ex June 6, 2023' });
//     console.log(myWorkouts);

//     let html = `
//     <h1>Recent Activities</h1>
//     <table class="table">
//         <tr>
//             <th>Activity</th>
//             <th>Distance in miles</th>
//             <th>Date Completed</th>
//         </tr>
//         `;

//     myWorkouts.forEach(function (workout) {
//         if (workout.Distance === undefined) {
//             workout.Distance = 0;
//         }
//         html += `
//         <tr>
//             <td>${workout.Activity}</td>
//             <td>${workout.Distance}</td>
//             <td>${workout.Date}</td>
//         </tr>`;
//     });

//     html += `</table>
//     <form onsubmit="return false">
//         <label for="activity">Activity:</label><br>
//         <input type="text" id="activity" name="activity"><br>

//         <label for="distance">Distance (enter miles):</label><br>
//         <input type="text" id="distance" name="distance"><br>

//         <label for="date">Date:</label><br>
//         <input type="text" id="date" name="date">

//         <button onclick="handleWorkoutAdd()">Submit</button>
//     </form>`;

//     document.getElementById('app').innerHTML = html;
// }

// function handleOnClick() {
//     count++;
//     document.getElementById("body").innerHTML = count;
//     localStorage.setItem('myWorkouts', JSON.stringify(myWorkouts));
// }

// function handleWorkoutAdd() {
//     let workout = {
//         Activity: document.getElementById('activity').value,
//         Distance: document.getElementById('distance').value,
//         Date: document.getElementById('date').value
//     };

//     myWorkouts.push(workout);
//     localStorage.setItem('myWorkouts', JSON.stringify(myWorkouts));
// }
let selectedRow = null;


function onFormSubmit(e) {
    event.preventDefault();

    let formData = readFormData();
    //decides if the record is new for insertion or is just to update a record
    if (selectedRow === null) {
        insertNewRecord(formData);
    }else {
        updateRecord(formData);
    }
    resetForm();

}

//retrieve data
function readFormData() {
    //this is like a normal array but instead of numbers to index, its field ids, which are field labels
    //formData[0] = "runnung"
    let formData = {}; //push html element id into object
    formData["id"] = document.getElementById("id").value;
    formData["activity"] =  document.getElementById("activity").value;
    formData["distance"] =  document.getElementById("distance").value;
    formData["completeDate"] =  document.getElementById("completeDate").value;
    //formData["action"] =  document.getElementById("action").value;
    return formData;
}

//getElemenveById - used when minuplating html element
//getElementByTagName


//insert new data
function insertNewRecord(data) {
    let table = document.getElementById("storeList").getElementsByTagName('tbody')[0];
    let newRow = table.insertRow(table.length);
    //create variable for each element in form
    let cell0 = newRow.insertCell(0);
    cell0.innerHTML  = data.id;

    let cell1 = newRow.insertCell(1);
    cell1.innerHTML  = data.activity;

    let cell2 = newRow.insertCell(2);
    cell2.innerHTML  = data.distance;

    let cell3 = newRow.insertCell(3);
    cell3.innerHTML  = data.completeDate;

    let actionButton = newRow.insertCell(4);
    actionButton.innerHTML  =`<button onclick= 'onEdit(this)>Edit</button> <button onclick = 'onDelete(this)'>Delete</button> <button>Pin</button>`
}

//edit data
function onEdit(td) {
    selectedRow = td.parentElement.parentElement;
    //poplate value into field
    document.getElementById('id').value = selectedRow.cells[0].innerHTML;
    document.getElementById('activity').value = selectedRow.cells[1].innerHTML;
    document.getElementById('distance').value = selectedRow.cells[2].innerHTML;
    document.getElementById('completeDate').value = selectedRow.cells[3].innerHTML;
    //document.getElementById('activity').value = selectedRow.cells[0].innerHTML;
}

//updat record
function updateRecord(formData) {
    selectedRow.cells[0].innerHTML = formData.id; //will be auto assigned
    selectedRow.cells[1].innerHTML = formData.activity;
    selectedRow.cells[2].innerHTML = formData.distance;
    selectedRow.cells[3].innerHTML = formData.completeDate;
  //  selectedRow.cells[3].innerHTML = formData.activity; action
}

//delete the data
function onDelete(td){
    if(confirm('Do you want to delete this record?')) {
        row = td.parentElement.parentElement;
        document.getElementById('storeList').deleteRow(row.rowIndex);
    }
    resetForm();
}


//reset the data
function resetForm() {
    document.getElementById('id').value = '';
    document.getElementById('activity').value = '';
    document.getElementById('distance').value = '';
    document.getElementById('completeDate').value = '';

    selectedRow = null;
}