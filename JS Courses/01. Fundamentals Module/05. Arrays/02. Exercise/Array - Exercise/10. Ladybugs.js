function ladyBugs(arr) {
    let length = arr[0];
    let field = new Array();
    let ladyBugIndexes = arr[1].split(' ').map(Number);

    for (let i = 0; i < length; i++) {
        field.push(0);
    }

    for (let i = 0; i < length; i++) {
        let ladybugIndex = ladyBugIndexes[i];

        if (ladybugIndex >= 0 && ladybugIndex < length) {
            field[ladybugIndex] = 1;
        }
    }

    for (let i = 2; i < arr.length; i++) {
        let commands = arr[i].split(' ');    

        let fromWhere = Number(commands[0]);
        let direction = commands[1];
        let flyLength = Number(commands[2]);

        if (fromWhere < 0 || fromWhere >= length) {
            continue;
        }

        if (field[fromWhere] == 0) {
            continue;
        }

        field[fromWhere] = 0;

        let position = fromWhere;

        while (true) {
            if (direction == "left") {
                position -= flyLength;
            } else if (direction == "right") {
                position += flyLength;
            }

            if (position < 0 || position >= length) {
                break;
            }

            if (field[position] == 1) {
                continue;
            } else {
                field[position] = 1;
                break;
            }
        }
    }
    
    console.log(field.join(" "));
}
ladyBugs([ 3, '0 1',
'0 right 1',
'2 right 1' ]

);