const { Router } = require('express');
const router = Router();

const homeController = require('./controllers/home');
const userController = require('./controllers/user');
const tripController = require('./controllers/trip');


router.use('/', userController);
router.use('/', tripController);
router.use('/', homeController);


module.exports = router;