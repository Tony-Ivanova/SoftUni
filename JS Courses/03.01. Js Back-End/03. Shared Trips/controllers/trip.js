const express = require('express');
const router = express.Router();
const { getUserStatus } = require('../middlewares/getUserStatus')

const { userJoinsTrip, userTripStatus, createTrip, getAllTrips, getTrip, editTrip, deleteTrip } = require('../services/trip');
const { authAccess } = require('../middlewares/authAccess');


router.get('/shared-trips', getUserStatus, async (req, res) => {

    const trips = await getAllTrips();

    res.render('trip/shared-trips', {
        isLoggedIn: req.isLoggedIn,
        userEmail: req.userEmail,
        trips
    });
});

router.get('/offer-trip', authAccess, getUserStatus, (req, res) => {
    res.render('trip/trip-create', {
        isLoggedIn: req.isLoggedIn,
        userEmail: req.userEmail
    });
});

router.post('/offer-trip', authAccess, getUserStatus, async (req, res) => {

    const response = await createTrip(req);

    if (response.error) {
        return res.render('trip/trip-create', {
            errors: response.messages,
            isLoggedIn: req.isLoggedIn,
            userEmail: req.userEmail
        })
    }

    res.redirect('/shared-trips');
});

router.get('/trip-details/:id', getUserStatus, async (req, res) => {
    const tripId = req.params.id;

    const trip = await getTrip(tripId);

    const userTripStat = await userTripStatus(req, trip);

    res.render('trip/trip-details', {
        isLoggedIn: req.isLoggedIn,
        userEmail: req.userEmail,
        isCreator: userTripStat.isCreator,
        joinTrip: userTripStat.hasJoinedTrip,
        hasSeats: userTripStat.hasSeats,
        ...trip
    });
})

router.get('/trip-edit/:id', authAccess, getUserStatus, async (req, res) => {
    const tripId = req.params.id;

    const trip = await getTrip(tripId);

    res.render('trip/trip-edit', {
        isLoggedIn: req.isLoggedIn,
        userEmail: req.userEmail,
        ...trip
    });
})

router.post('/trip-edit/:id', authAccess, getUserStatus, async (req, res) => {
    const tripId = req.params.id;
    const response = await editTrip(req, tripId);

    if (response.error) {
        return res.render(`trip/trip-edit`, {
            errors: response.messages,
            isLoggedIn: req.isLoggedIn,
            userEmail: req.userEmail
        })
    }

    res.redirect(`/trip-details/${tripId}`)
})

router.get('/trip-delete/:id', authAccess, async (req, res) => {
    const tripId = req.params.id;

    const trip = await deleteTrip(tripId);

    res.redirect('/shared-trips');
})

router.get('/trip-join/:id', authAccess, getUserStatus, async (req, res) => {
    const tripId = req.params.id;

    const trip = await getTrip(tripId);

    const joinTrip = await userJoinsTrip(req, trip);

    res.redirect(`/trip-details/${tripId}`);
})

module.exports = router;