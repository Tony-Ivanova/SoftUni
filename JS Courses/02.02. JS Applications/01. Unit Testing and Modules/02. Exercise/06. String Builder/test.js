let { assert } = require('chai');
let StringBuilder = require('./builder.js');

describe('StringBuilder', () => {
    let sb;
    beforeEach(() => {
        sb = new StringBuilder();
    })

    describe('verifyParams', () => {
        it('should throw exception when param is not a string', () => {
            assert.throw(() => {
                new StringBuilder({});

            }, 'Argument must be string');
        })
    })

    describe('constructor', () => {
        it('should work properly without argument', () => {
            assert.equal('', sb.toString());
        })

        it('should work properly with argument', () => {
            sb = new StringBuilder('pesho');
            assert.equal('pesho', sb.toString());
        })
    })

    describe('append', () => {
        it('should append text at the end of the string', () => {
            sb.append('pesho');
            assert.equal('pesho', sb.toString());
        })
    })

    describe('prepend', () => {
        it('should prepend text at the beginning of the string', () => {
            sb.prepend('esho');
            sb.prepend('p');
            assert.equal('pesho', sb.toString());
        })
    })

    describe('insert', () => {
        it('should insert text at the given index in the string', () => {
            sb.insertAt('pesho', 0);
            sb.insertAt('gosho', 0);
            sb.insertAt('+', 5);
            assert.equal('gosho+pesho', sb.toString());
        })
    })

    describe('remove', () => {
        it('should remove text at the given index in the string', () => {
            sb.append('pesho');
            sb.remove(0, 1);
            assert.equal('esho', sb.toString());
        })
    })

    describe('toString', () => {
        it('should return correct string', () => {
            sb.append('pesho');
            assert.equal('pesho', sb.toString());
        })
    })
})