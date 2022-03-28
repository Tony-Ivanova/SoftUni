function solve(array) {
    let newArray = [];

    while (array.length > 0) {
        let element = array.shift();

        if (element >= 0) {
            newArray.push(element);
        } else {
            newArray.unshift(element);
        }
    }
    
    console.log(newArray.join("\r\n"));
}
solve([7, -2, 8, 9]);