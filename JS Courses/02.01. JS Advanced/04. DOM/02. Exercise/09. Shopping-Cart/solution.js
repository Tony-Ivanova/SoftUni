function solve() {
   let buttons = document.getElementsByClassName(`add-product`);
   let textArea = document.getElementsByTagName(`textarea`)[0];
   let checkoutButton = document.getElementsByClassName(`checkout`)[0];

   let list = new Map();

   Array.from(buttons).forEach(b => {
      b.addEventListener("click", (e) => {

         let currentElement = e.target.parentElement;

         let priceElement = currentElement.nextElementSibling.textContent;
         let brandElement = currentElement.previousElementSibling.children[0].textContent;

         if (!list.has(brandElement)) {
            list.set(brandElement, 0)
         }

         list.set(brandElement, list.get(brandElement) + Number(priceElement))

         textArea.value += `Added ${brandElement} for ${priceElement} to the cart.\n`;
      })
   });

   checkoutButton.addEventListener("click", (e) => {

      let totalPrice = Number(Array.from(list.values()).reduce((a, b) => Number(a) + Number(b), 0));

      textArea.textContent += `You bought ${Array.from(list.keys()).join(', ')} for ${totalPrice.toFixed(2)}.`

      Array.from(buttons).forEach(b => b.disabled = true);
   });
}