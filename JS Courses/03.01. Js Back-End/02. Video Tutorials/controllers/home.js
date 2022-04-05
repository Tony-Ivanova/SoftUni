const express = require('express');
const router = express.Router();
const { getUserStatus } = require('../middlewares/getUserStatus')

router.get('/', getUserStatus, (req, res) => {
    res.render('home', {
        isLoggedIn: req.isLoggedIn,
        username: req.username
    });
});

module.exports = router;
