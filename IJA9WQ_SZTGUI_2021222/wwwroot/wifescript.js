let wives = [];
let connection = null;
let wifeIdToUpdate=-1;
getwifedata();
setupSignalRwife();

function setupSignalRwife() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:18885/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("WifeCreated", (user, message) => {
        getwifedata();
    });

    connection.on("WifeUpdated", (user, message) => {
        getwifedata();
    });

    connection.on("WifeDeleted", (user, message) => {
        getwifedata();
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

async function getwifedata() {
    await fetch('http://localhost:18885/wife')
        .then(x => x.json())
        .then(y => {
            wives = y;
            console.log(wives);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    wives.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            + t.age + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function showupdate(id) {

    document.getElementById('wifenametoupdate').value = wives.find(t => t['id'] == id)['name'];
    document.getElementById('wifeagetoupdate').value = wives.find(t => t['id'] == id)['age'];
    document.getElementById('updateformdiv').style.display = 'flex';
    wifeIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:18885/wife/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getwifedata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('wifename').value;
    let age = document.getElementById('age').value;
    fetch('http://localhost:18885/wife', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Age: age })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getwifedata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('wifenametoupdate').value;
    let age = document.getElementById('wifeagetoupdate').value;
    fetch('http://localhost:18885/wife', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: wifeIdToUpdate, Name: name, Age: age })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getwifedata();
        })
        .catch((error) => { console.error('Error:', error); });

}
