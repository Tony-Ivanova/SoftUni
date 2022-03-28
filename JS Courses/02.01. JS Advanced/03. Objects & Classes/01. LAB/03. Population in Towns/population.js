function solve(args) {

    let townsAndPopulation = {};

    for (const pair of args) {
        let [town, population] = pair.split(' <-> ')
        
        if (!townsAndPopulation.hasOwnProperty(town)) {
            townsAndPopulation[town] = Number(population);
        } else {
            townsAndPopulation[town] += Number(population);
        }
    }

    for (const key in townsAndPopulation) {
        console.log(`${key} : ${townsAndPopulation[key]}`);
    }
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000',
    'Sofia <-> 333'
]

)