const Trip = require('../models/trip');
const privateKey = process.env.PRIVATE_KEY;

const jwt = require('jsonwebtoken');

const validateNotMissingInput = (req) => {
    const { startPoint, endPoint, date, time, carImage, carBrand, seats, price, description } = req.body;
    if (!startPoint ||
        !endPoint ||
        !date ||
        !time ||
        !carImage ||
        !carBrand ||
        !seats ||
        !price ||
        !description) {
        return false
    }

    return true
}

const prepareErrorMessages = (err) => {
    let allErrors = [];

    if (err.errors.startPoint) {
        allErrors.push(err.errors.startPoint.properties.message)
    }

    if (err.errors.startPoint) {
        allErrors.push(err.errors.endPoint.properties.message)
    }

    if (err.errors.carImage) {
        allErrors.push(err.errors.carImage.properties.message)
    }

    if (err.errors.carBrand) {
        allErrors.push(err.errors.carBrand.properties.message)
    }

    if (err.errors.seats) {
        allErrors.push(err.errors.seats.properties.message)
    }

    if (err.errors.price) {
        allErrors.push(err.errors.price.properties.message)
    }

    if (err.errors.description) {
        allErrors.push(err.errors.description.properties.message)
    }

    return allErrors;
}

const createTrip = async (req) => {
    const { startPoint, endPoint, date, time, carImage, carBrand, seats, price, description } = req.body;

    const noEmptyInputs = validateNotMissingInput(req);

    if (!noEmptyInputs) {
        return {
            error: true,
            messages: ['All fields are required']
        }
    }

    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, privateKey);

    const userId = decodedObject.userID;

    try {
        const tripObject = new Trip({
            startPoint,
            endPoint,
            date,
            time,
            carImage,
            carBrand,
            seats,
            price,
            description,
            creator: userId
        })

        const trip = await tripObject.save();
        console.log(trip)
        return trip;

    } catch (err) {
        const errorsInfo = prepareErrorMessages(err);    

        return {
            error: true,
            messages: errorsInfo
        }
    }
}

const getAllTrips = () => {
    const trips = Trip.find().lean();

    return trips;
}

const getTrip = async (id) => {
    const trip = await Trip.findById(id).populate('creator').populate('buddies').lean();

    return trip;
}

const editTrip = async (req, tripId) => {
    const noEmptyInputs = validateNotMissingInput(req);

    if (!noEmptyInputs) {
        return {
            error: true,
            messages: ['All fields are required']
        }
    }

    try {
        const filter = { _id: tripId };
        const opts = { runValidators: true }
        const newData = { 
            startPoint: startPoint, 
            endPoint: endPoint, 
            date: date, time: time, 
            carImage: carImage, 
            carBrand: carBrand, 
            seats: seats, 
            price: price, 
            description: description 
        }

        const trip = await Trip.findOneAndUpdate(filter, newData, opts);

        return trip;
    } catch (err) {
        const errorsInfo = prepareErrorMessages(err);    

        return {
            error: true,
            messages: errorsInfo
        }
    }
}

const deleteTrip = async (id) => {
    const trip = await Trip.findOneAndDelete({ _id: id }).lean();

    return trip;
}

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

const userJoinsTrip = async (req, trip) => {
    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, privateKey);

    const userId = decodedObject.userID;

    const tripFromDb = await Trip.findById(trip._id);
    tripFromDb.buddies.push(userId);
    tripFromDb.seats -= 1;

    await tripFromDb.save();

    req.hasJoinedTrip = true;
    const status = req.hasJoinedTrip;
    return status
}


module.exports = {
    createTrip,
    getAllTrips,
    getTrip,
    editTrip,
    deleteTrip,
    userTripStatus,
    userJoinsTrip
}