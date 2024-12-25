function toggleMenu() {
    const sideMenu = document.getElementById('side-menu');

    sideMenu.classList.toggle('active');
}

document.getElementById('hamburger').addEventListener('click', toggleMenu);
function updateQuantity(productId, change) {
    // Найти элементы количества и общей стоимости
    const quantityElement = document.getElementById(`quantity-${productId}`);
    const totalElement = document.getElementById(`total-${productId}`);
    const totalPriceElement = document.getElementById('total-price');

    // Получить текущее количество и цену товара
    let currentQuantity = parseInt(quantityElement.innerText);
    let itemTotal = parseFloat(totalElement.innerText.split(' ')[0]);
    let itemPrice = currentQuantity > 0 ? itemTotal / currentQuantity : 0;

    // Рассчитать новое количество
    let newQuantity = currentQuantity + change;
    if (newQuantity < 1) return; // Минимум 1 товар

    // Обновить интерфейс
    quantityElement.innerText = newQuantity;
    totalElement.innerText = (itemPrice * newQuantity).toFixed(2) + ' руб';

    // Пересчитать общую стоимость корзины
    let totalPrice = 0;
    document.querySelectorAll('[id^="total-"]').forEach(element => {
        totalPrice += parseFloat(element.innerText.split(' ')[0]);
    });
    totalPriceElement.innerText = `Итоговая стоимость: ${totalPrice.toFixed(2)} руб`;

    // Отправить данные на сервер
    fetch('/Cart/UpdateQuantity', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ cartItemId: productId, quantity: newQuantity })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Ошибка обновления на сервере.");
            }
            return response.json();
        })
        .then(data => {
            if (!data.success) {
                alert("Ошибка на сервере. Попробуйте позже.");
            }
        })
        .catch(error => {
            console.error('Ошибка:', error);
            // Восстановить прежнее значение в случае ошибки
            quantityElement.innerText = currentQuantity;
            totalElement.innerText = (itemPrice * currentQuantity).toFixed(2) + ' руб';
            alert("Произошла ошибка при обновлении количества.");
        });
}
function deleteItem(productId) {
    if (!confirm("Вы уверены, что хотите удалить этот товар?")) return;

    fetch('/Cart/DeleteItem', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ cartItemId: productId })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Ошибка при удалении товара.");
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                // Удалить строку товара из таблицы
                const row = document.querySelector(`[id="quantity-${productId}"]`).closest('tr');
                row.remove();

                // Обновить общую стоимость
                const totalPriceElement = document.getElementById('total-price');
                totalPriceElement.innerText = `Итоговая стоимость: ${data.totalPrice.toFixed(2)} руб`;
            } else {
                alert("Ошибка на сервере. Попробуйте позже.");
            }
        })
        .catch(error => {
            console.error('Ошибка:', error);
            alert("Произошла ошибка при удалении товара.");
        });
}
function removeFromArchive(productName) {
    console.log("Removing product from archive:", productName); // Debugging
    fetch('/Archive/RemoveFromArchive', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ productName })
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert(data.message);
                location.reload(); // Обновление страницы
            } else {
                alert(data.message);
            }
        })
        .catch(error => console.error('Ошибка:', error));
}
