function solve(numberOfSteps, lengthInMeters, speedInKmPerH) {

    let distance = numberOfSteps * lengthInMeters;
    let speedInSeconds = speedInKmPerH / 3.6;
    let additionalMinutes = Math.floor(distance / 500) * 60;
    let time = Math.round(distance / speedInSeconds + additionalMinutes);

    let date = new Date(null);
    date.setSeconds(time);
    let timeString = date.toISOString().substr(11, 8);
    console.log(timeString);
}
solve(4000, 0.60, 5)