const express = require('express');
const router = express.Router();

const { createUser } = require('../services/user');
const { signInUser } = require('../utilities/signInUser')

router.get('/register', (req, res) => {
    res.render('user/register');
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

    const token = signInUser(response._id, response.email);

    res.redirect('/')
})

router.get('/login', (req, res) => {
    res.render('user/login');
});

router.get('/profile', (req, res) => {
    res.render('user/profile');
});

router.get('/logout', (req, res) => {
    res.clearCookie('aid');

    res.redirect('/');
})

module.exports = router;