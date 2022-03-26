function evenAndOddSum(arr) {
    let evenSum = 0;
    let oddSum = 0;

    for (const number of arr) {
        if (number % 2 == 0) {
            evenSum += Number(number);
        } else {
            oddSum += Number(number);
        }
    }
    let result = evenSum - oddSum;

    console.log(result);
}
evenAndOddSum([3, 5, 7, 9]);