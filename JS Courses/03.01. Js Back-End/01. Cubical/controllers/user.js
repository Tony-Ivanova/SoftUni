const env = process.env.NODE_ENV || 'development'

const jwt = require('jsonwebtoken')
const config = require('../config/config')[env]
const bcrypt = require('bcrypt')
const User = require('../models/user')

const generateToken = (data) => {
    const token = jwt.sign(data, config.privateKey);

    return token;
}

const saveUser = async (req, res) => {
    const {
        username,
        password
    } = req.body;

    const salt = await bcrypt.genSalt(10);
    const hashedPassword = await bcrypt.hash(password, salt);

    try {
        const user = new User({
            username,
            password: hashedPassword
        })

        const userObject = await user.save()

        const token = generateToken({
            userID: userObject._id,
            username: userObject.username
        })

        res.cookie('aid', token)

        return token
    } catch (err) {

        return {
            error: true,
            message: err
        }
    }
} 
  
  module.exports = {
    saveUser
  }