function dungeonestDark(arr) {
    let health = 100;
    let coins = 0;
    let rooms = arr[0].split('|');

    for (let i = 0; i < rooms.length; i++) {

        let room = rooms[i].split(' ');
        let roomContent = room[0];
        let roomValue = Number(room[1]);

        if (roomContent == "potion") {
            let newHealth = Math.min(roomValue, 100 - health);
            health += newHealth;
            console.log(`You healed for ${newHealth} hp.`);
            console.log(`Current health: ${health} hp.`);
        }
        else if (roomContent == "chest") {
            coins += roomValue;
            console.log(`You found ${roomValue} coins.`);
        }
        else {
            let monster = roomContent;
            attackMonster = roomValue;

            health -= attackMonster;

            if (health <= 0) {
                console.log(`You died! Killed by ${monster}.`);
                console.log(`Best room: ${i + 1}`);
                break;
            }

            console.log(`You slayed ${monster}.`);
        }
    }
    if (health > 0) {
        console.log(`You've made it!`);
        console.log(`Coins: ${coins}`);
        console.log(`Health: ${health}`);        
    }
}

dungeonestDark(['rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000']);