function createArticle() {
	let titleElement = document.getElementById('createTitle').value;
	let contentElement = document.getElementById('createContent').value;
	let articleSectionElement = document.getElementById('articles');

	if (titleElement !== '' && contentElement !== '') {
		let article = document.createElement('article');
		let title = document.createElement('h3');
		title.textContent = titleElement;

		let paragraph = document.createElement('p');
		paragraph.textContent = contentElement;

		article.appendChild(title);
		article.appendChild(paragraph);
		articleSectionElement.appendChild(article);
	}

	document.getElementById('createTitle').value = "";
	document.getElementById('createContent').value = "";
}