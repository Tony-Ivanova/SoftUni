const express = require('express');
const router = express.Router();

const homeController = require('./controllers/home');
const userController = require('./controllers/user');
const productController = require('./controllers/publication');

router.use('/', productController);
router.use('/', userController)
router.use('/', homeController);


module.exports = router;
