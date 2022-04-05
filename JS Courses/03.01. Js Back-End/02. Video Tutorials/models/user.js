const mongoose = require('mongoose');

const userSchema = mongoose.Schema({
    username: {
        type: String,
        required: true,
        unique: true
    },
    password: {
        type: String,
        required: true
    },
    enrolledCourse:[{
        type: mongoose.Types.ObjectId,
        ref: 'Course'
    }]
})

module.exports = mongoose.model('User', userSchema);