function solve() {
    const baseUrl = 'https://judgetests.firebaseio.com/schedule/';
    let stopId = 'depot';
    let stopName;
    const info = document.getElementById('info');

    function changeButton() {
        const departDis = document.getElementById('depart');
        const arriveDis = document.getElementById('arrive');

        if (departDis.disabled) {
            departDis.disabled = false;
            arriveDis.disabled = true;
        } else {
            departDis.disabled = true;
            arriveDis.disabled = false;
        }
    }

    function depart() {
        const url = `${baseUrl}${stopId}.json`;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                info.textContent = `Next stop ${data.name}`;
                stopId = data.next;
                stopName = data.name;
            })
            .catch(() => {
                info.textContent = 'ERROR';
            });

        changeButton()
    }

    function arrive() {
        info.textContent = `Arriving at ${stopName}`;
        changeButton()
    }

    return {
        depart,
        arrive
    };
}

let result = solve();