function getNextDay(year, month, day) {

    let originalDate = new Date(year, month, day);
    let nextDay = new Date(year, month - 1, originalDate.getDate() + 1);

    console.log(`${nextDay.getFullYear()}-${nextDay.getMonth() + 1}-${nextDay.getDate()}`);
}
getNextDay(2016, 11, 2)