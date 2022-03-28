namespace _03._MOBA_Challenger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static object ToList { get; private set; }

        public static void Main()
        {
            var arrow = new Dictionary<string, Dictionary<string, int>>();
            var points = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Season end")
                {
                    break;
                }

                string[] delimeters = { " -> ", " vs " };
                var tokens = input.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    var firstPlayer = tokens[0];
                    var secondPlayer = tokens[1];

                    if (arrow.ContainsKey(firstPlayer) && arrow.ContainsKey(secondPlayer))
                    {
                        var needToBreak = false;

                        foreach (var item in arrow[firstPlayer])
                        {
                            foreach (var item1 in arrow[secondPlayer])
                            {
                                if (item.Key == item1.Key)
                                {
                                    needToBreak = true;
                                    break;
                                }
                            }
                            if (needToBreak)
                            {
                                break;
                            }
                        }
                        if (needToBreak)
                        {
                            if (points[firstPlayer] < points[secondPlayer])
                            {
                                arrow.Remove(firstPlayer);
                                points.Remove(firstPlayer);
                            }
                            else if (points[firstPlayer] > points[secondPlayer])
                            {
                                arrow.Remove(secondPlayer);
                                points.Remove(secondPlayer);
                            }
                        }
                    }
                }
                else
                {
                    var player = tokens[0];
                    var position = tokens[1];
                    var skill = int.Parse(tokens[2]);

                    if (!arrow.ContainsKey(player))
                    {
                        arrow.Add(player, new Dictionary<string, int>());
                    }

                    if (!arrow[player].ContainsKey(position))
                    {
                        arrow[player].Add(position, skill);

                        if (!points.ContainsKey(player))
                        {
                            points.Add(player, skill);
                        }
                        else
                        {
                            points[player] += skill;
                        }
                    }
                    else
                    {
                        if (arrow[player][position] < skill)
                        {
                            points[player] += skill - arrow[player][position];
                            arrow[player][position] = skill;
                        }
                    }
                }
            }

            foreach (var kvp in points.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} skill");

                foreach (var kvp2 in arrow[kvp.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {kvp2.Key} <::> {kvp2.Value}");
                }
            }
        }
    }
}
