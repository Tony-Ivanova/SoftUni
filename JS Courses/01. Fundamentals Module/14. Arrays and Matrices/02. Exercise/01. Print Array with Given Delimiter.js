function givenDelimeter(arr) {
    let delimeter = arr[arr.length - 1];
    arr.pop();
    console.log(arr.join(delimeter));
}