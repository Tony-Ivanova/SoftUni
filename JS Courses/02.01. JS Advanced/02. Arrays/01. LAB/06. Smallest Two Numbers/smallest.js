function solve(arr1) {
    let smallestNumbers = arr1.sort((a, b) => a - b).slice(0, 2);
    console.log(smallestNumbers.join(' '));
}
solve([30, 15, 50, 5])