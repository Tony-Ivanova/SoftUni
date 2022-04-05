const User = require('../models/user');
const bcrypt = require('bcrypt');
const { signInUser } = require('../utilities/signInUser')


const userRegister = async (username, password) => {
    const saltRounds = process.env.SALT;
    const salt = await bcrypt.genSalt(saltRounds);
    const hashedPassword = await bcrypt.hash(password, salt);

    try {
        const user = new User({
            username,
            password: hashedPassword,
        });

        const userObject = await user.save();

        const token = signInUser(userObject._id, userObject.username)

        return token;
    } catch (err) {
        const errorsInfo = [];

        if (err.code === 11000) {
            errorsInfo.push('User already exists')
        }

        return {
            error: true,
            errorsInfo
        }
    }
}

const loginUser = async (username, password) => {
    try {
        const user = await User.findOne({ username: username }).lean();

        if (!user) {
            return {
                error: true,
                messages: ['No such user']
            }
        }

        const status = await bcrypt.compare(password, user.password);

        if (status) {
            const token = signInUser(user._id, user.username)
            return token;
        } else {
            return {
                error: true,
                messages: ['Wrong username or password']
            }
        }
    } catch (err) {
        return {
            error: true,
            messages: ['Login unsuccessful']
        }
    }
}

module.exports = { userRegister, loginUser }