let { assert, expect } = require('chai');
let Console = require('./console.js');

describe('Console', () => {
    it('should return the correct string if input is string', () => {
        let expected = "Gosho";
        assert.equal(expected, Console.writeLine("Gosho"));
    })
    it('should return the correct json if input is object', () => {
        let expected = '{"JS":"sucks;)"}';
        assert.equal(expected, Console.writeLine({ "JS": "sucks;)" }));
    })

    it('should throw an error if input is not given', () => {
        expect(() => Console.writeLine()).to.throw(TypeError);
    })

    it('should throw an error if first param is not a string', () => {
        expect(() => Console.writeLine(5, 3, 6)).to.throw(TypeError);
    })

    it('should throw an error if placeholders are less than params', () => {
        let expected = "{0}{1}.";
        expect(() => Console.writeLine(expected, "5", "6", "7", "8")).to.throw(RangeError);
    })

    it('should throw an error if incorrect placeholder is given', () => {
        let string = "{0}{1}{2}";
        expect(() => Console.writeLine(string, "5", "6")).to.throw(RangeError);
    })

    it('should successfully replace placeholders with valid params', () => {
        let string = "This {0} doesnt seem to {1}";
        expect(Console.writeLine(string, "homework", "end")).to.equal("This homework doesnt seem to end");
    })
})
