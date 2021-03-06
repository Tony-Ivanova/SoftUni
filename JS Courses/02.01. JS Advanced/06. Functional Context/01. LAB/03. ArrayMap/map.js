function solve(arr, func) {
    let mappedArray = arr.reduce((a, x) => {
        a.push(func(x))

        return a;
    }, []);

    return mappedArray;
}

let nums = [1, 2, 3, 4, 5];
console.log(arrayMap(nums, (item) => item * 2)); 
