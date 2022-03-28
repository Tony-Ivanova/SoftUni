# Hello, France

*The budget was enough to get them to Frankfurt and they have some money
left, but their final aim is to go to France, which means that they will
need more finances. They’ve decided to make profit by buying items on
discount from the Thrift Shop and selling them for a higher price. You
must help them.*

Create a program that calculates the profit after buying some items and
selling them on a higher price. In order to fulfil that, you are going
to need certain data - you will receive a **collection of items** and a
**budget** in the following format:

{type-\>price|type-\>price|type-\>price……|type-\>price}

{budget}

**The prices** for each of the types **cannot** **exceed** a certain
**price**, which is given bellow:

| **Type**    | **Maximum Price** |
| ----------- | ----------------- |
| Clothes     | 50.00             |
| Shoes       | 35.00             |
| Accessories | 20.50             |

If a **price** for a certain **item** is
**<span class="underline">higher than</span>** the
**<span class="underline">maximum</span>** price,
**<span class="underline">don’t buy it</span>**. Every time you **buy an
item**, you have to **reduce the budget** with the value of **its**
**price**. If you don’t have enough money for it, you
**<span class="underline">can’t buy it</span>**. Buy **as much** items
**as you can**.

You have to **increase** the price of **each of the items you have
successfully bought with 40%.** Print the list with **the new prices**
and **the profit** you will gain **<span class="underline">from selling
the items</span>**. They need exactly **150$** for tickets for the
train, so if their budget after selling the products is enough – print –
**"Hello, France\!"** and if not – **"Time to go."**

## Input / Constraints

  - **On the 1<sup>st</sup> line** you are going to receive the **items
    with their prices** in the format described above **– real numbers
    in the range \[0.00……1000.00\]**

  - **On the 2<sup>nd</sup> line**, you are going to be given the
    **budget** – **a real number** in the range **\[0.0….1000.0\]**

## Output

  - > Print the list with the bought item’s new prices, rounded 2 digits
    > after the decimal separator in the following format:

"{price1} {price2} {price3} {price5}………{priceN}"

  - > Print the profit, **rounded 2 digits** after the decimal separator
    > in the following format:

**"Profit: {profit**}"

  - > If the money for tickets are enough, print: **"Hello, France\!"**
    > and if not – **"Time to go."**

## Examples

<table>
<tbody>
<tr class="odd">
<td><strong>Input</strong></td>
<td><strong>Output</strong></td>
<td><strong>Comments</strong></td>
</tr>
<tr class="even">
<td><p>Clothes-&gt;43.30|Shoes-&gt;25.25|Clothes-&gt;36.52|Clothes-&gt;20.90|Accessories-&gt;15.60</p>
<p>120</p></td>
<td><p>60.62 35.35 51.13</p>
<p>Profit: 42.03</p>
<p>Hello, France!</p></td>
<td><p>We start subtracting the valid prices from the budget:</p>
<p>120 – 43.40 = <strong>76.7.</strong></p>
<p>76.7 – 25.25 = <strong>51.45</strong></p>
<p>51.45 – 36.52 = <strong>14.93</strong></p>
<p>14.93 is <strong>less</strong> than <strong>20.90</strong> and <strong>15.60</strong>, so we can’t buy either of the last two. We must increase <strong>each price</strong> with 40% and the new prices are: <strong>60.62 35.35 51.13.</strong> The profit is <strong>42.03</strong> and their new budget will be – what is left of the budget - <strong>14.93 + {sum of all newPrices}.</strong> It is enough, so we print: <strong>Hello, France!</strong></p></td>
</tr>
<tr class="odd">
<td><p>Shoes-&gt;41.20|Clothes-&gt;20.30|Accessories-&gt;40|Shoes-&gt;15.60|Shoes-&gt;33.30|Clothes-&gt;48.60</p>
<p>90</p></td>
<td><p>28.42 21.84 46.62</p>
<p>Profit: 27.68</p>
<p>Time to go.</p></td>
<td></td>
</tr>
</tbody>
</table>
