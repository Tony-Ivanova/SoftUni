function sumFirstAndLast(arr) {
    let firstElement = Number(arr.shift());
    let lastElement = Number(arr.pop());

    let result = firstElement + lastElement;
    console.log(result);
}
sumFirstAndLast(['10', '17', '22', '33']);