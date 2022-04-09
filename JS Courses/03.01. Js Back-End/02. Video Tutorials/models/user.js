const mongoose = require('mongoose');
const { userMsg, userRegex, userValues } = require('../models/validation')

const userSchema = mongoose.Schema({
    username: {
        type: String,
        required: true,
        match: [userRegex.usernameRegex, userMsg.usernameRegexMsg],
        minlength: [userValues.username, userMsg.usernameMinLngth],
        unique: true
    },
    password: {
        type: String,
        required: true,
    },
    enrolledCourse: [{
        type: mongoose.Types.ObjectId,
        ref: 'Course'
    }]
})

module.exports = mongoose.model('User', userSchema);