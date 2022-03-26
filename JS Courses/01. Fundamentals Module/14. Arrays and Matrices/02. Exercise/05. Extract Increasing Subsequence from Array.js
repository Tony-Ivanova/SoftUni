function nonExisting(arr) {

    let arrayOfNumbers = [];
    let bestNumber = 0;

    for (let index = 0; index < arr.length; index++) {

        let currentElement = arr[index];

        if (currentElement >= bestNumber) {
            arrayOfNumbers.push(currentElement);
            bestNumber = currentElement;
        }
    }

    console.log(arrayOfNumbers.join('\n'));
}