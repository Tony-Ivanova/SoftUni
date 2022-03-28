Problem 3. Cinema
=================

You have been tasked to manage and keep list of cinemas and movies that
will be projected.

You will receive input lines in the following format:\
**{cinemaName} \<=\> {movieName} : {priceForMovie}**

The **cinemaName** and **movieName** will be **strings**. The
**priceForMovie** will be an **floating-point number**. Your task is to
store every **cinema** and the **movies** that will be projected.\
If you receive an existent **cinema**, you should **add** the **new**
**movie** to it. If **cinemaName** or **movieName** are invalid **DO
NOT** add them.

A single **cinema** may have **many movies** with the **same movieName**
and the **same price**.

The **input sequence ends** when you **receive** the command
"**Done**".\
Then you must print all cinemas and their movies. The cinema must be
printed by **alphabetic** **order**. Each **cinema's movies** must be
**ordered** by **price** in **descending order**.

### Input

-   The input will come in the form of lines in the format specified
    above.

-   The input sequence ends when you receive the command "**Done**".

### Output

-   **Cinema** and their **movies** must be printed in the following
    format:

> "{cinamaName}\
> {movieName2} : {priceForMovie1}\
> {movieName2} : {priceForMovie2}
>
> ..."

-   If you have received the **ending command**, and you are printing
    the **cinemas and movies with their price**, the order is -- by
    **price** in **descending order**.

-   If **cinemaName** is invalid print "**Invalid cinema name**";

-   If **movieName** is invalid print "**Invalid movie name**";

### Constrains

-   The **movieName** and **cinemaName** are strings which may contain
    any ASCII character\
    (except '**-**', '**\>**').

-   The **movieName** and **cinemaName** are **less 20 symbols**.

-   The **price** will be **floating-point number**.

-   Allowed time / memory: **100ms / 16 MB**.

### Examples

+--------------------------------------+------------------------------+
| **Input**                            | **Output**                   |
+======================================+==============================+
| **Cinema City \<=\> Fantastic Beasts | **- Arene**                  |
| : 12.50**                            |                              |
|                                      | **Harry Potter : 20.60**     |
| **Arene \<=\> Harry Potter : 20.60** |                              |
|                                      | **- Cinema City**            |
| **Cinema City \<=\> Fantastic Beasts |                              |
| : 10.50**                            | **Fantastic Beasts : 12.50** |
|                                      |                              |
| **Done**                             | **Fantastic Beasts : 10.50** |
+--------------------------------------+------------------------------+
| **Arena \<=\> Black Pantern :        | **Invalid cinema name**      |
| 15.70**                              |                              |
|                                      | **- Arena**                  |
| **Saffron Screen \<=\> Iron Man :    |                              |
| 12.30**                              | **Black Pantern : 15.70**    |
|                                      |                              |
| **Cinema in United Kingdoms \<=\>    | **- Saffron Screen**         |
| Venom : 45.70**                      |                              |
|                                      | **Iron Man : 12.30**         |
| **Done**                             |                              |
+--------------------------------------+------------------------------+
