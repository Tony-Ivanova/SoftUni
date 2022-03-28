namespace _01._Count_Chars_in_a_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var letters = input.ToList();

            letters.RemoveAll(x => x == ' ');

            var counter = new Dictionary<char, int>();

            foreach (var letter in letters)
            {
                if (!counter.ContainsKey(letter))
                {
                    counter[letter] = 0;
                }

                counter[letter]++;
            }

            foreach (var kvp in counter)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
