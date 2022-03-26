function printEveryNElementFromArray(arr) {
    let theNeededStep = Number(arr[arr.length - 1]);
    arr.pop();
    for (let i = 0; i <= arr.length - 1; i += theNeededStep) {
        let currentElement = arr[i];
        console.log(currentElement);
    }
}