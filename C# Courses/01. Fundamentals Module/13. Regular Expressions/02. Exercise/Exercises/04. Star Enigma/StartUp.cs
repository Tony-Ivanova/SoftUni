namespace _04._Star_Enigma
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            int messagesCount = int.Parse(Console.ReadLine());
            string firstPattern = @"[starSTAR]";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < messagesCount; i++)
            {
                string currentMessage = Console.ReadLine();

                MatchCollection lettersMatched = Regex.Matches(currentMessage, firstPattern);

                int countOfLetters = lettersMatched.Count;

                string decryptedMessage = string.Empty;

                foreach (char letter in currentMessage)
                {
                    decryptedMessage += (char)(letter - countOfLetters);
                }

                string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:]*:(?<population>[0-9]+)[^@\-!:]*!(?<attackType>A|D)![^@\-!:]*->(?<soldierCount>[0-9]+)";

                Match planetArgs = Regex.Match(decryptedMessage, pattern);

                if (planetArgs.Success)
                {
                    string planetName = planetArgs.Groups["name"].Value;
                    string attackType = planetArgs.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (string attackedPlanet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {attackedPlanet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (string destroyedPlanet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {destroyedPlanet}");
            }
        }
    }
}
