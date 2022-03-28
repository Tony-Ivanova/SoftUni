namespace _2._Rage_Quit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string pattern = @"(?<text>[\D]+)(?<number>[\d]+)";

            string input = Console.ReadLine();

            HashSet<char> uniqueChars = new HashSet<char>();

            MatchCollection matches = Regex.Matches(input, pattern);

            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                string text = match.Groups["text"].Value.ToUpper();
                int number = int.Parse(match.Groups["number"].Value);

                if (number > 0)
                {
                    foreach (var charLetter in text)
                    {
                        uniqueChars.Add(charLetter);
                    }
                }

                for (int i = 0; i < number; i++)
                {
                    result.Append(text);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueChars.Count}");
            Console.WriteLine(result.ToString());
        }
    }
}