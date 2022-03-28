function create(words) {
   let area = document.getElementById("content");

   words.forEach(word => {
      let div = document.createElement("div");
      let p = document.createElement("p");
      p.textContent = word;
      p.style.display = 'none';
      div.appendChild(p);
      area.appendChild(div);
   });

   let allDivs = document.querySelectorAll("div div");

   Array.from(allDivs).forEach(x => x.addEventListener("click", () => {
      let p = x.firstChild;
      p.style.display = 'block';
   }));
}