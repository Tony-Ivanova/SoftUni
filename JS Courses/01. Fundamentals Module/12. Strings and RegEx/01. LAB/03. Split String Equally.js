function solve() {
    let text = document.getElementById("text").value;
    let groupSize = parseInt(document.getElementById("number").value);

    function splitStringEqually(text, groupSize) {
        if (text.length % groupSize > 0) {
            const remainder = text.length % groupSize;
            const charsToFill = groupSize - remainder;
            text = text + text.substr(0, charsToFill);
        }

        const result = [];

        for (let i = 0; i < text.length; i += groupSize) {
            result.push(text.substr(i, groupSize));
        }
        
        document.getElementById("result").innerHTML = result.join(' ');
    }

    splitStringEqually(text, groupSize);
}