const Course = require('../models/course');
const { getUserId } = require('../utilities/getUserId')

const createCourse = async (req) => {
    const { title, description, imageUrl, isPublic } = req.body;
    const creatorId = getUserId(req);

    let public = !isPublic ? false : true;

    try {
        const course = new Course({
            title,
            description,
            imageUrl,
            isPublic: public,
            createdAt: new Date(),
            creator: creatorId
        })

        const response = await course.save();

        return response;
    }
    catch (err) {
        return {
            error: true,
            messages: ['Course creation unsuccessful']
        }
    }

}

const getAllCourses = async () => {
    let allCourses = await Course.find().lean();

    allCourses = allCourses.map(x => ({ ...x, createdAt: x.createdAt.toUTCString() }));

    return allCourses;
}

module.exports = {
    createCourse,
    getAllCourses
}