const express = require('express');
const router = express.Router();
const {createUser} = require('../services/user')

router.get('/register', (req, res) => {
    res.render('register');
});

router.post('/register', async (req, res) => {
    const { username, password, repassword, address } = req.body;

    const user = await createUser(username, password, address);

    res.cookie('aid', user)
    res.redirect('/');
})

router.get('/login', (req, res) => {
    res.render('login');
});

router.get('/profile', (req, res) => {
    res.render('profile');
});

router.get('/logout', (req, res) => {
    res.clearCookie();
    res.redirect('/');
});

module.exports = router;