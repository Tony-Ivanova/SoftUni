# Sport Cards

You will receive **several input lines** in one of the following
formats:

  - "{card} - {sport} - {price}"

  - "check {card}"

The **card** and **sport** are strings. **Price** will be a **floating
point** number. You need to keep track of **every card**.

When you receive a **card**, a **sport** and a **price**, register the
card in the database if **it isn't present**, **otherwise add** the
sport and the price. If the card already contains the sport, you need to
**overwrite** the price.

If you receive **"check {card}"** you need to check if the card is
available or not and **print** it on the console in the format:

**"{card} is available\!"** if the **card is present** and

**"{card} is not available\!"** if the **card is not present**

You should end your program when you receive the command **"end"**. At
that point you should print the cards, **ordered by sports’ count in
desecending order**. **Foreach** card print their sport and price
**ordered by sports’ name**.

## Input / Constraints

  - The input comes in the form of commands in one of the formats
    specified above.

  - Card and sport **will always be one word string, containing no
    whitespaces**.

  - Price will be a **floating point** number in the **range \[0,
    1000\]**.

  - There will be **no invalid** input lines.

  - The programm ends when you receive the command **"end"**.

## Output

  - The output format for each card is:

> "{card}:"

" -{sport} **- {price}"**

  - Print the **price** rounded to the **second digit** after the
    separator.

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
<td><p><strong>Multisport - Jumping - 10.00</strong></p>
<p><strong>Viasport - Swimming - 8.60</strong></p>
<p><strong>Supercard - Football – 5.40</strong></p>
<p><strong>end</strong></p></td>
<td><p><strong>Multisport:</strong></p>
<p><strong>-Jumping - 10.00</strong></p>
<p><strong>Viasport:</strong></p>
<p><strong>-Swimming - 8.60</strong></p>
<p><strong>Supercard:</strong></p>
<p><strong>-Football - 5.40</strong></p></td>
</tr>
<tr class="even">
<td><strong>Input</strong></td>
<td><strong>Output</strong></td>
</tr>
<tr class="odd">
<td><p><strong>Multisport - Box – 20.50</strong></p>
<p><strong>Supercard - Kickbox – 23.75</strong></p>
<p><strong>Multisport - Box - 16.80</strong></p>
<p><strong>Viasport - Jumping – 20.37</strong></p>
<p><strong>check Supercard</strong></p>
<p><strong>Supercard - Racing – 46.35</strong></p>
<p><strong>end</strong></p></td>
<td><p><strong>Supercard is available!</strong></p>
<p><strong>Supercard:</strong></p>
<p><strong>-Kickbox - 23.75</strong></p>
<p><strong>-Racing - 46.35</strong></p>
<p><strong>Multisport:</strong></p>
<p><strong>-Box - 16.80</strong></p>
<p><strong>Viasport:</strong></p>
<p><strong>-Jumping - 20.37</strong></p></td>
</tr>
</tbody>
</table>
