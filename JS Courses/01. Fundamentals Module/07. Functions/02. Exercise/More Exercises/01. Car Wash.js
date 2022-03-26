function carWash(commands) {

    let clean = 0;

    let cleanPercentage = FollowCommands(commands);

    console.log(`The car is ${cleanPercentage.toFixed(2)}% clean.`);

    function FollowCommands(commands) {

        let clean = 0;

        for (let i = 0; i < commands.length; i++) {

            let currentCommand = commands[i];
            clean = FindCleanence(currentCommand);

            function FindCleanence(currentCommand) {
                switch (currentCommand) {
                    case 'soap':
                        return clean += 10;
                        break;
                    case 'water':
                        return clean += clean * 0.20;
                        break;
                    case 'vacuum cleaner':
                        return clean += clean * 0.25;
                        break;
                    case 'mud':
                        return clean -= clean * 0.10;
                        break;
                }
            }
        }
        return clean;
    }
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water'])