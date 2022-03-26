function solve() {

    let counter = 0;

    let answers = ['onclick',
        'JSON.stringify()',
        'A programming API for HTML and XML documents']

    Array.from(document.querySelectorAll('.answer-text')).forEach(x => x.addEventListener('click', changePage));

    function changePage() {
        let section = this.parentNode.parentNode.parentNode.parentNode
        let nextSection = section.nextElementSibling;

        section.style.display = 'none';
        nextSection.style.display = 'block';

        if (answers.includes(this.textContent)) {
            counter++
        }

        if (nextSection.id === 'results') {
            section.style.display = 'none';
            nextSection.style.display = 'block';

            document.querySelector('#results h1').textContent =
                counter === 3
                    ? 'You are recognized as top JavaScript fan!'
                    : `You have ${counter} right answers`
        }
    }
}