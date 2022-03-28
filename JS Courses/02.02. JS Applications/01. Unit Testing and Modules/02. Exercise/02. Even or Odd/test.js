let assert = require('chai').assert;
let { isOddOrEven } = require('./evenOrOdd.js');

describe('isOddorEven', () => {
    it('should return undefined with param different from string', () => {
        assert.equal(undefined, isOddOrEven(5));
    })

    it('should return undefined with param different from string.2', () => {
        assert.equal(undefined, isOddOrEven({}));
    })

    it('should return even', () => {
        assert.equal('even', isOddOrEven('word'));
    })

    it('should return odd', () => {
        assert.equal('odd', isOddOrEven('words'));
    })

    it('should return correct values with multiple consecutive checks', () => {
        assert.equal('odd', isOddOrEven.isOddOrEven('words'), 'Function did not return the correct result!');
        assert.equal('even', isOddOrEven.isOddOrEven('word'), 'Function did not return the correct result!');
        assert.equal('odd', isOddOrEven.isOddOrEven('words'), 'Function did not return the correct result!');
        assert.equal(undefined, isOddOrEven.isOddOrEven({}), 'Function did not return the correct result!');
        assert.equal(undefined, isOddOrEven.isOddOrEven(4), 'Function did not return the correct result!');
    })
});
