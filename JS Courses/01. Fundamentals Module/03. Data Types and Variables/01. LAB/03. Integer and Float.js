function typeOfNumber(firstNumber, secondNumber, thirdNumber){
   
    let sum = firstNumber + secondNumber + thirdNumber;
    let type = sum % 1 === 0 ? `Integer` : `Float`
    
    console.log(`${sum} - ${type}`);    
}

typeOfNumber(9, 100, 1.1)