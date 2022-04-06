const express = require('express');
const router = express.Router();
const { getUserStatus } = require('../middlewares/getUserStatus')
const { createCourse } = require('../services/course')

router.get('/create-course', (req, res) => {
    res.render('courses/create-course')
})

router.post('/create-course', getUserStatus, async (req, res) => {
    const { title, description, imageUrl } = req.body;
    
    if (!title || !description || !imageUrl) {
        return res.render('courses/create-course', {
            isLoggedIn: req.isLoggedIn,
            errors: ['All fields are required']
        })
    }

    const response = await createCourse(req);

    if(response.error){
        return res.render('courses/create-course', {
            isLoggedIn: req.isLoggedIn,
            errors: response.messages
        })
    }

    res.redirect('/')
})

router.get('/edit', (req, res) => {
    res.render('courses/edit-course')
})

router.get('/details', (req, res) => {
    res.render('courses/course-details')
})

module.exports = router;
