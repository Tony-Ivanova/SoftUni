namespace EasterRaces.Models.Cars.Entities
{

    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public abstract class Car : ICar
    {
        private string model;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
        }


        public string Model 
        {
            get => this.model;
            protected set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }            
        }

        public int MinHorsePower { get; set; }
        public int MaxHorsePower { get; set; }

        public virtual int HorsePower { get; set; }

        public double CubicCentimeters { get; protected set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
