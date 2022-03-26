function passwordValidator(password) {

    let isLongEnough = lengthValidator(password);
    let containsDigitsAndLetters = containsValidator(password);
    let containsMinimum2Digits = checkMinimum2Digits(password);

    if (!isLongEnough) {
        console.log(`Password must be between 6 and 10 characters`);
    }

    if (!containsDigitsAndLetters) {
        console.log(`Password must consist only of letters and digits`);
    }

    if (!containsMinimum2Digits) {
        console.log(`Password must have at least 2 digits`);
    }

    if (isLongEnough && containsMinimum2Digits && containsDigitsAndLetters) {
        console.log(`Password is valid`);
    }

    function lengthValidator(password) {
        return password.length >= 6 && password.length <= 10 ? true : false;
    }

    function containsValidator(password) {
        let characters = password.split('');
        let isValid = true
        for (let letter of characters) {

            let asciiValue = letter.charCodeAt(0);

            if (!isDigit(asciiValue) && !isCapitalLetter(asciiValue) && !isLowerLetter(asciiValue)) {
                return isValid = false;
                break;
            }

        }

        function isDigit(char) {
            return char >= 48 && char <= 57;
        }

        function isCapitalLetter(char) {
            return char >= 65 && char <= 90;
        }

        function isLowerLetter(char) {
            return char >= 97 && char <= 122;
        }

        return isValid;
    }

    function checkMinimum2Digits(password) {
        let digits = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];

        let counter = 0;

        password.split('').forEach(element => {
            let value = Number(element);

            if (digits.includes(value)) {
                counter++;
            }
        });

        return counter >= 2 ? true : false;
    }
}

passwordValidator('Pa$s$s')