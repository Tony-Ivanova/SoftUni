function solve() {
    let button = document.getElementsByTagName("button")[0];
    let nameInput = document.getElementsByTagName("input")[0];
    let listItemElements = document.getElementsByTagName("li");

    button.addEventListener('click', function () {
        let name = nameInput.value;
        let firstLetter = name[0].toUpperCase();
        let index = firstLetter.charCodeAt(0) - 65;
        let currentRow = listItemElements[index].textContent;
        name = name[0].toUpperCase() + name.slice(1).toLowerCase();

        if (currentRow === "") {
            listItemElements[index].textContent += name;
        } else {
            listItemElements[index].textContent += ", " + name;
        }

        nameInput.value = "";
    });
}