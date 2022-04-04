const jwt = require('jsonwebtoken')
const privateKey = process.env.PRIVATE_KEY;
const User = require('../models/user')

const getUserStatus =  (req, res, next) => {
    const token = req.cookies['aid']
    if (!token) {
        req.isLoggedIn = false
    }

    try {
        const result = jwt.verify(token, privateKey)
        const email = result.email;
        req.isLoggedIn = true
        req.userEmail = email
        
    } catch (e) {
        req.isLoggedIn = false
    }

    next()
}

module.exports = { getUserStatus }