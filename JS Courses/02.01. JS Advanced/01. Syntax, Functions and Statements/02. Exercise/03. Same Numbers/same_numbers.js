function sameNumber(arg1) {

    let numberAsString = String(arg1);
    let areTheyEqual = true;

    for (let i = 0; i < numberAsString.length - 1; i++) {

        let firstNumber = Number(numberAsString[i]);
        let secondNumber = Number(numberAsString[i + 1]);

        if (firstNumber !== secondNumber) {
            areTheyEqual = false;
        }
    }

    var sum = Array.from(numberAsString, Number).reduce((a, b) => a + b, 0);

    console.log(areTheyEqual);
    console.log(sum);
}

sameNumber(112)