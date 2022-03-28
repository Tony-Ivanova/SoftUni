namespace _05._Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public class Person
        {
            private string name;
            private decimal money;
            private List<Product> bagOfProducts;

            public Person(string name, decimal money)
            {
                this.Name = name;
                this.Money = money;
                this.bagOfProducts = new List<Product>();
            }


            public string Name
            {
                get => this.name;
                private set
                {
                    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))

                    {
                        throw new ArgumentException("Name cannot be empty");

                    }
                    this.name = value;
                }
            }

            public decimal Money
            {
                get => this.money;
                private set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Money cannot be negative");

                    }
                    this.money = value;
                }
            }

            public IReadOnlyCollection<Product> BagOfProducts
            {
                get => this.bagOfProducts;
            }

            public string EnoughMoneyToPurchaseProduct(Product product)
            {
                if (this.money < product.Cost)
                {
                    throw new ArgumentException($"{this.Name} can't afford {product.Name}");
                }
                else
                {
                    this.money -= product.Cost;
                    this.bagOfProducts.Add(product);
                    return $"{this.Name} bought {product.Name}";
                }
            }
        }

        public class Product
        {
            private string name;
            private decimal cost;

            public Product(string name, decimal cost)
            {
                this.Name = name;
                this.Cost = cost;
            }

            public string Name
            {
                get => this.name;
                private set
                {
                    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Name cannot be empty");
                    }
                    this.name = value;
                }
            }

            public decimal Cost
            {
                get => this.cost;
                private set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Money cannot be negative");
                    }
                    this.cost = value;
                }
            }

            public static void Main()
            {
                var people = new List<Person>();
                var products = new List<Product>();

                var peopleAndMoney = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < peopleAndMoney.Length; i++)
                {
                    try
                    {
                        var currentPairOfInput = peopleAndMoney[i]
                            .Split('=', StringSplitOptions.RemoveEmptyEntries);
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

                var productsAndCost = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

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

                        var currentPersonname = people
                                                .Single(x => x.Name == personName);

                        var currrentProduct = products
                                                .Single(x => x.Name == productBought);


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
}

