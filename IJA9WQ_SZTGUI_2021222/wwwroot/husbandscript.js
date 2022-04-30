let husbands = [];
let connection = null;
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
            //display();
        });
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
    let name = document.getElementById('actorname').value;
    fetch('http://localhost:18885/husband', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { actorName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            gethusbanddata();
        })
        .catch((error) => { console.error('Error:', error); });

}
