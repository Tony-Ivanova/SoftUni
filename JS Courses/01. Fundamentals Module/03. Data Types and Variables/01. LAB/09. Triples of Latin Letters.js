function triplesOfLatinLetters(number) {

    let result = "";
    let loopUntil = String.fromCharCode(97 + number);

    for (let first = 0; first < number; first++) {

        for (let second = 0; second < number; second++) {

            for (let third = 0; third < number; third++) {

                console.log(`${String.fromCharCode(first + 97)}
                            ${String.fromCharCode(second + 97)}
                            ${String.fromCharCode(third + 97)}`);
            }
        }
    }
}
triplesOfLatinLetters(3);