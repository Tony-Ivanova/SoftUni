function solve() {
    let input = document.getElementById('expressionOutput');
    let resultInput = document.getElementById('resultOutput');
    let keys = Array.from(document.getElementsByClassName('keys'));
    let clearButton = document.getElementsByClassName('clear')[0];

    let number = '';
    let lastElement = '';
    let numbersToCalculate = [];

    clearButton.addEventListener('click', () => {
        input.textContent = '';
        resultInput.textContent = '';
        number = '';
        numbersToCalculate = [];
    });

    keys.forEach(x => x.addEventListener('click', function (e) {
        let currentButton = e.target.value;

        let operands = ['+', '-', '*', '/'];

        if (Number(currentButton) || currentButton === '.' || currentButton === '0') {

            number += currentButton;
            input.textContent += currentButton;

        } else if (operands.includes(currentButton)) {

            if (number === '') {
                number = 0;
                input.textContent += number;
                numbersToCalculate.push(number);
            }

            numbersToCalculate.push(number);
            number = '';
            numbersToCalculate.push(currentButton);
            input.textContent += ` ${currentButton} `;

        } else if (currentButton === '=') {

            numbersToCalculate.push(number);
            lastElement = numbersToCalculate.pop();
            numbersToCalculate.push(lastElement);

            if (Number(lastElement) && numbersToCalculate.length >= 3) {
                let finalResult = calculator(numbersToCalculate);
                resultInput.textContent += finalResult
            } else {
                resultInput.textContent += "NaN";
            }
        }

        function calculator(args) {

            let result = 0;

            while (true) {

                if (args.length === 1) {
                    break;
                }

                let firstNumber = Number(args.shift());
                let operator = args.shift();
                let secondNumber = Number(args.shift());

                switch (operator) {
                    case '+':
                        result = firstNumber + secondNumber;
                        break;
                    case '-':
                        result = firstNumber - secondNumber;
                        break;
                    case '*':
                        result = firstNumber * secondNumber;
                        break;
                    case '/':
                        result = firstNumber / secondNumber;
                        break;
                }

                args.unshift(result);
            }

            return result;
        }
    }));
}