Problem 4. DOTA 2 Tournament
============================

You have been tasked to make system to manage teams for Dota 2
Tournament.

You will receive three types of input lines in the following format:\
Adding a team: **New team** **-\>** **{teamName} -\> {playerName1},
{playerName2}\... {playerName5}**

Removing a team: **Disqualification -\> {teamName}**

Adding win to team: **Win -\> {teamName}**

The **teamName** and **playerNames** will be **strings**. The **wins**
will be an **integer**. Your task is to store every **team** and his
**players** or **remove team** and his **players**. Players will be
**exactly five**.

The **input sequence ends** when you **receive** the command
"**Tournament end**".\
Then you must print all teams, their players and wins. Each **team**
must be **ordered** by **wins** in **descending order**.

### Input

-   The input will come in the form of lines in the format specified
    above.

-   The input sequence ends when you receive the command "**Tournament
    end**".

### Output

-   **Teams**, their **players and wins** must be printed in the
    following format:

> "{teamName} - {player1, player2,...player5} -\> {wins}
>
> {teamName} - {player1, player2,...player5} -\> {wins}
>
> ..."

-   If you have received the **ending command**, and you are printing
    the **teams, players and wins**, the order is -- by **wins** in
    **descending order**.

### Constrains

-   The **teamName** and **player names** are strings.

-   Allowed time / memory: **100ms / 16 MB**.

### Examples

+----------------------------------+----------------------------------+
| **Input**                        | **Output**                       |
+==================================+==================================+
| **New team -\> ProPlayers -\>    | **Teams:**                       |
| Nikolay, Gosho, Pesho, Stamat,   |                                  |
| Mitko**                          | **Spartancite - Miro, Rosen,     |
|                                  | Stoyan, Nikolay, Gosho -\> 1     |
| **New team -\> Spartancite -\>   | wins**                           |
| Miro, Rosen, Stoyan, Nikolay,    |                                  |
| Gosho**                          | **ProPlayers - Nikolay, Gosho,   |
|                                  | Pesho, Stamat, Mitko -\> 0       |
| **Win -\> Spartancite**          | wins**                           |
|                                  |                                  |
| **Tournament end**               |                                  |
+----------------------------------+----------------------------------+
| **New team -\> ProPlayers -\>    | **Teams:**                       |
| Nikolay, Gosho, Pesho, Stamat,   |                                  |
| Mitko**                          | **Spartancite - Miro, Rosen,     |
|                                  | Stoyan, Nikolay, Gosho -\> 2     |
| **New team -\> Spartancite -\>   | wins**                           |
| Miro, Rosen, Stoyan, Nikolay,    |                                  |
| Gosho**                          | **Fnatic - Pesho, Parkash,       |
|                                  | Misho, Ivo, Pavel -\> 1 wins**   |
| **Win -\> Spartancite**          |                                  |
|                                  |                                  |
| **Win -\> Spartancite**          |                                  |
|                                  |                                  |
| **New team -\> Fnatic -\> Pesho, |                                  |
| Parkash, Misho, Ivo, Pavel**     |                                  |
|                                  |                                  |
| **Disqualification -\>           |                                  |
| ProPlayers**                     |                                  |
|                                  |                                  |
| **Win -\> Fnatic**               |                                  |
|                                  |                                  |
| **Tournament end**               |                                  |
+----------------------------------+----------------------------------+
