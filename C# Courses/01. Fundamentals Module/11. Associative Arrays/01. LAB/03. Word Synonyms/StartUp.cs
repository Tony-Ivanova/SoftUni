namespace _03._Word_Synonyms
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int totalWords = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            for (int i = 0; i < totalWords; i++)
            {
                string word = Console.ReadLine();
                string synonyms = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words[word] = new List<string>();
                }

                words[word].Add(synonyms);
            }

            foreach (var kvp in words)
            {
                string word = kvp.Key;
                List<string> synonyms = kvp.Value;

                Console.WriteLine($"{word} - {string.Join(", ", synonyms)}");
            }
        }
    }
}
