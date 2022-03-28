import { homePage, createPage, postCreate, detailsPage, editPage, postEdit, deleteDestination, myDestinationsPage } from './controllers/catalog.js';
import { registerPage, postRegister, loginPage, postLogin, logoutPage } from './controllers/user.js';
import * as api from './data.js';
import { getUserData } from './util.js';

const app = Sammy('#container', function (context) {

    this.use('Handlebars', 'hbs');

    const user = getUserData();
    this.userData = user;

    this.get('/', homePage);
    this.get('/home', homePage);
    this.get('/destinations', myDestinationsPage);


    this.get('/logout', logoutPage);
    
    this.get('/register', registerPage);
    this.post('/register', (context) => { postRegister(context); });

    this.get('/add', createPage);
    this.post('/add', (context) => { postCreate(context); });

    this.get('/details/:id', detailsPage);

    this.get('/edit/:id', editPage);
    this.post('/edit/:id', (context) => { postEdit(context); });

    this.get('/delete/:id', deleteDestination);

    this.get('/login', loginPage);
    this.post('/login', (context) => { postLogin(context); });
});

app.run();