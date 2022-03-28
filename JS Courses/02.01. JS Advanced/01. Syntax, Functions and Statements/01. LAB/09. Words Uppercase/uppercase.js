function solve(arg) {
    let regex = /\b\w+\b/g;
    let matches = arg.match(regex);

    let newArray = matches.map(element => {
        return element.toUpperCase();
    });

    console.log(newArray.join(', '));
}

solve('Hi, how are you?');