function sumFirstAndLast(arr) {
    let first = Number(arr.shift());
    let last = Number(arr.pop());
    console.log(first + last);
}
sumFirstAndLast(['20', '30', '40'])