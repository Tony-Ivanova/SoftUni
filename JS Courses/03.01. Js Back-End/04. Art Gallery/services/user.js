const express = require('express');
const User = require('../models/user');
const bcrypt = require('bcrypt');
const { signInUser } = require('../middlewares/signInUser')


const createUser = async (username, password, address) => {

    console.log(username)
    const saltRounds = process.env.SALT_ROUNDS;
    const salt = await bcrypt.genSalt(parseInt(saltRounds));
    const hashedPassword = await bcrypt.hash(password, salt);

    try {
        const user = new User({
            username,
            password: hashedPassword,
            address
        });

        const userObject = await user.save();

        const token = signInUser(userObject._id, userObject.username)

        return token;
    } catch (err) {
        console.log(err);
    }

}


module.exports = { createUser };