namespace _03._Exact_Sum_of_Real_Numbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double numberCount = double.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 1; i <= numberCount; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
