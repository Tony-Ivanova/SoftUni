function solve(arr) {
    arr.sort((a, b) => a.localeCompare(b)).sort((a, b) => a.length - b.length);
    console.log(arr.join("\r\n"));
}

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
)