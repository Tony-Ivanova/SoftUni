const express = require('express');
const router = express.Router();

const { getUserStatus } = require('../middlewares/getUserStatus');
const { createUser, loginUser, getUser } = require('../services/user');
const { authAccess } = require('../middlewares/authAccess');
const { signInUser } = require('../utilities/signInUser');

router.get('/register', getUserStatus, (req, res) => {

    res.render('user/register', {
        isLoggedIn: req.isLoggedIn
    });
})

router.post('/register', async (req, res) => {
    const { email, password, repassword, gender } = req.body;

    if (password.length <= 4 || password !== repassword) {
        return res.render('user/register', {
            errors: ['Passwords are required or do not match']
        })
    }

    const response = await createUser(email, password, gender);

    if (response.error) {
        return res.render('user/register', {
            errors: response.errorsInfo
        })
    }

    res.cookie('aid', response)
    res.redirect('/');
})

router.get('/login', getUserStatus, (req, res) => {

    res.render('user/login', {
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/login', async (req, res) => {
    const { email, password } = req.body;

    const response = await loginUser(email, password);
    if (response.error) {
        return res.render('user/login', {
            errors: response.messages
        })
    }

    res.cookie('aid', response)
    res.redirect('/');
})

router.get('/profile', authAccess, getUserStatus, async (req, res) => {
    const profileInfo = await getUser(req);
    const profileTrips = profileInfo.createdTrips;

    res.render('user/profile', {
        isLoggedIn: req.isLoggedIn,
        userEmail: req.userEmail,
        isMale: profileInfo.isMale,
        tripCount: profileInfo.createdTrips.length,
        profileTrips
    });
});

router.get('/logout', authAccess, (req, res) => {
    res.clearCookie('aid');

    res.redirect('/');
})

module.exports = router;