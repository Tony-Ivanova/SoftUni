function stopwatch() {
    let startButton = document.getElementById("startBtn");
    let stopButton = document.getElementById("stopBtn");
    let time = document.getElementById("time");
    let interval;


    startButton.addEventListener("click", (e) => {
        time.textContent = '00:00';
        stopButton.removeAttribute('disabled');
        e.currentTarget.setAttribute('disabled', true);

        interval = setInterval(function () {
            let currentTime = time.textContent;
            let [minInput, secInput] = currentTime.split(':');
            let min = Number(minInput);
            let sec = Number(secInput);

            sec++;
            if (sec > 59) {
                min++;
                sec = 0;
            }

            time.textContent = `${min.toString().padStart(2, '0')}:${sec.toString().padStart(2, '0')}`;

        }, 1000);

    });

    stopButton.addEventListener("click", (e) => {
        clearInterval(interval);
        e.currentTarget.setAttribute('disabled', true);
        startButton.removeAttribute('disabled');
    });
}