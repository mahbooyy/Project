document.addEventListener('DOMContentLoaded', () => {
    const sortSelect = document.getElementById('sort-options');
    const productsContainer = document.querySelector('.container-products');

    sortSelect.addEventListener('change', () => {
        const sortOption = sortSelect.value;

        const products = Array.from(productsContainer.querySelectorAll('.tour-item'));

        products.sort((a, b) => {
            const priceA = parseFloat(a.querySelector('td strong').textContent.replace(' руб', '').trim());
            const priceB = parseFloat(b.querySelector('td strong').textContent.replace(' руб', '').trim());

            if (sortOption === 'price-asc') {
                return priceA - priceB; // От меньшей к большей
            } else if (sortOption === 'price-desc') {
                return priceB - priceA; // От большей к меньшей
            }
            return 0;
        });

        productsContainer.innerHTML = '';
        products.forEach((product) => productsContainer.appendChild(product));
    });
});