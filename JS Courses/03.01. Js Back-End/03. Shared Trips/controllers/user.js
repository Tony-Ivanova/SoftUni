const express = require('express');
const router = express.Router();

const { getUserStatus } = require('../middlewares/getUserStatus');
const { createUser, loginUser } = require('../services/user');
const { signInUser } = require('../utilities/signInUser')

router.get('/register', getUserStatus, (req, res) => {
    res.render('user/register', {
        isLoggedIn: req.isLoggedIn
    });
})

router.post('/register', async (req, res) => {
    const { email, password, repassword, gender } = req.body;

    if (password !== repassword) {
        return res.render('user/register', {
            error: 'Passwords do not match'
        })
    }

    const response = await createUser(email, password, gender);

    if (response.error) {
        return res.render('user/register', {
            error: response.message
        })
    }

    res.cookie('aid', response)
    res.redirect('/');
})

router.get('/login', getUserStatus, (req, res) => {

    res.render('user/login');
});

router.post('/login', async (req, res) => {
    const { email, password } = req.body;
    const response = await loginUser(email, password);

    if (response.error) {
        console.log(response.message)
        return res.render('user/login', {

            error: response.message
        })
    }

    res.cookie('aid', response)
    res.redirect('/');
})

router.get('/profile', (req, res) => {
    res.render('user/profile');
});

router.get('/logout', (req, res) => {
    res.clearCookie('aid');

    res.redirect('/');
})

module.exports = router;