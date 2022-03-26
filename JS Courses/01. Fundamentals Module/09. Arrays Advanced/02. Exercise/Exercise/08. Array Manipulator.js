function arrayManipulator(numbers, input) {

    for (let operations of input) {
        let commands = operations.split(' ');
        let command = commands[0];

        if (command == "print") {
            break;
        }

        if (command == "add") {
            let index = Number(commands[1]);
            let element = Number(commands[2]);

            numbers.splice(index, 0, element);
        } else if (command == "addMany") {
            let index = Number(commands[1]);

            let tempList = commands.splice(2);

            numbers.splice(index, 0, ...tempList);
        } else if (command == "contains") {
            let element = Number(commands[1]);
            if (numbers.includes(element)) {
                let index = numbers.indexOf(element);
                console.log(index)
            }
            else {
                console.log(-1);
            }
        } else if (command == "remove") {
            let index = Number(commands[1]);
            numbers.splice(index, 1);
        } else if (command == "shift") {
            let position = Number(commands[1]);

            for (let i = 0; i < position; i++) {
                let pushedElement = numbers.shift();
                numbers.push(pushedElement);
            }
        } else if (command == "sumPairs") {
            numbers = numbers.map((e, i, arr) => i < arr.length - 1 ? (arr[i] += arr[i + 1]) : arr[i] = arr[i]).filter((e, i) => i % 2 === 0);
        }
    }

    console.log(`[ ${numbers.join(', ')} ]`);
}

arrayManipulator([1, 2, 3, 4, 5],
    ["addMany 5 9 8 7 6 5", "contains 15", "remove 3", "shift 1", "print"]
)
