const express = require('express');
const router = express.Router();
const { getUserStatus } = require('../middlewares/getUserStatus')
const {getAllCourses} = require('../services/course');


router.get('/', getUserStatus, async (req, res) => {

    const allCourses = await getAllCourses();
    
    res.render('home', {
        isLoggedIn: req.isLoggedIn,
        username: req.username,
        courses: allCourses
    });
});

module.exports = router;
