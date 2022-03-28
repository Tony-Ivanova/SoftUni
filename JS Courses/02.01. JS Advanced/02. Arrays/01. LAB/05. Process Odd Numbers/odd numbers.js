function solve(arr) {
    let arrayOfOddElements = arr.filter(function (arr, index) { return index % 2 === 1 }).reverse().map(x => x * 2);
    console.log(arrayOfOddElements);
}
solve([3, 0, 10, 4, 7, 3])