namespace P01_RawData.CarProperties
{
    public class Tire
    {
        private int age;
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.age = age;
        }

        public double Pressure { get; private set; }
    }
}
