document.addEventListener('DOMContentLoaded', () => {
    const sortSelect = document.getElementById('sort-options');
    const productsContainer = document.querySelector('.list-products');  // Измените на правильный класс контейнера

    sortSelect.addEventListener('change', () => {
        const sortOption = sortSelect.value;

        // Получаем все товары внутри контейнера
        const products = Array.from(productsContainer.querySelectorAll('.tour-item'));

        products.sort((a, b) => {
            const priceA = parseFloat(a.querySelector('td strong').textContent.replace(' руб', '').trim());
            const priceB = parseFloat(b.querySelector('td strong').textContent.replace(' руб', '').trim());

            if (sortOption === 'price-asc') {
                return priceA - priceB; // От меньшей к большей
            } else if (sortOption === 'price-desc') {
                return priceB - priceA; // От большей к меньшей
            }
            return 0; // Если сортировка не выбрана
        });

        // Очищаем только товары, оставляя сам контейнер
        productsContainer.innerHTML = '';

        // Если товары есть, добавляем их обратно, если нет - показываем сообщение
        if (products.length === 0) {
            productsContainer.innerHTML = '<h2>По данному фильтру товаров нет</h2>';
        } else {
            products.forEach((product) => productsContainer.appendChild(product));
        }
    });
});
