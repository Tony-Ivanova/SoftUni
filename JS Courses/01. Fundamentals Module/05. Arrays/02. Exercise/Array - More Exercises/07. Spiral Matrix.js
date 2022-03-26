function spiral(rowsNumber, colsNumber){

    let result = new Array(rowsNumber).fill().map(() => new Array(colsNumber).fill('')); // create empty n x n array
    let counter = 1;
    let startCol = 0;
    let endCol = colsNumber - 1;
    let startRow = 0;
    let endRow = rowsNumber - 1;

    while (startCol <= endCol && startRow <= endRow) {
      
        for (let i = startCol; i <= endCol; i++) {
            result[startRow][i] = counter;
            counter++;
        }

        startRow++;

        for (let j = startRow; j <= endRow; j++) {
            result[j][endCol] = counter;
            counter++;
        }

        endCol--;

        for (let i = endCol; i >= startCol; i--) {
            result[endRow][i] = counter;
            counter++;
        }

        endRow--;
        
        for (let i = endRow; i >= startRow; i--) {
            result[i][startCol] = counter;
            counter++;
        }

        startCol++;

    }

    for(let row in result){
        console.log(result[row].join(" "))
    }
}