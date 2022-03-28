namespace _06._Calculate_Rectangle_Area
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            double area = GetRectangleArea(width, heigth);
            Console.WriteLine(area);
        }
        private static double GetRectangleArea(double width, double heigth)
        {
            return width * heigth;
        }
    }
}
