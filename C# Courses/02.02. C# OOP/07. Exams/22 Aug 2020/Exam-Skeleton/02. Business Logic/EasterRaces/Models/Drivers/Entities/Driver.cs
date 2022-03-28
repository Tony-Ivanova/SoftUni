namespace EasterRaces.Models.Drivers.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public ICar Car { get; set; }

        public int NumberOfWins { get; set; }

        public bool CanParticipate { get; set; }

        public void AddCar(ICar car)
        {
            if(car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarInvalid));
            }

            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }
    }
}
