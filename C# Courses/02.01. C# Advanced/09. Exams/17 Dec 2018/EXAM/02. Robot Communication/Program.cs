namespace _02._Robot_Communication
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class RobotCommunication
    {
        public static void Main()
        {
            string pattern = @"([_,])([a-zA-Z]+)([\d])";

            string line = Console.ReadLine();

            while (line != "Report")
            {
                MatchCollection collection = Regex.Matches(line, pattern);
                List<string> text = new List<string>();

                foreach (Match item in collection)
                {
                    char beginning = char.Parse(item.Groups[1].Value);
                    string lettersToDecode = item.Groups[2].Value;
                    int end = int.Parse(item.Groups[3].Value);

                    text.Add(DecodeCode(beginning, lettersToDecode, end));
                }

                Console.WriteLine(string.Join(" ", text));

                line = Console.ReadLine();
            }
        }

        private static string DecodeCode(char specialChar, string letters, int number)
        {
            string result = string.Empty;

            if (specialChar == ',')
            {
                foreach (char item in letters)
                {
                    result += (char)(number + (int)item);
                }
            }
            else if (specialChar == '_')
            {
                foreach (char item in letters)
                {
                    result += (char)((int)item - number);
                }
            }

            return result;
        }
    }
}
