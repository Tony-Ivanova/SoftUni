const mongoose = require('mongoose');
const {tripRegex, tripValidationMsg, tripValues} = require('../models/validationMsg')


const tripSchema = new mongoose.Schema({
    startPoint: {
        type: String,
        minLength: [tripValues.starPointLength, tripValidationMsg.startPoint],
        required: true
    },
    endPoint: {
        type: String,
        minLength: [tripValues.endPointLength, tripValidationMsg.endPoint],
        required: true,
    },
    date: {
        type: String,
        required: true
    },
    time: {
        type: String,
        required: true
    },
    carImage:{
        type: String,
        match: [tripRegex.carImage, tripValidationMsg.carImage],
        required: true
    },
    carBrand:{
        type: String,
        minLength: [tripValues.carBrandLength, tripValidationMsg.carBrand],
        required: true
    },
    seats:{
        type: Number,
        min: [tripValues.seatsMinNumber, tripValidationMsg.seats],
        max: [tripValues.seatsMaxNumber, tripValidationMsg.seats],
        required: true
    },
    price:{
        type: Number,
        min: [tripValues.priceMinNumber, tripValidationMsg.price],
        max: [tripValues.priceMaxNumber, tripValidationMsg.price],
        required: true
    },
    description:{
        type: String,
        minLength: [tripValues.descriptionMinLength, tripValidationMsg.description],
        required: true
    },
    creator:{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    },
    buddies: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }]
})

module.exports = mongoose.model('Trip', tripSchema);