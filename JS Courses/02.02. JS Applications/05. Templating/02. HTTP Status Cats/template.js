const elements = {
    allCats: () => document.getElementById("allCats"),
};

Promise.all([
    getTemplate('./template.hbs'),
    getTemplate('./cat.hbs')
])
    .then(([temlateSrc, catScrc]) => {
        Handlebars.registerPartial('cat', catScrc);
        let template = Handlebars.compile(temlateSrc);
        let resultHtml = template({ cats });
        elements.allCats().innerHTML = resultHtml;
        attachEventListener();
    })
    .catch((e) => console.error(e));

function getTemplate(tempLateLocation) {
    return fetch(tempLateLocation).then((res) => res.text());
}

function attachEventListener() {
    elements.allCats().addEventListener('click', (e) => {
        const { target } = e;
        if (target.nodeName === "BUTTON" && target.className === "showBtn") {
            let divStatus = target.parentNode.querySelector("div.status");

            if (divStatus.style.display == 'none') {
                divStatus.style.display = 'block';
                e.target.textContent = 'Show status code';
            } else {
                divStatus.style.display = 'none';
                e.target.textContent = 'Hide status code';
            }
        }
    })
}