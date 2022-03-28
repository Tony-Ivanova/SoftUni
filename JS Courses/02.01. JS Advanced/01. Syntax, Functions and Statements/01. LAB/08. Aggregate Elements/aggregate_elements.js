function solve(array1) {
    let sum = array1.reduce((a, b) => a + b, 0);
    let newArray = array1.map(convertElements);

    function convertElements(num) {
        return 1 / num
    }

    let sumInverse = newArray.reduce((a, b) => a + b, 0);
    let concatElements = array1.join('');

    console.log(sum);
    console.log(sumInverse);
    console.log(concatElements);
}

solve([1, 2, 3]);