const mongoose = require('mongoose');

const { courseMsg, courseRegex, courseValue } = require('../models/validation')

const courseSchema = mongoose.Schema({
    title: {
        type: String,
        required: true,
        minlength: [courseValue.titleMinLngth, courseMsg.titleMinLngth],
        unique: true
    },
    description: {
        type: String,
        required: true,
        maxlength: [courseValue.descriptionMaxLngth, courseMsg.descriptionMaxLngth],
        minlength: [courseValue.desciptionMinLngth, courseMsg.descirptionMinLngth],
    },
    imageUrl: {
        type: String,
        match: [courseRegex.imageUrlRegex, courseMsg.imageUrlRegexMsg],
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