function attachEventsListeners() {
    let buttonElements = document.querySelectorAll('input[value="Convert"]');
    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondsInput = document.getElementById('seconds');

    Array.from(buttonElements).forEach(x => x.addEventListener("click", () => {
        let typeById = x.id;
        let date;
        switch (typeById) {
            case "daysBtn":
                date = daysInput.value;
                hoursInput.value = date * 24;
                minutesInput.value = date * 1440;
                secondsInput.value = date * 86400;
                break;
            case "hoursBtn":
                date = hoursInput.value;
                daysInput.value = date / 24;
                minutesInput.value = date * 60;
                secondsInput.value = date * 60 * 60;
                break;
            case "minutesBtn":
                date = minutesInput.value;
                daysInput.value = date / 60 / 24;
                hoursInput.value = date / 60;
                secondsInput.value = date * 60;
                break;
            case "secondsBtn":
                date = secondsInput.value;
                daysInput.value = date / 60 / 60 / 24;
                hoursInput.value = date / 60 / 60;
                minutesInput.value = date / 60;
                break;
            default:
                break;
        }

    }))
}