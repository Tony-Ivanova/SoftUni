namespace _01._Sign_of_Integer_Numbers
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine()); 
            string result = DetermineSign(number);
            PrintResult(number, result);
        }

        private static string DetermineSign(int number)
        {
            string result = string.Empty;

            if (number > 0)
                result = "positive";
            else if (number < 0)
                result = "negative";
            else
                result = "zero";

            return result;
        }

        private static void PrintResult(int number, string result)
        {
            Console.WriteLine($"The number {number} is {result}");
        }
    }
}
