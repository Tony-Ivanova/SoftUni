function searchNumbers(originalArray, numbers) {
    let numbersToTake = numbers[0];
    let numbersToDelete = numbers[1];
    let numbersToFind = numbers[2];

    originalArray.splice(numbersToTake);
    originalArray.splice(0, numbersToDelete);

    let counter = 0;

    originalArray.forEach((v) => (v === numbersToFind && counter++));

    console.log(`Number ${numbersToFind} occurs ${counter} times.`);
}

searchNumbers([5, 2, 3, 4, 1, 6],
    [5, 2, 3]
)