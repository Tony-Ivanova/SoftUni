function solve() {
    let input = document.getElementById('input');
    let output = document.getElementById('output');

    let sentance = input.textContent.split('.').filter(x => x !== '').map(x => (x += '.'));

    for (let index = 0; index < sentance.length; index += 3) {
        let p = document.createElement('p');
        p.textContent = sentance.slice(index, index + 3).join(' ');

        output.appendChild(p);
    }
}