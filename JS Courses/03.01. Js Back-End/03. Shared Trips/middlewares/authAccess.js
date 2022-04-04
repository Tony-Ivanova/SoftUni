const jwt = require('jsonwebtoken')
const privateKey = process.env.PRIVATE_KEY

const authAccess = (req, res, next) => {
    const token = req.cookies['aid']
    if (!token) {
        return res.redirect('/login')
    }

    try {
        jwt.verify(token, privateKey)
        next()
    } catch (e) {
        return res.redirect('/')
    }
}

module.exports = { authAccess }
