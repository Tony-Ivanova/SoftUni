function sortArrayFunction(array, sortType) {
    if (sortType === 'asc') {
        return array.sort((a, b) => {
            return a - b
        })
    } else {
        return array.sort((a, b) => {
            return b - a
        })
    }
}