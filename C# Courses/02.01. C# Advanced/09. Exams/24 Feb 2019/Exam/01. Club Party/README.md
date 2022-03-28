#  Club Party

*A new club has opened in town and everyone wants to go partying. The
club has many halls and people may only go there with reservations.*

You will be given **n** – an integer specifying the **halls' maximum
capacity**. Then you will be given input line which will contain
**English alphabet letters** and **numbers**, separated by a **single
space**. The input for the line should be read **from the last inserted
to the first one**. The **letters** represent the **halls** and the
**numbers** – the **people in a single reservation**. Companies of
people should go in the halls. The **first entered** hall is the **first
which people are entering**. Every reservation takes **specific
capacity**, equal to its number.

When a hall **overflows** (it **cannot contain** a given number of
people due to lack of enough **free capacity)**, it passes the people to
the **next entered hall**. If there is **no open hall** and you receive
a reservation, you should **skip it**.

If a hall overflows you must **remove it**, and print it on the console,
along with all of the companies of people it **currently contains**.
After you’ve removed that hall, **the next one** becomes the **first in
the order** – people will **first be passed to it**.

### Input

  - The first line will be halls' maximum capacity.

  - The second line will contain letters and digits separated by a
    space.

### Output

  - For output, you must print a hall, every time it overflows, after
    removing it.

  - The format is the following: **{hall}** **-\> {reservation1},
    {reservation2}…**

  - Where **{hall}** is the letter that corresponds to that hall, and
    the **reservations** are the numbers.

### Constraints

  - The halls will only be English alphabet letters.

  - Each hall’s letter will always be unique.

  - The integer **n** will be in the range **\[0, 500\]**.

  - The reservations will always be valid integers in the range **\[0,
    500\]**.

### Examples 

<table>
<thead>
<tr class="header">
<th>Input</th>
<th>Output</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>60</p>
<p>1 20 b 20 20 a</p></td>
<td>a -&gt; 20, 20, 20</td>
</tr>
<tr class="even">
<td>Comment</td>
<td></td>
</tr>
<tr class="odd">
<td>“a” is the first entered hall. Then we receive the reservations 20 and 20 which are passed to “a”. Then we get the hall “b”. Then again, we receive a reservation 20. “a” still has enough capacity to hold the people so they enter there. Then we get the reservation 1. “a” has capacity 60/60 – it overflows, so we pass the person to the next hall. We find “b” and we pass the person to “b”. “a” is then removed and printed on the console. “b” becomes the first hall now.</td>
<td></td>
</tr>
</tbody>
</table>

<table>
<thead>
<tr class="header">
<th>Input</th>
<th>Output</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>50</p>
<p>15 a 40 30 20 c 15 10 b</p></td>
<td><p>b -&gt; 10, 15, 20</p>
<p>c -&gt; 30</p></td>
</tr>
</tbody>
</table>

<table>
<thead>
<tr class="header">
<th>Input</th>
<th>Output</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>40</p>
<p>20 20 20 20 20 20 D F 15 5 M 26 38</p></td>
<td><p>M -&gt; 5, 15, 20</p>
<p>F -&gt; 20, 20</p>
<p>D -&gt; 20, 20</p></td>
</tr>
</tbody>
</table>
