function attachGradientEvents() {
    let area = document.getElementById("gradient");
    let result = document.getElementById("result");

    area.addEventListener('mousemove', (e) => {
        let percent = parseInt((e.offsetX / e.currentTarget.clientWidth) * 100);
        result.textContent = `${percent}%`;
    })

    area.addEventListener('mouseout', (e) => {
        result.textContent = "";
    })
}