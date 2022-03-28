import { addPartials, getUserId } from "../util.js";
import { getAll, createPost, getById, editPost, deleteById } from "../data.js";

export async function homePage() {
    await addPartials(this);
    this.partials.createPage = await this.load('/templates/catalog/createPage.hbs');
    this.partials.blogPost = await this.load('/templates/catalog/blogPost.hbs');

    const data = await getAll();

    const context = {
        user: this.app.userData,
        posts: data,
    }

    context.user = this.app.userData;

    this.partial('/templates/catalog/homePage.hbs', context);
};

export async function postCreate(context) {
    const { title, category, content } = context.params;
    try {
        if (title.length == 0 || category.length == 0 || content.length == 0) {
            throw new Error('All fields are required!');
        } else {
            const result = await createPost({
                title,
                category,
                content
            });

            context.redirect('/home');
        }
    } catch (err) {
        alert(err.message);
    }
};

export async function detailsPage() {
    await addPartials(this);

    const blogPost = await getById(this.params.id);

    const context = {
        user: this.app.userData,
        blogPost,
    };

    this.partial('/templates/catalog/detailsPage.hbs', context);
}

export async function editPage() {
    await addPartials(this);
    this.partials.blogPost = await this.load('/templates/catalog/blogPost.hbs');
    const data =  await getAll();
    const blogPost = await getById(this.params.id);

    if (blogPost._ownerId !== getUserId()) {
        this.redirect('/home');
    } else {
        const context = {
            user: this.app.userData,
            blogPost,
            posts: data,
        };
        
        this.partial('/templates/catalog/editPage.hbs', context);
    }
}

export async function postEdit(context) {
    const { title, category, content } = context.params;

    try {
        if (title.length == 0 || category.length == 0 || content.length == 0) {
            throw new Error('All fields are required!');
        } else {
            const result = await editPost(context.params.id, {
                title,
                category,
                content
            });
            context.redirect('/home');
        }
    } catch (err) {
        alert(err.message);
    }
}

export async function deletePost() {
    try {
        const id = this.params.id;
        const result = await deleteById(id);
        this.redirect('/home');
    } catch (err) {
        alert(err.message);
    }
}