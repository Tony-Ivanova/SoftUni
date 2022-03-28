function solve(matrix) {
    let arrayOfBiggestNumbers = []
    
    for (let i = 0; i < matrix.length; i++) {
        let biggestElement = Math.max(...matrix[i]);
        arrayOfBiggestNumbers.push(biggestElement);
    }

    let element = Math.max(...arrayOfBiggestNumbers);
    console.log(element);
}

solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
)