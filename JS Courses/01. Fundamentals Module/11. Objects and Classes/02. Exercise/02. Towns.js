function towns(input) {

    for (let i = 0; i < input.length; i++) {
        let [town, latidute, longitude] = input[i].split(" | ");
        let currentTown = {
            town: town,
            latitude: Number(latidute).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        };
        
        console.log(currentTown);
    }
}

towns(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625'])