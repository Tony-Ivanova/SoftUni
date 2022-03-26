function perfectNumber(number) {

    let divisors = FindingDivisors(number);

    let sumOfDivisors = Sum(divisors);

    let result = CheckIfPerfect(sumOfDivisors);

    if (result) {
        console.log(`We have a perfect number!`);
    } else if (!result) {
        console.log(`It's not so perfect.`);
    }

    function CheckIfPerfect(sumOfDivisors) {
        return sumOfDivisors === number ? true : false;
    }

    function Sum(divisors) {
        return divisors.reduce((a, b) => a + b, 0);
    }

    function FindingDivisors(number) {

        let array = [];

        for (let i = 1; i < number; i++) {
            if (number % i === 0) {
                array.push(i);
            }
        }
        
        return array;
    }
}
perfectNumber(1236498);