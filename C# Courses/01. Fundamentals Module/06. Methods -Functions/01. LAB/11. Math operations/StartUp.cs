namespace _11._Math_operations
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            string opera = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            double result = Calculate(a, opera, b);
            Console.WriteLine(result);
        }

        private static double Calculate(int a, string opera, int b)
        {
            double result = 0;

            switch (opera)
            {
                case "/":
                    result = a / b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
            }
            return result;
        }
    }
}
