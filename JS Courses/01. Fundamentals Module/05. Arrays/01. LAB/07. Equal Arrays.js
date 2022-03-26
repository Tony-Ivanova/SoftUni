function equalArrays(arr1, arr2) {

    for (let i = 0; i < arr1.length; i++) {
        arr1[i] = Number(arr1[i]);        
    }

    for (let i = 0; i < arr2.length; i++) {
        arr2[i] = Number(arr2[i]);        
    }

    let sum = 0;
    let isTrue = true;

    for (let i = 0; i < arr1.length; i++) {
        if (arr1[i] !== arr2[i]) {
            console.log(`Arrays are not identical. Found difference at ${i} index`);
            isTrue = false;
            break;
        }
        else if (arr1[i] === arr2[i]) {
            let currentNumber = arr1[i];
            sum += currentNumber;
            isTrue = true;
        }
    }
    if (isTrue == true) {
        console.log(`Arrays are identical. Sum: ${sum}`);
    }
}
equalArrays(['10', '20', '30'], ['10', '20', '30']);