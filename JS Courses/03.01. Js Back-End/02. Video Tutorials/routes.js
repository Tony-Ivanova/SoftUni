const { Router } = require('express');
const router = Router();

const homeController = require('./controllers/home');
const userController = require('./controllers/user');
const courseController = require('./controllers/course');

router.use('/', courseController);
router.use('/', userController);
router.use('/', homeController);


module.exports = router;