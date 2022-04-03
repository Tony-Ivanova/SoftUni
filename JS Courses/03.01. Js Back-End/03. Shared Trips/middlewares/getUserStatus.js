const jwt = require('jsonwebtoken')
const privateKey = process.env.PRIVATE_KEY;

const getUserStatus = (req, res, next) => {
    const token = req.cookies['aid']
    if (!token) {
        req.isLoggedIn = false
    }

    try {
        jwt.verify(token, privateKey)
        req.isLoggedIn = true
    } catch (e) {
        req.isLoggedIn = false
    }

    next()
}

module.exports = { getUserStatus }