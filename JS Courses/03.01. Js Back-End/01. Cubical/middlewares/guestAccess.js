const guestAccess = (req, res, next) => {
    const token = req.cookies['aid']
    if (token) {
        return res.redirect('/')
    }
    next()
}

module.exports = { guestAccess }