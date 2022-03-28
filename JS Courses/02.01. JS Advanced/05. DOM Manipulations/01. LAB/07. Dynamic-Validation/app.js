function validate() {
    let inputElement = document.getElementById("email");

    inputElement.addEventListener('change', (e) => {
        let currentValue = e.currentTarget.value;

        let regexPattern = /[a-z]+@[a-z]+.[a-z]+/;

        if (regexPattern.test(currentValue)) {
            e.currentTarget.classList.remove('error');
        } else {
            e.currentTarget.classList.add('error');

        }
    })
}