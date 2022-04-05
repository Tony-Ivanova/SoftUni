const userTripStatus = async (req, trip) => {

    const currentUser = req.userEmail;
    const tripCreator = trip.creator.email;
    const tripBuddies = trip.buddies;
    const includedInTripBuddies = tripBuddies.find(x => x.email === currentUser);
    const seatsAvailable = trip.seats;

    if (tripCreator === currentUser) {
        req.isCreator = true;
    } else {
        req.isCreator = false;
    }

    if (!includedInTripBuddies) {
        req.hasJoinedTrip = false;
    } else {
        req.hasJoinedTrip = true;
    }

    if (seatsAvailable >= 1) {
        req.hasSeats = true;
    } else {
        req.hasSeats = false;
    }


    const isCreator = req.isCreator;
    const hasJoinedTrip = req.hasJoinedTrip;
    const hasSeats = req.hasSeats;

    const status = { isCreator, hasJoinedTrip, hasSeats };

    return status;
}

module.exports = { userTripStatus }