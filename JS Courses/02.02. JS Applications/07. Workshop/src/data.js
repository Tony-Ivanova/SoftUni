const apiKey = 'AIzaSyDxp4DtoQ-J3NDqqTWxSZNAMKSWlZDD8Us';
const dbUrl = 'https://movies-b5a2a.firebaseio.com/';

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    OFFERS: 'offers',
}

function host(url){

    let result = dbUrl + url + '.json';

    const auth = localStorage.getItem('auth');

    if(auth !== null){
        result += `?auth=${JSON.parse(auth).idToken}`;
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


async function login(email, password) {
    let response = await post(endpoints.LOGIN + apiKey, {
        email,
        password,
    });

    let data = await response.json();

    localStorage.setItem('auth', JSON.stringify(data));

    return data;
};

async function register(email, password) {
    let response = await post(endpoints.REGISTER + apiKey, {
        email,
        password,
    });

    let data = await response.json();

    return data;
};

window.login = login;
window.register = register;

async function getOffers(){
    return get(dbUrl + endpoints.OFFERS);
}


async function createOffer(offer){
    const mock = {
        productName: 'Shiny Shoes',
        price: 150,
        imageUrl: '',
        description: 'Shiny Shoes are Shiny',
        brand: 'The Shining',
        salesman: 'Who cares',
        clients: [],
    };
    
    return post(host(endpoints.OFFERS), mock);
}

window.getOffers = getOffers;
window.createOffer = createOffer;