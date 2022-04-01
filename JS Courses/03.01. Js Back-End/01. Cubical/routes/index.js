const { Router } = require('express');
const { getUserStatus } = require('../middlewares/getUserStatus');
const { getAllCubes } = require('../controllers/cube');

const router = Router()

router.get('/', getUserStatus, async (req, res) => {
    const cubes = await getAllCubes(req.query);

    res.render('index', {
        title: 'Cube Workshop',
        cubes,
        isLoggedIn: req.isLoggedIn
    })
})

router.get('/about', getUserStatus, (req, res) => {
    res.render('about', {
        title: 'About | Cube Workshop',
        isLoggedIn: req.isLoggedIn
    })
})


module.exports = router