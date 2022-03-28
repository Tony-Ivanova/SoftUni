function solve() {
   let searchInputElement = document.getElementById("searchField");
   let searchButton = document.getElementById("searchBtn");
   let allTrElemens = document.querySelectorAll("tbody > tr");

   searchButton.addEventListener("click", () => {

      let searchInput = searchInputElement.value;
      let regex = new RegExp(searchInput, 'gim');

      Array.from(allTrElemens).map(currentTr => {
         currentTr.classList.remove('select');
         
         if (currentTr.textContent.match(regex) !== null) {
            currentTr.classList.add('select');
         }
      });

      searchInputElement.value = '';
   });
}