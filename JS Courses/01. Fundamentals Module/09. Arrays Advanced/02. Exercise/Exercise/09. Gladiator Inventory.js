function inventory(arr) {
    let games = arr[0].split(' ');

    for (let i = 0; i < arr.length; i++) {

        let currentInput = arr[i].split(' ');
        let command = currentInput[0];
        let game = currentInput[1];

        if (command === "Buy" && !games.includes(game)) {
            games.push(game);
        } else if (command === 'Trash' && games.includes(game)) {
            let index = games.indexOf(game);
            games.splice(index, 1);
        } else if (command === 'Repair' && games.includes(game)) {
            let index = games.indexOf(game);
            games.splice(index, 1);
            games.push(game);
        } else if (command === 'Upgrade') {
            let expansion = game.split('-');
            let currentGame = expansion[0];
            let expansionOfCurrentGame = expansion[1];

            if (games.includes(currentGame)) {
                let index = games.indexOf(currentGame);
                let expandedGame = `${currentGame}:${expansionOfCurrentGame}`;
                games.splice(index + 1, 0, expandedGame);
            }
        }
    }

    console.log(games.join(' '));
}
inventory(['SWORD Shield Spear',
    'Buy Bag',
    'Trash Shield',
    'Repair Spear',
    'Upgrade SWORD-Steel']

);