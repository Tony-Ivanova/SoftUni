function solve() {
    let checkBtn = document.getElementsByTagName("button")[0];
    let clearBtn = document.getElementsByTagName("button")[1];
    let wholeTable = document.getElementsByTagName("table")[0];
    let sudoku = document.getElementsByTagName("tbody")[0].querySelectorAll("tr");
    let meesage = document.getElementById("check").getElementsByTagName("p")[0];
    let inputs = document.getElementsByTagName("input");

    let winnerMessage = `You solve it! Congratulations!`;
    let looseMessage = `NOP! You are not done yet…`;

    checkBtn.addEventListener("click", () => {
        let matrix = [];

        for (const row of sudoku) {
            let cellsInRow = row.getElementsByTagName("td");
            let currentRow = [];

            for (const cell of cellsInRow) {
                let value = cell.getElementsByTagName("input")[0].value;
                currentRow.push(value);
            }

            matrix.push(currentRow);
        }


        if (isSolved(matrix)) {
            changeTableDisplay(winnerMessage, "green");
        } else {
            changeTableDisplay(looseMessage, "red");
        }


    });

    clearBtn.addEventListener("click", () => {
        meesage.textContent = '';
        table.style.border = 'none';
        Array.from(inputs).forEach(x => x.value = '');
    });


    function isSolved(matrix) {
        let isSolved = true;

        loop: for (let i = 0; i < matrix.length; i++) {
            let row = [];
            let col = [];

            for (let j = 0; j < matrix[i].length; j++) {
                let currentRowValue = matrix[i][j];
                let currentColValue = matrix[j][i];

                if (!isValidInputValue(currentColValue) || !isValidInputValue(currentRowValue)) {
                    isSolved = false;
                    break loop;
                }

                if (isNotDuplicate(row, currentRowValue) && isNotDuplicate(col, currentColValue)) {
                    row.push(currentRowValue);
                    col.push(currentColValue);
                } else {
                    isSolved = false;
                    break loop;
                }
            }
        }
        return isSolved;
    }

    function isValidInputValue(value) {
        return !Number.isNaN(value) && value >= 1 && value <= 3;
    }

    function isNotDuplicate(rowOrCol, value) {
        return rowOrCol.indexOf(value) === -1;
    }

    function changeTableDisplay(messageToDisplay, color) {
        meesage.textContent = messageToDisplay;
        meesage.style.color = color;
        wholeTable.style.border = `2px solid ${color}`;
    }
}