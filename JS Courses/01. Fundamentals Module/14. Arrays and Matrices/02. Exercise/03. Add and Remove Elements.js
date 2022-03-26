function addOrRemove(arr) {

    let arrayOfNumbers = [];
    let number = 1;

    for (let i = 0; i < arr.length; i++) {

        let command = arr[i];
        if (command === "add") {
            arrayOfNumbers.push(number);
        } else {
            arrayOfNumbers.pop();
        }
        number++;
    }

    if (arrayOfNumbers.length > 0) {
        console.log(arrayOfNumbers.join('\n'));
    } else {
        console.log("Empty")
    }
}