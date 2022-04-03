const { generateToken } = require('../utilities/generateToken');

const signInUser = (userID, email) => {
    const token = generateToken({
        userID,
        email
    })

    return token;
}

module.exports = { signInUser }