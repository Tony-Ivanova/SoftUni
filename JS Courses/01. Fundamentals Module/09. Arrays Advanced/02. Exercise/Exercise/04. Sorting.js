function sorting(arr) {
    let firstArray = arr.sort((a, b) => b - a);
    let result = [];
    
    for (let i = firstArray.length - 1; i >= 0; i--) {
        let biggestNumber = firstArray.shift();
        result.push(biggestNumber);
        let smallestNumber = firstArray.pop();
        result.push(smallestNumber);
    }

    console.log(result.join(' '));
}
sorting([1, 21, 3, 69, 63, 31, 2, 18, 94])