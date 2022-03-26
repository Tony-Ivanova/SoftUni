function dayOfWeek(day) {

    const week = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"]
    if (day < 1 || day > 7) {
        console.log(`Invalid day!`);
    } else {
        let currentDay = week[day - 1];
        console.log(currentDay);
    }
}
dayOfWeek(1);