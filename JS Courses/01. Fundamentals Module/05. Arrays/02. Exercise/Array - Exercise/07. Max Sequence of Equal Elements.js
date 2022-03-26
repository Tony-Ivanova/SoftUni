function maxSequence(numbers) {

    let initialLength = 1;
    let currentMaxLength = 1;
    let maxNumbers = 0;
    let result = new Array();

    for (let i = 0; i < numbers.length - 1; i++) {

        if (numbers[i] == numbers[i + 1]) {
            initialLength++;

            if (initialLength > currentMaxLength) {
                currentMaxLength = initialLength;
                maxNumbers = numbers[i];
            }
        }
        else {
            initialLength = 1;
        }
    }

    if (currentMaxLength == 1) {
        maxNumbers = numbers[0];
        console.log(maxNumbers);
    }
    else {
        for (let i = 0; i < currentMaxLength; i++) {
            result.push(maxNumbers);
        }
    }

    console.log(result.join(" "));
}
maxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);