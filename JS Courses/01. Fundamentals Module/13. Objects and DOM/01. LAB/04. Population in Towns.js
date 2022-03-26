function populationInTown(input) {

    let regex = /\s<->\s/;
    let objects = new Map();

    for (let index = 0; index < input.length; index++) {
        let element = input[index].split(regex);

        let city = element[0];
        let population = Number(element[1]);

        if (!objects.has(city)) {
            objects.set(city, population);
        } else {
            objects.set(city, objects.get(city) + population);
        }
    }

    for (let currentObject of objects) {
        console.log(`${currentObject[0]} : ${currentObject[1]}`);
    }
}