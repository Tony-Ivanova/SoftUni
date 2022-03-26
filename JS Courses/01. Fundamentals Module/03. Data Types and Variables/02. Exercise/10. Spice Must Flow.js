function spiceMustFlow(yield) {
    let totalAmount = 0;
    let days = 0;

    let enoughYield = 100;
    let yieldLostPerDay = 10;
    let yieldForWorkers = 26;


    while (yield >= enoughYield) {
        totalAmount += yield - yieldForWorkers;
        yield -= yieldLostPerDay;
        days++;
    }

    if (totalAmount != 0) {
        totalAmount -= yieldForWorkers;
    }

    console.log(days);
    console.log(totalAmount);
}
spiceMustFlow(111);