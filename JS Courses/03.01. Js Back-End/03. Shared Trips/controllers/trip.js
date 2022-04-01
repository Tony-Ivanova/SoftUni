const express = require('express');
const router = express.Router();

router.get('/shared-trips', (req, res) => {
    res.render('trip/shared-trips');
});

router.get('/offer-trip', (req, res) => {
    res.render('trip/trip-create');
});

router.get('/trip-details', (req, res) => {
    res.render('trip/trip-details');
})

router.get('/trip-edit', (req, res) => {
    res.render('trip/trip-edit');
})

module.exports = router;