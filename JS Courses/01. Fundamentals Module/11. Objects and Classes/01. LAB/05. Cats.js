function catClass(input) {

    let cats = [];

    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (let i = 0; i < input.length; i++) {
        let catArr = input[i].split(' ');
        let [name, age] = catArr;
        let cat = new Cat(name, Number(age));
        cats.push(cat);
    }

    for (const cat of cats) {
        cat.meow();
    }
}

catClass(['Mellow 2', 'Tom 5'])