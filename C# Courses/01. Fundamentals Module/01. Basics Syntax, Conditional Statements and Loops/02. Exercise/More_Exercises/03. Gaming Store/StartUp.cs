namespace _03._Gaming_Store
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal priceOfGame = 0m;
            decimal sumOfBoughtGames = 0m;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${sumOfBoughtGames}. Remaining: ${budget:f2}");
                    break;
                }

                if (input == "OutFall 4")
                {
                    priceOfGame = 39.99m;
                    var results = EnoughMoney(budget, priceOfGame, input, sumOfBoughtGames);
                    budget = results.Item1;
                    sumOfBoughtGames = results.Item2;
                }
                else if (input == "CS: OG")
                {
                    priceOfGame = 15.99m;
                    var results = EnoughMoney(budget, priceOfGame, input, sumOfBoughtGames);
                    budget = results.Item1;
                    sumOfBoughtGames = results.Item2;
                }
                else if (input == "Zplinter Zell")
                {
                    priceOfGame = 19.99m;
                    var results = EnoughMoney(budget, priceOfGame, input, sumOfBoughtGames);
                    budget = results.Item1;
                    sumOfBoughtGames = results.Item2;
                }
                else if (input == "Honored 2")
                {
                    priceOfGame = 59.99m;
                    var results = EnoughMoney(budget, priceOfGame, input, sumOfBoughtGames);
                    budget = results.Item1;
                    sumOfBoughtGames = results.Item2;
                }
                else if (input == "RoverWatch")
                {
                    priceOfGame = 29.99m;
                    var results = EnoughMoney(budget, priceOfGame, input, sumOfBoughtGames);
                    budget = results.Item1;
                    sumOfBoughtGames = results.Item2;
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    priceOfGame = 39.99m;
                    var results = EnoughMoney(budget, priceOfGame, input, sumOfBoughtGames);
                    budget = results.Item1;
                    sumOfBoughtGames = results.Item2;
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                if (budget == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

            }
        }

        private static (decimal, decimal) EnoughMoney(decimal budget, decimal priceOfGame, string nameOfGame, decimal sumOfBoughtGames)
        {
            if (budget - priceOfGame >= 0)
            {
                budget -= priceOfGame;
                sumOfBoughtGames += priceOfGame;
                Console.WriteLine($"Bought {nameOfGame}");
            }
            else
            {
                Console.WriteLine("Too Expensive");
            }
            return (budget, sumOfBoughtGames);

        }
    }
}
