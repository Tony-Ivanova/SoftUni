namespace _07._The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> myDict = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] data = input.Split();

                string vlogger = data[0];
                string command = data[1];

                if (command == "joined")
                {
                    if (!myDict.ContainsKey(vlogger))
                    {
                        myDict.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        myDict[vlogger].Add("followers", new HashSet<string>());
                        myDict[vlogger].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string member = data[2];

                    if (vlogger != member && myDict.ContainsKey(vlogger) && myDict.ContainsKey(member))
                    {
                        myDict[vlogger]["following"].Add(member);
                        myDict[member]["followers"].Add(vlogger);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {myDict.Count} vloggers in its logs.");

            int number = 1;

            foreach (var vlogger in myDict.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                number++;
            }
        }
    }
}
