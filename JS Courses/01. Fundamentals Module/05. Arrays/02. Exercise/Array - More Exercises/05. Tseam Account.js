function tseamAccount(arr) {
    let games = arr[0].split(' ');
 
    for (let i = 1; i < arr.length; i++) {

        let currentInput = arr[i].split(' ');
        let command = currentInput[0];
        let game = currentInput[1];
 
        if (command === 'Play') {
            break;
        } else if (command === "Install" && !games.includes(game)) {
            games.push(game);
        } else if (command === 'Uninstall' && games.includes(game)) {
            let index = games.indexOf(game);
            games.splice(index, 1);
        } else if (command === 'Update' && games.includes(game)) {
            let index = games.indexOf(game);
            games.splice(index, 1);
            games.push(game);
        } else if (command === 'Expansion') {
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
tseamAccount(['CS WoW Diablo',
'Install LoL',
'Uninstall WoW',
'Update Diablo',
'Expansion CS-Go',
'Play!']
)