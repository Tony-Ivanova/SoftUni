const Course = require('../models/course');
const User = require('../models/user');

const { getUserId } = require('../utilities/getUserId')
const { getUserCourseStatus } = require('../utilities/getUserCourseStatus')

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
        const errorsInfo = [];

        if (err.errors.title) {
            errorsInfo.push(err.errors.title.message)
        }

        if (err.errors.description) {
            errorsInfo.push(err.errors.description.message)
        }


        if (err.errors.imageUrl) {
            errorsInfo.push(err.errors.imageUrl.message)
        }

        return {
            error: true,
            errorsInfo
        }
    }

}

const getCourse = async (req) => {
    const courseId = req.params.id;

    const course = await Course.findById({ _id: courseId }).lean();

    if (!course) {
        return {
            error: true,
            messages: ['No such course']
        }
    }

    const userStatus = getUserCourseStatus(req, course);

    return { course, userStatus };

}

const getAllCourses = async (searchInput) => {
    let allCourses = await Course.find().sort({ createdAt: -1 }).lean();

    if (searchInput) {

        allCourses = allCourses.filter(x => x.title.toLowerCase().includes(searchInput))
    }

    allCourses = allCourses.map(x => ({ ...x, createdAt: x.createdAt.toUTCString() }));

    return allCourses;
}

const enrollUser = async (req) => {
    const courseId = req.params.id;
    const userId = getUserId(req);

    const user = await User.findById(userId);
    const course = await Course.findById(courseId);

    if (!user) {
        return {
            error: true,
            messages: ['No such user']
        }
    }

    if (!course) {
        return {
            error: true,
            messages: ['No such course']
        }
    }

    course.usersEnrolled.push(userId);
    user.enrolledCourse.push(courseId);

    await course.save();
    await user.save();


    return course;
}

const editCourse = async (req) => {
    const courseId = req.params.id;
    
    const { title, description, imageUrl, isPublic } = req.body;

    let public = !isPublic ? false : true;

    const course = await Course.findOneAndUpdate({ _id: courseId }, { title: title, description: description, imageUrl: imageUrl, isPublic: public });

    if (!course) {
        return {
            error: true,
            messages: ['No such course']
        }
    }

    return course;
}

const deleteCourse = async (req) => {
    const courseId = req.params.id;

    const course = await Course.findByIdAndDelete(courseId);

    if (!course) {
        return {
            error: true,
            messages: ['No such course']
        }
    }

    return course;
}

const getPopular = async (howMany) => {
    let popularCourses = await Course.find().lean().sort({ 'usersEntrolled': -1 }).limit(howMany);

    popularCourses = popularCourses.map(x => ({ ...x, createdAt: x.createdAt.toUTCString() }));
    return popularCourses;
}

module.exports = {
    createCourse,
    getAllCourses,
    getCourse,
    enrollUser,
    editCourse,
    deleteCourse,
    getPopular
}