function wrongResult(firstNum, secondNum, thirdNum) {
    let result = ``;
    if (firstNum >= 0 && secondNum >= 0 && thirdNum >= 0) {
        result = `Positive`;

    } else if (((firstNum > 0 && secondNum > 0) 
                    || (secondNum > 0 && thirdNum > 0) 
                    || (firstNum > 0 && thirdNum > 0))
        && (firstNum < 0 || secondNum < 0 || thirdNum < 0)) {
        result = `Negative`;
    }
    else if ((firstNum < 0 || secondNum < 0 || thirdNum < 0)
        && (firstNum >= 0 || secondNum >= 0 || thirdNum >= 0)) {
        result = `Positive`;
    }
    else if (firstNum < 0 || secondNum < 0 || thirdNum < 0) {
        result = `Negative`;
    }
    return result;
}
console.log(wrongResult(-1,
    0,
    1
))