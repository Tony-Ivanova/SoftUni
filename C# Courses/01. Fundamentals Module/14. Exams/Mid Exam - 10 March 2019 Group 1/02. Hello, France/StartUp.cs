namespace _02._Hello__France
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, decimal> collectionOfItems = new Dictionary<string, decimal>();
            collectionOfItems["Clothes"] = 50.00m;
            collectionOfItems["Shoes"] = 35.00m;
            collectionOfItems["Accessories"] = 20.50m;

            List<string> sellPrices = new List<string>();
            decimal totalPrice = 0;

            string[] itemsAndPrice = Console.ReadLine().Split('|');
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal profit = 0m;

            foreach (var pair in itemsAndPrice)
            {
                string[] itemWithPrice = pair.Split("->");
                string item = itemWithPrice[0];
                decimal price = decimal.Parse(itemWithPrice[1]);

                if (collectionOfItems.ContainsKey(item) && collectionOfItems[item] >= price && budget >= price)
                {
                    budget -= price;
                    decimal increasedPrice = price * 1.4m;
                    totalPrice += increasedPrice;
                    profit += increasedPrice - price;
                    string sellPrice = $"{increasedPrice:f2}";
                    sellPrices.Add(sellPrice);
                }
            }
           
            Console.WriteLine(string.Join(" ", sellPrices));
            Console.WriteLine($"Profit: {profit:f2}");
            if (budget + totalPrice >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }
    }
}
