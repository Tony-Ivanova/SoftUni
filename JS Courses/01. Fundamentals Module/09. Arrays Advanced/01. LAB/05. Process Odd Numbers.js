function oddNumbers(arr) {
    
    let result = arr.filter((element, index) => index % 2 !== 0)
        .map(x => 2 * x)
        .reverse();

    console.log(result.join(' '));
}
oddNumbers([10, 15, 20, 25])