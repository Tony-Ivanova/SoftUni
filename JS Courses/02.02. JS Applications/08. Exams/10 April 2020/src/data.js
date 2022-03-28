import { getUserData, getUserId, objectToArray, setUserData } from "./util.js";

const apiKey = 'AIzaSyBAls6G4meBTj0SmJ5ux6t9dQhBTzFdkRo';
const dbUrl = 'https://myblog-896d3-default-rtdb.firebaseio.com/';

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    POSTS: 'posts',
    POSTBYID: 'posts/',
}

function host(url) {

    let result = dbUrl + url + '.json';

    const auth = getUserData();

    if (auth !== null) {
        result += `?auth=${auth.idToken}`;
    }

    return result;
}

async function request(url, method, body) {
    let options = {
        method,
    };

    if (body) {
        Object.assign(options, {
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(body)
        });
    }

    let response = await fetch(url, options);

    let data = await response.json();

    // if (data && data.hasOwnProperty('error')) {
    //     const message = data.error.message;
    //     throw new Error(message);
    // }


    return data;
}

async function get(url) {
    return request(url, 'GET');
}

async function post(url, body) {
    return request(url, 'POST', body);
}

async function del(url) {
    return request(url, 'DELETE');
}

async function patch(url, body) {
    return request(url, 'PATCH', body);
}


export async function login(email, password) {
    let response = await post(endpoints.LOGIN + apiKey, {
        email,
        password,
        returnSecureToken: true,
    });

    setUserData(response);

    return response;
};

export async function register(email, password) {
    let response = await post(endpoints.REGISTER + apiKey, {
        email,
        password,
        returnSecureToken: true,
    });

    setUserData(response);

    return response;
};

export async function getAll() {
    const records = await get(host(endpoints.POSTS));

    return objectToArray(records);
}

export async function getById(id) {
    const record = await get(host(endpoints.POSTBYID + id));
    record._id = id;
    return record;
}

export async function createPost(blogPost) {  
    const data = Object.assign({ _ownerId: getUserId() }, blogPost);
    return post(host(endpoints.POSTS), data);
}

export async function editPost(id, blogPost) {
    return patch(host(endpoints.POSTBYID + id), blogPost);
}

export async function deleteById(id) {
    return del(host(endpoints.POSTBYID + id));
}