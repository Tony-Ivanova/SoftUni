function solve(array1) {

    let foodAndCalories = [];

    for (let i = 0; i < array1.length; i += 2) {
        let foodName = array1[i];
        let calories = array1[i + 1];
        foodAndCalories.push(`${foodName}: ${calories}`);
    }

    console.log(`{ ${foodAndCalories.join(', ')} }`);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);