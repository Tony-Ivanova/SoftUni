namespace FoodShortage
{
    using FoodShortage.Interfaces;
    using FoodShortage.Minions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            var citizensAndRebels = new List<IBuyer>();

            int numberOfCitizens = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCitizens; i++)
            {
                var tokens = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];
                    var birthday = tokens[3];

                    var citizen = new Citizen(name, age, id, birthday);

                    citizensAndRebels.Add(citizen);
                }
                else if (tokens.Length == 3)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var group = tokens[2];

                    var rebel = new Rebel(name, age, group);
                    citizensAndRebels.Add(rebel);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                
                var currentBuyerOfFood = citizensAndRebels.SingleOrDefault(x => x.Name == input);
                
                if (currentBuyerOfFood != null)
                {
                    currentBuyerOfFood.BuyFood();
                }
            }

            Console.WriteLine(citizensAndRebels.Sum(x => x.Food));
        }
    }
}
