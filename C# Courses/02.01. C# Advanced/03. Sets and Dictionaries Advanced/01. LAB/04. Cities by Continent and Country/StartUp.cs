namespace _04._Cities_by_Continent_and_Country
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> geography = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] tokens = Console.ReadLine()
                                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!geography.ContainsKey(continent))
                {
                    geography.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!geography[continent].ContainsKey(country))
                {
                    geography[continent].Add(country, new List<string>());
                }

                geography[continent][country].Add(city);

            }

            foreach (var kvp in geography)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var item in kvp.Value)
                {
                    List<string> city = item.Value;
                    string country = item.Key;

                    Console.Write($"  {country} -> ");
                    Console.WriteLine(string.Join(", ", city));
                }
            }
        }
    }
}
