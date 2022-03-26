function oddEvenSum(number) {

    let allEvenDigits = getEvenDigits(number);
    let allOddDigits = getOddDigits(number);

    let sumEvenDigits = getSum(allEvenDigits);
    let sumOddDigits = getSum(allOddDigits);
    console.log(`Odd sum = ${sumOddDigits}, Even sum = ${sumEvenDigits}`);

    function getEvenDigits(number) {
        let evenDigits = [];

        number.toString().split('').forEach(digit => {
            let currentNumber = Number(digit);
            if (currentNumber % 2 === 0) {
                evenDigits.push(currentNumber);
            }
        });
        
        return evenDigits;
    }

    function getOddDigits(number) {

        let oddDigits = [];

        number.toString().split('').forEach(digit => {
            let currentNumber = Number(digit);
            if (currentNumber % 2 !== 0) {
                oddDigits.push(currentNumber);
            }
        });

        return oddDigits;
    };

    function getSum(arr) {
        return arr.reduce((a, b) => a + b, 0)
    }
}

oddEvenSum(1000435);