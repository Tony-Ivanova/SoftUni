function poundsToDollars(pounds) {

    let dollarRate = 1.31;
    let dollars = pounds * dollarRate;

    console.log(dollars.toFixed(3));
}
poundsToDollars(80)