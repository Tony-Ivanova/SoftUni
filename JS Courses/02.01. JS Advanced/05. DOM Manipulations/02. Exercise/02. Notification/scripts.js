function notify(message) {
    let area = document.getElementById("notification");
    area.style.display = "block";
    area.textContent = message;

    setTimeout(function () {
        area.style.display = "none";
    }, 2000);
}