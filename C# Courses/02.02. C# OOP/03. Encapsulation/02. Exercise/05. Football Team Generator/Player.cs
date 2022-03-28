using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateData(value, nameof(Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateData(value, nameof(Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                ValidateData(value, nameof(Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateData(value, nameof(Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateData(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        private void ValidateData(int value, string name)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }

        public int SkillLevel()
        {
            return (int)Math.Round((this.Endurance + this.Sprint + this.Shooting + this.Dribble + this.Passing) / 5.0);
        } 
    }
}
