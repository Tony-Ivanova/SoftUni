require('dotenv').config()

const express = require('express');

const config = require('./config/index');
const routes = require('./routes');
const app = express();

require('./config/express')(app);
require('./config/mongoose')(app);

app.use(routes);

app.listen(process.env.PORT, () => console.log(`Server is running on port ${process.env.PORT}...`));