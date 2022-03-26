function addSubstract(arr) {

    let newArray = new Array();

    for (let i = 0; i < arr.length; i++) {

        let currentElement = Number(arr[i]);

        if (currentElement % 2 == 0) {
            currentElement += i;
        } else {
            currentElement -= i;
        }
        newArray.push(currentElement);

    }
    let sumOriginal = arr.reduce((a, b) => a + b, 0);
    let sumNewArray = newArray.reduce((a, b) => a + b, 0);

    console.log(newArray);
    console.log(sumOriginal);
    console.log(sumNewArray);
}
addSubstract([-5, 11, 3, 0, 2]);