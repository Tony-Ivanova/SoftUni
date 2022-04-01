const express = require('express');
const { saveUser } = require('../controllers/user');
const { verifyUser } = require('../middlewares/verifyUser');
const { getUserStatus } = require('../middlewares/getUserStatus');
const { guestAccess } = require('../middlewares/guestAccess');

const router = express.Router();

router.get('/login', guestAccess, getUserStatus, (req, res) => {

    res.render('user/loginPage', {
        isLoggedIn: req.isLoggedIn
    })
})

router.get('/signup', guestAccess, getUserStatus, (req, res) => {
    res.render('user/registerPage', {
        isLoggedIn: req.isLoggedIn
    })
})

router.post('/signup', async (req, res) => {
    const { password } = req.body;

    if (!password || password.length < 8 || !password.match(/^[A-Za-z0-9]+$/)) {
        return res.render('user/registerPage', {
            error: 'Username or password is not valid'
        })
    }

    const { error } = await saveUser(req, res);

    if (error) {
        return res.render('user/registerPage', {
            error: 'Username or password is not valid'
        })
    }

    res.redirect('/');
})

router.post('/login', async (req, res) => {
    const { error } = await verifyUser(req, res);

    if (error) {
        return res.render('user/loginPage', {
            error: 'Username or password are not correct'
        })
    }

    res.redirect('/')
})

router.get('/logout', (req, res) => {
    res.clearCookie('aid');

    res.redirect('/');
})

module.exports = router