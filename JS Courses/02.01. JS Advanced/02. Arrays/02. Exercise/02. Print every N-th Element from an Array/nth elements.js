function solve(arr1) {
    let step = Number(arr1.pop());

    for (let i = 0; i < arr1.length; i += step) {
        console.log(arr1[i]);
    }
}

solve(['1',
    '2',
    '3',
    '4',
    '5',
    '6']
)