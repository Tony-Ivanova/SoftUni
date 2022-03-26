function bitcoinMining(arg) {

    let bitcoin = 11949.16;
    let gold = 67.51;
    let totalMoney = 0;
    let dayOfTheFirstBitcoin = 0;
    let bitcoinCount = 0;
    let bitcoinSum = 0;
    let days = 0;

    for (let i = 0; i < arg.length; i++) {
        days++;
        let goldForTheDay = arg[i];
        if (days % 3 == 0) {
            goldForTheDay *= 0.7;
        }

        let moneyForTheDay = goldForTheDay * gold;
        totalMoney += moneyForTheDay;

        if (totalMoney >= bitcoin) {
            bitcoinCount++;
            bitcoinAmount = Math.floor(totalMoney / bitcoin);
            totalMoney -= bitcoinAmount * bitcoin;
            bitcoinSum += bitcoinAmount
        }

        if (bitcoinCount == 1) {
            dayOfTheFirstBitcoin = days;
        }
    }

    console.log(`Bought bitcoins: ${bitcoinSum}`);
    if (dayOfTheFirstBitcoin != 0) {

        console.log(`Day of the first purchased bitcoin: ${dayOfTheFirstBitcoin}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}
bitcoinMining([50, 100])