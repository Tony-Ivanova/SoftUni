namespace _05._Multiplication_Sign
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            string result = Checker(a, b, c);

            Console.WriteLine(result);
        }
        public static string Checker(int a, int b, int c)
        {
            string result = string.Empty;

            if ((a < 0 && b > 0 && c > 0) 
                || (b < 0 && a > 0 && c > 0) 
                || (c < 0 && a > 0 && b > 0) 
                || (a < 0 && b < 0 && c < 0))
            {
                result = "negative";
            }
            else if ((a < 0 && b < 0 && c > 0) 
                || (a < 0 && c < 0 && b > 0) 
                || (b < 0 && c < 0 && a > 0) 
                || (a > 0 && b > 0 && c > 0))
            {
                result = "positive";
            }
            else if (a == 0 || b == 0 || c == 0)
            {
                result = "zero";
            }
            return result;
        }
    }
}
