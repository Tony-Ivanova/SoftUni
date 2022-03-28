function solve(arr1) {
    let newArr = [];
    let smallest = Math.min(...arr1);
    arr1.reduce((a, b) => {
        if (b >= a) {
            newArr.push(b);
            return b;
        }
        else {
            return a;
        }
    }, smallest);

    newArr.sort((a, b) => a - b);
    console.log(newArr.join("\r\n"));
}

solve([-20,
-19,
    1,
    3,
    8,
    4,
-8,
    10,
    10,
    12,
    3,
    2,
    24,
    23]
)