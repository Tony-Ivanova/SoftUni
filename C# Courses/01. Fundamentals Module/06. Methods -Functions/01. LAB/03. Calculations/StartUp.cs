namespace _03._Calculations
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            double result = MathCalculation(command, a, b);

            Console.WriteLine(result);
        }

        private static double MathCalculation(string command, int a, int b)
        {
            double result = 0d;

            switch (command)
            {
                case "add":
                    result = a + b;
                    break;
                case "substract":
                    result = a - b;
                    break;
                case "multiply":
                    result = a * b;
                    break;
                case "divide":
                    result = a / b;
                    break;
                default:
                    result = 1;
                    break;
            }
            return result;
        }
    }
}
