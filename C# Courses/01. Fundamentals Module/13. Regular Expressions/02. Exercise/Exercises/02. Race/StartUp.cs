namespace _02._Race
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string[] participants = Console.ReadLine()
                                                     .Split(", ");

            Dictionary<string, int> racers = new Dictionary<string, int>();

            for (int i = 0; i < participants.Length; i++)
            {
                string name = participants[i];

                if (!racers.ContainsKey(name))
                {
                    racers[name] = 0;
                }
            }

            string pattern = @"(?<name>[A-Za-z]+)|(?<distance>\d)";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                MatchCollection regex = Regex.Matches(input, pattern);

                string name = string.Empty;
                int distance = 0;

                foreach (Match match in regex)
                {
                    foreach (var letter in match.Groups["name"].Value)
                    {
                        name += letter;
                    }

                    foreach (var digit in match.Groups["distance"].Value)
                    {
                        distance += int.Parse(match.Groups["distance"].Value);
                    }
                }

                if (racers.ContainsKey(name))
                {
                    racers[name] += distance;
                }
            }

            int place = 1;
            foreach (var kvp in racers.OrderByDescending(x=>x.Value).Take(3))
            {

                string position = string.Empty;

                switch (place)
                {
                    case 1:
                        position = "st";
                        break;
                    case 2:
                        position = "nd";
                        break;
                    case 3:
                        position = "rd";
                        break;
                }

                string racerName = kvp.Key;

                Console.WriteLine($"{place}{position} place: {racerName}");

                place++;
            }
        }
    }
}