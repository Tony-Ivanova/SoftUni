# The Kitchen

*Mary has the urgent need to rearrange her cutlery sets, because her
mother is coming to her house to visit. She needs to go through all of
her forks and knives one by one and decide how to arrange them in sets.
Your job is to help her get the job done.*

First you will be given **a sequence of integers representing the
knives**. Afterwards you will be given another **sequence of integers
representing the forks**.

Check all of the knives and forks in order to make sets. Take **the last
given knife**, and the **first given fork** and check **if the knife is
bigger than the fork** and if it is – you have to **create a set. A set
is created when you add the value of the fork to the value of the
knife**. If you have a set, **remove both** the fork and the knife from
their collections.

**If the fork’s value is bigger** – **remove the knife and check the
next one**.

If their values **are equal** – **remove the fork** and **increment**
the value of the knife with **1**

Mary wants to give her mother **the biggest set**, so you have to find
out which one it is and print it in the following format: "**The biggest
set is: {maxSet}**"

Afterwards **print the created sets** from **the first added to the
last,** separated by a space.

### Input

  - On the **first line** of input you will receive the integers,
    representing the knives, **separated** by a **single space**.

  - On the **second line** of input you will receive the integers,
    representing the **forks**, **separated** by a **single space**.

### Output

  - On the first line of output - print the biggest set in the format
    specified above.

  - On the second line - print the sets, separated by a single space
    **in the order specified above.**

### Constraints

  - All of the given numbers will be valid integers in the range \[1,
    10000\].

  - There will always be at least 1 set.

  - Allowed time/memory: 100ms/16MB.

### Examples

<table>
<thead>
<tr class="header">
<th><strong>Input</strong></th>
<th><strong>Output</strong></th>
<th><strong>Comment</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>10 8 7 13 8 4</p>
<p>4 7 3 6 4 12</p></td>
<td><p>The biggest set is: 16</p>
<p>15 16 13 12</p></td>
<td><p>First, we take the last given knife – 4 and the first given fork – 4. They are equal, so we have to remove the fork and increment the knife with 1. The knife becomes 5 and the collection looks like this</p>
<p>Knives: 10 8 7 13 8 5</p>
<p>Forks: 7 3 6 4 12</p>
<p>Next, we take the knife with value 5 and the fork with value 7 – the fork is bigger, so we <strong>remove</strong> the <strong>knife</strong> and the collections should look like this:</p>
<p>Knives: 10 8 7 13 8</p>
<p>Forks: 7 3 6 4 12</p>
<p>After that we the knife 8 and the fork 7 – the knife is bigger, so we have our first <strong>set</strong> with value 15. In the end we have to print the biggest set, which in this case is with value 16, and the collection of sets, that we have created.</p></td>
</tr>
<tr class="even">
<td><p>9 5 4 7 8 5 2 6 9</p>
<p>1 4 5 7 9 6 3 5 4 7</p></td>
<td><p>The biggest set is: 16</p>
<p>10 10 15 16</p></td>
<td></td>
</tr>
</tbody>
</table>
