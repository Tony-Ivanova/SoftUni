import { createPage, deleteArticle, detailsPage, editPage, homePage, postCreate, postEdit } from './controllers/catalog.js';
import { registerPage, loginPage, postRegister, postLogin, logoutPage } from './controllers/user.js';
import * as api from './data.js';
import { getUserData } from './util.js';

const app = Sammy('#root', function (context) {

    this.use('Handlebars', 'hbs');

    const user = getUserData();
    this.userData = user;

    this.get('/', homePage);
    this.get('/home', homePage);
    this.get('/create', createPage);
    this.get('/register', registerPage);
    this.get('/login', loginPage);
    this.get('/details/:id', detailsPage);
    this.get('/edit/:id', editPage);
    this.get('/logout', logoutPage);
    
    this.post('/register', (context) => { postRegister(context); });
    this.post('/login', (context) => { postLogin(context); });
    this.post('/edit/:id', (context) => { postEdit(context); });
    this.post('/create', (context) => { postCreate(context); });

    this.get('/delete/:id', deleteArticle);
});

app.run();

