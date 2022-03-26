function sortNumbers(first, second, third) {

    let numbers = [first, second, third];

    numbers.sort();

    numbers.reverse();

    for (let i = 0; i < numbers.length; i++) {
        console.log(numbers[i]);
    }
}
sortNumbers(2,
    1,
    3
)