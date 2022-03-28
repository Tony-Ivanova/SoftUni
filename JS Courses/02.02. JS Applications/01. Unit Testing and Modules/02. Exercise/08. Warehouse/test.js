let { assert } = require('chai');
let Warehouse = require('./warehouse.js');

describe('Warehouse', () => {
    let warehouse;

    beforeEach(function () {
        warehouse = new Warehouse(5);
    });

    describe('constructor', () => {
        it('constructor should work properly with correct capacity', () => {
            assert.equal(5, warehouse.capacity);
            assert.deepEqual({ Food: {}, Drink: {} }, warehouse.availableProducts);
        });

        it('constructor should throw error if capacity is not a number', () => {
            assert.throw(() => {
                warehouse = new Warehouse("Gosho");
            }, 'Invalid given warehouse space');
        });

        it('constructor should throw error if capacity is a negative number', () => {
            assert.throw(() => {
                warehouse = new Warehouse(-10);
            }, 'Invalid given warehouse space');
        });
    })

    describe('addProduct', () => {
        it('should add the correct product', () => {
            warehouse.addProduct("Food", "Potato", 3);
            assert.equal(3, warehouse.availableProducts.Food["Potato"]);
            assert.deepEqual({ Food: { Potato: 3 }, Drink: {} }, warehouse.availableProducts)
        })

        it('should throw exception if warehouse is full', () => {
            assert.throw(() => {
                warehouse.addProduct("Food", "Potato", 6);
            }, 'There is not enough space or the warehouse is already full')
        })
    })

    describe('orderProduct', () => {
        it('should return the correct alphabetical order', () => {
            warehouse.addProduct("Drink", "Cola", 1);
            warehouse.addProduct("Drink", "Soda", 1);
            warehouse.addProduct("Food", "Potato", 1);
            warehouse.addProduct("Food", "Papaya", 1);

            let expected = JSON.stringify(warehouse.orderProducts("Food"));
            assert.equal('{"Potato":1,"Papaya":1}', expected);
        })

        it('should work without products entered', () => {
            let expected = JSON.stringify(warehouse.orderProducts("Drink"));
            assert.equal(`{}`, expected);
        })
    })

    describe('occupiedCapacity', () => {
        it('should return correct occupied capacity with products', () => {
            warehouse.addProduct("Drink", "Cola", 1);
            warehouse.addProduct("Drink", "Soda", 1);
            warehouse.addProduct("Food", "Potato", 1);
            warehouse.addProduct("Food", "Papaya", 1);
            let expected = warehouse.occupiedCapacity();
            assert.equal(4, expected);
        })

        it('should return correct occupied capacity with no products', () => {
            let expected = warehouse.occupiedCapacity();
            assert.equal(0, expected);
        })
    })

    describe('revision', () => {
        it('should return correct output with available products', () => {
            warehouse.addProduct("Drink", "Cola", 1);
            warehouse.addProduct("Drink", "Soda", 1);
            warehouse.addProduct("Food", "Potato", 1);
            warehouse.addProduct("Food", "Papaya", 1);
            let expected = warehouse.revision();
            assert.equal(expected, "Product type - [Food]\n- Potato 1\n- Papaya 1\nProduct type - [Drink]\n- Cola 1\n- Soda 1");
        })

        it('should return correct message when there are no products', () => {
            let expected = 'The warehouse is empty';
            assert.equal(expected, warehouse.revision());
        })
    })

    describe('scrapeAProduct', () => {
        it('should throw exception if product doesnt exist', () => {
            assert.throw(() => {
                warehouse.scrapeAProduct("Potato", 2);
            }, `Potato do not exists`)
        })

        it('test should work correctly with correct products of type food', () => {
            warehouse.addProduct("Drink", "Cola", 1);
            warehouse.addProduct("Drink", "Soda", 1);
            warehouse.addProduct("Food", "Potato", 1);
            warehouse.addProduct("Food", "Papaya", 1);

            let result = warehouse.scrapeAProduct("Potato", 1);
            assert.deepEqual({ Potato: 0, Papaya: 1 }, result)
        })

        it('test should work correctly with correct products of type drink', () => {
            warehouse.addProduct("Drink", "Cola", 1);
            warehouse.addProduct("Drink", "Soda", 1);
            warehouse.addProduct("Food", "Potato", 1);
            warehouse.addProduct("Food", "Papaya", 1);

            let result = warehouse.scrapeAProduct("Cola", 1);
            assert.deepEqual({ Cola: 0, Soda: 1 }, result)
        })
    })
})
