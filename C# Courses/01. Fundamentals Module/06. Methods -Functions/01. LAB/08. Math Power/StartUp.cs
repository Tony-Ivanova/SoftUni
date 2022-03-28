namespace _08._Math_Power
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = RaiseToPower(number, power); 
            Console.WriteLine(result);
        }
        private static double RaiseToPower(double number, int power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }
            return result;

            //or return Math.Pow(number, power);
        }
    }
}
