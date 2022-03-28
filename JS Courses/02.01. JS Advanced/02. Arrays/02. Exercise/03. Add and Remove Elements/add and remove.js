function solve(arr1) {

    let newArr = [];
    let sum = 1;

    for (let i = 0; i < arr1.length; i++) {

        if (arr1[i] === 'add') {
            newArr.push(sum);
        } else if (arr1[i] === 'remove') {
            newArr.pop();
        }

        sum += 1;
    }

    if (newArr.length > 0) {
        console.log(newArr.join("\r\n"));
    } else {
        console.log("Empty");
    }
}

solve(['remove',
    'remove',
    'remove']
)