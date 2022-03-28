namespace _05._Orders
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string product = Console.ReadLine();
            int numberOfProducts = int.Parse(Console.ReadLine());

            double priceOfProduct = CalculateMoneyNeeded(product);
            double money = priceOfProduct * numberOfProducts;
            Console.WriteLine($"{money:f2}");
        }

        private static double CalculateMoneyNeeded(string product)
        {
            double price = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;
            }

            return price;
        }
    }
}
