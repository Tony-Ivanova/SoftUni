const Cube = require('../models/cube');
const Accessory = require('../models/accessory');

const getAllCubes = async (searchData) => {


    let cubes = await Cube.find().lean();


    if (searchData.search) {
        cubes = cubes.filter(x => x.name.toLowerCase().includes(searchData.search));
    }

    if (searchData.from) {
        cubes = cubes.filter(x => Number(x.difficulty) >= searchData.from);
    }

    if (searchData.to) {
        cubes = cubes.filter(x => Number(x.difficulty) <= searchData.to);
    }

    return cubes;
}

const getCube = async (id) => {
    const cube = await Cube.findById(id).lean();

    return cube;
}


const deleteCube = async (id) => {
    const cube = await Cube.findByIdAndDelete(id).lean();
}

const updateCubeOnly = async (id, data) => {
    try {
        const cube = await Cube.findByIdAndUpdate(id, { ...data })

        return cube;
    } catch (err) {
        return err
    }
}

const updateCube = async (cubeId, accessoryId) => {
    try {
        await Cube.findByIdAndUpdate(cubeId, {
            $addToSet: {
                accessories: [accessoryId],
            },
        });
        await Accessory.findByIdAndUpdate(accessoryId, {
            $addToSet: {
                cubes: [cubeId],
            },
        })
    } catch (err) {
        return err
    }
}

const getCubeWithAccessories = async (id) => {
    const cube = await Cube.findById(id).populate('accessories').lean();

    return cube
}

module.exports = {
    getAllCubes,
    getCube,
    updateCube,
    getCubeWithAccessories,
    updateCubeOnly,
    deleteCube
}