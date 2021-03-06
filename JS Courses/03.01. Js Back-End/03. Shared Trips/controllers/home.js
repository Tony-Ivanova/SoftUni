const express = require('express');
const router = express.Router();
const { getUserStatus } = require('../middlewares/getUserStatus')

router.get('/', getUserStatus, (req, res) => {
    res.render('home', {
        isLoggedIn: req.isLoggedIn,
        userEmail: req.userEmail
    });
});

router.get('*', (req, res) => {
    res.render('404');
});

module.exports = router;