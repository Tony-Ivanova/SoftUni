const User = require('../models/user');
const Trip = require('../models/trip');
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
        const errorsInfo = [];

        if (err.errors.email) {
            errorsInfo.push(err.errors.email.properties.message)
        }

        if (err.errors.gender) {
            errorsInfo.push(err.errors.gender.properties.message)
        }

        return {
            error: true,
            errorsInfo
        }
    }
}

const loginUser = async (email, password) => {

    try {
        const user = await User.findOne({ email }).lean();

        if (!user) {
            return {
                error: true,
                messages: ['No such user']
            }
        }

        const status = await bcrypt.compare(password, user.password);
        if (status) {
            const token = signInUser(user._id, user.email)
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

const getUser = async (userEmail) => {
    const user = await User.findOne({ email: userEmail }).select({ gender: 1 });
    const gender = user.gender;

    const createdTrips = await Trip.find({ creator: user }).select({ _id: 1, startPoint: 1, endPoint: 1, date: 1, time: 1 }).lean();

    let isMale = false;

    if (gender == 'male') {
        isMale = true;
    }

    const profileInfo = { isMale, createdTrips };

    return profileInfo;
}

module.exports = {
    createUser,
    loginUser,
    getUser
}