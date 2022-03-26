function sortArray(arr) {

    arr.sort((a, b) => {
        return a.length - b.length || a.localeCompare(b);
    }).forEach(x => console.log(x));
}