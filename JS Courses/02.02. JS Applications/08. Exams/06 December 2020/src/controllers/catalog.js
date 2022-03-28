import { getAll, createDestination, getById, editDestination, deleteById } from "../data.js";
import { addPartials, displayError, displaySuccess, getUserId } from "../util.js";


export async function homePage() {
    await addPartials(this);
    this.partials.trip = await this.load('/templates/catalog/trip.hbs');

    const data = await getAll();
    const context = {
        user: this.app.userData,
        trips: data,
    }

    this.partial('/templates/catalog/homePage.hbs', context);
};

export async function myDestinationsPage() {
    await addPartials(this);
    this.partials.myDestination = await this.load('/templates/catalog/myDestination.hbs');

    const data = await getAll();
    const userId = getUserId();

    const myData = data.filter(x => x._ownerId === userId);

    const context = {
        user: this.app.userData,
        trips: myData,
    }

    this.partial('/templates/catalog/detailsDashboard.hbs', context);
};

export async function createPage() {
    await addPartials(this);

    const context = {
        user: this.app.userData
    };

    this.partial('/templates/catalog/createPage.hbs', context);
}

export async function postCreate(context) {
    const { destination, city, duration, departureDate, imgUrl } = context.params;

    try {
        if (destination.length == 0 ||
            city.length == 0 ||
            duration.length == 0 ||
            departureDate.length == 0 ||
            imgUrl.length == 0) {
            displayError('All fields are required!');
        } else if (duration < 1 || duration > 100) {
            displayError('The duration must be between 1 and 100 days!');
        } else {
            const result = await createDestination({
                destination,
                city,
                duration,
                departureDate,
                imgUrl
            });
            displaySuccess('Destination added succesfully');
            context.redirect('/home');
        }
    } catch (err) {
        displayError(err.message);
    }

}

export async function detailsPage() {
    await addPartials(this);

    const trip = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        trip,
        canEdit: trip._ownerId == getUserId(),
    };

    this.partial('/templates/catalog/detailsPage.hbs', context);
}

export async function editPage() {
    await addPartials(this);

    const trip = await getById(this.params.id);

    if (trip._ownerId !== getUserId()) {
        this.redirect('/home');
    } else {
        const context = {
            user: this.app.userData,
            trip
        };

        this.partial('/templates/catalog/editPage.hbs', context);
    }
}

export async function postEdit(context) {
    const { destination, city, duration, departureDate, imgUrl } = context.params;

    try {
        if (destination.length == 0 ||
            city.length == 0 ||
            duration.length == 0 ||
            departureDate.length == 0 ||
            imgUrl.length == 0) {
            displayError('All fields are required!');
        } else if (duration < 1 || duration > 100) {
            displayError('The duration must be between 1 and 100 days!');
        } else {
            const result = await editDestination(context.params.id, {
                destination,
                city,
                duration,
                departureDate,
                imgUrl
            });
            displaySuccess('Successfully edited destination');
            context.redirect('/home');
        }
    } catch (err) {
        displayError(err.message);
    }
}

export async function deleteDestination() {
    const trip = await getById(this.params.id);

    try {
        if (trip._ownerId !== getUserId()) {
            this.redirect('home');
        } else {

            const id = this.params.id;
            const result = await deleteById(id);
            displaySuccess('Destination removes successfully');
            this.redirect('/home');
        }
    } catch (err) {
        displayError(err.message);
    }
}