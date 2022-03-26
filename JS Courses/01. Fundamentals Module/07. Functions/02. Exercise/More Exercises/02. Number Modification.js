function numberModification(number) {
    let currentNumber = number.toString();
    let sum = Sum(currentNumber);

    while (sum / currentNumber.length <= 5) {
        currentNumber += '9';
        sum = Sum(currentNumber);
    }

    console.log(currentNumber);

    function Sum(currentNumber) {
        let result = 0;
        for (let i = 0; i < currentNumber.length; i++) {
            result += Number(currentNumber[i]);
        }
        return result;
    }
}
numberModification(101);