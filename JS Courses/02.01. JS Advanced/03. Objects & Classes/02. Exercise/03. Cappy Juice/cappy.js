function solve(args) {
    let results = {};
    let juicesInOrder = {};

    args.forEach(line => {
        let [fruit, quantityInput] = line.split(' => ');
        let quantity = Number(quantityInput);
        
        if (!results[fruit]) {
            results[fruit] = quantity;
        } else {
            results[fruit] += quantity;
        }

        if (results[fruit] >= 1000) {
            juicesInOrder[fruit] = 0;
        }
    });

    Object.keys(results).forEach(fruit => {
        if (juicesInOrder[fruit] !== undefined) {
            juicesInOrder[fruit] += parseInt(results[fruit] / 1000);
        }
    });

    Object.keys(juicesInOrder).forEach(fruit => console.log(`${fruit} => ${juicesInOrder[fruit]}`));
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
)