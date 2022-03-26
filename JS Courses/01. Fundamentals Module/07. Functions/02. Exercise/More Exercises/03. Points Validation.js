function pointValidation(array) {

    let x1 = Number(array[0]);
    let y1 = Number(array[1]);
    let x2 = Number(array[2]);
    let y2 = Number(array[3]);


    let firstDistance = IsValid(x1, y1, 0, 0);
    let secondDistance = IsValid(x2, y2, 0, 0);
    let finalDistance = IsValid(x1, y1, x2, y2);

    console.log(firstDistance);
    console.log(secondDistance);
    console.log(finalDistance);


    function IsValid(first, second, third, forth) {
        let validOrNot = Number.isInteger(Distance(first, second, third, forth));
        if (validOrNot) {
            return `{${first}, ${second}} to {${third}, ${forth}} is valid`;
        } else if (!validOrNot) {
            return `{${first}, ${second}} to {${third}, ${forth}} is invalid`;
        }
    }

    function Distance(x1, y1, x2, y2) {
        let distanceX = x1 - x2;
        let distanceY = y1 - y2;

        return Math.sqrt(distanceX ** 2 + distanceY ** 2);
    }
}

pointValidation([2, 1, 1, 1]);