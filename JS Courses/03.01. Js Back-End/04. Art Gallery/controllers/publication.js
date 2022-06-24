const express = require('express');
const router = express.Router();

router.get('/createpublication', (req, res) => {
    res.render('create', {
        title: 'Create Publication',
    })
});

module.exports = router; 