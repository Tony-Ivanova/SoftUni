using System.Text;

namespace Rhombus_of_Stars.Forms
{
    public class Rhombus : IForm
    {
        public string CreateForm(int size)
        {
            StringBuilder sb = new StringBuilder();

            for (int starCount = 0; starCount < size; starCount++)
            {
                PrintRow(size, starCount, sb);
            }
            for (int starCount = size - 2; starCount >= 0; starCount--)
            {
                PrintRow(size, starCount, sb);
            }

            return sb.ToString().TrimEnd();
        }

        private void PrintRow(int size, int starCount, StringBuilder sb)
        {
            for (int row = 1; row <= size - starCount; row++)
            {
                sb.Append(" ");
            }
            for (int col = 1; col <= starCount; col++)
            {
                sb.Append("* ");
            }

            sb.AppendLine("*");
        }
    }
}
