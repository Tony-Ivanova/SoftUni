**JS Applications Exam -- MyBlog SPA**

You are assigned to implement a **Web application (SPA) using HTML5,
JavaScript, AJAX, REST and JSON with cloud-based backend (Firebase or
Kinvey)**. Using libraries like **jQuery**, **Handlebars** and **Sammy**
is allowed but is **not obligatory**. The app keeps **users** and
**posts**. **Users** should be able to **register** and **login**.
Logged-in users should be able to view **their posts**, **create**
**posts**, see **details about an post** and **logout**. Logged-in users
should also be able to **edit** or **delete** the articles **they have
created**. Create a Firebase REST Service

Register at **Firebase.com** and create application to keep your data in
the cloud.

Create a collection called **posts.** Each **post** has a **title**,
**category**, **content**.

![](media/image1.png){width="6.073611111111111in"
height="3.6256944444444446in"}

![](media/image2.png){width="6.771527777777778in"
height="3.5215277777777776in"}

Test the Firebase REST Services
-------------------------------

Using **Postman** or other HTTP client tool, test the REST service end
points:

### List All Posts

  -------------------------------------------------------------
  **GET** [https://{apiKey}.com/{uid}/posts.json]{.underline}
  -------------------------------------------------------------

### Create Post

+----------------------------------+----------------------------------+
| **POST**                         |                                  |
| [https://{apiKey}.firebaseio.c   |                                  |
| om/{uid}/posts.json]{.underline} |                                  |
+==================================+==================================+
| **Request body**                 | {                                |
|                                  |                                  |
|                                  | \"title\": \"Javascript\",       |
|                                  |                                  |
|                                  | \"category\": \"Programming\",   |
|                                  |                                  |
|                                  | \"content\": \"Lorem ipsum dolor |
|                                  | sit amet, consectetur\...\",     |
|                                  |                                  |
|                                  | }                                |
+----------------------------------+----------------------------------+
| **Response**                     | {Key}:{                          |
|                                  |                                  |
| **201 Created**                  | \"title\": \"Javascript\",       |
|                                  |                                  |
|                                  | \"category\": \"Programming\",   |
|                                  |                                  |
|                                  | \"content\": \"Lorem ipsum dolor |
|                                  | sit amet, consectetur\...\",     |
|                                  |                                  |
|                                  | }                                |
+----------------------------------+----------------------------------+
| **Error response**               | **{ \"error\":                   |
|                                  | \"InvalidCredentials\",          |
| **401 Unauthorized**             | \"description\": \"Invalid       |
|                                  | credentials. Please retry your   |
|                                  | request with correct             |
|                                  | credentials\", \"debug\": \"\"   |
|                                  | }**                              |
+----------------------------------+----------------------------------+

### Edit Post

+----------------------------------+----------------------------------+
| **PUT**                          |                                  |
| [https://{apiKey}.c              |                                  |
| om/{uid}/posts/{id}]{.underline} |                                  |
+==================================+==================================+
| **Request body**                 | {                                |
|                                  |                                  |
|                                  | \"title\": \"Arrays\",           |
|                                  |                                  |
|                                  | \"category\": \"JavaScript\",    |
|                                  |                                  |
|                                  | \"content\": \"Lorem ipsum dolor |
|                                  | sit amet, consectetur\...\",     |
|                                  |                                  |
|                                  | \"creator-email\":               |
|                                  | \"peter.georgiev\@email.com\"    |
|                                  |                                  |
|                                  | }                                |
+----------------------------------+----------------------------------+
| **Response**                     | {key}:{                          |
|                                  |                                  |
| **200 Ok**                       | \"title\": \"Arrays\",           |
|                                  |                                  |
|                                  | \"category\": \"JavaScript\",    |
|                                  |                                  |
|                                  | \"content\": \"Lorem ipsum dolor |
|                                  | sit amet, consectetur\...\",     |
|                                  |                                  |
|                                  | \"creator-email\":               |
|                                  | \"peter.georgiev\@email.com\"    |
|                                  |                                  |
|                                  | }                                |
+----------------------------------+----------------------------------+
| **Error response**               | **{ \"error\":                   |
|                                  | \"InvalidCredentials\",          |
| **401 Unauthorized**             | \"description\": \"Invalid       |
|                                  | credentials. Please retry your   |
|                                  | request with correct             |
|                                  | credentials\", \"debug\": \"\"   |
|                                  | }**                              |
+----------------------------------+----------------------------------+

### Delete Post

+----------------------------------+----------------------------------+
| **DELETE**                       |                                  |
| [https://{apiKey}.c              |                                  |
| om/{uid}/posts/{id}]{.underline} |                                  |
+==================================+==================================+
| **Error response**               | { \"error\": \"EntityNotFound\", |
|                                  | \"description\": \"This entity   |
| **404 Not Found**                | not found in the collection\",   |
|                                  | \"debug\": \"\" }                |
+----------------------------------+----------------------------------+
| **Error response**               | { \"error\":                     |
|                                  | \"InvalidCredentials\",          |
| **401 Unauthorized**             | \"description\": \"Invalid       |
|                                  | credentials. Please retry your   |
|                                  | request with correct             |
|                                  | credentials\", \"debug\": \"\" } |
+----------------------------------+----------------------------------+

**MyBlog -- HTML and CSS**

You have been given the web design of the application as **HTML** +
**CSS** files.

-   Initially all views and forms are shown by the HTML. Your
    application may **hide/show elements** by CSS (**display: none**) or
    **delete/reattach** from and to the DOM all unneeded elements, or
    just display the views it needs to display.

```{=html}
<!-- -->
```
-   You may render the views/forms/components with **JavaScript** or
    **Handlebars**.

**Important**: Don't change the elements' **class names** and **ids**.
Don't rename form fields/link names/ids. You are **allowed** to add
**data attributes** to any elements. You may modify **href attributes**
of links and add **action/method attributes** to **forms**, to allow the
use of a routing library.

MyBlog - Client-Side Web Application
------------------------------------

**Design** and **implement** a client-side front-end app (SPA) for
managing **articles**. Implement the functionality described below.

**Navigation Bar (5 Pts)**

Navigation links should correctly change the current page (view).

-   Clicking on the links in the **Header** should display the view
    behind the link (views are represented as sections in the HTML
    code).

-   Your application may **hide/show elements** by CSS (**display:
    none**) or **delete/reattach** from and to the DOM all unneeded
    elements, or just display the views it needs to display.

> The Logged-in user navbar should contain the following elements:
> **[\[Email\] and \[Logout\]]{.underline}**

![](media/image3.png){width="7.246527777777778in"
height="0.3597222222222222in"}

The guest users header should contain the following elements:
[\[**Home**\], \[**Login**\]]{.underline} [and
\[**Register**\].]{.underline}

> ![](media/image4.png){width="7.246527777777778in"
> height="0.35555555555555557in"}

**Register User (5 Pts)**

By given **email** and **password,** the app should register a new user
in the system and should **[redirect you to the login
page.]{.underline}**

-   Keep the user local data in the browser\'s **local/session
    storage**.

![](media/image5.png){width="7.246527777777778in" height="3.7in"}

**Login User (5 Pts)**

By given **email** and **password,** the app should login an existing
user.

-   Keep the user local data in the browser\'s **local storage**.

-   After a successful login **[redirect to the home
    page]{.underline}**.

![](media/image6.png){width="7.246527777777778in" height="3.7in"}

**Logout (5 Pts)**

Successfully logged in users should be able to **logout** from the app.

-   The **\"logout\" REST service** at the back-end **must** be called
    at logout

-   All local/session information in the browser (**user local data**)
    about the current user should be deleted

-   After a successful logout **[redirect to the home
    page]{.underline}**.

**Home Page (40 Pts)**

Guest users should be welcomed by the **Home page**. They should be able
to navigate to register or login.

![](media/image7.png){width="7.246527777777778in"
height="3.6951388888888888in"}

Successfully logged-in users should be welcomed by the **Home page**.
They should be able to create and see all their posts.

![](media/image8.png){width="7.246527777777778in" height="3.7in"}

![](media/image9.png){width="7.246527777777778in" height="3.7in"}

If there are no posts, posts section should be empty.

**Create Post (10 Pts)**

Logged-in users should be able to **Create posts**.

-   The newly added post should be stored in the Firebase\\Kinvey
    collection \"**posts**\".

-   After a post is created successfully you should be redirected to the
    **Home Page**.

![](media/image10.png){width="7.246527777777778in" height="3.7in"}

**Details (15 Pts)**

Logged-in users should be able to **view details about** their posts.

Clicking the **\[Details\] link in of a particular post** should
**display** the **Posts** **Details** **page**.

![](media/image11.png){width="7.246527777777778in" height="3.7in"}

**Edit Article (10 Pts)**

Logged-in users should be able to **edit** their **own** posts.

Clicking the **\[Edit\] button of a particular post on the Posts
section** should **display** the **Edit** **page**:

-   After a **successful edit** the user should be redirected to the
    **Home** **page**.

![](media/image12.png){width="7.246527777777778in"
height="3.6951388888888888in"}

**Delete Post (5 Pts)**

Logged-in users should be able to **delete their** articles.

Clicking the **\[Delete\] button of an particular post** should
**delete** the **post**.

-   After **successful** **post delete** you should redirect to the
    **Home** **page.**

**(BONUS) Notifications (5 Pts)**

The application should notify the users about the result of their
actions.

-   In case of a **successful** action, a **notification message**
    **(green)** should be shown, which disappears automatically after 5
    seconds.

![](media/image13.png){width="1.6979166666666667in"
height="0.6145833333333334in"}

-   In case of **error**, an **error notification message (red)** should
    be shown, which disappears automatically after 5 seconds.

![](media/image14.png){width="2.28125in" height="0.6041666666666666in"}

-   **[NOTE]{.underline}**: You get all the points if **all** the
    notifications have the **exact content** as described in each
    section above.

Submitting Your Solution
------------------------

Exclude the **node\_modules** folder and ZIP your project. Upload the
archive to Judge system.

![](media/image15.png){width="7.246527777777778in"
height="2.5854166666666667in"}![](media/image16.png){width="7.246527777777778in"
height="3.23125in"}

![](media/image17.png){width="7.246527777777778in"
height="3.0597222222222222in"}
