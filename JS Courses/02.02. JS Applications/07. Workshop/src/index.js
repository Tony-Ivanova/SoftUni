import { homePage } from './controllers/home.js';
import { registerPage, loginPage, logout, registerPost, loginPost } from './controllers/user.js';
import { createPage, editPost, detailsPage, deleteOffer, editPage, createPost, buyPage } from './controllers/catalog.js';
import { getUserData } from './util.js';

const app = Sammy('#root', function (context) {
    
    this.use('Handlebars', 'hbs');

    const user = getUserData();
    this.userData = {
        isLoggedIn: user ? true : false,
        ...user
    }

    this.get('/home', homePage);

    this.get('/register', registerPage);

    this.post('/register', registerPost);

    this.get('/login', loginPage)

    this.post('/login', loginPost);

    this.get('/logout', logout)

    this.get('/create-offer', createPage);

    this.post('/create-offer', createPost);

    this.get('#/details/:offerId', detailsPage);

    this.get('#/delete/:offerId', deleteOffer);

    this.get('#/edit/:offerId', editPage);

    this.post('#/edit/:offerId', editPost);

    this.get('#/buy/:offerId', buyPage);
});

app.run('/home');

