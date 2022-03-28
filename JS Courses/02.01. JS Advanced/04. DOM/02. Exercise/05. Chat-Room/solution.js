function solve() {
   let textInput = document.getElementById('chat_input');
   let sendButton = document.getElementById('send');
   let myMessagesTemplate = document.getElementsByClassName('my-message')[0];
   let placeToDisplayMessages = document.getElementById('chat_messages');

   sendButton.addEventListener('click', function () {

      let div = myMessagesTemplate.cloneNode(true);
      let message = textInput.value;

      let someoneIsTyping = document.getElementById("typing");

      if (message !== "") {
         div.textContent = message;
         placeToDisplayMessages.appendChild(div);
         textInput.value = '';
      }
   });
}





