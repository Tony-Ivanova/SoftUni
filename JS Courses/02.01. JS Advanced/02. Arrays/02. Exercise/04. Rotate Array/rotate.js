function solve(arr1) {
    let numberRotations = Number(arr1.pop());

    for (let i = 0; i < numberRotations % 100; i++) {
        let lastElement = arr1.pop();
        arr1.unshift(lastElement);
    }

    console.log(arr1.join(' '));
}

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']
)