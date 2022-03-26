function printNElements(arr) {

    let newArray = new Array();

    let step = Number(arr.pop());

    for (let i = 0; i < arr.length; i += step) {
        let currentElement = arr[i];
        newArray.push(currentElement);
    }
    
    console.log(newArray.join(" "));
}
printNElements(['dsa', 'asd', 'test', 'test', '2']);