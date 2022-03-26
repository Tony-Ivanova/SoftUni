function printAndSum(start, finish) {

    let sum = 0;
    let outputNumbers = "";

    for (let i = start; i <= finish; i++) {
        sum += i;
        outputNumbers += `${i} `;
    }

    console.log(outputNumbers.trim());
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10)