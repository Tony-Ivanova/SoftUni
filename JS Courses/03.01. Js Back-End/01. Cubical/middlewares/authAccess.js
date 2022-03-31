const env = process.env.NODE_ENV || 'development'

const jwt = require('jsonwebtoken')
const config = require('../config/config')[env]
const bcrypt = require('bcrypt')
const User = require('../models/user')

const authAccess = (req, res, next) => {
    const token = req.cookies['aid']
    if (!token) {
        return res.redirect('/')
    }

    try {
        jwt.verify(token, config.privateKey)
        next()
    } catch (e) {
        return res.redirect('/')
    }
}

const authAccessJSON = (req, res, next) => {
    const token = req.cookies['aid']
    if (!token) {
        return res.json({
            error: "Not authenticated"
        })
    }

    try {
        jwt.verify(token, config.privateKey)
        next()
    } catch (e) {
        return res.json({
            error: "Not authenticated"
        })
    }
}

module.exports = { authAccess, authAccessJSON }