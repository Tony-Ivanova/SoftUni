function focus() {

    let inputs = document.querySelectorAll('input[type="text"]');

    Array.from(inputs).forEach(x => {
        x.addEventListener('focus', function (e) {
            let parentDiv = e.currentTarget.parentElement;
            parentDiv.classList.add('focused');
        });

        x.addEventListener('blur', function (e) {
            let parentDiv = e.currentTarget.parentElement;
            parentDiv.classList.remove('focused');
        });
    });
}