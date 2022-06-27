const express = require('express');
const User = require('../models/user');
const bcrypt = require('bcrypt');
const { signInUser } = require('../middlewares/signInUser')


const createUser = async (username, password, address) => {

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
        return {
            error: true,
            messages: ['Registration unsuccessful']
        }
    }
}

const loginUser = async (username, password) => {

    try {
        const user = await User.findOne({ username }).lean();

        if (!user) {
            return {
                error: true,
                messages: ['No such user']
            }
        }

        const status = await bcrypt.compare(password, user.password);

        if (status) {
            const token = signInUser(user._id, user.username)
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


module.exports = { createUser, loginUser };