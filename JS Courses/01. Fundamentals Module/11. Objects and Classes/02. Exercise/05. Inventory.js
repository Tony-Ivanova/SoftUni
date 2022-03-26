function heroRegister(input) {

    let heroes = [];

    for (let i = 0; i < input.length; i++) {
        let heroArr = input[i].split(" / ");
        let name = heroArr[0];
        let level = Number(heroArr[1]);
        let items = heroArr[2].split(", ").sort((a, b) => a.localeCompare(b));

        let currentHero = { 'name': name, 'level': level, 'items': items };
        heroes.push(currentHero);
    }

    heroes.sort((a, b) => a.level - b.level);

    heroes.forEach(hero =>
        console.log(`Hero: ${hero.name}\nlevel => ${hero.level}\nitems => ${hero.items.join(", ")}`)
    );
}

heroRegister([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara"
]
)