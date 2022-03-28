namespace _4._Santa_s_Secret_Helper
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            int subtractionKey = int.Parse(Console.ReadLine());

            string pattern = @"\@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behaviourType>[GN])!";

            List<string> result = new List<string>();

            while (true)
            {
                string message = Console.ReadLine();
                string decrypted = string.Empty;

                if (message == "end")
                {
                    break;
                }

                for (int i = 0; i < message.Length; i++)
                {
                    char currentChar = message[i];
                    decrypted += (char)(currentChar - subtractionKey);
                }

                MatchCollection matches = Regex.Matches(decrypted, pattern);

                foreach (Match match in matches)
                {
                    string name = match.Groups["name"].Value;
                    string behaviour = match.Groups["behaviourType"].Value;

                    if (behaviour == "G")
                    {
                        result.Add(name);
                    }
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}