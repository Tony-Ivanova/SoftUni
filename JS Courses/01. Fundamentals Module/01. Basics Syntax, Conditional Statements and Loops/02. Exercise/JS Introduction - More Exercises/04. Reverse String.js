function reverseString(arg) {
    let arrayFromString = arg.split("");
    arrayFromString.reverse();
    let wordFromArray = arrayFromString.join("");
    console.log(wordFromArray);
}
reverseString("hello")