let { assert } = require('chai');
let { lookupChar } = require('./lookup.js');

describe('charLookUp', () => {
    it('should return undefined with incorrect first param', () => {
        assert.equal(undefined, lookupChar(5, 0));
    })

    it('should return undefined with incorrect second param', () => {
        assert.equal(undefined, lookupChar('pesho', 'gosho'))
    })

    it('should return Incorrect index with incorrect first param length', () => {
        assert.equal('Incorrect index', lookupChar('pesho', 5));
    })

    it('should return Incorrect index when second param is lower than 0', () => {
        assert.equal('Incorrect index', lookupChar('pesho', -1));
    })

    it('should return correct character', () => {
        assert.equal('a', lookupChar('Stamat', 2));
    })
})
