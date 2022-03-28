class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length) {
        this.innerLength += Number(length);
    }

    decrease(length) {
        if (this.innerLength - Number(length) <= 0) {
            this.innerLength = 0;
        } else {
            this.innerLength = this.innerLength - Number(length);
        }
    }

    toString() {
        if (this.innerLength === 0) {
            return `...`;
        } else if (this.innerString.length > this.innerLength) {
            let word = this.innerString;
            return word.slice(0, this.innerLength).concat('...');
        } else {
            return this.innerString;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
