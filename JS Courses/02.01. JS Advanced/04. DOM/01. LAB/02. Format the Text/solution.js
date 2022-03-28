function solve() {
  let input = document.getElementById('input');
  let output = document.getElementById('output');

  let sentances = input.textContent.split('.').filter(x => x !== '').map(x => (x += '.'));

  for (let i = 0; i < sentances.length; i += 3) {
    let sentancesToTake = sentances.slice(i, i + 3).join(' ');

    let paragraph = document.createElement('p');
    paragraph.textContent = sentancesToTake;

    output.appendChild(paragraph);
  }
}