const { Router } = require('express');
const router = Router();

const homeController = require('./controllers/home');
const userController = require('./controllers/user');
const courseController = require('./controllers/course');

router.use('/', userController);
router.use('/', courseController);
router.use('/', homeController);


module.exports = router;