Problem 2 -- Hero of Eldevir
============================

Greetings Red Paladin, you are preparing for the grand battle of the
realm! You are given an input data from the console. The first line
represents all items in your inventory, separated by comma and
whitespace. You will receive lines of information which contain actions
about what happens to the items in your inventory, until command
\"Battle\" or if there are no items left in your inventory. Your task is
to print all items in the inventory.

You may receive the following actions:

-   Loot {item}

-   Disenchant {item}

-   Upgrade {firstItem}/{secondItem}

If you receive the **Loot action**, you should **add** the item to the
inventory, but only **if the item is not in the inventory**.

-   If the loot is successful print in the console -\> \"{item} has been
    added to the inventory.\"

If you receive the **Disenchant action**, you must **remove** the item
**if** it is part of the inventory.

-   After removing the item if there are no items in the inventory you
    should print only \"The inventory is empty.\" and stop the program.

-   If the item is disenchanted and there are items left in the invetory
    print in the console -\> \"{item} has been disenchanted.\"

If you receive the **Upgrade action**, you must upgrade the first item,
but only if the first item is part of the inventory.

-   If the upgrade is successful you should print in the console
    \"{item} has been upgraded to {firstItem} \~ {secondItem}.\"

Input / Constraints
-------------------

You will receive lines until command **\"Battle\"** or if there are **no
items in the inventory**.

-   In the **first line,** you will receive all the items in the
    inventory-- sequence of items, separated by comma and space.

-   Each next line will be **action** and **item name**.

Output
------

-   When you get command **\"Battle\"** you should print

    -   \"Red Paladin\'s inventory :\"

-   And print all items in the inventory in the following way.

    -   \"\--\> {itemName}\"

Constraints
-----------

-   The **actions will always be valid.**

-   The **items will be a string containing only letters from the
    alphabet**.

```{=html}
<!-- -->
```
-   Allowed working **time** / **memory**: **100ms** / **16MB**.

Examples
--------

+----------------------------------+----------------------------------+
| **Input**                        | **Output**                       |
+==================================+==================================+
| SwordOfDivine, InfinityEdge,     | Potion has been added to the     |
| Sheen                            | inventory.                       |
|                                  |                                  |
| Loot Potion                      | Sheen has been disenchanted.     |
|                                  |                                  |
| Disenchant Sheen                 | InfinityEdge has been upgraded   |
|                                  | to InfinityEdge \~ MightOfPower. |
| Upgrade                          |                                  |
| InfinityEdge/MightOfPower        | Red Paladin\'s inventory :       |
|                                  |                                  |
| Battle                           | \--\> SwordOfDivine              |
|                                  |                                  |
|                                  | \--\> InfinityEdge \~            |
|                                  | MightOfPower                     |
|                                  |                                  |
|                                  | \--\> Potion                     |
+----------------------------------+----------------------------------+
| ShadowMourne, KaelsDagger        | Bane has been added to the       |
|                                  | inventory.                       |
| Loot Bane                        |                                  |
|                                  | CrimsonHelemt has been added to  |
| Loot CrimsonHelemt               | the inventory.                   |
|                                  |                                  |
| Loot ShadowMourne                | Bane has been disenchanted.      |
|                                  |                                  |
| Disenchant Bane                  | Red Paladin\'s inventory :       |
|                                  |                                  |
| Battle                           | \--\> ShadowMourne               |
|                                  |                                  |
|                                  | \--\> KaelsDagger                |
|                                  |                                  |
|                                  | \--\> CrimsonHelemt              |
+----------------------------------+----------------------------------+
| FuriousPauldron,                 | Bersker has been added to the    |
| RelentlessGauntlet, Mace         | inventory.                       |
|                                  |                                  |
| Loot Bersker                     | FuriousPauldron has been         |
|                                  | upgraded to FuriousPauldron \~   |
| Upgrade                          | WrathFull.                       |
| FuriousPauldron/WrathFull        |                                  |
|                                  | Red Paladin\'s inventory :       |
| Battle                           |                                  |
|                                  | \--\> FuriousPauldron \~         |
|                                  | WrathFull                        |
|                                  |                                  |
|                                  | \--\> RelentlessGauntlet         |
|                                  |                                  |
|                                  | \--\> Mace                       |
|                                  |                                  |
|                                  | \--\> Bersker                    |
+----------------------------------+----------------------------------+
