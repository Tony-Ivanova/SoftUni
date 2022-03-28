import { errorHandler, loadPartialsToContext, getUserData, UserModel, dbContext, saveUserData, clearUserData } from '../util.js';


export async function createPage(context) {
    await loadPartialsToContext(context);

    this.partial('./templates/createOffer.hbs');
};

export function editPage(context) {
    const { offerId } = context.params;

    dbContext.collection('offers')
        .doc(offerId)
        .get()
        .then((res) => {
            context.offer = { id: offerId, ...res.data() };
            loadPartialsToContext(context)
                .then(function () {
                    this.partial('./templates/editOffer.hbs');
                });
        });
};

export function detailsPage(context) {
    const { offerId } = context.params;
    dbContext.collection('offers')
        .doc(offerId)
        .get()
        .then((response) => {
            const { uid } = getUserData();
            const actualOfferData = response.data();
            const imTheSalesman = actualOfferData.salesman === uid;
            const userIndex = actualOfferData.clients.indexOf(uid);
            console.log(userIndex);
            const imInTheClientsList = userIndex > -1;
            context.offer = { ...actualOfferData, imTheSalesman, id: offerId, imInTheClientsList };
            loadPartialsToContext(context)
                .then(function () {
                    this.partial('./templates/details.hbs');
                })
        })
};

export function deleteOffer(context) {
    const { offerId } = context.params;

    dbContext
        .collection('offers')
        .doc(offerId)
        .delete()
        .then(() => this.redirect('/home'))
        .catch((e) => console.log(e));
};

export function editPost(context) {
    const { offerId, productName, price, brand, imageUrl, description } = context.params;

    dbContext.collection('offers')
        .doc(offerId)
        .get()
        .then((response) => {

            return dbContext.collection('offers')
                .doc(offerId)
                .set({
                    ...response.data(),
                    productName,
                    price,
                    brand,
                    imageUrl,
                    description
                })

        })
        .then((resp) => {
            this.redirect(`#/details/${offerId}`);
        })
        .catch((e) => console.log(e));
};

export function buyPage(context) {
    const { offerId } = context.params;
    const { uid } = getUserData();

    dbContext.collection('offers')
        .doc(offerId)
        .get()
        .then((response) => {
            const offerData = { ...response.data() };
            offerData.clients.push(uid)

            return dbContext.collection('offers')
                .doc(offerId)
                .set(offerData)
        })
        .then(() => {
            this.redirect(`#/details/${offerId}`);
        })
        .catch((e) => console.log(e));
};

export function createPost(context) {
    const { productName, price, imageUrl, description, brand } = context.params;
    console.log(context.params);

    dbContext.collection("offers").add({
        productName,
        price,
        imageUrl,
        description,
        brand,
        salesman: getUserData().uid,
        clients: [],
    })
        .then((createdProduct) => {
            console.log(createdProduct);
            this.redirect('/home');
        })
        .catch((e) => console.log(e));
};