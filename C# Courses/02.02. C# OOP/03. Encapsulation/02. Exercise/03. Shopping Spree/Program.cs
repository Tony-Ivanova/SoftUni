namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var peopleAndMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleAndMoney.Length; i++)
            {
                try
                {

                    var currentPairOfInput = peopleAndMoney[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var personName = currentPairOfInput[0];
                    var personMoney = decimal.Parse(currentPairOfInput[1]);
                    var person = new Person(personName, personMoney);

                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            var productsAndCost = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsAndCost.Length; i++)
            {
                try
                {
                    var currentPairOfInput = productsAndCost[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var productName = currentPairOfInput[0];
                    var productMoney = decimal.Parse(currentPairOfInput[1]);
                    var product = new Product(productName, productMoney);

                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    var personNameAndProductBought = input.Split();
                    var personName = personNameAndProductBought[0];
                    var productBought = personNameAndProductBought[1];

                    var currentPersonname = people.Single(x => x.Name == personName);
                    var currrentProduct = products.Single(x => x.Name == productBought);


                    Console.WriteLine(currentPersonname.EnoughMoneyToPurchaseProduct(currrentProduct));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var person in people)
            {
                if (person.BagOfProducts.Count() == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(x => x.Name))}");
                }
            }
        }
    }
}
