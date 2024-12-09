document.addEventListener('DOMContentLoaded', function () {
    const mySearch = document.querySelector("#mySearch");

    if (mySearch) {

        const clear = document.querySelector('.clear');
        if (clear) {
            clear.addEventListener("click", function () {
                mySearch.value = '';
                triggerSearch();
            });
        }

        mySearch.oninput = triggerSearch;
    }

    function insertMark(str, pos, len) {
        return str.slice(0, pos) + '<mark>' + str.slice(pos, pos + len) + '</mark>' + str.slice(pos + len);
    }

    function triggerSearch() {
        let val = mySearch.value.trim().toLowerCase();
        let products = document.querySelectorAll('.product-item');
        products.forEach(function (product_item) {
            let name = product_item.querySelector('.Name').innerText.toLowerCase();

            if (name.search(val) === -1) {
                product_item.classList.add('hide');
            } else {
                product_item.classList.remove('hide');
                let str = product_item.querySelector('.Name').innerText;
                product_item.querySelector('.Name').innerHTML = insertMark(str, name.search(val), val.length);
            }
        });
    }
});
