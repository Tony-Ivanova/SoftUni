const mongoose = require('mongoose');

const courseSchema = mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true
    },
    description: {
        type: String,
        required: true,
        maxlength: 50
    },
    imageUrl: {
        type: String,
        required: true,
    },
    isPublic: {
        type: Boolean,
        default: false,
    },
    createdAt: {
        type: Date,
        required: true,
    },
    creator: {
        type: mongoose.Types.ObjectId,
        ref: 'User'
    },
    usersEnrolled: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }]
})

module.exports = mongoose.model('Course', courseSchema);