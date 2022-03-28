function solve(arr) {

    let matrix = [[false, false, false],
    [false, false, false],
    [false, false, false]];

    let player = 'O';

    while (true) {

        if (noMoreMoves(matrix) !== true || arr.length == 0) {
            console.log(`The game ended! Nobody wins :(`);
            break;
        }

        let tokens = arr.shift().split(' ').map(Number);
        let [moveRow, moveCol] = [tokens[0], tokens[1]];

        if (matrix[moveRow][moveCol] !== false) {
            console.log(`This place is already taken. Please choose another!`);
            continue;
        }

        player = player === 'O' ? 'X' : 'O';
        matrix[moveRow][moveCol] = player;

        if (checkWinnerRow(matrix, player) === true || checkWinnerCols(matrix, player) === true || checkWinnerDiagonals(matrix, player) === true) {
            console.log(`Player ${player} wins!`);
            break;
        }

        function checkWinnerRow(matrix, player) {
            let thereIsWinner = false;

            for (let row = 0; row < matrix.length; row++) {
                thereIsWinner = matrix[row].every(x => x === player);
                if (thereIsWinner === true) {
                    break;
                }
            }

            return thereIsWinner;
        }

        function checkWinnerCols(matrix, player) {
            let thereIsWinner = false;

            for (let i = 0; i < matrix.length; i++) {
                const arrayColumn = (arr, n) => arr.map(x => x[n]);
                let col = arrayColumn(matrix, i);
                if (col.every(x => x === player)) {
                    thereIsWinner = true;
                    break;
                }
            }

            return thereIsWinner;
        }

        function checkWinnerDiagonals(matrix, player) {
            let thereIsWinner = false;

            let mainArray = [];
            let secondaryArray = [];
            let mainElement = '';
            let secondaryElement = '';

            for (let row = 0; row < matrix.length; row++) {
                mainElement = matrix[row][row];
                mainArray.push(mainElement);
                secondaryElement = matrix[row][matrix.length - 1 - row];
                secondaryArray.push(secondaryElement);
            }

            if (mainArray.every(x => x == player) || secondaryArray.every(x => x == player)) {
                thereIsWinner = true;
            }

            return thereIsWinner;
        }

        function noMoreMoves(matrix) {
            let thereAreEmptySpaces = false;

            for (let row = 0; row < matrix.length; row++) {
                thereAreEmptySpaces = matrix[row].some(x => x === false);

                if (thereAreEmptySpaces) {
                    break;
                }
            }
            return thereAreEmptySpaces;
        }
    }

    for (var row = 0; row < matrix.length; row++) {
        console.log(matrix[row].join('\t'));
    }
}

solve(["0 0",
    "0 2",
    "1 0",
    "2 2",
    "2 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"
]
)