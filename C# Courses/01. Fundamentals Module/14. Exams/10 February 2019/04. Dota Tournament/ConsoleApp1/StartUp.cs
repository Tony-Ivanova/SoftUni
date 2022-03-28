namespace DOTA_2_Tournament
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class StartUp
    {
        static void Main(string[] args)
        {

            var teamPlayers = new Dictionary<string, List<string>>();
            var teamWins = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Tournament end")
                {
                    break;
                }

                var tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var nameOfTeam = tokens[1];

                if (command == "New team")
                {
                    var players = tokens[2].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (players.Length == 5)
                    {
                        if (!teamPlayers.ContainsKey(nameOfTeam))
                        {
                            teamPlayers[nameOfTeam] = new List<string>();
                            teamPlayers[nameOfTeam].AddRange(players);
                            teamWins[nameOfTeam] = 0;
                        }
                    }
                }
                else if (command == "Win")
                {
                    if (teamPlayers.ContainsKey(nameOfTeam))
                    {
                        teamWins[nameOfTeam] += 1;
                    }
                }
                else if (command == "Disqualification")
                {
                    if (teamPlayers.ContainsKey(nameOfTeam))
                    {
                        teamPlayers.Remove(nameOfTeam);
                        teamWins.Remove(nameOfTeam);
                    }
                }
            }

            Console.WriteLine("Teams:");

            foreach (var item in teamWins.OrderByDescending(x => x.Value))
            {
                var name = item.Key;
                var wins = item.Value;
                var players = teamPlayers[name];

                Console.WriteLine($"{name} - {string.Join(", ", players)} -> {wins} wins");
            }
        }
    }
}