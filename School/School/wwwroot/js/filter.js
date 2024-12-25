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
document.getElementById("searchInput").addEventListener("input", function () {
    var searchQuery = this.value.toLowerCase();
    var products = document.querySelectorAll(".tour-item");

    products.forEach(function (product) {
        var productName = product.getAttribute("data-name").toLowerCase();
        var productDescription = product.getAttribute("data-description").toLowerCase();

        if (productName.includes(searchQuery) || productDescription.includes(searchQuery)) {
            product.style.display = "block"; // Показываем товар
        } else {
            product.style.display = "none"; // Скрываем товар
        }
    });
}); 