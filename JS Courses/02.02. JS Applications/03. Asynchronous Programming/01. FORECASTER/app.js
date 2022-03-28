import { symbols } from './symbols.js';
import { baseUrl, currentCityForcastUrl, upcomingCityForecastUrl } from './html.js';
import { btn, cityInput, currentDiv, forecastParentDiv, upcomingDiv } from './buttons.js';

function attachEvents() {
    btn.addEventListener("click", () => {
        fetch(baseUrl)
            .then(res => res.json())
            .then(data => {
                let code = checkIfCityExist(data);
                promises(code);
            })
            .catch(() => {
                forecastParentDiv.style.display = 'block';
                let forecastDiv = createElement('div', 'error', 'ERROR');
                currentDiv.appendChild(forecastDiv);
            });
    })

    function checkIfCityExist(data) {
        let { code } = data.find((city) => city.name === cityInput.value);
        return code;
    }

    function promises(code) {
        let current = fetch(currentCityForcastUrl.replace('code', code))
            .then(res => res.json());

        let upcoming = fetch(upcomingCityForecastUrl.replace('code', code))
            .then(res => res.json());

        Promise.all([current, upcoming])
            .then(showForecast)
    }

    function showForecast([currentData, upcomingData]) {
        forecastParentDiv.style.display = 'block';

        showCurrent(currentData);
        showUpcoming(upcomingData);
    }

    function showCurrent(currentData) {
        let currentSymbol = symbols[currentData.forecast.condition];

        let forecastDiv = createElement('div', 'forecasts', '');
        let conditionSymbolSpan = createElement('span', 'condition symbol', currentSymbol);
        let conditionInfoSpan = createElement('span', 'condition', '');
        let forecastCitySpan = createElement('span', 'forecast-data', currentData.name);
        let highLow = `${currentData.forecast.low}${symbols.Degrees}/${currentData.forecast.high}${symbols.Degrees}`;
        let forecastConditionSpan = createElement('span', 'forecast-data', currentData.forecast.condition);
        let forecastInfoSpan = createElement('span', 'forecast-data', highLow);

        forecastDiv.append(conditionSymbolSpan, conditionInfoSpan);
        currentDiv.appendChild(forecastDiv);
        conditionInfoSpan.append(forecastCitySpan, forecastInfoSpan, forecastConditionSpan);
    }

    function showUpcoming(upcomingData) {
        let forecastInfo = createElement("div", "forecast-info", "");

        upcomingData.forecast.forEach(obj => {
            let upcomingSpan = createElement("span", "upcoming", '');
            let conditionSymbolSpan = createElement("span", "symbol", symbols[obj.condition]);

            let highLow = `${obj.low}${symbols.Degrees}/${obj.high}${symbols.Degrees}`;
            let forecastInfoSpan = createElement('span', 'forecast-data', highLow);

            let forecastConditionSpan = createElement('span', 'forecast-data', obj.condition);

            upcomingSpan.append(conditionSymbolSpan, forecastInfoSpan, forecastConditionSpan);
            forecastInfo.appendChild(upcomingSpan);
        })

        upcomingDiv.appendChild(forecastInfo);
    }


    function createElement(typeOfElement, classOfElement, contentOfElement) {
        let element = document.createElement(typeOfElement);
        element.className = classOfElement;
        element.innerHTML = contentOfElement;

        return element;
    }
}

attachEvents();