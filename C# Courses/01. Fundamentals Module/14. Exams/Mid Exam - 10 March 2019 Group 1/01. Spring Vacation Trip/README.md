# Spring Vacation Trip

*A group of friends decide to go to a trip for a few days during spring
vacation. They have a certain budget. Your task is to calculate their
expenses during the trip and find out if they are going to have enough
money to finish the vacation.*

Create a program that calculates travelling expenses by entering the
following information:

  - **Days of the vacation**

  - **Budget** - its for the whole group

  - **The count of people**

  - **Fuel per kilometer – the price for fuel** that their car consumes
    **per kilometer**

  - **Food expenses per person**

  - **Hotel room price for one night** – again, for **one person**

If the group **<span class="underline">is bigger than 10</span>**, they
receive a **25% discount** from the **total
<span class="underline">hotel</span> expenses**.

**Every day**, they **travel** some **distance** and you have to
**calculate the expenses** for the **travelled kilometers**.

Every **third** and **fifth** day, they have some additional expenses,
which are **40% of the <span class="underline">current value</span> of
the expenses**.

Every **seventh** day, their expenses are reduced, because they
**withdraw (receive)** a small amount of money – you can calculate it by
**dividing the amount of <span class="underline">the current
expenses</span>** by the **<span class="underline">group of
people</span>**.

If the **expenses** **exceed the budget at some point**, stop
calculating and print the following message:

"Not enough money to continue the trip"

If the **budget is enough**:

"You have reached the destination. You have {money}$ budget left."

**Print** the result formatted **2 digits** after the decimal separator.

## Input / Constraints

  - > **On the 1<sup>st</sup> line**, you are going to receive the days
    > of the trip – **an integer** in the range **\[1…100\]**

  - > **On the 2<sup>nd</sup> line** – the budget – **a real number** in
    > the range **\[0.00 – 1000000.00\]**

  - > **On the 3<sup>rd</sup> line** - the group of people – **an
    > integer** in the rang **\[1 - 50\]**

  - > **On the 4<sup>th</sup> line** – the price for fuel per kilometer
    > – **a real number** **\[0.00 – 20.00\]**

  - > **On the 5<sup>th</sup> line** – food expenses per person for a
    > day – **a real number** **\[0.00 – 50.00\]**

  - > **On the 6<sup>th</sup> line** – the price for a room for one
    > night per person – **a real number** **\[0.00 – 1000.00\]**

  - > On the next **n** lines – one for each of the days – the
    > **travelled** **distance** in kilometers per day– **a real
    > number** in the range **\[0.00 - 1000\]**

## Output

  - **"Not enough money to continue the trip. You need {money}$ more."**
    –  
    if the budget is not enough

  - **"You have reached the destination. You have {money}$ budget
    left."** – if it’s enough.

> Print the result formatted **2 digits** after the decimal separator.

## Examples

<table>
<tbody>
<tr class="odd">
<td><strong>Input</strong></td>
<td><strong>Output</strong></td>
<td><strong>Comments</strong></td>
</tr>
<tr class="even">
<td><p><strong>7</strong></p>
<p><strong>12000</strong></p>
<p><strong>5</strong></p>
<p><strong>1.5</strong></p>
<p><strong>10</strong></p>
<p><strong>20</strong></p>
<p>512</p>
<p>318</p>
<p>202</p>
<p>154</p>
<p>222</p>
<p>108</p>
<p>123</p></td>
<td>You have reached the destination. You have 5083.48$ budget left.</td>
<td><p>We receive the days of the vacation, the budget, the group, the consumed fuel per kilometer, the food expenses and the price for a hotel room for one night. We must calclate the food expenses: <strong>10 * 5 * 7 = 350</strong></p>
<p>And the price for the hotel for all of the nights:</p>
<p><strong>20 * 5 * 7 = 700</strong></p>
<p>The curent expenses are <strong>1050</strong>. For each day, we have to calculate the consumed fuel – <strong>{travelledDistance} * 1.5</strong></p>
<p>On every <strong>3<sup>rd</sup></strong> and <strong>5<sup>th</sup></strong> day we add the additional expenses:</p>
<p><strong>0.4 * {currentExpenses}</strong></p>
<p>On every <strong>7<sup>th</sup></strong> day, they <strong>receive</strong> some <strong>money</strong>:</p>
<p><strong>{currentExpense} / {groupOfPeople}</strong></p>
<p>After <strong>we have added</strong> the <strong>fuel expenses for each day</strong> and made the <strong>other calculations</strong>, the <strong>expenses</strong> have reached <strong>8645.652</strong>. When we divide them by <strong>the group (5),</strong> the result is <strong>1729.1304</strong>, so we have to <strong>reduce the expenses</strong> by that sum. The expenses become <strong>6916.5216</strong>. The budget is <strong>enough</strong>, so the result is:</p>
<p>"You have reached the destination. You have 5083.48$ budget left."</p></td>
</tr>
<tr class="odd">
<td><p><strong>10</strong></p>
<p><strong>20500</strong></p>
<p><strong>11</strong></p>
<p><strong>1.2</strong></p>
<p><strong>8</strong></p>
<p><strong>13</strong></p>
<p>100</p>
<p>150</p>
<p>500</p>
<p>400</p>
<p>600</p>
<p>130</p>
<p>300</p>
<p>350</p>
<p>200</p>
<p>300</p></td>
<td>Not enough money to continue the trip. You need 465.79$ more.</td>
<td></td>
</tr>
</tbody>
</table>
