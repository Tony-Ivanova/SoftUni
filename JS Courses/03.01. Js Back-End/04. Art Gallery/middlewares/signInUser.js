const { generateToken } = require('./generateToken');

const signInUser = (userID, username) => {
    const token = generateToken({
        userID,
        username
    })

    return token;
}

module.exports = { signInUser }