function nXnMatrix(number) {

    let numberToDraw = Number(number);
    Draw(numberToDraw);

    function Draw(n) {
        for (let row = 1; row <= n; row++) {
            let array = [];

            for (let column = 1; column <= n; column++) {
                array.push(n);
            }
            console.log(array.join(' '));
        }
    }
}
nXnMatrix(7)