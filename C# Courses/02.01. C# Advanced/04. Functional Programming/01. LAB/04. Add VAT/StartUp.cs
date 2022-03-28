namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double[] prices = Console.ReadLine()
                                     .Split(new char[] { ',', ' ' },
                                         StringSplitOptions.RemoveEmptyEntries)
                                     .Select(double.Parse)
                                     .Select(n => n * 1.2)
                                     .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
