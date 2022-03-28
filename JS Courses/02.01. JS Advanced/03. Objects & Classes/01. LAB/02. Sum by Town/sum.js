function solve(arr1) {
    let towns = {};

    for (let i = 0; i < arr1.length; i += 2) {
        let currentTown = arr1[i];
        
        if (!towns.hasOwnProperty(currentTown)) {
            towns[currentTown] = 0;
        }

        let income = Number(arr1[i + 1]);
        towns[currentTown] += income;
    }

    let myJSON = JSON.stringify(towns);
    console.log(myJSON);
}

solve(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4'])