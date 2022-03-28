namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Utilities.Messages;
    using System;

    public class SportsCar : Car
    {
        private const double cubicCentimetersInitial = 3000;
        private const int minumumHorsePower = 250;
        private const int maximumHorsePower = 450;
        private int horsePower;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cubicCentimetersInitial, minumumHorsePower, maximumHorsePower)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            set
            {
                if (value < minumumHorsePower || value > maximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}
