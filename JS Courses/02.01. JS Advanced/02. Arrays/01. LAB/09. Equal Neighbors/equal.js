function solve(matrix) {

    let numberOfPairs = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {

            let currentElement = matrix[row][col];

            let leftElement = matrix[row][col + 1];

            if (currentElement === leftElement) {
                numberOfPairs += 1;
            }

            if (row !== matrix.length - 1) {
                let downElement = matrix[row + 1][col];
                
                if (currentElement === downElement) {
                    numberOfPairs += 1;
                }
            }
        }
    }

    console.log(numberOfPairs);
}

solve([['2', '2', '5', '7', '4'],
['4', '0', '5', '3', '4'],
['2', '5', '5', '4', '2']])