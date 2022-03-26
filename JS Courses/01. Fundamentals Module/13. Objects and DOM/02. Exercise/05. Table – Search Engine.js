function solve() {

    let searchButton = document.getElementById("searchBtn");
    let whatIsSearchedField = document.getElementById("searchField");
    let tableCells = document.getElementsByTagName("tbody").item(0).getElementsByTagName("tr");

    searchButton.addEventListener('click', searchFunction);

    function searchFunction() {

        let wahtIsSearched = whatIsSearchedField.value;

        for (let row of tableCells) {
            row.removeAttribute("class");

            if (row.textContent.includes(wahtIsSearched)) {
                row.className = "select";
            }
        }

        document.getElementById("searchField").value = "";
    }
}