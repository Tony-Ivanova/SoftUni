function subtract() {
    let firstNumberInput = document.getElementById('firstNumber').value;
    let secondNumberInput = document.getElementById('secondNumber').value;
    let result = document.getElementById('result');

    let substractionProduct = Number(firstNumberInput) - Number(secondNumberInput);
    result.textContent = substractionProduct;
}