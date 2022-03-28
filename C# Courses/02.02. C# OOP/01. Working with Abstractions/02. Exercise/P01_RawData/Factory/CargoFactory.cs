namespace P01_RawData.Factory
{
    using CarProperties;

    public class CargoFactory
    {
        public Cargo Create(int cargoWeight, string cargoType)
        {
            return new Cargo(cargoWeight, cargoType);
        }
    }
}
