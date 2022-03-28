function addItem() {
    let textInput = document.getElementById('newItemText').value;
    let valueInput = document.getElementById('newItemValue').value;
    let menuElement = document.getElementById('menu');

    let optionElement = document.createElement('option');
    optionElement.textContent = textInput;
    optionElement.value = valueInput;

    menuElement.appendChild(optionElement);

    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}