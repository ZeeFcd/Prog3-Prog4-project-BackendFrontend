let husbands = [];
let connection = null;
let husbandIdToUpdate = -1;
gethusbanddata();
setupSignalRhusband();




function setupSignalRhusband() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:18885/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("HusbandCreated", (user, message) => {
        gethusbanddata();
    });

    connection.on("HusbandUpdated", (user, message) => {
        gethusbanddata();
    });

    connection.on("HusbandDeleted", (user, message) => {
        gethusbanddata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function gethusbanddata() {
    await fetch('http://localhost:18885/husband')
        .then(x => x.json())
        .then(y => {
            husbands = y;
            console.log(husbands);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    husbands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            + t.age + "</td><td>" +
            + t.wifeID + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function showupdate(id) {

    document.getElementById('husbandnametoupdate').value = husbands.find(t => t['id'] == id)['name'];
    document.getElementById('husbandagetoupdate').value = husbands.find(t => t['id'] == id)['age'];
    document.getElementById('wifeidtoupdate').value = husbands.find(t => t['id'] == id)['wifeID'];
    document.getElementById('updateformdiv').style.display = 'flex';
    husbandIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:18885/husband/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            gethusbanddata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('husbandname').value;
    let age = document.getElementById('age').value;
    let wifeid = document.getElementById('wifeid').value;
    fetch('http://localhost:18885/husband', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Age: age, WifeID: wifeid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            gethusbanddata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('husbandnametoupdate').value;
    let age = document.getElementById('husbandagetoupdate').value;
    let wifeid = document.getElementById('wifeidtoupdate').value;
    fetch('http://localhost:18885/husband', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: husbandIdToUpdate, Name: name, Age: age, WifeID: wifeid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            gethusbanddata();
        })
        .catch((error) => { console.error('Error:', error); });

}
