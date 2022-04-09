const express = require('express');
const router = express.Router();

const { getUserStatus } = require('../middlewares/getUserStatus');
const { guestAccess } = require('../middlewares/guestAccess');

const { userRegister, loginUser } = require('../services/user');

router.get('/register', guestAccess, getUserStatus, (req, res) => {
    res.render('user/register', {
        isLoggedIn: req.isLoggedIn,
    })
})

router.post('/register', guestAccess, getUserStatus, async (req, res) => {
    const { username, password, repeatPassword } = req.body;

    if (!username || !password || !repeatPassword) {
        return res.render('user/register', {
            isLoggedIn: req.isLoggedIn,
            errors: ['All inputs are required'],
        })
    }

    if (password !== repeatPassword) {
        return res.render('user/register', {
            isLoggedIn: req.isLoggedIn,
            errors: ['Passwords do not match'],
        })
    }

    const response = await userRegister(username, password);

    if (response.error) {
        return res.render('user/register', {
            isLoggedIn: req.isLoggedIn,
            errors: response.errorsInfo
        })
    }

    res.cookie('aid', response)
    res.redirect('/');
})

router.get('/login', guestAccess, getUserStatus, (req, res) => {
    res.render('user/login', {
        isLoggedIn: req.isLoggedIn
    })
})

router.post('/login', guestAccess, getUserStatus, async (req, res) => {
    const { username, password } = req.body;

    if (!username || !password) {
        return res.render('user/login', {
            isLoggedIn: req.isLoggedIn,
            errors: ['All inputs are required']
        })
    }

    const response = await loginUser(username, password);

    if (response.error) {
        return res.render('user/login', {
            isLoggedIn: req.isLoggedIn,
            errors: response.messages
        })
    }

    res.cookie('aid', response)
    res.redirect('/');
})

router.get('/logout', getUserStatus, (req, res) => {
    res.clearCookie('aid');
    res.redirect('/');
})


module.exports = router;
