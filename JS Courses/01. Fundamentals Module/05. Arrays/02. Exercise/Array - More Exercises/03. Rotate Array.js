function rotateArray(arr) {

    let rotations = arr.pop();

    for (let i = 0; i < rotations; i++) {
        let lastElement = arr.pop();
        arr.unshift(lastElement);
    }
    
    console.log(arr.join(" "));
}

rotateArray(['Banana', 'Orange', 'Coconut', 'Apple', '15']);