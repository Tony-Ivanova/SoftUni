const express = require('express');
const router = express.Router();

const { getUserStatus } = require('../middlewares/getUserStatus')
const { getAllCourses, getPopular } = require('../services/course');


router.get('/', getUserStatus, async (req, res) => {

    if (!req.isLoggedIn) {
        const popularCourses = await getPopular(3);
        
        return res.render('home', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            courses: popularCourses,
            isEnrolled: req.isEnrolled
        });
    } else {
        const searchInput = req.query.search;
        const allCourses = await getAllCourses(searchInput);

        return res.render('home', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            courses: allCourses,
            isEnrolled: req.isEnrolled
        });
    }
});

module.exports = router;
