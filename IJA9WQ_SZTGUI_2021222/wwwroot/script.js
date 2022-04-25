fetch('http://localhost:18885/wedding')
    .then(x => x.json())
    .then(y => console.log(y));