function rotateArray(arr) {

    let howManyRotations = Number(arr.pop());

    for (let i = 1; i <= howManyRotations % arr.length; i++) {

        let currentElement = arr.pop();
        arr.unshift(currentElement);
    }
    
    console.log(arr.join(" "));
}