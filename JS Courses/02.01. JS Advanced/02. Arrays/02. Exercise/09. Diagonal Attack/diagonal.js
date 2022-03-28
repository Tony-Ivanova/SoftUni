function solve(arr) {

    let matrix = arr.map(row => row.split(' ').map(Number));

    let mainArray = [];
    let secondaryArray = [];

    for (let row = 0; row < matrix.length; row++) {
        let mainElement = matrix[row][row];
        mainArray.push(mainElement);
        let secondaryElement = matrix[row][matrix.length - 1 - row];
        secondaryArray.push(secondaryElement);
    }

    let sumMainArray = mainArray.reduce((a, b) => a + b, 0);
    let sumSecondaryArray = secondaryArray.reduce((a, b) => a + b, 0);

    if (sumMainArray === sumSecondaryArray) {
        for (let row = 0; row < matrix.length; row++) {
            matrix[row].fill(sumMainArray);
        }

        for (let row = 0; row < matrix.length; row++) {
            let mainElement = mainArray.shift();
            matrix[row][row] = mainElement
            let secondaryElement = secondaryArray.shift();
            matrix[row][matrix.length - 1 - row] = secondaryElement;
        }
    }

    for (var row = 0; row < matrix.length; row++) {
        console.log(matrix[row].join(' '));
    }
}

solve(['1 1 1',
    '1 1 1',
    '1 1 0']

)