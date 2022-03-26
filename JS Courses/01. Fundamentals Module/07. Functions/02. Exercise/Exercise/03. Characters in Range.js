function charactersInRange(firstChar, secondChar) {

    let startAscii = getAsciiValue(firstChar);
    let endAscii = getAsciiValue(secondChar);

    let startingPoint = Math.min(startAscii, endAscii);
    let endPoint = Math.max(startAscii, endAscii);

    let result = printAsciiRange(startingPoint, endPoint);

    console.log(result.join(' '));

    function printAsciiRange(after, before) {

        let symbols = [];

        for (let i = after + 1; i < before; i++) {
            let currentChar = String.fromCharCode(i);
            symbols.push(currentChar);
        }

        return symbols;
    }

    function getAsciiValue(char) {
        return char.charCodeAt();
    }
}

charactersInRange('a', 'd')