module.exports = {
    development: {
        port: process.env.PORT,
        saltRounds: process.env.SALT_ROUNDS,
        databaseUrl: process.env.DB_CONNECTION
    },
    production: {}
};