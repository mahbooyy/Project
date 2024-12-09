const sortSelect = document.getElementById('sort-options');
const serviceContainer = document.querySelector('.container-services');

sortSelect.addEventListener('change', () => {

    const sortOption = sortSelect.value;

    const services = Array.from(serviceContainer.querySelectorAll('.service-item'));

    services.sort((a, b) => {
        const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
        const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

        switch (sortOption) {
            case 'price-asc': {
                return priceA - priceB; // От меньшей к большей
            }
            case 'price-desc': {
                return priceB - priceA; // От большей к меньшей
            }
            default:
                return 0;
        }
    });

    // Добавляем отсортированные элементы обратно в контейнер
    services.forEach(service => serviceContainer.appendChild(service));
});
