const tripValidationMsg = {
    startPoint: 'Starting point should be at least 4 characters long',
    endPoint: 'End point should be at least 4 characters long',
    carImage: 'Image not valid',
    carBrand: 'Car brand should be at least 4 characters long',
    seats: 'Seats should be between 0 and 4',
    price: 'Price should be between 1 and 50',
    description: 'Description should be at least 10 characters long',
}

const userValidationMsg = {
    email: 'Email not valid',
    gender: 'Gender is required',
}

const userRegex = {
    email: /^[a-z0-9.]+@[a-z0.9.]+$/
}

const tripRegex = {
    carImage: /^(http|https)/
}

const tripValues = {
    starPointLength: 4,
    endPointLength: 4,
    carBrandLength: 4,
    seatsMinNumber: 0,
    seatsMaxNumber: 4,
    priceMinNumber: 1,
    priceMaxNumber: 50,
    descriptionMinLength: 10
}

module.exports = { userRegex, tripRegex, tripValidationMsg, tripValues, userValidationMsg }