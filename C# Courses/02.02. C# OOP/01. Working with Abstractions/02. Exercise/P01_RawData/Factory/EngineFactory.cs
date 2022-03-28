namespace P01_RawData.Factory
{
    using CarProperties;

    public class EngineFactory
    {
        public CarEngine Create(int speed, int power)
        {
            return new CarEngine(speed, power);
        }
    }
}
