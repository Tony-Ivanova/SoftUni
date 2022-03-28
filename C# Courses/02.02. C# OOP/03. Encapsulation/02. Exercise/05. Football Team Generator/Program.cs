namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var teams = new List<Team>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {

                    var teamTokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    var command = teamTokens[0];

                    var teamName = teamTokens[1];

                    if (command == "Team")
                    {
                        var currentTeam = new Team(teamName);
                        teams.Add(currentTeam);
                    }
                    else if (command == "Add")
                    {                        
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        var team = teams.FirstOrDefault(t => t.Name == teamName);

                        var playerName = teamTokens[2];
                        var endurance = int.Parse(teamTokens[3]);
                        var sprint = int.Parse(teamTokens[4]);
                        var dribble = int.Parse(teamTokens[5]);
                        var passing = int.Parse(teamTokens[6]);
                        var shooting = int.Parse(teamTokens[7]);

                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == teamName);

                        var playerName = teamTokens[2];

                        team.RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            var team = teams.FirstOrDefault(t => t.Name == teamName);
                            Console.WriteLine($"{team.Name} - {team.Rating()}");
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
