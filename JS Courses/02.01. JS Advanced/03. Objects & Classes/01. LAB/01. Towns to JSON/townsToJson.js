function solve(array1) {
    let towns = [];
    let regex = /\s*\|\s*/;

    for (let currentLine of array1.splice(1)) {
        let tokens = currentLine.split(regex);

        let currentTown = {
            Town: tokens[1],
            Latitude: Number(Number(tokens[2]).toFixed(2)),
            Longitude: Number(Number(tokens[3]).toFixed(2))
        };

        towns.push(currentTown);
    }

    let myJSON = JSON.stringify(towns);
    console.log(myJSON);
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
)