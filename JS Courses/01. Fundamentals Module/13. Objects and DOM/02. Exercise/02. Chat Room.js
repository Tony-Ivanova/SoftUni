function solve() {

    let targetDiv = document.getElementsByClassName("my-message")[0];
    let textArea = document.getElementById("chat_input");
    let sendButton = document.getElementById("send");
    let chatMessageArea = document.getElementById("chat_messages");

    sendButton.addEventListener("click", function () {
        let targetDivClone = targetDiv.cloneNode(true);
        let textAreaContent = textArea.value;

        if (textAreaContent !== "") {
            targetDivClone.textContent = textAreaContent;
            chatMessageArea.appendChild(targetDivClone);
            textArea.value = "";
        }
    });
}
