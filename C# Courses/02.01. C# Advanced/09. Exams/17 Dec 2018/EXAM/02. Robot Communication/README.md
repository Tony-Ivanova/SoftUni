# Robot Communication

*There is a Galaxy far away, where all of the planets are populated with
robots, who communicate with each other through encrypted messages. You
have a mission to decrypt the messages they send to each other and
report them to the Earth station.*

You will be given several input lines, consisting of encrypted messages
between the robots. Read them, until you receive the command
“**Report**”.

There are a few encoded strings in each of the messages and you must
find them. After you have found such string, you have to **decrypt** it.
**Print** each line **immediately after** you have decrypted it. The
encoded string consists of – a **single comma** (**,**) or an
**underscore** (**\_**), a **sequence of English Alphabet letters**, and
a **digit** at the end of it. **Examples:** “**,htr7**”, “**\_lki5**”,
“**,edsr2**“.

In order to **decode** a **message**, you have to either **add** or
**subtract** the **value** of the **digit inside the match** from the
**ASCII code** of **each** of the **characters** **in the sequence**. If
the front character is a **comma** (**,**) you have to **add** the
**digit** to the **ASCII codes** of the characters and if it’s an
**underscore** (**\_**), you must **subtract** it. Print the decoded
words from each line **separated by a single space**.

### Input

  - The input comes in the form of input lines containing the encoded
    messages.

  - When you receive the command “**Report**” the input sequence ends.

### Output

  - You must print each line, **immediately** after you’ve decoded it.

  - Print the decoded words separated by a single space.

### Constrains

  - The input lines may consist of any **ASCII character**.

  - When you **replace** the **memorized** patterns, you must do it in
    **the order** in which you’ve **found the patterns**.

### Examples

<table>
<thead>
<tr class="header">
<th><strong>Input</strong></th>
<th><strong>Output</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>zsjfg,Ilsb3kdrgjshdg_lv3gfyts&amp;*,bsbovqefkd3djgheuh</p>
<p>Report</p></td>
<td><strong>Love is everything</strong></td>
</tr>
<tr class="even">
<td><p><strong>vbe4g,Qmdrslg2vbf</strong></p>
<p><strong>sfa_gpsfwfs1ret</strong></p>
<p><strong>Report</strong></p></td>
<td><p>Softuni</p>
<p>forever</p></td>
</tr>
</tbody>
</table>
