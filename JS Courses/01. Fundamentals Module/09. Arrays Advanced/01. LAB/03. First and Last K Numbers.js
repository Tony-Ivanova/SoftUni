function kNumbers(arr) {
    let k = arr.shift();
    let arrayFromBeginning = arr.slice(0, k)
    let arrayFromEnd = arr.slice(-k, arr.length);

    console.log(arrayFromBeginning.join(' '));
    console.log(arrayFromEnd.join(' '));
}

kNumbers(
    [3, 6, 7, 8, 9])
