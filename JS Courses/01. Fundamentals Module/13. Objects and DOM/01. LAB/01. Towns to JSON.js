function TownsToJSON(array1) {

    let towns = [];
    let regex = /\s*\|\s*/;

    for (let currentLine of array1.splice(1)) {
        let tokens = currentLine.split(regex);

        let currentTown = {
            Town: tokens[1],
            Latitude: Number(tokens[2]),
            Longitude: Number(tokens[3])
        };

        towns.push(currentTown);
    }

    let myJSON = JSON.stringify(towns);
    console.log(myJSON);
}