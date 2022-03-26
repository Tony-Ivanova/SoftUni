function houseParty(arr) {

    let partyList = [];
    for (let i = 0; i < arr.length; i++) {
        let currentInput = arr[i].split(' ');
        let personAttending = currentInput[0];

        if (currentInput.includes(`not`)) {
            if (partyList.includes(personAttending)) {
                let whereInThePartyList = partyList.indexOf(personAttending);
                partyList.splice(whereInThePartyList, 1);
            } else {
                console.log(`${personAttending} is not in the list!`);
            }
        } else {
            if (partyList.includes(personAttending)) {
                console.log(`${personAttending} is already in the list!`);
            } else {
                partyList.push(personAttending);
            }
        }
    }
    
    console.log(partyList.join('\n'));
}
houseParty(['Tom is going!',
    'Annie is going!',
    'Tom is going!',
    'Garry is going!',
    'Jerry is going!'])