function nonDecreasing(arr) {
    let newArray = [];
    let lastBiggestNumber = arr[0];
    newArray.push(lastBiggestNumber);

    for (let i = 1; i < arr.length; i++) {

        let currentNumber = Number(arr[i]);

        if (lastBiggestNumber <= currentNumber) {
            newArray.push(currentNumber);
            lastBiggestNumber = currentNumber;
        }
    }
    
    console.log(newArray.join(" "));
}
nonDecreasing([20, 3, 2, 15, 6, 1]);