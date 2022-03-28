function solve(httpRequest) {

    let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriReg = /^([A-Za-z0-9.]+)$|\*/g;
    let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let messageReg = /^[^<>\\&'"]*$/g;

    if (!httpRequest.hasOwnProperty('method') || !methods.includes(httpRequest.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!httpRequest.hasOwnProperty('uri') || !httpRequest.uri.match(uriReg)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!httpRequest.hasOwnProperty('version') || !versions.includes(httpRequest.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (!httpRequest.hasOwnProperty('message') || !httpRequest.message.match(messageReg)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return httpRequest;
}

solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
})

