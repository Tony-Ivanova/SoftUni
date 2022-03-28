namespace _03._Product_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, double>> productShops = new Dictionary<string, Dictionary<string, double>>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Revision")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!productShops.ContainsKey(shop))
                {
                    productShops.Add(shop, new Dictionary<string, double>());
                }

                if (!productShops[shop].ContainsKey(product))
                {
                    productShops[shop].Add(product, 0);
                }

                productShops[shop][product] = price;
            }

            foreach (var shop in productShops.OrderBy(shop => shop.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
