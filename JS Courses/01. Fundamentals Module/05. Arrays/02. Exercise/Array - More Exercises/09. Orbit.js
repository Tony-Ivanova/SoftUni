function orbit(arr){
    let width = arr[0];
    let height = arr[1];
    let x = arr[2];
    let y = arr[3];

    let matrix = [];
    for(let i=0; i<width; i++) {
        matrix.push([]);
    }

    for(let row = 0; row< width; row++) {
        for(let col=0; col<height; col++) {
            matrix[row][col] = Math.max(Math.abs(row - x), Math.abs(col - y)) + 1;
        }
    }
    
    matrix.forEach(x => console.log(x.join(" ")));
}
orbit([5, 5, 2, 2]);