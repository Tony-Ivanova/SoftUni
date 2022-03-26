function sumOddNumbers(finalNumber) {
    let sum = 0;

    for (i = 1; i <= finalNumber * 2; i += 2) {
        sum += i;
        console.log(i);
    }
    console.log(`Sum: ${sum}`);
}

sumOddNumbers(5);