function solve(firstStr, secondStr, thirdStr) {

    let first = firstStr.length;
    let second = secondStr.length;
    let third = thirdStr.length;

    let sumOfstrings = first + second + third;
    let averageSum = sumOfstrings / 3;

    console.log(sumOfstrings);
    console.log(Math.floor(averageSum));
}

solve('chocolate', 'ice cream', 'cake')