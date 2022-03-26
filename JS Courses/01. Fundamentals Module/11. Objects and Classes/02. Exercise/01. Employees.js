function employees(input) {

    let employees = [];

    class Person {
        constructor(name, personalNumber) {
            this.name = name;
            this.personalNumber = personalNumber;
        }
    }

    for (let i = 0; i < input.length; i++) {
        let personName = input[i];
        let personNumber = input[i].length;
        let currentPerson = new Person(personName, personNumber);

        employees.push(currentPerson);
    }

    employees.forEach((x) => console.log(`Name: ${x.name} -- Personal Number: ${x.personalNumber}`))
}

employees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
)