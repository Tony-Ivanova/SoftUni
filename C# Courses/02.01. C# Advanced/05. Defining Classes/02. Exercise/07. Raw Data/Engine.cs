namespace DefiningClasses
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.Power = power;
            this.Speed = speed;
        }

        public int Speed { get; set; }

        public int Power { get; set; }
    }
}
