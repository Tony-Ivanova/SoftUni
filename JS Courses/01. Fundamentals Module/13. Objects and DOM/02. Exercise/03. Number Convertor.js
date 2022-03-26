function solve() {

    let numberToBeConverted = document.getElementById("input");
    let listTo = document.getElementById("selectMenuTo");
    let placeToAddaListToOption = document.querySelector("#selectMenuTo option");
    let convertButton = document.getElementsByTagName("button")[0];
    let result = document.getElementById("result");
    let currentResult;

    extendList('binary', 'Binary');
    extendList('hexadecimal', 'Hexadecimal');

    function extendList(valueToBeAdded, contentToBeAdded) {

        let newElement = placeToAddaListToOption.cloneNode(true);
        newElement.value = `${valueToBeAdded}`;
        newElement.textContent = `${contentToBeAdded}`;
        listTo.appendChild(newElement);
    }

    convertButton.addEventListener(`click`, function () {

        if (listTo.value === 'binary') {
            currentResult = parseInt(numberToBeConverted.value)
            result.value = currentResult.toString(2);
        } else if (listTo.value === 'hexadecimal') {
            currentResult = parseInt(numberToBeConverted.value)
            result.value = currentResult.toString(16).toUpperCase();
        }
    });
}