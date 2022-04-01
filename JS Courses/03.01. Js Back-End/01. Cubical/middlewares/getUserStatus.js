const env = process.env.NODE_ENV || 'development'

const jwt = require('jsonwebtoken')
const config = require('../config/config')[env]

const getUserStatus = (req, res, next) => {
    const token = req.cookies['aid']
    if (!token) {
        req.isLoggedIn = false
    }

    try {
        jwt.verify(token, config.privateKey)
        req.isLoggedIn = true
    } catch (e) {
        req.isLoggedIn = false
    }

    next()
}

module.exports = { getUserStatus }