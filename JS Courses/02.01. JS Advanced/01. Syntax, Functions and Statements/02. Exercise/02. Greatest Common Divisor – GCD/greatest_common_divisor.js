function greatestCommonDiv(firstNumber, secondNumber) {

    while (secondNumber) {
        let thirdNumber = secondNumber;
        secondNumber = firstNumber % secondNumber;
        firstNumber = thirdNumber;
    }

    console.log(firstNumber);
}