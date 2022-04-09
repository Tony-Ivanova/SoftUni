const { getUserId } = require('../utilities/getUserId')


const getUserCourseStatus = (req, course) => {
    const currentUserId = getUserId(req);
    const courseCreatorId = course.creator._id.toString();
    const isCreator = courseCreatorId === currentUserId ? true : false;
    const isEntrolled = course.usersEnrolled.find(x => x._id == currentUserId) ? true : false;

    return {
        isCreator,
        isEntrolled
    }
}

module.exports = {
    getUserCourseStatus
}