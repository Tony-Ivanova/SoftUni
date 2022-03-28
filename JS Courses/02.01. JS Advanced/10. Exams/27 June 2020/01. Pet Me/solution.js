function solve() {
    let information = Array.from(document.getElementById("container").children);
    let [nameElement, ageElement, kindElement, currentOwnerElement, submitButton] = information;
    let adoptionSection = document.querySelector("#adoption ul");
    let adoptedSection = document.querySelector('#adopted ul');

    submitButton.addEventListener("click", gatherInformation);

    function gatherInformation(e) {
        e.preventDefault();
        let age = ageElement.value;
        let name = nameElement.value;
        let kind = kindElement.value;
        let currentOwner = currentOwnerElement.value;

        if (!Number(age) || !name || !kind || !currentOwner) {
            return;
        }

        let liElement = document.createElement('li');
        let p = document.createElement('p');
        let span = document.createElement('span');
        let contactOwnerBtn = document.createElement('button');

        p.innerHTML = `<strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong>`;
        span.textContent = `Owner: ${currentOwner}`;
        contactOwnerBtn.textContent = `Contact with owner`;

        liElement.appendChild(p);
        liElement.appendChild(span);
        liElement.appendChild(contactOwnerBtn);

        adoptionSection.appendChild(liElement);

        ageElement.value = '';
        nameElement.value = '';
        kindElement.value = '';
        currentOwnerElement.value = '';

        contactOwnerBtn.addEventListener("click", adoptAnAnimal);
    }

    function adoptAnAnimal(e) {

        let placeToChangeInformation = e.currentTarget.parentElement;

        e.currentTarget.remove();

        let div = document.createElement('div');
        let input = document.createElement('input');
        let adoptBtn = document.createElement('button');

        input.setAttribute('placeholder', 'Enter your names');
        adoptBtn.textContent = 'Yes! I take it!';

        div.appendChild(input);
        div.appendChild(adoptBtn);

        placeToChangeInformation.appendChild(div);

        adoptBtn.addEventListener("click", animalFindsANewHome);
    }

    function animalFindsANewHome(e) {
        let parentElement = e.currentTarget.parentElement;
        let liElement = parentElement.parentElement;

        let newOwnerInputElement = liElement.querySelector('input');
        let ownerNameSpanElement = liElement.querySelector('span');

        let ownerName = newOwnerInputElement.value;

        if (!ownerName) {
            return;
        }

        ownerNameSpanElement.textContent = `New Owner: ${ownerName}`;

        adoptedSection.appendChild(liElement);

        parentElement.remove();

        let checkedButtonElement = document.createElement('button');
        checkedButtonElement.textContent = 'Checked';

        liElement.appendChild(checkedButtonElement);

        checkedButtonElement.addEventListener('click', e => {
            e.currentTarget.parentElement.remove();
        });
    }
}

