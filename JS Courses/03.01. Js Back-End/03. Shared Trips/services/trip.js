const Trip = require('../models/trip');

const createTrip = async (data) => {
    const { startPoint, endPoint, date, time, carImage, carBrand, seats, price, description } = { ...data };

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
            description
        })

        const trip = await tripObject.save();
        return trip;

    } catch (err) {
        return {
            error: true,
            message: 'Trip details are not valid'
        }
    }
}

const getAllTrips = () => {
    const trips = Trip.find().lean();

    return trips;
}
module.exports = {
    createTrip,
    getAllTrips
}