function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let div = document.getElementById('extra');
    let buttonState = button.textContent;

    if (buttonState == "More") {
        document.getElementsByClassName("button")[0].innerHTML = "Less";
        div.style.display = "block";
    } else {
        document.getElementsByClassName("button")[0].innerHTML = "More";
        div.style.display = "none";
    }
}