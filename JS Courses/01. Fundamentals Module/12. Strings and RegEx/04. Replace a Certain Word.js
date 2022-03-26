function solve() {
    let inputWord = document.getElementById('word').value;
    let text = document.getElementById('text').value;
    let inputArray = JSON.parse(text);
    let result = document.getElementById("result");

    function replaceCertainWord(inputArray, inputWord) {
        let wordToReplace = inputArray[0].split(" ").filter(a => a !== "")[2];
        let regex = new RegExp(wordToReplace, "gi");

        for (let sentance of inputArray) {
            sentance = sentance.replace(regex, inputWord);
            let p = document.createElement("p");
            p.innerHTML = sentance;
            result.appendChild(p);
        }
    }

    replaceCertainWord(inputArray, inputWord);
}