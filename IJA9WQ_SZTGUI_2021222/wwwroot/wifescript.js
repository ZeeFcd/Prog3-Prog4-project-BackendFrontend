let wives = [];
let connection = null;
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
            //display();
        });
}
