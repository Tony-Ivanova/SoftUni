namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(new string[] { " -> " }, StringSplitOptions.None);
                string color = input[0];
                string[] clotes = input[1].Split(new char[] { ',' }, StringSplitOptions.None);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clotes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] found = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = found[0];
            string clothToFind = found[1];

            foreach (var kvp in wardrobe)
            {
                string color = kvp.Key;
                Console.WriteLine($"{color} clothes:");

                foreach (var item in kvp.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");

                    if (kvp.Key == colorToFind && item.Key == clothToFind)
                    {
                        Console.Write($" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
