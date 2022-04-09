const userMsg = {
    usernameRegexMsg: 'The username should contain only english letters and digits',
    usernameMinLngth: 'Username should be at least 5 characters long',
}

const courseMsg = {
    titleMinLngth: 'The title should at least 4 characters long',
    descriptionMaxLngth: 'The description should be between 20 and 50 characters',
    descirptionMinLngth: 'The description should be between 20 and 50 characters',
    imageUrlRegexMsg: 'The image path should start with http or https',
}

const userRegex = {
    usernameRegex: /^[A-Za-z0-9]+$/,
}

const courseRegex = {
    imageUrlRegex: /^(http|https)/
}

const userValues = {
    username: 5,
    password: 5
}

const courseValue = {
    titleMinLngth: 4,
    descriptionMaxLngth: 50,
    desciptionMinLngth: 20
}


module.exports = { userMsg, courseMsg, userRegex, courseRegex, userValues, courseValue }