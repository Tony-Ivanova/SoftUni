function centuriesToMinutes(centuries) {

    let hoursInADay = 24;
    let minutesInAHour = 60;
    let daysInAYear = 365.2422;
    let yearsInACentury = 100;


    let years = centuries * yearsInACentury;
    let days = Math.trunc(years * daysInAYear);
    let hours = days * hoursInADay;
    let minutes = hours * minutesInAHour;

    console.log(`${centuries} centuries = ${years} years 
                                        = ${days} days 
                                        = ${hours} hours 
                                        = ${minutes} minutes`);
}
centuriesToMinutes(1);