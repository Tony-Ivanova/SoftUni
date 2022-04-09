const express = require('express');
const router = express.Router();

const { getUserStatus } = require('../middlewares/getUserStatus')
const { createCourse, getCourse, deleteCourse, enrollUser, editCourse } = require('../services/course')

router.get('/create-course', getUserStatus, (req, res) => {
    res.render('courses/create-course', {
        isLoggedIn: req.isLoggedIn,
        username: req.username,
    })
})

router.post('/create-course', getUserStatus, async (req, res) => {
    const { title, description, imageUrl } = req.body;

    if (!title || !description || !imageUrl) {
        return res.render('courses/create-course', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            errors: ['All fields are required'],
        })
    }

    const response = await createCourse(req);

    if (response.errorsInfo) {
        return res.render('courses/create-course', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            errors: response.errorsInfo,
        })
    }

    res.redirect('/')
})

router.get('/edit/:id', getUserStatus, async (req, res) => {

    const response = await getCourse(req);

    if (response.error) {
        return res.render('courses/edit-course', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            errors: response.messages
        })
    }

    const course = response.course;
    course.checked = course.isPublic ? 'checked' : '';

    res.render('courses/edit-course', {
        isLoggedIn: req.isLoggedIn,
        username: req.username,
        ...course
    })
})

router.post('/edit/:id', getUserStatus, async (req, res) => {

    const response = await editCourse(req);

    if (response.error) {
        return res.render('courses/edit-course', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            errors: response.messages
        })
    }

    res.redirect('/');
})

router.get('/details/:id', getUserStatus, async (req, res) => {

    const response = await getCourse(req);

    if (response.error) {
        return res.render('courses/course-details', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            errors: response.messages
        })
    }

    const { course, userStatus } = response;

    res.render('courses/course-details', {
        isCreator: userStatus.isCreator,
        isEntrolled: userStatus.isEntrolled,
        isLoggedIn: req.isLoggedIn,
        username: req.username,
        ...course
    })
})

router.get('/enroll/:id', getUserStatus, async (req, res) => {

    const courseId = req.params.id;

    const response = await enrollUser(req);

    if (response.errorsInfo) {
        return res.render('courses/create-course', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            errors: response.messages,
        })
    }


    res.redirect(`/details/${courseId}`);
})

router.get('/delete/:id', getUserStatus, async (req, res) => {

    const response = await deleteCourse(req);

    if (response.error) {
        return res.render('courses/course-details', {
            isLoggedIn: req.isLoggedIn,
            username: req.username,
            errors: response.messages
        })
    }

    res.redirect('/')
})

module.exports = router;
