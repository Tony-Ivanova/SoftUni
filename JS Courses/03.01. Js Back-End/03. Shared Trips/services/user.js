const User = require('../models/user');
const bcrypt = require('bcrypt');
const { generateToken } = require('../utilities/generateToken');



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
        return userObject;
    } catch (err) {
        return {
            error: true,
            message: 'User validation failed'
        }
    }
}

module.exports = {
    createUser
}