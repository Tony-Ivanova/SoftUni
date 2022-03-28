
namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public double Rating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            else
            {
                return (int)players.Select(x => x.SkillLevel()).Average();
            }            
        }


        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {            
            if (this.players.Any(p => p.Name == playerName))
            {
                this.players.Remove(this.players.First(x => x.Name == playerName));
            }
            else
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
        }
    }
}
