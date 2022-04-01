const env = process.env.NODE_ENV || 'development'
const config = require('../config/config')[env]
const express = require('express');
const router = express.Router();
const jwt = require('jsonwebtoken');

const { getUserStatus } = require('../middlewares/getUserStatus');
const { authAccess } = require('../middlewares/authAccess');
const Cube = require('../models/cube');
const { getCubeWithAccessories, getCube, updateCubeOnly, deleteCube } = require('../controllers/cube');


router.get('/create', authAccess, getUserStatus, (req, res) => {
    res.render('cube/create', {
        title: 'Create Cube | Cube Workshop',
        isLoggedIn: req.isLoggedIn
    })
})

router.post('/create', authAccess, async (req, res) => {
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body;

    const token = req.cookies['aid'];
    const decodedObject = jwt.verify(token, config.privateKey);

    const cube = new Cube({
        name: name.trim(),
        description: description.trim(),
        imageUrl,
        difficulty: difficultyLevel,
        creatorId: decodedObject.userID
    });

    try {
        await cube.save();
        return res.redirect('/')
    } catch (err) {
        return res.render('cube/create', {
            title: 'Create Cube | Cube Workshop',
            isLoggedIn: req.isLoggedIn,
            error: 'Cube details are not valid'
        })
    }

})

router.get('/edit/:id', authAccess, getUserStatus, async(req, res) => {
    const cubeId = req.params.id;

    const cube = await getCube(cubeId);

    res.render('cube/editCubePage', {
        isLoggedIn: req.isLoggedIn,
        ...cube
    })
})

router.post('/edit/:id', authAccess, getUserStatus, async(req, res) => {
    const cubeId = req.params.id;

    const data = req.body;

    const cube = await updateCubeOnly(cubeId, data);

    res.redirect(`cube/details/${cubeId}`);
})

router.get('/delete/:id', authAccess, getUserStatus, async (req, res) => {
    const cubeId = req.params.id;

    const cube = await getCube(cubeId);
   
    res.render('cube/deleteCubePage', {
        isLoggedIn: req.isLoggedIn,
        ...cube
    })
})

router.post('/delete/:id', authAccess, getUserStatus, async (req, res) => {
    const cubeId = req.params.id;

    const cube = await deleteCube(cubeId);
   
    res.redirect('/');
})

router.get('/details/:id', getUserStatus, async (req, res) => {

    const cube = await getCubeWithAccessories(req.params.id);


    res.render('cube/details', {
        title: 'Details | Cube Workshop',
        ...cube,
        isLoggedIn: req.isLoggedIn
    })
})

module.exports = router