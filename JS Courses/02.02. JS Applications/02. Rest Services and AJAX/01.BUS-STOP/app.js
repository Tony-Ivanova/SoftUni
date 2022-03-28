function getInfo() {
    let validBusses = ["1287", "1308", "1327", "2334"];
    let stopId = document.getElementById("stopId");
    let stopInfo = document.getElementById("stopName");
    let busesList = document.getElementById('buses');

    if (!validBusses.includes(stopId.value)) {
        stopInfo.textContent = "Error";
        busesList.textContent = '';
        return;
    }

    const url = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json`;

    const httpRequest = new XMLHttpRequest();

    httpRequest.addEventListener('loadend', function () {
        busesList.textContent = '';
        let data = JSON.parse(this.responseText);

        stopInfo.textContent = data.name;
        Object.keys(data.buses).forEach(key => {
            let li = document.createElement('li');
            li.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`;
            busesList.appendChild(li);
        })

        stopId.value = '';

    })

    httpRequest.open('GET', url);

    httpRequest.send();


    /*
    Other way
    fetch(url)
      .then((response) => response.json())
      .then((data) => {
          stopInfo.textContent = data.name;
   
          Object.keys(data.buses).forEach(key => {
              let li = document.createElement('li');
              li.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`;
              busesList.appendChild(li);
          })
   
          stopId.value = '';
      }); */
}