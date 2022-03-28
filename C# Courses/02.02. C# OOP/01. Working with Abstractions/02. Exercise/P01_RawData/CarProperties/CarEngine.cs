namespace P01_RawData.CarProperties
{
    public class CarEngine
    {
        private int engineSpeed;

        public CarEngine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.Power = enginePower;
        }

        public int Power { get; private set; }
    }
}
