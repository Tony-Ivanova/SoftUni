function Spy(target, methodName) {
    let result = {
        count: 0
    };

    let originalMethod = target[methodName];

    target[methodName] = function () {
        result.count++;

        return originalMethod.apply(target, arguments);
    };

    return result;
}

let spy = Spy(Array.prototype, 'map');

[].map(x => x * 2);
[].map(x => x * 2);
[].map(x => x * 2);
[].map(x => x * 2);
[].map(x => x * 2);

console.log(spy);