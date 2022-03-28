namespace _04._Orders
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var productPrice = new Dictionary<string, decimal>();
            var productQuantity = new Dictionary<string, decimal>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input.Split();

                string product = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                decimal quantity = decimal.Parse(tokens[2]);
                
                if (!productPrice.ContainsKey(product))
                {
                    productQuantity[product] = quantity;
                }
                else
                {

                    productQuantity[product] += quantity;
                }

                productPrice[product] = price;
            }

            foreach (var kvp in productQuantity)
            {
                string product = kvp.Key;
                decimal quantity = kvp.Value;
                decimal price = productPrice[product];

                decimal result = quantity * price;

                Console.WriteLine($"{product} -> {result:f2}");
            }
        }
    }
}
