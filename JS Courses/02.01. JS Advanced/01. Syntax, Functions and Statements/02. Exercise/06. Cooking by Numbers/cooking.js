function solve(array1) {
    let number = array1.shift();

    for (let i = 0; i < array1.length; i++) {
        let command = array1[i];

        switch (command) {
            case 'chop':
                number = number / 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number -= number * 0.20;
                break;
        }

        console.log(number);
    }
}

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);