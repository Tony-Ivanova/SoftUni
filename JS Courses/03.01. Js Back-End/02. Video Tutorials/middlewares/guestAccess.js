const jwt = require('jsonwebtoken')
const privateKey = process.env.PRIVATE_KEY

const guestAccess = (req, res, next) =>{
    const token = req.cookies['aid']
    if(token){
        return res.redirect('/');
    }

    next()
}

module.exports = { guestAccess }