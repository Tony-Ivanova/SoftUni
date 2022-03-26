function factorialDivision(firstNum, secondNum) {

    let factorialFirstNum = Factorial(firstNum);
    let factorialSecondNum = Factorial(secondNum);

    let result = factorialFirstNum / factorialSecondNum;

    console.log(result.toFixed(2));

    function Factorial(number) {

        let factorial = 1;

        for (let i = 1; i <= number; i++) {

            factorial *= i;
        }

        return factorial;
    }
}

factorialDivision(6, 2)