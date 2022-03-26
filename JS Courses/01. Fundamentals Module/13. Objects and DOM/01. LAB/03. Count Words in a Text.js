function countWordsInAText([input]) {

    let counter = {};
    let regex = /\W+/;
    let words = input.split(regex).filter(w => w != "");

    for (let word of words) {

        if (!counter.hasOwnProperty(word)) {
            counter[word] = 1;
        } else {
            counter[word]++;
        }
    }

    let myJSON = JSON.stringify(counter);
    console.log(myJSON);
}