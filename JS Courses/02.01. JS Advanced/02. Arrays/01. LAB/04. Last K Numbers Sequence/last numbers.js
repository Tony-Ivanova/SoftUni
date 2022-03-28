function solve(length, numbersToSum) {
    let arr1 = [];
    arr1[0] = 1;

    for (let i = 1; i < length; i++) {
        let newSum = 0;

        if (arr1.length >= numbersToSum) {
            arr1.reverse();
            newSum = arr1.slice(0, numbersToSum).reduce((a, b) => a + b);
            arr1.reverse();
        } else {
            newSum = arr1.reduce((a, b) => a + b);
        }

        arr1.push(newSum);
    }

    console.log(arr1);
}

solve(6, 3)