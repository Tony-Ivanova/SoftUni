const express = require('express');
const router = express.Router();
const { getUserStatus } = require('../middlewares/getUserStatus');


router.get('/createpublication', getUserStatus, (req, res) => {
    res.render('create', {
        title: 'Create Publication',
        isLoggedIn: req.isLoggedIn,
        username: req.username
    })
});

module.exports = router; 