function division(isDivisible) {

    if (isDivisible % 10 == 0) {
        console.log("The number is divisible by 10");
    } else if (isDivisible % 7 == 0) {
        console.log("The number is divisible by 7");
    } else if (isDivisible % 6 == 0) {
        console.log("The number is divisible by 6");
    } else if (isDivisible % 3 == 0) {
        console.log("The number is divisible by 3");
    } else if (isDivisible % 2 == 0) {
        console.log("The number is divisible by 2");
    } else {
        console.log("Not divisible");
    }
}