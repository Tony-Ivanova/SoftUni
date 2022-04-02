const {generateToken} = require('../utilities/generateToken');

const signInUser = (userID, email) => {
    console.log(userID)
    const token = generateToken({
        userID,
        email
    })

    return token;
}

module.exports = {signInUser}