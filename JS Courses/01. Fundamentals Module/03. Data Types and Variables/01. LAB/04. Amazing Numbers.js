function amazingNumber(number) {
    number = number.toString();
    let sum = 0;

    for (let digit = 0; digit < number.length; digit++) {
        sum += Number(number[digit]);
    }

    let isAmazing = sum.toString().includes(`9`) ? `Amazing? True` : `Amazing? False`;

    console.log(`${number} ${isAmazing}`);
}
amazingNumber(1233)