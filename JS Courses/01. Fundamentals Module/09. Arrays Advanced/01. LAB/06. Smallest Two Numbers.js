function smallestTwo(arr) {
    let twoElements = arr.sort((a, b) => {
        return a - b
    }).slice(0, 2);
    
    console.log(twoElements.join(' '));
}
smallestTwo([3, 0, 10, 4, 7, 3])