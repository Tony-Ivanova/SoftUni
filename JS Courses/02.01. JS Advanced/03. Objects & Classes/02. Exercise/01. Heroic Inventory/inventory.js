function solve(arg) {

    let results = [];

    for (const currentHero of arg) {
        let [name, levelInput, items] = currentHero.split(' / ');
        let level = Number(levelInput);
        items = items ? items.split(', ') : [];

        results.push({ name, level, items });
    }

    console.log(JSON.stringify(results));
}

solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
)