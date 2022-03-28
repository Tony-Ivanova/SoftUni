function solve(input) {

    let results = {};
    let letter = '';

    input.forEach(line => {
        let [product, priceInput] = line.split(" : ");
        let price = Number(priceInput);
        results[product] = price;
    });

    let sortedByLetter = Object.keys(results).sort((a, b) =>
        a.localeCompare(b));

    for (const product of sortedByLetter) {

        if (letter !== product[0]) {
            letter = product[0];
            console.log(letter);
        }

        console.log(`${product}: ${results[product]}`);
    }

}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
)