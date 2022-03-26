function store(currentStock, orderedProducts) {

    let store = {};

    for (let i = 0; i < currentStock.length - 1; i += 2) {
        let product = currentStock[i];
        let quantity = Number(currentStock[i + 1]);

        store[product] = quantity;
    }

    for (let i = 0; i < orderedProducts.length - 1; i += 2) {
        let product = orderedProducts[i];
        let quantity = Number(orderedProducts[i + 1]);

        if (store[product] !== undefined) {
            store[product] += quantity;
        } else {
            store[product] = quantity;
        }
    }

    for (const kvp in store) {
        console.log(`${kvp} -> ${store[kvp]}`);
    }
}

store([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
)