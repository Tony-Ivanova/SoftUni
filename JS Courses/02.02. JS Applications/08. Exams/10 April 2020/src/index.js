import { editPage, detailsPage, homePage, postCreate, postEdit, deletePost } from './controllers/catalog.js';
import { loginPage, registerPage, postRegister, postLogin, logoutPage } from './controllers/user.js';
import * as api from './data.js';
import { getUserData } from './util.js';

const app = Sammy('#root', function (context) {

    this.use('Handlebars', 'hbs');

    const user = getUserData();
    this.userData = user;

    this.get('/', homePage);
    this.get('/home', homePage);  
   
    this.get('/login', loginPage);
    this.post('/login', (context) => { postLogin(context); });
    
    this.get('/logout', logoutPage);
    
    this.get('/register', registerPage);
    this.post('/register', (context) => { postRegister(context); });

    this.get('/details/:id', detailsPage);

    this.get('/edit/:id', editPage);
    this.post('/edit/:id', (context) => { postEdit(context); });

    this.post('/create', (context) => { postCreate(context); });
    this.get('/delete/:id', deletePost);

});

app.run();