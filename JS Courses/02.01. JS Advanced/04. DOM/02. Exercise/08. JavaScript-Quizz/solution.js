function solve() {
  var result = 0;
  var clicks = 0;

  let rightAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

  let answers = Array.from(document.querySelectorAll('.answer-text'));

  answers.forEach(x => x.addEventListener('click', function (e) {
    let answerSelected = e.target.textContent;

    if (rightAnswers.includes(answerSelected)) {
      result++;
    }

    let sections = document.querySelectorAll('section');
    let currentSelection = sections[clicks];
    currentSelection.style.display = 'none';

    if (clicks < 2) {
      let nextSelection = sections[clicks + 1];
      nextSelection.style.display = "block";
      clicks++;
    } else {
      let onlyRightAnswersGivenMessage = 'You are recognized as top JavaScript fan!';
      let numberOfRightAnswersGivenMessage = `You have ${result} right answers`;

      document.querySelector("#results").style.display = "block";
      let placeForResult = document.querySelector('#results h1');
      placeForResult.textContent += result === 3
        ? onlyRightAnswersGivenMessage
        : numberOfRightAnswersGivenMessage;
    }
  }));
}
