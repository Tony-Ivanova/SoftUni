function getArticleGenerator(articles) {
    let content = document.getElementById("content");
    let count = 0;

    return function () {
        let article = document.createElement("article");

        if (count < articles.length) {
            article.innerHTML = articles[count];
            content.appendChild(article);
            count++;
        }
    }
}