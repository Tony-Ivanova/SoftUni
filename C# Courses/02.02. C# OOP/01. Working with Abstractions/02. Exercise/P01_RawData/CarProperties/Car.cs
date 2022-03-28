namespace P01_RawData.CarProperties
{
    public class Car
    {       
        public Car(string model, CarEngine carEngine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.CarEngine = carEngine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; private set; }
        public CarEngine CarEngine { get; private set; }
        public Cargo Cargo { get; private set; }
        public  Tire[] Tires { get; private set; }
    }
}

