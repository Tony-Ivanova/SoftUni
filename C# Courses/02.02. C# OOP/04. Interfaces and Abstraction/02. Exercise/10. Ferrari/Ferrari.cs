namespace Ferrari
{
    public class Ferrari : IFerrari
    {

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Model => "488-Spider";
        public string Driver { get; private set; }

        public string Brakes()
        {
            return $"Brakes!";
        }

        public string Gas()
        {
            return $"Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
        }
    }
}
