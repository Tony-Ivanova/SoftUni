import { errorHandler, loadPartialsToContext, dbContext } from '../util.js';

export async function homePage(context) {
    let offers;

    try {
        const response = await dbContext.collection('offers').get();
        offers = response.docs.map((offer => ({ id: offer.id, ...offer.data() })));
    } catch (err) {
        errorHandler(err);
    }

    const data = Object.assign({offers}, this.app.userData);

    await loadPartialsToContext(context);
    this.partial('./templates/home.hbs', data);
};