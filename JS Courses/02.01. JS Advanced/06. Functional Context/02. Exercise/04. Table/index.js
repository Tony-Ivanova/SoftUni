function solve() {
   let allRowElements = document.querySelectorAll("tbody tr");
   let lastClickedElement;

   Array.from(allRowElements).forEach(x => x.addEventListener("click", (e) => {

      let element = e.target.parentNode.style;

      if (element.backgroundColor === '' || element.backgroundColor == undefined) {
         element.backgroundColor = "#413f5e";

         if (lastClickedElement) {
            lastClickedElement.backgroundColor = '';
         }
      } else {
         element.backgroundColor = '';

      }
      lastClickedElement = element;
   }));
}
