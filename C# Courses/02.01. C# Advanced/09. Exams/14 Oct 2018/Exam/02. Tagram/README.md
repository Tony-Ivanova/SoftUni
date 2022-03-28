# Tagram

You will receive **several input lines** in one of the following
formats:

  - "{username} -\> {tag} -\> {likes}"

  - "ban {username}"

The **username** and **tag** are strings. **Likes** will be an integer
number. You need to keep track of **every user**.

When you receive a **user**, a **tag** and **likes**, register the user
if **he isn't present**, **otherwise add** the tag and the likes. If the
user has already used the tag just add the likes to it.

If you receive **"ban {username}"** and **the username exists**, remove
him from the database.

You should end your program when you receive the command **"end"**. At
that point you should print the users, **ordered by total likes in
desecending order, then ordered by the tags’ count in ascending order**.
**Foreach** player print their tag and likes.

## Input / Constraints

  - The input comes in the form of commands in one of the formats
    specified above.

  - Username and tag **will always be one word string, containing no
    whitespaces**.

  - Likes will be an **integer** in the **range \[0, 1000\]**.

  - There will be **no invalid** input lines.

  - The programm ends when you receive the command **"end"**.

## Output

  - The output format for each player is:

> "{username}"

"- {tag}**: {likes}"**

## Examples

<table>
<thead>
<tr class="header">
<th><strong>Input</strong></th>
<th><strong>Output</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>Katty -&gt; healthy -&gt; 50</strong></p>
<p><strong>Elvin -&gt; food -&gt; 20</strong></p>
<p><strong>John -&gt; music -&gt; 30</strong></p>
<p><strong>Katty -&gt; fitness -&gt; 100</strong></p>
<p><strong>end</strong></p></td>
<td><p><strong>Katty</strong></p>
<p><strong>- healthy: 50</strong></p>
<p><strong>- fitness: 100</strong></p>
<p><strong>John</strong></p>
<p><strong>- music: 30</strong></p>
<p><strong>Elvin</strong></p>
<p><strong>- food: 20</strong></p></td>
</tr>
<tr class="even">
<td><strong>Input</strong></td>
<td><strong>Output</strong></td>
</tr>
<tr class="odd">
<td><p><strong>Monica -&gt; music -&gt; 100</strong></p>
<p><strong>Monica -&gt; dance -&gt; 50</strong></p>
<p><strong>John -&gt; chill -&gt; 200</strong></p>
<p><strong>Santa -&gt; angry -&gt; 300</strong></p>
<p><strong>ban Santa</strong></p>
<p><strong>Joshua -&gt; football -&gt; 500</strong></p>
<p><strong>end</strong></p></td>
<td><p><strong>Joshua</strong></p>
<p><strong>- football: 500</strong></p>
<p><strong>John</strong></p>
<p><strong>- chill: 200</strong></p>
<p><strong>Monica</strong></p>
<p><strong>- music: 100</strong></p>
<p><strong>- dance: 50</strong></p></td>
</tr>
<tr class="even">
<td><p><strong>Ani -&gt; A1 -&gt; 100</strong></p>
<p><strong>Bobi -&gt; B2 -&gt; 100</strong></p>
<p><strong>Bobi -&gt; BB2 -&gt; 150</strong></p>
<p><strong>Ani -&gt; AA1 -&gt; 100</strong></p>
<p><strong>Ani -&gt; AAA1 -&gt; 50</strong></p>
<p><strong>end</strong></p></td>
<td><p><strong>Bobi</strong></p>
<p><strong>- B2: 100</strong></p>
<p><strong>- BB2: 150</strong></p>
<p><strong>Ani</strong></p>
<p><strong>- A1: 100</strong></p>
<p><strong>- AA1: 100</strong></p>
<p><strong>- AAA1: 50</strong></p></td>
</tr>
</tbody>
</table>
