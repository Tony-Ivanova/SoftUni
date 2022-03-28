function solve(arg1) {

    let typeOfArg1 = typeof arg1;

    if (typeOfArg1 == 'number') {
        let circleArea = Math.PI * Math.pow(arg1, 2);
        console.log(circleArea.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfArg1}.`);
    }
}

solve(5);