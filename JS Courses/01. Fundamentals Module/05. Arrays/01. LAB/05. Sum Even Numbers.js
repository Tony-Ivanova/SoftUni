function sumEvenElements(arr) {

    let sum = 0;

    for (let number of arr) {
        if (number % 2 === 0) {
            sum += Number(number);
        }
    }
    console.log(sum);
}
sumEvenElements(['2', '4', '6', '8', '10']);