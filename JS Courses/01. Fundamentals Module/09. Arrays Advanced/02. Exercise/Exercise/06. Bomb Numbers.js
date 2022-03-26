function bombNumbers(arr, bomb) {
    let bombNumber = bomb[0];
    let bombPower = bomb[1];

    while (arr.includes(bombNumber)) {

        let indexOfBomb = arr.indexOf(bombNumber);
        let start = indexOfBomb - bombPower <= 0 ? 0 : indexOfBomb - bombPower;
        let end = bombPower * 2 + 1;

        arr.splice(start, end);
    }

    let sum = arr.reduce((a, b) => a + b, 0);
    console.log(sum);
    
}
bombNumbers([1, 4, 4, 2, 8, 9, 1],
    [9, 3]

)