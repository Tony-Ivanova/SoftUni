const htmlSelectors = {
    'errorContainer': () => document.getElementById('error-notification'),
    'registerBtn': () => document.getElementById('register-btn'),
    'emailInput': () => document.querySelector('#register-form input[name="email"]'),
    'passwordInput': () => document.querySelector('#register-form input[name="psw"]'),
    'registerForm': () => document.getElementById('register-form'),
    'loginInBtn': () => document.getElementById('login-btn'),
    'loginEmailInput': () => document.querySelector('#login-form input[name="email"]'),
    'loginPasswordInput': () => document.querySelector('#login-form input[name="psw"]'),
    'loginForm': () => document.getElementById('login-form'),
    'signOutForm': () => document.getElementById('sign-out'),
    'logoutBtn': () => document.getElementById('logout'),
}

htmlSelectors['registerBtn']()
    .addEventListener('click', registerUser);

htmlSelectors['loginInBtn']()
    .addEventListener('click', loginUser);

htmlSelectors['logoutBtn']()
    .addEventListener('click', logoutUser);


function registerUser(e) {
    e.preventDefault();

    const emailInput = htmlSelectors['emailInput']();
    const passwordInput = htmlSelectors['passwordInput']();

    if (emailInput.value !== '' && passwordInput.value.length >= 6) {
        firebase.auth().createUserWithEmailAndPassword(emailInput.value, passwordInput.value)
            .then(() => {
                htmlSelectors['registerForm']().style.display = "none";
                htmlSelectors['loginForm']().style.display = "block";
            })
            .catch(handleError);
    } else {
        const error = { message: '' };

        if (emailInput.value === '') {
            error.message += 'Email must not be empty! ';
        }

        if (passwordInput.value.length < 6) {
            error.message += 'Password length must not be 6 symbols or more! ';
        }

        handleError(error);
    }
}

function loginUser(e) {
    e.preventDefault();

    const loginEmailInput = htmlSelectors['loginEmailInput']();
    const loginPasswordInput = htmlSelectors['loginPasswordInput']();

    if (loginEmailInput.value !== '' && loginPasswordInput.value.length >= 6) {
        firebase.auth().signInWithEmailAndPassword(loginEmailInput.value, loginPasswordInput.value)
            .then(() => {
                htmlSelectors['loginForm']().style.display = "none";
                htmlSelectors['signOutForm']().style.display = "block";
            })
            .catch(handleError);

    } else {
        const error = { message: '' };

        if (loginEmailInput.value === '') {
            error.message += 'Email must not be empty! ';
        }

        if (loginPasswordInput.value.length < 6) {
            error.message += 'Password length must not be 6 symbols or more! ';
        }

        handleError(error);
    }

}

function logoutUser() {

    firebase.auth().signOut()
        .then(() => {
            let h1 = document.createElement('h1');
            h1.textContent = 'Sign out successfully';
            htmlSelectors['signOutForm']().appendChild(h1);
        })
        .catch(handleError);
}

function handleError(error) {
    const errorContainer = htmlSelectors['errorContainer']();
    errorContainer.style.display = 'block';
    errorContainer.textContent = error.message;

    setTimeout(() => {
        errorContainer.style.display = 'none';
    }, 5000);
}

