const privateKey = process.env.PRIVATE_KEY;

const jwt = require('jsonwebtoken');


const getUserId = (req) => {
    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, privateKey);

    const userId = decodedObject.userID;

    return userId;

}


module.exports = {getUserId}