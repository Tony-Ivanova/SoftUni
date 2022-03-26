function smallestNumber(firstNum, secondNum, thirdNum) {

    let array = [firstNum, secondNum, thirdNum];

    let result = Number(firstNum);

    for (let i = 1; i < 3; i++) {
        let number = Number(array[i]);
        result = SmallerNumber(number, result);
    }

    console.log(result);

    function SmallerNumber(first, second) {
        if (first < second) {
            return first;
        }
        return second;
    }
}
smallestNumber(600,
    342,
    123
)