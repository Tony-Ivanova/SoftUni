namespace _03._Floating_Equality
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double left = Math.Abs(a - b);

            if (left < 0.000001)
            {
                Console.WriteLine("True");
            }
            else if (left >= 0.000001)
            {
                Console.WriteLine("False");
            }
        }
    }
}
