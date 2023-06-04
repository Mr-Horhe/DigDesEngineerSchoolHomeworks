const ratioInp = document.getElementById('ratio');
const ageInp = document.getElementById('age');

ratioInp.addEventListener('input', function () {
    ageInp.value = this.value;
});

ageInp.addEventListener('input', function () {
    ratioInp.value = this.value;
});

document.querySelector('#getCur').addEventListener('click', async (event) => {

    const USDInput = document.getElementById('USD');
    const EURInput = document.getElementById('EUR');

    try {
        const response = await fetch('https://www.cbr-xml-daily.ru/daily_json.js');
        const data = await response.json();

        const USDRate = data.Valute.USD.Value;
        const EURRate = data.Valute.EUR.Value;

        USDInput.value = USDRate.toFixed(2);
        EURInput.value = EURRate.toFixed(2);
    } catch (error) {
        console.log('Ошибка при получении курсов валют:', error);
    }
});

const imageElement = document.createElement('img');

document.querySelector('#get').addEventListener('click', async (event) => {
    try {
        const response = await fetch('https://api.thecatapi.com/v1/images/search?mime_types=gif');
        const data = await response.json();

        const url = data[0].url;

        imageElement.src = url;
        document.querySelector('#image-container').appendChild(imageElement);
    } catch (error) {
        console.log('Ошибка при получении кота:', error);
    }
});



