export function setUserData(data) {
    sessionStorage.setItem('auth', JSON.stringify(data));
}

export function removeUserData(){
    sessionStorage.removeItem('auth');
}

export function getUserData() {
    const auth = sessionStorage.getItem('auth');

    if (auth !== null) {
        return JSON.parse(auth);
    }

    return null;
}

export function getUserId() {
    const auth = sessionStorage.getItem('auth');

    if (auth !== null) {
        return JSON.parse(auth).localId;
    }

    return null;
}

export function objectToArray(data) {
    if (data == null) {
        return [];
    } else {
        return Object.entries(data).map(([k, v]) => Object.assign({ _id: k }, v));
    }
}

export async function addPartials(context) {
    const partials = await Promise.all([
        context.load('/templates/common/header.hbs'),
        context.load('/templates/common/footer.hbs'),
    ]);

    context.partials = {
        header: partials[0],
        footer: partials[1],
    };
}

export const categoryMap = {
    'JavaScript': 'js',
    'C#': 'csharp',
    'Java': 'java',
    'Python': 'python',
}

export function mapCategories(data) {
    const result = {
        js: [],
        csharp: [],
        java: [],
        python: []
    };

    for (let article of data) {
        result[categoryMap[article.category]].push(article);
    }

    return result;
}