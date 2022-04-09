const jwt = require('jsonwebtoken')
const privateKey = process.env.PRIVATE_KEY;

const getUserStatus = (req, res, next) => {
    const token = req.cookies['aid']
    if (!token) {
        req.isLoggedIn = false
    }

    try {
        const result = jwt.verify(token, privateKey)
        const username = result.username;
        req.isLoggedIn = true
        req.username = username

    } catch (e) {
        req.isLoggedIn = false
    }

    next()
}

module.exports = { getUserStatus }