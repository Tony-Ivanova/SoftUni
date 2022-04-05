const express = require('express');
const router = express.Router();

router.get('/create', (req, res) => {
    res.render('courses/create-course')
})

router.get('/edit', (req, res) => {
    res.render('courses/edit-course')
})

router.get('/details', (req, res) => {
    res.render('courses/course-details')
})

module.exports = router;
