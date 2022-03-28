let { assert } = require('chai');
let PaymentPackage = require('./package.js');

describe('PaymentPackage', () => {
    let paymentPackage;
    describe('constructor', () => {
        it('constructor should work properly with 2 params', () => {
            paymentPackage = new PaymentPackage('Pesho', 10);
            assert.equal('Pesho', paymentPackage.name);
            assert.equal(10, paymentPackage.value);
        });

        it('should throw exception with incorrect name', () => {
            assert.throw(() => {
                paymentPackage = new PaymentPackage(10, 10);
            }, 'Name must be a non-empty string')
        })

        it('should throw exception with incorrect name length 0', () => {
            assert.throw(() => {
                paymentPackage = new PaymentPackage('', 10);
            }, 'Name must be a non-empty string')
        })

        it('should throw exception with incorrect value', () => {
            assert.throw(() => {
                paymentPackage = new PaymentPackage('Pesho', 'Gosho');
            }, 'Value must be a non-negative number')
        })

        it('should throw exception with incorrect value lower then 0', () => {
            assert.throw(() => {
                paymentPackage = new PaymentPackage('Pesho', -5);
            }, 'Value must be a non-negative number')
        })
    })

    describe('VAT', () => {
        it('should throw exception with incorrect VAT value', () => {
            paymentPackage = new PaymentPackage('Pesho', 10);
            assert.throw(() => {
                paymentPackage.VAT = "Gosho";
            }, 'VAT must be a non-negative number')
        })

        it('should throw exception with VAT lower than 0', () => {
            paymentPackage = new PaymentPackage('Pesho', 10);
            assert.throw(() => {
                paymentPackage.VAT = -10;
            }, 'VAT must be a non-negative number')
        })

        it('should set VAT correctly', () => {
            paymentPackage = new PaymentPackage('Pesho', 10);
            paymentPackage.VAT = 10;
            assert.equal(10, paymentPackage.VAT);
        })
    })

    describe('active', () => {
        it('should throw exception with incorrect active value', () => {
            paymentPackage = new PaymentPackage('Pesho', 10);
            assert.throw(() => {
                paymentPackage.active = "Gosho";
            }, 'Active status must be a boolean')
        })

        it('should set active value correctly', () => {
            paymentPackage = new PaymentPackage('Pesho', 10);
            paymentPackage.active = false;
            assert.equal(false, paymentPackage.active);
        })
    })

    describe('toString', () => {
        it("should return correct result with correct name and value", () => {
            paymentPackage = new PaymentPackage('Gosho', 1500);
            let expected = 'Package: Gosho\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800';
            assert.equal(expected, paymentPackage.toString());
        });

        it("should return correct result with changed active value", () => {
            paymentPackage = new PaymentPackage('Gosho', 1500);
            paymentPackage.active = false;
            let expected = 'Package: Gosho (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800';
            assert.equal(expected, paymentPackage.toString());
        });

        it("should return correct result with changed VAT value", () => {
            paymentPackage = new PaymentPackage('Gosho', 1500);
            paymentPackage.VAT = 0;
            let expected = 'Package: Gosho\n- Value (excl. VAT): 1500\n- Value (VAT 0%): 1500';
            assert.equal(expected, paymentPackage.toString());
        })

        it('should return correct result with value 0', () => {
            paymentPackage = new PaymentPackage('Gosho', 0);
            let expected = 'Package: Gosho\n- Value (excl. VAT): 0\n- Value (VAT 20%): 0';
            assert.equal(expected, paymentPackage.toString());
        })
    })
})
