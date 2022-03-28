namespace _02._Center_Point
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintCloserLine(x1, y1, x2, y2);
        }

        private static void PrintCloserLine(double x1, double y1, double x2, double y2)
        {
            double lineOne = CalculatePythagorean(x1, y1);
            double lineTwo = CalculatePythagorean(x2, y2);

            if (lineOne <= lineTwo)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        private static double CalculatePythagorean(double x, double y)
        {
            double result = Math.Sqrt(x * x + y * y);
            return result;
        }

    }
}