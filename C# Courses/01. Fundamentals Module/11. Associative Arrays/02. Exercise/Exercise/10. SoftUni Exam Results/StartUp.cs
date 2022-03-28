namespace _10._SoftUni_Exam_Results
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var userPoints = new Dictionary<string, int>();
            var userLanguage = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "exam finished")
                {
                    break;
                }

                var tokens = input.Split('-');
                var username = tokens[0];
                var languageOrBanned = tokens[1];

                if (languageOrBanned == "banned")
                {
                    userPoints.Remove(username);
                }
                else
                {
                    var points = int.Parse(tokens[2]);
                    if (!userPoints.ContainsKey(username))
                    {
                        userPoints[username] = points;
                    }
                    else
                    {
                        if (points > userPoints[username])
                        {
                            userPoints[username] = points;
                        }
                    }

                    if (!userLanguage.ContainsKey(languageOrBanned))
                    {
                        userLanguage[languageOrBanned] = 1;
                    }
                    else
                    {
                        userLanguage[languageOrBanned]++;
                    }
                }
            }

            Console.WriteLine("Results:");

            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in userLanguage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
