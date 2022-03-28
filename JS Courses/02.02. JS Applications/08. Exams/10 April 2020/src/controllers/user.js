import { addPartials, removeUserData } from "../util.js";
import { login, register } from "../data.js";


export async function registerPage() {
    await addPartials(this);
    this.partial('/templates/user/registerPage.hbs');
}

export function logoutPage(context){
    context.app.userData = null;
    removeUserData();
    this.redirect('/home');
}

export async function loginPage() {
    await addPartials(this);
    this.partial('/templates/user/loginPage.hbs');
}

export async function postRegister(context) {
    const { email, password, repeatPassword } = context.params;
    try {
        if (email.length == 0 || password.length == 0) {
            throw new Error('All fields are required!');
        } else if (password !== repeatPassword) {
            throw new Error('Passwords don\'t match!');
        } else {
            const result = await register(email, password);
            context.redirect('/login');
        }
    } catch (err) {
        alert(err.message);
    }
}

export async function postLogin(context) {
    const { email, password } = context.params;
    try {
        if (email.length == 0 || password.length == 0) {
            throw new Error('All fields are required!');
        } else {
            const result = await login(email, password);
            context.app.userData = result;
            context.redirect('/home');
        }
    } catch (err) {
        alert(err.message);
    }
}