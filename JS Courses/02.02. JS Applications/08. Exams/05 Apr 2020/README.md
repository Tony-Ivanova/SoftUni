**JS Applications Exam -- the SoftWiki SPA**

You are assigned to implement a **Web application (SPA) using HTML5,
JavaScript, AJAX, REST and JSON with cloud-based backend (Firebase or
Kinvey)**. Using libraries like **jQuery**, **Handlebars** and **Sammy**
is allowed but is **not obligatory**. The app keeps **users** and
**articles**. **Users** should be able to **register** and **login**.
Logged-in users should be able to view **all articles**, **create**
**articles**, see **details about an article** and **logout**. Logged-in
users should also be able to **edit** or **delete** the articles **they
have created**. Create a Firebase REST Service

Register at **Firebase.com** and create application to keep your data in
the cloud.

Create a collection called **articles.** Each **article** has a
**title**, **category**, **content** and **creator**

![](media/image1.png){width="6.531944444444444in"
height="2.3520833333333333in"}

![](media/image2.png){width="6.531944444444444in"
height="3.0881944444444445in"}

Then go to the **rules** and **edit** them to look like this:

![](media/image3.png){width="6.531944444444444in"
height="2.1569444444444446in"}

Test the Firebase REST Services
-------------------------------

Using **Postman** or other HTTP client tool, test the REST service end
points:

### List All Articles

  --------------------------------------------
  **GET** https://{apiKey}.com/articles.json
  --------------------------------------------

### Create Article

+----------------------------------+----------------------------------+
| **POST**                         |                                  |
| https://{apiK                    |                                  |
| ey}.firebaseio.com/articles.json |                                  |
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
| **Response**                     | {Key}:{                          |
|                                  |                                  |
| **201 Created**                  | \"title\": \"Arrays\",           |
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

### Edit Article

+----------------------------------+----------------------------------+
| **PUT**                          |                                  |
| ht                               |                                  |
| tps://{apiKey}.com/articles/{id} |                                  |
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

### Delete Article

+----------------------------------+----------------------------------+
| **DELETE**                       |                                  |
| ht                               |                                  |
| tps://{apiKey}.com/articles/{id} |                                  |
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

**The SoftWiki -- HTML and CSS**

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

The SoftWiki- Client-Side Web Application
-----------------------------------------

**Design** and **implement** a client-side front-end app (SPA) for
managing **articles**. Implement the functionality described below.

### Navigation Bar (5 Pts)

Navigation links should correctly change the current page (view).

-   Clicking on the links in the **Header** should display the view
    behind the link (views are represented as sections in the HTML
    code).

-   Your application may **hide/show elements** by CSS (**display:
    none**) or **delete/reattach** from and to the DOM all unneeded
    elements, or just display the views it needs to display.

> ![](media/image4.png){width="6.531944444444444in"
> height="0.3548611111111111in"}The Logged-in user navbar should contain
> the following elements: [\[**SoftWiki\]** which is a link to the
> **Home Page, \[Create\] and \[Logout\]**]{.underline}

-   ![](media/image5.png){width="6.531944444444444in"
    height="0.33402777777777776in"}The guest users header should contain
    the following elements: [\[**SoftWiki\]** which is a **link** to the
    **Login page** and \[**Register**\].]{.underline}

### Register User (5 Pts)

By given **email** and **password,** the app should register a new user
in the system and should **[redirect you to the home
page.]{.underline}**

-   Keep the user local data in the browser\'s **local/session
    storage**.

Register once and create/read awesome articles!

![](media/image6.png){width="6.531944444444444in"
height="3.298611111111111in"}

### Login User / Guest Home Page(5 Pts)

By given **email** and **password,** the app should login an existing
user.

-   Keep the user local data in the browser\'s **local storage**.

-   After a successful login **[redirect to the home
    page]{.underline}**. You are one step away from awesome articles!

![](media/image7.png){width="6.165139982502187in"
height="2.5729166666666665in"}

### Logout (5 Pts)

Successfully logged in users should be able to **logout** from the app.

-   The **\"logout\" REST service** at the back-end **must** be called
    at logout

-   All local/session information in the browser (**user local data**)
    about the current user should be deleted

-   After a successful logout **[redirect to the login
    page]{.underline}**.

### Home Page (40 Pts)

Successfully logged-in users should be welcomed by the **Home page**.
They should be able to see all created articles.
![](media/image8.png){width="6.531944444444444in" height="3.0in"}

If there are **NO** such articles, the following view should be
displayed:

![](media/image9.png){width="6.531944444444444in"
height="1.7402777777777778in"}

### Create Article (10 Pts)

Logged-in users should be able to **Create** articles.

Clicking the **\[Create\] link in the NavBar** should **display** the
**Create Article** **page**.

-   **By** **default**, every newly created article must have additional
    information:

    -   **Creator:** the email of the current user;

```{=html}
<!-- -->
```
-   The newly organizer article should be stored in the Firebase\\Kinvey
    collection \"**articles**\".

-   After an article is created successfully you should be redirected to
    the **Home Page**.

![](media/image10.png){width="6.531944444444444in"
height="3.2819444444444446in"}

### Details (15 Pts)

Logged-in users should be able to **view details about** articles.

Clicking the **\[Details\] link in of a particular article** should
**display** the **Article** **Details** **page**.

-   If the currently logged-in user is the creator of the article, the
    \[**Edit**\] and \[**Delete**\] **buttons** should be set to
    **visible**, otherwise there should be only 1 button \[**Back**\]
    which redirects to the Home Page.

![](media/image11.png){width="6.531944444444444in"
height="2.1006944444444446in"}

![](media/image12.png){width="6.531944444444444in"
height="1.9423611111111112in"}

### Edit Article (10 Pts)

Logged-in users should be able to **edit** their **own** articles.

Clicking the **\[Edit\] link of a particular article on the Details**
**page** should **display** the **Edit** **page**:

-   ![](media/image13.png){width="6.531944444444444in"
    height="3.0680555555555555in"}After a **successful edit** the user
    should be redirected to the **Home** **page**.

### Delete Article (5 Pts)

Logged-in users should be able to **delete their** articles.

Clicking the **\[Delete\] link of an article** (on the **Details**
**page**) should **delete** the **article**.

-   After **successful** **article delete** you should show the **Home**
    **page**

### (BONUS) Sorting: (5 Pts)

The articles in the **home** **page** (for **registered** users), should
be sorted in **descending** order by **title.**

Submitting Your Solution
------------------------

Exclude the **node\_modules** folder and ZIP your project. Upload the
archive to Judge system.

![](media/image14.png){width="7.246527777777778in" height="3.23125in"}

![](media/image15.png){width="7.246527777777778in"
height="3.0597222222222222in"}

![](media/image16.png){width="7.246527777777778in"
height="2.5854166666666667in"}
