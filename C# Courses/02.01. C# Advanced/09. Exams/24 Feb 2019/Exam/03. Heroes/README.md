# Heroes

## Preparation

Download the skeleton provided in Judge. **Do not** change the
**StartUp** class or its **namespace**.

## Problem description

Your task is to create a repository which stores hero by creating the
classes described below.

First, write a C\# class **Item** with the following properties:

  - **Strength: int**

  - **Ability: int**

  - **Intelligence: int**

The class **constructor** should receive **strength, ability and
intelligence** and override the **ToString()** method in the following
format:

**"Item:"**

**" \* Strength: {Strength Value}"**

**" \* Ability: {Ability Value}"**

**" \* Intelligence: {Intelligence Value}"**

Next, write a C\# class **Hero** with the following properties:

  - **Name: string**

  - **Level: int**

  - **Item: Item**

The class **constructor** should receive **name, level and item** and
override the **ToString()** method in the following format:

**"Hero: {Name} – {Level}lvl"**

**"Item:"**

**" \* Strength: {Strength Value}"**

**" \* Ability: {Ability Value}"**

**" \* Intelligence: {Intelligence Value}"**

Write a C\# class **HeroRepository** that has **data** (a collection
which stores the entity **Hero**). All entities inside the repository
have the **same properties**.

<table>
<tbody>
<tr class="odd">
<td><p><strong>public class Hero</strong>Repository</p>
<p>{<br />
<em>// <strong>TODO: implement this class<br />
</strong></em>}</p></td>
</tr>
</tbody>
</table>

The class **constructor** should initialize the **data** with a new
instance of the collection**.** Implement the following features:

  - Field **data** – **collection** that holds added heroes

  - Method **Add(Hero hero)** – adds an entity to the data.

  - Method **Remove(string name)** – removes an entity by given hero
    name.

  - Method **GetHeroWithHighestStrength()** – returns the Hero which
    poses the item with the highest stength.

  - Method **GetHeroWithHighestAbility()** – returns the Hero which
    poses the item with the highest ability.

  - Method **GetHeroWithHighestIntelligence()** – returns the Hero which
    poses the item with the highest intellgence.

  - Getter **Count** – returns the number of stored heroes.

  - Оverride **ToString()** – Print all the heroes.

## Constraints

  - The names of the heroes will be always unique.

  - The items of the heroes will always be with positive values.

  - The items of the heroes will always be different.

  - You will always have an item with the highest strength, ability and
    intelligence.

## Examples

This is an example how the **HeroRepository** class is **intended to be
used**.

<table>
<thead>
<tr class="header">
<th>Sample code usage</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>//Initialize the repository</p>
<p>HeroRepository repository = new HeroRepository();</p>
<p>//Initialize entity</p>
<p>Item item = new Item(23, 35, 48);</p>
<p>//Print Item</p>
<p>Console.WriteLine(item);</p>
<p>//Item:</p>
<p>// * Strength: 23</p>
<p>// * Ability: 35</p>
<p>// * Intelligence: 48</p>
<p>//Initialize entity</p>
<p>Hero hero = new Hero("Hero Name", 24, item);</p>
<p>//Print Hero</p>
<p>Console.WriteLine(hero);</p>
<p>//Hero: Hero Name - 24lvl</p>
<p>//Item:</p>
<p>// * Strength: 23</p>
<p>// * Ability: 35</p>
<p>// * Intelligence: 48</p>
<p>//Add Hero</p>
<p>repository.Add(hero);</p>
<p>//Remove Hero</p>
<p>repository.Remove("Hero Name");</p>
<p>Item secondItem = new Item(100, 20, 13);</p>
<p>Hero secondHero = new Hero("Second Hero Name", 125, secondItem);</p>
<p>//Add Heroes</p>
<p>repository.Add(hero);</p>
<p>repository.Add(secondHero);</p>
<p>Hero heroStrength = repository.GetHeroWithHighestStrength(); // Hero with name Second Hero</p>
<p>Hero heroAbility = repository.GetHeroWithHighestAbility(); // Hero with name Hero Name</p>
<p>Hero heroIntelligence = repository.GetHeroWithHighestIntelligence(); // Hero with name Hero</p>
<p>Console.WriteLine(repository.Count); //2</p>
<p>Console.WriteLine(repository);</p>
<p>//Hero: Hero Name - 24lvl</p>
<p>//Item:</p>
<p>//*Strength: 23</p>
<p>// * Ability: 35</p>
<p>// * Intelligence: 48</p>
<p>//Hero: Second Hero Name - 125lvl</p>
<p>//Item:</p>
<p>// * Strength: 100</p>
<p>// * Ability: 20</p>
<p>// * Intelligence: 13</p></td>
</tr>
</tbody>
</table>

## Submission

Zip all the files in the project folder except **bin** and **obj**
folders
