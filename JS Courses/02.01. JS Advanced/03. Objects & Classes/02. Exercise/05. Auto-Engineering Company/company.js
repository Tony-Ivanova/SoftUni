function solve(input) {

    let results = new Map();

    input.forEach(line => {
        let [brand, model, numberOfCarsInput] = line.split(' | ');
        let numberOfCars = Number(numberOfCarsInput);

        if (!results.has(brand)) {
            results.set(brand, new Map());
        }

        let mapModels = results.get(brand);

        if (!mapModels.has(model)) {
            mapModels.set(model, 0);
        }

        mapModels.set(model, mapModels.get(model) + Number(numberOfCars));
    });

    for (const brand of results.keys()) {
        console.log(brand);

        let mapModels = results.get(brand);

        for (const model of mapModels.keys()) {
            console.log(`###${model} -> ${mapModels.get(model)}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
)