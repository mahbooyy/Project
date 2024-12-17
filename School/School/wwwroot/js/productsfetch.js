document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('apply-filter').addEventListener('click', () => {
        const idCategory = document.getElementById('id_Category').value;

        // Пример фильтрации по диапазону цены (можно добавить дополнительные фильтры)
        const priceMin = document.getElementById('adult-min-price').value || 0;
        const priceMax = document.getElementById('adult-max-price').value || Infinity;

        // Собираем данные для фильтрации
        const filterData = {
            idCategory: idCategory,
            priceMin: parseFloat(priceMin),
            priceMax: parseFloat(priceMax),
        };

        console.log('Отправляемые данные для фильтрации:', filterData);

        // Отправка фильтров на сервер
        fetch('/Products/Filter', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(filterData),
        })
            .then((response) => {
                if (!response.ok) {
                    throw new Error('Ошибка при фильтрации данных');
                }
                return response.json();
            })
            .then((data) => {
                console.log('Результаты фильтрации:', data);
                displayProducts(data);
            })
            .catch((error) => {
                console.error('Ошибка:', error);
            });
    });

    // Функция отображения товаров после фильтрации
    function displayProducts(data) {
        const productsContainer = document.querySelector('.list-products');

        // Очистка только содержимого контейнера, но не самого контейнера
        productsContainer.innerHTML = '';

        if (!data || data.length === 0) {
            productsContainer.innerHTML = '<h2>По данному фильтру товаров нет</h2>';
        } else {
            data.forEach((product) => {
                const productItem = `
                    <div class="tour-item">
                        <img src="${product.pathImage}" alt="Товар" class="item-tour-img" />
                        <div class="item-info">
                            <h2>${product.name}</h2>
                            <p>${product.opisanie}</p>
                        </div>
                        <table>
                            <tbody>
                                <tr>
                                    <td><strong>${product.price} руб</strong></td>
                                </tr>
                            </tbody>
                        </table>
                        <button>Купить</button>
                        <input value="${product.id}" style="display: none" />
                        <input value="${product.idCategory}" style="display: none" />
                    </div>
                `;
                productsContainer.innerHTML += productItem;
            });
        }
    }

    // Сортировка товаров
    const sortSelect = document.getElementById('sort-options');

    sortSelect.addEventListener('change', function() {
        const sortOption = sortSelect.value;
        const productsContainer = document.querySelector('.list-products');

        // Собираем товары для сортировки
        const products = Array.from(productsContainer.querySelectorAll('.tour-item'));

        productsContainer = document.createElement('div');

        // Добавляем классы для стилизации
        productsContainer.classList.add('list-products');  // Добавление класса для стилизации

        products.sort((a, b) => {
            const priceA = parseFloat(a.querySelector('td strong').textContent.replace(' руб', '').trim());
            const priceB = parseFloat(b.querySelector('td strong').textContent.replace(' руб', '').trim());

            if (sortOption === 'price-asc') {
                return priceA - priceB;
            } else if (sortOption === 'price-desc') {
                return priceB - priceA;
            }
            return 0;
        });

        // Добавляем отсортированные товары обратно в контейнер
        products.forEach((product) => productsContainer.appendChild(product));
    });
});
