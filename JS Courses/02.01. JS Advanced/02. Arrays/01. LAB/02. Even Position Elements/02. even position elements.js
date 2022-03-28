function solve(arr1) {
    let newArr = arr1.filter(x => arr1.indexOf(x) % 2 == 0);
    console.log(newArr.join(' '));
}

solve(['20', '30', '40']);