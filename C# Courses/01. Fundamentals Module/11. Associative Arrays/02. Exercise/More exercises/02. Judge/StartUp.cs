namespace _02._Judge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var judge = new Dictionary<string, Dictionary<string, int>>();
            var students = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "no more time")
                {
                    break;
                }

                var tokens = input.Split(" -> ");
                var username = tokens[0];
                var contest = tokens[1];
                var points = int.Parse(tokens[2]);

                if (!judge.ContainsKey(contest))
                {
                    judge.Add(contest, new Dictionary<string, int>());
                }

                if (!judge[contest].ContainsKey(username))
                {
                    judge[contest].Add(username, points);


                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, points);
                    }
                    else
                    {
                        students[username] += points;
                    }
                }
                else
                {
                    if (judge[contest][username] < points)
                    {
                        students[username] += points - judge[contest][username];
                        judge[contest][username] = points;
                    }
                }
            }

            foreach (var kvp in judge)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");

                var counter = 1;
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value)
                                              .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter}. {item.Key} <::> {item.Value}");
                    counter++;
                }
            }

            Console.WriteLine("Individual standings:");
            
            var counter1 = 1;
            foreach (var item in students.OrderByDescending(x => x.Value)
                                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter1}. {item.Key} -> {item.Value}");
                counter1++;
            }
        }
    }
}
