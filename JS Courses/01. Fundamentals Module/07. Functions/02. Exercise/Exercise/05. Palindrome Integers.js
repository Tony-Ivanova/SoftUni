function palindromeInteger(arr) {

    for (let i = 0; i < arr.length; i++) {
        
        let currentNumber = arr[i];
        let reversedNumber = getReversedValue(currentNumber);

        isPalidrome(currentNumber, reversedNumber);
    }

    function isPalidrome(firstNumber, secondNumber) {
        return console.log(firstNumber === secondNumber);
    }

    function getReversedValue(originalValue) {
        return Number(originalValue
            .toString()
            .split('')
            .reverse()
            .join(''));
    }
}
palindromeInteger([123, 323, 421, 121])