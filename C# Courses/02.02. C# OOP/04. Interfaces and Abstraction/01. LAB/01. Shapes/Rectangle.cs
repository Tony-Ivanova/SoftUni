namespace Shapes
{
    using System.Text;
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }


        public string Draw()
        {
            var stringBuilder = new StringBuilder();

            DrawLine(this.Width, '*', '*', stringBuilder);

            for (int i = 1; i < this.Height - 1; ++i)
            {
                DrawLine(this.Width, '*', ' ', stringBuilder);

            }

            DrawLine(this.Width, '*', '*', stringBuilder);

            return stringBuilder.ToString();
        }

        private string DrawLine(int width, char end, char mid, StringBuilder sb)
        {
            sb.Append(end);

            for (int i = 1; i < width - 1; ++i)
            {
                sb.Append(mid);
            }

            sb.AppendLine(end.ToString());

            return sb.ToString();
        }
    }
}
