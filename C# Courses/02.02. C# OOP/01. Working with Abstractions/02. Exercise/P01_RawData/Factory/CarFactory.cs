namespace P01_RawData.Factory
{
    using CarProperties;
    public class CarFactory
    {
        public Car Create(string model, CarEngine carEngine, Cargo cargo, Tire[] tires)
        {
            return new Car(model, carEngine, cargo, tires);
        }
    }
}
