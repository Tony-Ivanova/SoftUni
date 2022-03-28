# Tron Racers

*The new TRON tournament has started and you have to keep track of the
players on the field.*

You will be given an integer **n** for the size of the matrix. On the
next **n** lines, you will receive the rows of the matrix. The game
starts with two players (first player is marked with **"f"** and the
second player is marked with **"s"**) in random positions and **all of
the empty slots** will be filled with **"\*"**.

Each turn you will be given commands **respectively for each player’s
movement.** The **first command** is for the first player and the
**second** is for the second player. After a player moves, **he leaves a
trail** on the field. The symbol that marks the trail is the same as the
player's symbol. If a player **goes** **out** of the matrix, he comes in
from **the other side**. For example, if the player is on 0, 0 and the
next command is left, he goes to the last spot in the first row.

If a player steps on the other player's trail, he dies. When a player
dies in the field, you should write **"x"** in the position where he
died.

When **only one of the players** is left alive on the field the game
ends.

### Input

  - On the first line, you are given the integer N – the size of the
    square matrix.

  - The next N lines holds the values for every row.

  - On each of the next lines you will get two commands separated by
    space .

### Output

  - In the end print the matrix.

### Constraints

  - The size of the matrix will be between **\[2…20\].**

  - There will always be exactly two players.

  - The players will always be indicated with **"f"** for the first one
    and **"s"** for the second one.

  - There will always be enough commands to finish the game with one
    player alive.

  - There will not be commands where a player goes back and steps on his
    trail from the previous turn.

  - Commands will be in the format **up**, **down**, **left** or
    **right**.

### Examples

<table>
<thead>
<tr class="header">
<th><strong>Input</strong></th>
<th><strong>Output</strong></th>
<th><strong>Comments</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>5</p>
<p>***f*</p>
<p>**s**</p>
<p>*****</p>
<p>*****</p>
<p>*****</p>
<p>down down</p>
<p>right down</p>
<p>down right</p>
<p>down down</p>
<p>down left</p>
<p>left left</p></td>
<td><p>***f*</p>
<p>**sff</p>
<p>**s*f</p>
<p>**ssf</p>
<p>**sxf</p></td>
<td><p>The first command is <strong>down down</strong> so <strong>f</strong> moves down and <strong>s</strong> moves down. After each turn the field is:</p>
<p>1 2 3 4 5 6</p>
<p>***f* ***f* ***f* ***f* ***f* ***f*</p>
<p>**sf* **sff **sff **sff **sff **sff</p>
<p>**s** **s** **s*f **s*f **s*f **s*f</p>
<p>***** **s** **ss* **ssf **ssf **ssf</p>
<p>***** ***** ***** ***s* **ssf **sxf</p>
<p>On turn 6 <strong>f</strong> crashes into <strong>s</strong>'s trail and <strong>f</strong> dies. As there is only one player left alive <strong>s</strong> is the only one left he is the winner.</p></td>
</tr>
<tr class="even">
<td><p>4</p>
<p>*f**</p>
<p>****</p>
<p>**s*</p>
<p>****</p>
<p>down up</p>
<p>down right</p>
<p>right right</p></td>
<td><p>*f**</p>
<p>*fss</p>
<p>*fx*</p>
<p>****</p></td>
<td></td>
</tr>
</tbody>
</table>
