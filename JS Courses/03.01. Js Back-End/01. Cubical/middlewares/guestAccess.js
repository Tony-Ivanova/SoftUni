const env = process.env.NODE_ENV || 'development'

const jwt = require('jsonwebtoken')
const config = require('../config/config')[env]
const bcrypt = require('bcrypt')
const User = require('../models/user')

const guestAccess = (req, res, next) => {
    const token = req.cookies['aid']
    if (token) {
        return res.redirect('/')
    }
    next()
}

module.exports = { guestAccess }