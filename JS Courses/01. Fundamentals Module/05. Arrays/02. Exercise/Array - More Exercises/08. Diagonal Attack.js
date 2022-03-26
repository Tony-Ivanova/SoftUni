function diagonalAttack(arr) {

    let numberMatrix = arr.map(element => element.split(" ").map(Number));

    let sumFirstDiagonal = 0;
    let sumSecondDiagonal = 0;

    for (let i = 0; i < numberMatrix.length; i++) {
        sumFirstDiagonal += numberMatrix[i][i];
        sumSecondDiagonal += numberMatrix[i][numberMatrix.length - i - 1];
    }

    if (sumFirstDiagonal === sumSecondDiagonal) {
        for (let row = 0; row < numberMatrix.length; row++) {
            let first = numberMatrix[row][row];
            let second = numberMatrix[row][numberMatrix - row - 1];

            for (let col = 0; col < numberMatrix.length; col++) {
                if (row !== col && (row + col) !== numberMatrix.length - 1) {
                    numberMatrix[row][col] = sumSecondDiagonal;
                }
            }
        }
        numberMatrix.forEach(x => console.log(x.join(" ")));

    } else {
        numberMatrix.forEach(x => console.log(x.join(" ")));
    }
}
diagonalAttack(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);