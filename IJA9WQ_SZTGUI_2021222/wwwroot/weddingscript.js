let weddings = [];
let connection = null;
let weddingIDToUpdate = -1;
getweddingdata();
setupSignalRwedding();

function setupSignalRwedding() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:18885/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("WeddingCreated", (user, message) => {
        getweddingdata();
    });

    connection.on("WeddingUpdated", (user, message) => {
        getweddingdata();
    });

    connection.on("WeddingDeleted", (user, message) => {
        getweddingdata();
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

async function getweddingdata() {
    await fetch('http://localhost:18885/wedding')
        .then(x => x.json())
        .then(y => {
            weddings = y;
            console.log(weddings);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    weddings.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.place + "</td><td>" +
            + t.price + "</td><td>" +
            + t.husbandID + "</td><td>" +
            + t.wifeID + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function showupdate(id) {

    document.getElementById('weddingplacetoupdate').value = weddings.find(t => t['id'] == id)['place'];
    document.getElementById('pricetoupdate').value = weddings.find(t => t['id'] == id)['price'];
    document.getElementById('husbandidtoupdate').value = weddings.find(t => t['id'] == id)['husbandID'];
    document.getElementById('wifeidtoupdate').value = weddings.find(t => t['id'] == id)['wifeID'];
    document.getElementById('updateformdiv').style.display = 'flex';
    weddingIDToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:18885/wedding/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getweddingdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let place = document.getElementById('weddingplace').value;
    let price = document.getElementById('price').value;
    let husbandid = document.getElementById('husbandid').value;
    let wifeid = document.getElementById('wifeid').value;
    fetch('http://localhost:18885/wedding', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Place: place, Price: price, HusbandID: husbandid, WifeID: wifeid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getweddingdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    let place = document.getElementById('weddingplacetoupdate').value;
    let price = document.getElementById('pricetoupdate').value;
    let husbandid = document.getElementById('husbandidtoupdate').value;
    let wifeid = document.getElementById('wifeidtoupdate').value;
    fetch('http://localhost:18885/wedding', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: weddingIDToUpdate, HusbandID: husbandid, WifeID: wifeid, Place: place, Price: price })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getweddingdata();
        })
        .catch((error) => { console.error('Error:', error); });

}