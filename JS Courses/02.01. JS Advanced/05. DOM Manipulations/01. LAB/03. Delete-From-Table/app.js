function deleteByEmail() {
    let emailInput = document.getElementsByTagName('input')[0];
    let allEntries = document.getElementsByTagName("tr");
    let placeForErrors = document.getElementById("result");
    let expectedMail = emailInput.value;
    emailInput.value = '';
    let isFound = false;

    Array.from(allEntries).forEach(tr => {
        let currentInput = tr.children;
        let currentEmail = currentInput[1].textContent;

        if (currentEmail === expectedMail) {
            isFound = true;
            tr.parentNode.removeChild(tr);
        }
    });

    if (!isFound) {
        placeForErrors.textContent = 'Not found.';
    } else {
        placeForErrors.textContent = 'Deleted.';
    }
}