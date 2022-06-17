const { Router } = require('express');
const router = Router();

const homeController = require('./controllers/home');

router.use('/', homeController);


module.exports = router;