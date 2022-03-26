function sumByTowns(input) {

    let objects = {};

    for (let i = 0; i < input.length; i += 2) {

        if (!objects.hasOwnProperty(input[i])) {
            objects[input[i]] = 0;
        }

        objects[input[i]] += Number(input[i + 1]);
    }

    let myJSON = JSON.stringify(objects);
    console.log(myJSON);
}