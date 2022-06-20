const mongoose = require('mongoose');

const userScheme = new mongoose.Schema({
    username: {
        type: String,
        unique: true,
        required: true,
    },
    password: {
        type: String,
        required: true,
    },
    address: {
        type: String,
        required: true,
    },
    myPublications: [{
        type: mongoose.Types.ObjectId,
        ref: 'Publication'
    }]
})

module.exports = mongoose.model('User', userScheme);