namespace _02._Odd_Occurrences
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordInLowerCase = word.ToLower();

                if (counts.ContainsKey(wordInLowerCase))
                {
                    counts[wordInLowerCase]++;
                }
                else
                {
                    counts.Add(wordInLowerCase, 1);
                }
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
