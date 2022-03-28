function addItem() {
    let text = document.getElementById('newItemText').value;
    let li = document.createElement("li");
    let placeToPutNewLi = document.getElementById("items");
    li.textContent += text;
    placeToPutNewLi.appendChild(li);
    document.getElementById('newItemText').value = '';
}