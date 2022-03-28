namespace _07._Vending_Machine
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string[] coins = new string[] { "0.1", "0.2", "0.5", "1", "2" };
            string[] items = new string[] { "nuts", "water", "crisps", "soda", "coke" };

            string input = Console.ReadLine();

            decimal totalPrice = 0m;

            while (input != "Start")
            {
                if (Array.Exists(coins, element => element == input))
                {
                    decimal coin = Convert.ToDecimal(input);
                    totalPrice += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {input}");
                }
                input = Console.ReadLine();
            }

            string product = Console.ReadLine().ToLower();

            decimal change = 0m;

            while (product != "end")
            {
                if (Array.Exists(items, element => element == product))
                {
                    change = totalPrice;

                    if (product == "nuts")
                    {
                        totalPrice -= 2.0m;
                    }
                    else if (product == "water")
                    {
                        totalPrice -= 0.7m;
                    }
                    else if (product == "crisps")
                    {
                        totalPrice -= 1.5m;
                    }
                    else if (product == "soda")
                    {
                        totalPrice -= 0.8m;
                    }
                    else if (product == "coke")
                    {
                        totalPrice -= 1.0m;
                    }
                    if (totalPrice >= 0)
                    {
                        Console.WriteLine($"Purchased {product}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        totalPrice = change;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid product");
                }
                product = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Change: {totalPrice:f2}");
        }
    }
}
