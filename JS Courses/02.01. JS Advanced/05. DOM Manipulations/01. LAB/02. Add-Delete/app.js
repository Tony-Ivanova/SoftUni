function addItem() {
    let text = document.getElementById('newText').value;
    let placeToPutNewLi = document.getElementById("items");
    document.getElementById('newText').value = '';

    if (text.length === 0) {
        return
    };

    let li = document.createElement("li");
    li.textContent += text;

    let remove = document.createElement("a");
    let linkText = document.createTextNode("[Delete]");
    remove.appendChild(linkText);
    remove.href = "#";
    li.appendChild(remove);

    remove.addEventListener("click", () => {
        li.remove();
    });

    placeToPutNewLi.appendChild(li);
}