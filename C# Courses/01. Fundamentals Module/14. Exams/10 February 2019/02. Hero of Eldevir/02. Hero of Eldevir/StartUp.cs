namespace Volley_Team
{
    using System;
    using System.Linq;
    
    public class StartUp
    {
        public static void Main()
        {
            var team = Console.ReadLine()
                              .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .ToList();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Battle")
                {
                    Console.WriteLine("Red Paladin's inventory :");

                    foreach (var item in team)
                    {
                        Console.WriteLine($"--> {item}");
                    }
                    break;
                }

                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                if (command == "Loot")
                {
                    var player = tokens[1];

                    if (!team.Contains(player))
                    {
                        team.Add(player);
                        Console.WriteLine($"{player} has been added to the inventory.");
                    }
                }
                else if (command == "Disenchant")
                {
                    var player = tokens[1];

                    if (team.Contains(player))
                    {
                        team.Remove(player);
                        if (team.Count() == 0)
                        {
                            Console.WriteLine("The inventory is empty.");
                            break;
                        }
                        else if (team.Count() > 0)
                        {
                            Console.WriteLine($"{player} has been disenchanted.");
                        }
                    }
                }
                else if (command == "Upgrade")
                {
                    var player = tokens[1].Split('/');

                    var firstPlayer = player[0];
                    var secondPlayer = player[1];

                    if (team.Contains(firstPlayer))
                    {
                        Console.WriteLine($"{firstPlayer} has been upgraded to {firstPlayer} ~ {secondPlayer}.");
                        var where = team.IndexOf(firstPlayer);
                        team.Remove(firstPlayer);
                        team.Insert(where, $"{firstPlayer} ~ {secondPlayer}");
                    }

                }
            }
        }
    }
}
