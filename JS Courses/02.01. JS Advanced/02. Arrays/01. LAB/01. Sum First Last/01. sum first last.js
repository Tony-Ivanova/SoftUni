function solve(arr1) {
    let firstNumber = Number(arr1.shift());
    
    if (arr1.length >= 1) {
        let lastNumber = Number(arr1.pop());
        console.log(lastNumber + firstNumber);
    } else {
        console.log(firstNumber * 2);
    }
}

solve(['5']);