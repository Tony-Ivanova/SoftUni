function addAndSubstract(firstNumber, secondNumber, thirdNumber) {
    let sumFirstSecond = Sum(firstNumber, secondNumber);
    let result = Substract(sumFirstSecond, thirdNumber);
    console.log(result);

    function Sum(firstNumber, secondNumber) {
        return Number(firstNumber) + Number(secondNumber);
    }
    
    function Substract(sumFirstSecond, thirdNumber) {
        return sumFirstSecond - Number(thirdNumber);
    }
}
addAndSubstract(23,
    6,
    10
)