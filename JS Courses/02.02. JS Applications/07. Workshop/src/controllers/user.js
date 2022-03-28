import { errorHandler, loadPartialsToContext, UserModel, dbContext, getUserData, clearUserData, saveUserData } from '../util.js';

export async function registerPage(context) {
    await loadPartialsToContext(context);
    this.partial('./templates/register.hbs');
};


export async function loginPage(context) {
    await loadPartialsToContext(context);
    this.partial('./templates/login.hbs');
};

export function logout() {
    UserModel.signOut()
        .then((res) => {
            clearUserData();
            this.redirect('/home');
        })
        .catch((e) => console.log(e));
};

export function registerPost(context) {
    let { email, password, repassword } = context.params;

    if (password !== repassword) {
        return;
    }

    UserModel.createUserWithEmailAndPassword(email, password)
        .then((userdata) => {
            this.redirect('/login');
        })
        .catch((e) => console.log(e));
};

export function loginPost(context) {
    let { email, password } = context.params;

    UserModel.signInWithEmailAndPassword(email, password)
        .then((userdata) => {
            saveUserData(userdata);
            this.redirect('/home');
        })
        .catch((e) => console.log(e));
};

