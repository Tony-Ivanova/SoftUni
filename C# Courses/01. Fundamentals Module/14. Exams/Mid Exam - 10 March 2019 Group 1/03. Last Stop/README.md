# Last Stop

*The group has reached Paris and went to visit "La Louvre". They
accidently found a map behind "The Wedding at Canna" painting. It had
some instructions, so they have decided to follow them and see where
they will lead them. Your job is to help them.*

Create a program that follows instructions in order to fulfil a quest.
First, you will receive a collection of numbers – each **representing**
a **painting number**. After that, you are going to be receiving
**instructions**, until the "**END**" command is given.

  - **Change {paintingNumber} {changedNumber}** – find the painting with
    the first number in the collection (**if it exists**) and **change**
    its **number** with the **second number – {changedNumber}**.

  - **Hide {paintingNumber}** – find the painting with this value and
    **if it exists** and hide it (**remove** it).

  - **Switch {paintingNumber} {paintingNumber2}** – find the given
    paintings in the collections **if they exist** and **switch** their
    places.

  - **Insert {place} {paintingNumber}** – **insert** the painting
    (**paintingNumber**) **<span class="underline">on the next place
    after</span>** the given one, **if it exists**.

  - **Reverse** – you must **reverse** the **order** of the paintings.

Once you complete the instructions, print the numbers of the paintings
on a single line, split by a space.

## Input / Constraints

  - > **On the 1<sup>st</sup> line**, you are going to receive the
    > numbers of the paintings, split by a single space – **integer
    > numbers** in the range **\[1…1000\]**

  - > **On the next lines**, you are going to receive **commands**,
    > until you receive the "**END**" command

## Output

  - Print the message you have received after the conversion of all
    numbers on a single line

## Examples

<table>
<tbody>
<tr class="odd">
<td><strong>Input</strong></td>
<td><strong>Output</strong></td>
<td><strong>Comments</strong></td>
</tr>
<tr class="even">
<td><p>115 115 101 114 73 111 116 75</p>
<p>Insert 5 114</p>
<p>Switch 116 73</p>
<p>Hide 75</p>
<p>Reverse</p>
<p>Change 73 70</p>
<p>Insert 10 85</p>
<p>END</p></td>
<td>70 114 111 116 114 101 115 115</td>
<td><p>The first command is "<strong>Insert</strong>". You have to insert <strong>painting number 114</strong> at the next index after the 5<sup>th</sup>:</p>
<p>115 115 101 114 73 111 <strong>114</strong> 116 75</p>
<p>The "<strong>Switch</strong>" will switch number <strong>116</strong> with <strong>73</strong> and the collection should look like this:</p>
<p>115 115 101 114 <strong>116</strong> 111 114 <strong>73</strong>  75</p>
<p>After receiving the"<strong>Hide</strong>" <strong>command</strong>, you must remove <strong>75</strong>. After that you receive "<strong>Reverse</strong>" and you have to reverse the whole collection. By receiving "<strong>Change</strong>" you have to exchange the value <strong>73</strong> with the value – <strong>70.</strong> The next "<strong>Insert</strong>"command is <strong>invalid</strong>, because there is <strong>no 11<sup>th</sup> index</strong> in the collection.</p></td>
</tr>
<tr class="odd">
<td><p>77 120 115 101 101 97 78 88 112 111 108 101 111 110</p>
<p>Insert 5 32</p>
<p>Switch 97 78</p>
<p>Hide 88</p>
<p>Change 120 117</p>
<p>END</p></td>
<td>77 117 115 101 101 78 32 97 112 111 108 101 111 110</td>
<td></td>
</tr>
</tbody>
</table>
