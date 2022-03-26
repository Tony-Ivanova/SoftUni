function rightPlace(wordWithMissingChar, charToPlace, wordToMatch) {

    let symbolToBeReplaced = '_';

    let newWord = wordWithMissingChar.replace(symbolToBeReplaced, charToPlace);

    let doMatch = newWord === wordToMatch ? `Matched` : `Not Matched`;

    console.log(doMatch);
}

rightPlace('Str_ng', 'i', 'String');
