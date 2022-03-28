function attachEventsListeners() {
    let fromValueInput = document.getElementById("inputDistance");
    let toValueInput = document.getElementById("outputDistance");
    let btnElement = document.getElementById("convert");
    let optionsFromInput = document.getElementById("inputUnits");
    let optionsToInput = document.getElementById("outputUnits");


    btnElement.addEventListener("click", () => {
        let optionsFrom = optionsFromInput.value;
        let optionsTo = optionsToInput.value;
        let fromValue = fromValueInput.value;

        let middleValueInM = 0;
        let newValue = 0;

        switch (optionsFrom) {
            case "km":
                middleValueInM = 1000 * fromValue;
                break;
            case "m":
                middleValueInM = 1 * fromValue;
                break;
            case "cm":
                middleValueInM = 0.01 * fromValue;
                break;
            case "mm":
                middleValueInM = 0.001 * fromValue;
                break;
            case "mi":
                middleValueInM = 1609.34 * fromValue;
                break;
            case "yrd":
                middleValueInM = 0.9144 * fromValue;
                break;
            case "ft":
                middleValueInM = 0.3048 * fromValue;
                break;
            case "in":
                middleValueInM = 0.0254 * fromValue;
                break;
        }

        switch (optionsTo) {
            case "km":
                newValue = middleValueInM / 1000;
                break;
            case "m":
                newValue = middleValueInM / 1;
                break;
            case "cm":
                newValue = middleValueInM / 0.01;
                break;
            case "mm":
                newValue = middleValueInM / 0.001;
                break;
            case "mi":
                newValue = middleValueInM / 1609.34;
                break;
            case "yrd":
                newValue = middleValueInM / 0.9144;
                break;
            case "ft":
                newValue = middleValueInM / 0.3048;
                break;
            case "in":
                newValue = middleValueInM / 0.0254;
                break;
        }

        toValueInput.value = newValue;
    });

}