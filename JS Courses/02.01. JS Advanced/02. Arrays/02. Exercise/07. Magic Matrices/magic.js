function solve(matrix) {
    let isEqual = true;
    let previousRowSum = matrix[0].map(Number).reduce((a, b) => a + b);

    for (let row = 1; row < matrix.length; row++) {
        let currentRowSum = matrix[row].map(Number).reduce((a, b) => a + b);

        if (currentRowSum !== previousRowSum) {
            isEqual = false;
            break;
        }

        previousRowSum = currentRowSum;
    }
    
    console.log(isEqual);
}

solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]

)