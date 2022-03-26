function distinctArray(arr) {
    let newArray = arr.map(Number);
    let result = newArray.filter((a, b) => newArray.indexOf(a) === b);
    console.log(result.join(' '));
}
distinctArray([7, 8, 9, 7, 2, 3, 4, 1, 2])