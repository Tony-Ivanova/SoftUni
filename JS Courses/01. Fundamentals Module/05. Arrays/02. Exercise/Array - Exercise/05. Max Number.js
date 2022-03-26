function maxNumber(arr) {

    let newArray = new Array();

    for (let i = 0; i < arr.length - 1; i++) {
        let currentNumber = arr[i];
        let biggestNumberOnTheRight = Math.max.apply(null, arr.slice(i + 1));

        if (currentNumber > biggestNumberOnTheRight) {
            newArray.push(currentNumber);
        }
    }
    
    newArray.push(arr[arr.length - 1]);

    console.log(newArray.join(" "));
}
maxNumber([14, 24, 3, 19, 15, 17]);