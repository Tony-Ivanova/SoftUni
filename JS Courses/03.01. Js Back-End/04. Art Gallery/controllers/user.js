const express = require('express');
const { getUserStatus } = require('../middlewares/getUserStatus');
const router = express.Router();
const { createUser, loginUser } = require('../services/user')

router.get('/register', getUserStatus, (req, res) => {
    res.render('register', {
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/register', getUserStatus, async (req, res) => {
    const { username, password, repassword, address } = req.body;

    const user = await createUser(username, password, address);

    res.cookie('aid', user)
    res.redirect('/');
})

router.get('/login', getUserStatus, (req, res) => {
    res.render('login', {
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/login', async (req, res) => {
    const { username, password } = req.body;

    const response = await loginUser(username, password);

    if (response.error) {
        return res.render('user/login', {
            errors: response.messages
        })
    }

    res.cookie('aid', response)
    res.redirect('/');
})

router.get('/profile', getUserStatus, (req, res) => {
    res.render('profile', {
        isLoggedIn: req.isLoggedIn
    });
});

router.get('/logout', (req, res) => {
    res.clearCookie('aid');
    res.redirect('/');
});

module.exports = router;