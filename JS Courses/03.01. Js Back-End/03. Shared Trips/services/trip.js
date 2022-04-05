const Trip = require('../models/trip');

const { validateNotMissingInput, prepareErrorMessages } = require('../utilities/errorHandling');
const { userTripStatus } = require('../utilities/userTripStatus');
const { getUserId } = require('../utilities/getUserId');

const createTrip = async (req) => {
    const { startPoint, endPoint, date, time, carImage, carBrand, seats, price, description } = req.body;

    const noEmptyInputs = validateNotMissingInput(req);

    if (!noEmptyInputs) {
        return {
            error: true,
            messages: ['All fields are required']
        }
    }

    const userId = getUserId(req);

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
    const { startPoint, endPoint, date, time, carImage, carBrand, seats, price, description } = req.body;

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
            date: date,
            time: time,
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

const userJoinsTrip = async (req, trip) => {
   
    const userId = getUserId(req);

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