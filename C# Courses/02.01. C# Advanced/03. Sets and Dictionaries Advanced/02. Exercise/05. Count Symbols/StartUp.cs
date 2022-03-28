namespace _05._Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            char[] letters = Console.ReadLine()
                                 .ToCharArray();

            Dictionary<char, int> counter = new Dictionary<char, int>();

            foreach (var letter in letters)
            {
                if (!counter.ContainsKey(letter))
                {
                    counter[letter] = 0;
                }
                counter[letter]++;
            }

            foreach (var kvp in counter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
