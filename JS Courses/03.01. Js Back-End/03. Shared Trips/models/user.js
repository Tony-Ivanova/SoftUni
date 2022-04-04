const mongoose = require('mongoose');
const {userRegex, userValidationMsg} = require('../models/validationMsg')


const userScheme = new mongoose.Schema({
    email: {
        type: String,
        match: [userRegex.email, userValidationMsg.email],
        unique: true,
        required: true
    },
    password: {
        type: String,
        required: true
    },
    gender: {
        type: String,
        required: [true, userValidationMsg.gender]
    },
    tripHistory: [{
        type: mongoose.Types.ObjectId,
        ref: 'Trip'
    }]
})

// userScheme.path('email').validate(function (email) {
//     return /^[a-z0-9.]+@[a-z0.9.]+$/.test(email)
// }, "Please enter a valid E-mail!")


module.exports = mongoose.model('User', userScheme);