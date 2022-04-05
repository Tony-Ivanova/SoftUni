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


module.exports = {
    validateNotMissingInput,
    prepareErrorMessages
}