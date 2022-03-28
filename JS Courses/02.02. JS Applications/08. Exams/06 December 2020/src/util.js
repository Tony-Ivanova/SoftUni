export function displayError(message) {
    const errorBox = document.getElementById('errorBoxSection');
    errorBox.style.display = 'block';
    errorBox.textContent = message;
    const timer = setTimeout(() => {
        errorBox.style.display = 'none';
    }, 3000);
    clearTimeout(timer);
}

export function displaySuccess(message) {
    const successBox = document.getElementById('successBoxSection');
    successBox.style.display = 'block';
    successBox.textContent = message;
    const timer = setTimeout(() => {
        successBox.style.display = 'none';
    }, 3000);
    clearTimeout('onclick', timer);
}

export function setUserData(data) {
    sessionStorage.setItem('auth', JSON.stringify(data));
}

export function removeUserData() {
    sessionStorage.removeItem('auth');
}

export function getUserData() {
    const auth = sessionStorage.getItem('auth');

    if (auth !== null) {
        return JSON.parse(auth);
    }

    return null;
}

export function getUserId() {
    const auth = sessionStorage.getItem('auth');

    if (auth !== null) {
        return JSON.parse(auth).localId;
    }

    return null;
}

export function objectToArray(data) {
    if (data == null) {
        return [];
    } else {
        return Object.entries(data).map(([k, v]) => Object.assign({ _id: k }, v));
    }
}

export async function addPartials(context) {
    const partials = await Promise.all([
        context.load('/templates/common/header.hbs'),
        context.load('/templates/common/footer.hbs'),
    ]);

    context.partials = {
        header: partials[0],
        footer: partials[1],
    };
}