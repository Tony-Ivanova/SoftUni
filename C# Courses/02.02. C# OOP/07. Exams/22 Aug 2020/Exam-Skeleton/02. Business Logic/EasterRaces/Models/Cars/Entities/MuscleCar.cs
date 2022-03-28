namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Utilities.Messages;
    using System;

    public class MuscleCar : Car
    {
        private const double cubicCentimetersInitial = 5000;
        private const int minumumHorsePower = 400;
        private const int maximumHorsePower = 600;
        private int horsePower;

        public MuscleCar(string model, int horsePower)
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
