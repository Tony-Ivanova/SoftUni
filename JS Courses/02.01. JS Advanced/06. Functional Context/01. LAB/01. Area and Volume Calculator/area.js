function solve(area, vol, stringArray) {

    let objects = JSON.parse(stringArray);

    function calc(object) {
        let areaOfObject = Math.abs(area.call(object));
        let volumeObject = Math.abs(vol.call(object));

        return { area: areaOfObject, volume: volumeObject };
    }

    return objects.map(calc);
}

function area() {
    return this.x * this.y;
};

function vol() {
    return this.x * this.y * this.z;
};

solve(area, vol, '[{"x":"10","y":"-22","z":"10"}, {"x":"47","y":"7","z":"-5"}, {"x":"55","y":"8","z":"0"}, {"x":"100","y":"100","z":"100"}, {"x":"55","y":"80","z":"250"}]');