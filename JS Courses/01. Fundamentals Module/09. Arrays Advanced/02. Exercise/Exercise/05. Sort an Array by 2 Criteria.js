function sortArrby2Critera(arr) {
    arr.sort((a, b) => a.localeCompare(b));
    arr.sort((a, b) => a.length - b.length);
    
    console.log(arr.join('\n'));
}
sortArrby2Critera(["Isacc", "Theodor", "Jack", "Harrison", "George"]);