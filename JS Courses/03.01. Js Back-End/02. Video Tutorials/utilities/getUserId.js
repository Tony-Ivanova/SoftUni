const privateKey = process.env.PRIVATE_KEY;
const jwt = require('jsonwebtoken');

const getUserId = (req) => {
    const token = req.cookies['aid'];
    const result = jwt.verify(token, privateKey)
    const creatorId = result.userID;

    return creatorId;
}

module.exports = {
    getUserId
}
