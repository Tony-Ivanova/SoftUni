namespace _03._Rounding_Numbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int roundedNumber = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);

                Console.WriteLine($"{numbers[i]} => {roundedNumber}");
            }
        }
    }
}
