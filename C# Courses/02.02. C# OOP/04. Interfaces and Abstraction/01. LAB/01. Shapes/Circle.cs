namespace Shapes
{
    using System.Text;
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius { get; private set; }

        public string Draw()
        {
            StringBuilder stringBuilder = new StringBuilder();

            double rIn = this.Radius - 0.4;

            double rOut = this.Radius + 0.4;

            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        stringBuilder.Append("*");
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                    }
                }

                stringBuilder.AppendLine();

            }
            return stringBuilder.ToString();
        }
    }
}
