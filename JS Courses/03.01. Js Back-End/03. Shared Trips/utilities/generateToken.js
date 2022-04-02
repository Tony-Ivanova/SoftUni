const jwt = require('jsonwebtoken');
const privateKey = process.env.PRIVATE_KEY;


const generateToken = (data) => {
    const token = jwt.sign(data, privateKey);

    return token;
}

module.exports = { generateToken }