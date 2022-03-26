function equalSums(arr) {

    let isEqual = false;

    for (let i = 0; i < arr.length; i++) {
        let currentElement = arr[i];

        let sumLeft = arr.slice(0, i).reduce((a, b) => a + b, 0);
        let sumRight = arr.slice(i + 1).reduce((a, b) => a + b, 0);

        if (sumLeft === sumRight) {
            isEqual = true;
            console.log(i);
        }
    }
    if (!isEqual) {
        console.log("no");
    }
}
equalSums([5]);