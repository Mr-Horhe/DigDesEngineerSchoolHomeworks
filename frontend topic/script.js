const currencyForm = document.getElementById('currencyForm');

currencyForm.addEventListener('submit', async (event) => {
    event.preventDefault();

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

const catForm = document.getElementById('catForm');
const img = document.createElement('img');
const container1 = document.querySelector('#image-container');
//img.src='https://cdn2.thecatapi.com/images/90.gif';
//img.width=100;
//img.height=100;
//container1.append(img);
catForm.addEventListener('submit', async (event)=>{
    event.preventDefault();
    try {
        const response = await fetch('https://api.thecatapi.com/v1/images/search?mime_types=gif');
        const data = await response.json();

        const catURL=data[0].url;

        img.src = catURL;
        //img.width=100;
        //img.height=100;
        const container = document.querySelector('#image-container');

        container.append(img);
    } catch (error) {
        console.log('Cat error', error);
    }
})


// Устанавливаем путь к изображению


// Устанавливаем альтернативный текст для изображения

// Получаем контейнер, куда нужно вставить изображение


// Вставляем изображение в контейнер

