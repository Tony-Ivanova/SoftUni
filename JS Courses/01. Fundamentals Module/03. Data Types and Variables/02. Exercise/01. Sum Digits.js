function sumDigits(number) {

    number = number.toString();
    let sum = 0;

    for (let index = 0; index < number.length; index++) {

        sum += Number(number[index]);
    }

    console.log(sum);
}

sumDigits(97561);