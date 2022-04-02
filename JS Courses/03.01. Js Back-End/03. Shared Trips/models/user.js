const mongoose = require('mongoose');

const userScheme = new mongoose.Schema({
    email: {
        type: String,
        required: true
    },
    password: {
        type: String,
        required: true,
    },
    gender: {
        type: String,
        required: true
    },
    tripHistory: [{
        type: mongoose.Types.ObjectId,
        ref: 'Trip'
    }]
})

module.exports = mongoose.model('User', userScheme);