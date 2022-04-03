const User = require('../models/user');
const bcrypt = require('bcrypt');
const { signInUser } = require('../utilities/signInUser')


const createUser = async (email, password, gender) => {
    const saltRounds = process.env.SALT;

    const salt = await bcrypt.genSalt(saltRounds);
    const hashedPassword = await bcrypt.hash(password, salt);

    try {
        const user = new User({
            email,
            password: hashedPassword,
            gender
        });

        const userObject = await user.save();

        const token = signInUser(userObject._id, userObject.email)

        return token;
    } catch (err) {
        return {
            error: true,
            message: 'User validation failed'
        }
    }
}

const loginUser = async (email, password) => {

    try {
        const user = await User.findOne({ email }).lean();

        if (!user) {
            return {
                error: true,
                message: 'Username or password not correct'
            }
        }

        const status = await bcrypt.compare(password, user.password);

        if (status) {
            const token = signInUser(user._id, user.email)
            return token;
        }
    } catch (err) {
        return {
            error: true,
            message: 'User validation failed'
        }
    }
}

module.exports = {
    createUser,
    loginUser
}