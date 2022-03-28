import { addPartials, displayError, displaySuccess, removeUserData } from "../util.js";
import { login, register } from "../data.js";

export async function registerPage() {
    await addPartials(this);
    this.partial('/templates/user/registerPage.hbs');
}

export async function postRegister(context) {
    const { email, password, rePassword } = context.params;
    try {
        if (email.length == 0 || password.length == 0) {
            displayError('All fields are required!');
        } else if (password !== rePassword) {
            displayError('Passwords don\'t match!');
        } else {
            displaySuccess('User registration successful.');
            const result = await register(email, password);
            context.app.userData = result;
            context.redirect('/home');
        }
    } catch (err) {
        displayError(err.message);
    }
}

export async function loginPage() {
    await addPartials(this);
    this.partial('/templates/user/loginPage.hbs');
}

export async function postLogin(context) {
    const { email, password } = context.params;
    try {
        if (email.length == 0 || password.length == 0) {
            displayError('All fields are required!');
        } else {
            const result = await login(email, password);
            context.app.userData = result;
            displaySuccess('Login successful.');
            context.redirect('/home');
        }
    } catch (err) {
        displayError(err.message);
    }
}

export function logoutPage(context){
    context.app.userData = null;
    removeUserData();
    displaySuccess('Logout successful.');
    this.redirect('/login');
}