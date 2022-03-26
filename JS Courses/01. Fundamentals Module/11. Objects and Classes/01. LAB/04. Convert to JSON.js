function convertToJson(name, lastName, hairColor) {
    let person = { name: name, lastName: lastName, hairColor: hairColor };
    let text = JSON.stringify(person);
    console.log(text);
}

convertToObj('George',
    'Jones',
    'Brown'
)