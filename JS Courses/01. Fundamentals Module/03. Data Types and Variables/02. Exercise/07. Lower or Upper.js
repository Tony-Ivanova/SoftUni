function lowerToUpper(givenChar) {

    let charUpper = givenChar.toUpperCase();

    let result = charUpper === givenChar ? `upper-case` : `lower-case`;

    console.log(result);

}
lowerToUpper('f')