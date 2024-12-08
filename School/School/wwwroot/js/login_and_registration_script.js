document.addEventListener('DOMContentLoaded', function () {
    // Функция для открытия/закрытия формы
    function hiddenOpen_Closeclick(container) {
        let x = document.querySelector(container);
        if (x.style.display === "none") {
            x.style.display = "grid";
        } else {
            x.style.display = "none";
        }
    }

    // Обработчики для скрытия/открытия формы
    document.getElementById("click-to-hide")?.addEventListener("click", function () {
        hiddenOpen_Closeclick(".container-login-registration");
    });

    document.getElementById('side-menu-button-click-to-hide')?.addEventListener('click', function () {
        hiddenOpen_Closeclick(".container-login-registration");
    });

    document.querySelector(".overlay")?.addEventListener("click", function () {
        hiddenOpen_Closeclick(".container-login-registration");
    });

    document.querySelector(".button_confirm_close")?.addEventListener("click", function () {
        hiddenOpen_Closeclick(".confirm-email-container");
    });

    // Переключение между формами входа и регистрации
    const signInBtn = document.querySelector('.signin-btn');
    const signUpBtn = document.querySelector('.signup-btn');
    const formBox = document.querySelector('.form-box');
    const block = document.querySelector('.block');

    if (signInBtn && signUpBtn) {
        signUpBtn.addEventListener('click', function () {
            formBox.classList.add('active');
            block.classList.add('active');
        });

        signInBtn.addEventListener('click', function () {
            formBox.classList.remove('active');
            block.classList.remove('active');
        });
    }

    // Обработка формы регистрации
    const form_btn_signup = document.querySelector('.form_btn_signup');
    const form_btn_signin = document.querySelector('.form_btn_signin');

    if (form_btn_signin) {
        form_btn_signin.addEventListener('click', function () {
            const requestURL = '/Home/Login';

            const errorContainer = document.getElementById('error-messages-singin');
            const form = {
                email: document.getElementById("signin_email"),
                password: document.getElementById("signin_password")
            };

            const body = {
                email: form.email.value,
                password: form.password.value
            };

            sendRequest('POST', requestURL, body)
                .then(data => {
                    cleaningAndClosingForm(form, errorContainer);
                    location.reload();
                })
                .catch(err => {
                    displayErrors(err, errorContainer);
                });
        });
    }

    if (form_btn_signup) {
        form_btn_signup.addEventListener('click', function () {
            const requestURL = '/Home/Register';
            const errorContainer = document.getElementById('error-messages-signup');
            const form = {
                login: document.getElementById("signup_login"),
                email: document.getElementById("signup_email"),
                password: document.getElementById("signup_password"),
                passwordConfirm: document.getElementById("signup_confirm_password"),
            };
            const body = {
                login: form.login.value,
                email: form.email.value,
                password: form.password.value,
                passwordConfirm: form.passwordConfirm.value,
            };

            sendRequest('POST', requestURL, body)
                .then(data => {
                    cleaningAndClosingForm(form, errorContainer);
                    hiddenOpen_Closeclick(".confirm-email-container");
                    confirmEmail(data);
                })
                .catch(err => {
                    displayErrors(err, errorContainer);
                });
        });
    }

    // Функция отправки запроса
    function sendRequest(method, url, body = null) {
        const headers = {
            'Content-Type': 'application/json'
        };
        return fetch(url, {
            method: method,
            body: JSON.stringify(body),
            headers: headers
        }).then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    throw errorData;
                });
            }
            return response.json();
        });
    }

    // Функция отображения ошибок
    function displayErrors(errors, errorContainer) {
        errorContainer.innerHTML = '';
        errors.forEach(error => {
            const errorMessage = document.createElement('div');
            errorMessage.classList.add('error');
            errorMessage.textContent = error;
            errorContainer.appendChild(errorMessage);
        });
    }

    // Функция очистки формы и скрытия
    function cleaningAndClosingForm(form, errorContainer) {
        errorContainer.innerHTML = '';
        for (const key in form) {
            if (form.hasOwnProperty(key)) {
                form[key].value = ''; // Очистка значений
            }
        }
        hiddenOpen_Closeclick(".container-login-registration"); // Закрытие формы
    }

    function confirmEmail(body) {
        document.querySelector(".send_confirm")?.addEventListener('click', function () {
            const codeConfirm = document.getElementById('code_confirm')?.value;
            if (!codeConfirm) {
                alert("Пожалуйста, введите код подтверждения.");
                return;
            }

            body.CodeConfirm = codeConfirm;
            const requestURL = '/Home/ConfirmEmail';

            sendRequest('POST', requestURL, body)
                .then(data => {
                    hiddenOpen_Closeclick(".confirm-email-container");
                    location.reload();
                })
                .catch(err => {
                    const errorContainer = document.getElementById('error-messages-confirm');
                    if (errorContainer) {
                        displayErrors(err, errorContainer);
                    }
                });
        });
    }

    // Обработка кнопки Google
    const googleBtns = document.querySelectorAll('.google');
    googleBtns.forEach(btn => {
        btn.addEventListener('click', function () {
            window.location.href = `/Home/AuthenticationGoogle?returnUrl=${encodeURIComponent(window.location.href)}`;
        });
    });
});
