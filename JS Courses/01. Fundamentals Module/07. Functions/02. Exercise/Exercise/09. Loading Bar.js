function loadingBar(number) {

    let checkHowManyBars = CheckBars(number);
    let specialCharacter = '%';
    let remainingToLoadCharacter = '.';

    if (checkHowManyBars === 10) {
        console.log(`100% Complete!`);
        console.log(`[${specialCharacter.repeat(checkHowManyBars)}]`);

    } else {
        console.log(`${number}% [${specialCharacter.repeat(checkHowManyBars)}${remainingToLoadCharacter.repeat(10 - checkHowManyBars)}]`);
        console.log(`Still loading...`);
    }

    function CheckBars(number) {
        let firstNumber = number.toString();
        let numberOfBars = 0;

        if (number !== 100) {
            numberOfBars = Number(firstNumber[0]);
        } else {
            numberOfBars = 10;
        }
        
        return numberOfBars;
    }
}
loadingBar(30);