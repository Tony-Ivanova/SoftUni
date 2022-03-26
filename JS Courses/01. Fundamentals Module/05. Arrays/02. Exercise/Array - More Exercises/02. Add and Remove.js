function addRemove(arr) {

    let newArray = new Array();

    for (let i = 0; i < arr.length; i++) {
        let currentCommand = arr[i];

        if (currentCommand == "add") {
            newArray.push(i + 1);
        } else if (currentCommand == "remove") {
            newArray.pop();
        }
    }

    if (newArray.length === 0) {
        console.log("Empty");
    } else {
        console.log(newArray.join(" "));
    }
}
addRemove(['add', 'add', 'remove', 'add', 'add']);