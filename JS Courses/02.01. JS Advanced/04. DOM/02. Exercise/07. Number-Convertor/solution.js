function solve() {
    let numberInput = document.getElementById("input");
    let menuTo = document.getElementById("selectMenuTo");
    let optionFromMenuTo = document.querySelector("#selectMenuTo option");
    let convertButton = document.getElementsByTagName("button")[0];
    let resultInput = document.getElementById("result");

    extendList('binary', 'Binary');
    extendList('hexadecimal', 'Hexadecimal');

    function extendList(valueToBeAdded, contentToBeAdded) {
        let newOption = optionFromMenuTo.cloneNode(true);
        newOption.value = `${valueToBeAdded}`;
        newOption.textContent = `${contentToBeAdded}`;
        menuTo.appendChild(newOption);
    }

    convertButton.addEventListener(`click`, function () {

        let currentResult = parseInt(numberInput.value)

        if (menuTo.value === 'binary') {
            resultInput.value = currentResult.toString(2);
        } else if (menuTo.value === 'hexadecimal') {
            resultInput.value = currentResult.toString(16).toUpperCase();
        }
    });
}