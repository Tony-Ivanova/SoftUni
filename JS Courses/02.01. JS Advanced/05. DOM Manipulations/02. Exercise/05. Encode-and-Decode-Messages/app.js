function encodeAndDecodeMessages() {
    let encodeButton = document.getElementsByTagName("button")[0];
    let decodeButton = document.getElementsByTagName("button")[1];
    let enteredMessageElement = document.getElementsByTagName("textarea")[0];
    let decodedMessageElement = document.getElementsByTagName("textarea")[1];

    encodeButton.addEventListener("click", () => {
        let enteredMessage = enteredMessageElement.value;
        let enteredMessageLng = enteredMessage.length;
        let encodedMessage = '';

        for (let i = 0; i < enteredMessageLng; i++) {
            encodedMessage += String.fromCharCode(enteredMessage.charCodeAt(i) + 1);
        }

        decodedMessageElement.value = encodedMessage;
        enteredMessageElement.value = '';
    });

    decodeButton.addEventListener("click", () => {
        let enteredMessage = decodedMessageElement.value;
        let enteredMessageLng = enteredMessage.length;
        let encodedMessage = '';

        for (let i = 0; i < enteredMessageLng; i++) {
            encodedMessage += String.fromCharCode(enteredMessage.charCodeAt(i) - 1);
        }

        decodedMessageElement.value = encodedMessage;
    });
}