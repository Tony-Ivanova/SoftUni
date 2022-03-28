namespace _02._Pounds_to_Dollars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            decimal convertionRate = 1.31M;

            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal dollars = pounds * convertionRate;
            Console.WriteLine($"{dollars:f3}");

        }
    }
}
