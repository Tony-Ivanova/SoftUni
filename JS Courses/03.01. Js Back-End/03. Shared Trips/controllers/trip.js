const express = require('express');
const router = express.Router();
const { getUserStatus } = require('../middlewares/getUserStatus')

const { createTrip, getAllTrips } = require('../services/trip');

router.get('/shared-trips', getUserStatus, async (req, res) => {

    const trips = await getAllTrips();

    console.log(trips);
    
    res.render('trip/shared-trips', {
        isLoggedIn: req.isLoggedIn,
        trips
    });
});

router.get('/offer-trip', getUserStatus, (req, res) => {
    res.render('trip/trip-create', {
        isLoggedIn: req.isLoggedIn
    });
});

router.post('/offer-trip', async (req, res) => {
    const tripData = req.body

    const response = await createTrip(tripData);

    if(response.error){
        console.log(response.message);
        return res.render('/offer-trip', {
            error: response.message
        })
    }

    res.redirect('/shared-trips');
});

router.get('/trip-details', (req, res) => {
    res.render('trip/trip-details');
})

router.get('/trip-edit', (req, res) => {
    res.render('trip/trip-edit');
})

module.exports = router;