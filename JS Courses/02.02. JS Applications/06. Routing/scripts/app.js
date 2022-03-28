const UserModel = firebase.auth();
const db = firebase.firestore();

const router = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');

    this.get('#/home', function (context) {

        const userInfo = localStorage.getItem('userInfo');
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        loadPartials(context)
            .then(function () {
                this.partial('../templates/home/home.hbs')
            })
    });

    this.get('#/about', function (context) {

        const userInfo = localStorage.getItem('userInfo');
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        loadPartials(context)
            .then(function () {
                this.partial('../templates/about/about.hbs')
            })
    });

    this.get('#/login', function (context) {
        const userInfo = localStorage.getItem('userInfo');
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'loginForm': '../templates/login/loginForm.hbs'
        }).then(function () {
            this.partial('../templates/login/loginPage.hbs')
        })
    });

    this.get('#/logout', function (context) {
        const userInfo = localStorage.getItem('userInfo');
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        UserModel.signOut()
            .then((res) => {
                localStorage.removeItem('userInfo');
                context.redirect('#/home');
            })
            .catch((e) => console.log(e));
    })

    this.get('#/register', function () {
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'registerForm': '../templates/register/registerForm.hbs'
        }).then(function () {
            this.partial('../templates/register/registerPage.hbs')
        })
    });

    this.get('#/catalog', function (context) {
        const userInfo = localStorage.getItem('userInfo');
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.hasNoTeam = true;
            context.email = email;
        }

        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'team': '../templates/catalog/team.hbs'
        }).then(function () {
            this.partial('../templates/catalog/teamCatalog.hbs')
        })
    })

    this.get('#/create', function (context) {
        const userInfo = localStorage.getItem('userInfo');
        if (userInfo) {
            const { uid, email } = JSON.parse(userInfo);
            context.loggedIn = true;
            context.email = email;
        }

        context.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'createForm': '../templates/create/createForm.hbs'
        }).then(function () {
            this.partial('../templates/create/createPage.hbs')
        })
    })

    this.post('#/register', function (context) {
        const { email, password, repeatPasword } = context.params;

        if (password !== repeatPasword) {
            let err = document.querySelector('#errorBox');
            err.textContent = "Both password should match!";
            err.style.display = 'block';
            return;
        }

        UserModel.createUserWithEmailAndPassword(email, password)
            .then((createdUser) => {
                console.log(createdUser);
                this.redirect('#/login')
            })
            .catch((e) => console.log(e));


    });

    this.post('#/login', function (context) {
        const { email, password } = context.params;

        UserModel.signInWithEmailAndPassword(email, password)
            .then(({ user: { uid, email } }) => {
                localStorage.setItem('userInfo', JSON.stringify({ uid, email }));
                context.redirect('#/home');
                console.log(userInfo);
            })
            .catch((e) => console.log(e))
    })

    this.post('#/create', function (context) {
        const { email, password } = context.params;
    })
});

(() => {
    router.run('#/home');
})();

function loadPartials(context) {
    return context.loadPartials({
        'header': '../templates/common/header.hbs',
        'footer': '../templates/common/footer.hbs'
    })
}