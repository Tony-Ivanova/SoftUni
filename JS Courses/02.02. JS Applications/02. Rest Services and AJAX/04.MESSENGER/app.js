function attachEvents() {
    let url = `https://rest-messanger.firebaseio.com/messanger.json`;

    let refreshButton = document.getElementById('refresh');

    refreshButton.addEventListener('click', () => {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                let result = Object.values(data).reduce(
                    (messages, message) =>
                        (messages += `${message.author}: ${message.content}\n`),
                    ""
                );

                document.getElementById('messages').textContent = result;
            })
    })

    let submitButton = document.getElementById('submit')

    submitButton.addEventListener('click', () => {
        let authorInput = document.getElementById('author');
        let contentInput = document.getElementById('content');

        let author = authorInput.value;
        let content = contentInput.value;
        if (author === '' || content === '') {
            alert("Name or content are empty");
        } else {
            fetch(url, {
                method: 'POST',
                body: JSON.stringify({
                    author: author,
                    content: content
                })
            })
        }

        author.value = '';
        content.value = '';
    })
}

attachEvents();
