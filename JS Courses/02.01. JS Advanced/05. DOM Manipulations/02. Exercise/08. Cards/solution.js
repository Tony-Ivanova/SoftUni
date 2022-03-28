function solve() {
    const playerOne = document.getElementById('player1Div');
    const playerTwo = document.getElementById('player2Div');
    const result = document.getElementById('result').children;
    const history = document.getElementById('history');

    let playerOneCard = '';
    let playerTwoCard = '';

    [playerOne, playerTwo].forEach(player => player.addEventListener('click', (e) => {

        if (player === playerOne) {
            playerOneCard = playerOneCard = showCard(playerOneCard, result[0], e);
        } else {
            playerTwoCard = playerTwoCard = showCard(playerTwoCard, result[2], e);
        }

        cardBattle();
    }));

    function cardBattle() {

        let leftSpan = result[0].textContent;
        let rightSpan = result[2].textContent;

        if (leftSpan !== '' && rightSpan !== '') {
            let resultFirstPlayer = Number(playerOneCard.name);
            let resultSecondPlayer = Number(playerTwoCard.name);

            if (resultFirstPlayer > resultSecondPlayer) {
                createBorder(playerOneCard, playerTwoCard);
            } else {
                createBorder(playerTwoCard, playerOneCard);
            }

            saveHistory();
            defaultValues();
        }
    }

    function createBorder(card1, card2) {
        card1.style.border = "2px solid green";
        card2.style.border = "2px solid red";
    }

    function showCard(player, span, e) {
        e.target.src = "images/whiteCard.jpg";
        span.textContent = e.target.name;
        player = e.target;
        return player;
    }

    function defaultValues() {
        result[0].textContent = '';
        result[2].textContent = '';
        playerOneCard = '';
        playerTwoCard = '';
    }

    function saveHistory() {
        history.textContent += `[${playerOneCard.name} vs ${playerTwoCard.name}] `;
    }
}