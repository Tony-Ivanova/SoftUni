import { addButton, loadButton, catchesDiv, angler, weight, species, location, bait, captureTime } from './inputs.js';
import { baseUrl, deleteBaseUrl } from './html.js';

function attachEvents() {

    addButton.addEventListener('click', () => {

        let obj = JSON.stringify({
            angler: angler.value,
            weight: weight.value,
            species: species.value,
            location: location.value,
            bait: bait.value,
            captureTime: captureTime.value,
        })

        fetch(baseUrl, {
            method: "POST",
            body: obj,
        })
            .then(res => res.json())
            .then(data => console.log(data));
    })

    loadButton.addEventListener('click', () => {
        fetch(baseUrl)
            .then(res => res.json())
            .then(data => {
                Object.keys(data).forEach(key => appendCatch(key, data));
            });
    })

    function appendCatch(key, data) {
        let { angler, weight, species, location, bait, captureTime } = data[key];
        let catchDiv = createElement('div', 'catch', '');
        catchDiv.setAttribute("data-id", key);

        let anglerLable = createElement("label", '', 'Angler');
        let anglerInput = createElement('input', 'angler', angler, 'text');

        let weightLable = createElement("label", '', 'Weight');
        let weightInput = createElement('input', 'weight', weight, 'number');

        let speciesLable = createElement("label", '', 'Species');
        let speciesInput = createElement('input', 'species', species, 'text');

        let locationLable = createElement("label", '', 'Location');
        let locationInput = createElement('input', 'location', location, 'text');

        let baitLable = createElement("label", '', 'Bait');
        let baitInput = createElement('input', 'bait', bait, 'text');

        let captureTimeLable = createElement("label", '', 'Capture Time');
        let captureTimeInput = createElement('input', 'captureTime', captureTime, 'number');

        let updateButton = createElement('button', 'update', 'Update');
        let deleteButton = createElement('button', 'delete', 'Delete');


        deleteButton.addEventListener('click', () => {
            let deleteUrl = deleteBaseUrl + key + ".json";
            fetch(deleteUrl, {
                method: "DELETE"
            })
                .then(res => res.json())
                .then(data => console.log(data))
        })

        updateButton.addEventListener('click', (event) => {
            let obj = JSON.stringify({
                angler: anglerInput.value,
                weight: weightInput.value,
                species: speciesInput.value,
                location: locationInput.value,
                bait: baitInput.value,
                captureTime: captureTimeInput.value,
            })

            let updateUrl = deleteBaseUrl + key + ".json";
            fetch(updateUrl, {
                method: "PUT",
                body: obj
            })
        })

        catchDiv.append(anglerLable, anglerInput, hr());
        catchDiv.append(weightLable, weightInput, hr());
        catchDiv.append(speciesLable, speciesInput, hr());
        catchDiv.append(locationLable, locationInput, hr());
        catchDiv.append(baitLable, baitInput, hr());
        catchDiv.append(captureTimeLable, captureTimeInput, hr());
        catchDiv.append(updateButton, deleteButton);
        catchesDiv.appendChild(catchDiv);
    }

    function hr() {
        let hr = document.createElement('hr')
        return hr;
    }

    function createElement(elementType, classType, content, type) {
        let element = document.createElement(elementType);

        if (elementType === 'input') {
            element.type = type;
            element.value = content;
        } else {
            element.innerHTML = content;
        }

        element.className = classType;

        return element;
    }
}

attachEvents();

