function fuelMoney(distance, passengers, pricePerL) {
    let fuelPer100kmInL = 7;
    let fuelPerPersonInL = 0.100;

    let neededFuel = (distance / 100) * fuelPer100kmInL;
    neededFuel += passengers * (fuelPerPersonInL);

    let neededMoney = neededFuel * pricePerL;

    console.log(`Needed money for that trip is ${neededMoney}lv.`);
}

fuelMoney(260, 9, 2.49);