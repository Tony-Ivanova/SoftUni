namespace _02._Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> myDict = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var tokens = input.Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "ban")
                {
                    string username = tokens[1];

                    if (myDict.ContainsKey(username))
                    {
                        myDict.Remove(username);
                    }
                }
                else
                {
                    string username = tokens[0];
                    string tag = tokens[1];
                    int likes = int.Parse(tokens[2]);

                    if (!myDict.ContainsKey(username))
                    {
                        myDict[username] = new Dictionary<string, int>();
                    }


                    if (myDict[username].ContainsKey(tag))
                    {
                        myDict[username][tag] += likes;
                    }
                    
                    myDict[username].Add(tag, likes);
                }
            }

            foreach (var item in myDict.OrderByDescending(x => x.Value.Values.Sum())
                                       .ThenBy(y => y.Value.Keys.Count()))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}
