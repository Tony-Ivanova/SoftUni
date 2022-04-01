const bcrypt = require('bcrypt')
const User = require('../models/user')
const { generateToken } = require('../controllers/user')

const verifyUser = async (req, res) => {
    const {
        username,
        password
    } = req.body;

    try {
        const user = await User.findOne({ username }).lean();


        if (!user) {
            return {
                error: true,
                message: 'There is no such user'
            }
        }

        const status = await bcrypt.compare(password, user.password);

        if (status) {
            const token = generateToken({
                userID: user._id,
                username: user.username
            })

            res.cookie('aid', token)
        }

        return {
            error: !status,
            message: status || 'Wrong password'
        }
    } catch (err) {

        return {
            error: true,
            message: 'There is no such user',
        }
    }
}

module.exports = { verifyUser }