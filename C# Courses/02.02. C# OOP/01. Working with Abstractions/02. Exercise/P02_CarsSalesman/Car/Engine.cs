namespace P02_CarsSalesman
{
    using System.Text;

    public class Engine
    {
        private const string offset = "  ";
        private const string defaultEfficientcytValue = "n/a";
        private const int defaultDisplacementValue = -1;

        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
            :this(model, power, defaultDisplacementValue, defaultEfficientcytValue)
        {           
        }

        public Engine(string model, int power, int displacement)
            :this(model, power, displacement, defaultEfficientcytValue)
        {           
        }

        public Engine(string model, int power, string efficiency)
            :this(model, power, defaultDisplacementValue, efficiency)
        {            
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Model { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.Model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.displacement == -1 ? defaultEfficientcytValue : this.displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.efficiency);

            return sb.ToString();
        }
    }
}
