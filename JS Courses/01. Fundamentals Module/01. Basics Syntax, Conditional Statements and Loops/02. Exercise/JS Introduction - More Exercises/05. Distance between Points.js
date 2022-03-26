function getDistanceBetweenPoints(x1, y1, x2, y2) {

    let xs = x2 - x1,
        ys = y2 - y1;

    xs *= xs;
    ys *= ys;

    console.log(Math.sqrt(xs + ys));
}
getDistanceBetweenPoints(2.34, 15.66, -13.55, -2.9985)