Problem 1 - Space Travel
========================

You are entrusted with the task to travel the galaxy and find a planet
similar to Earth. For this task you are given a spaceship with quite a
lot of fuel in it. Because you will be far away from Earth, a group of
highly renowned scientists will be communicating with you **via
encrypted messages**. The messages you receive will consist **only of
digits**. You should **replace each two digit number** **with the ASCII
character that represents it**. When you are done you will be left with
a single sentence, which you **should print on the console**.

For example: 79668369828669 = OBSERVE , since 79 = **O**, 66 = **B**, 83
= **S**, 69 = **E**, 82 = **R**, 86 = **V**, 69 = **E**

Each time you take off to a new planet, you will receive a **message
with instructions on what to do on that planet**.

Your journey ends once you receive the message \"**GO HOME**\".

Input / Constraints
-------------------

Until the decrypted message says **\"GO HOME\"** each time you will
receive:

-   The **name of the planet** you are about to go next

-   The **encrypted message** with instructions

Output
------

**Each time you receive a message from Earth and decrypt it, you should
print it on the screen.**

When your decrypted message says \"**GO HOME**\", print on the screen:

-   \"Going home.\"

Constraints
-----------

-   The **message will always contain only numbers**

```{=html}
<!-- -->
```
-   Allowed working **time** / **memory**: **100ms** / **16MB**

Examples
--------

+------------------------+-------------+
| **Input**              | **Output**  |
+========================+=============+
| Saturn                 | EXAMINE AIR |
|                        |             |
| 6988657773786932657382 | SEARCH LIFE |
|                        |             |
| Mars                   | GO HOME     |
|                        |             |
| 8369658267723276737069 | Going home. |
|                        |             |
| Pluto                  |             |
|                        |             |
| 71793272797769         |             |
+------------------------+-------------+
| Venus                  | FIND WATER  |
|                        |             |
| 70737868328765846982   | SEARCH LIFE |
|                        |             |
| Proxima Centauri       | GO HOME     |
|                        |             |
| 8369658267723276737069 | Going home. |
|                        |             |
| Luyten                 |             |
|                        |             |
| 71793272797769         |             |
+------------------------+-------------+
