function solve() {

    let input = document.getElementById("text").value;
    let result = document.getElementById("result");
    let output = "";

    function findASCII(input) {

        const parts = input.split(' ');

        parts.forEach(part => {
            if (isNaN(+part)) {
                //this is not a number
                const line = [...part].map(ch => ch.charCodeAt(0)).join(' ');
                let p = document.createElement('p');
                p.innerHTML = line;
                result.appendChild(p);
            } else {
                output += String.fromCharCode(+part);
            }
        });
    }

    findASCII(input);

    let p = document.createElement('p');
    p.innerHTML = output;
    result.appendChild(p);
}