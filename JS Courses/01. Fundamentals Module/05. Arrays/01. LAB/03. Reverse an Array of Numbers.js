function reverseAnArray(reverseTimes, arr) {

    let newArr = arr.slice(0, reverseTimes);
    newArr.reverse();
    console.log(newArr.join(" "));

}
reverseAnArray(3, [10, 20, 30, 40, 50])