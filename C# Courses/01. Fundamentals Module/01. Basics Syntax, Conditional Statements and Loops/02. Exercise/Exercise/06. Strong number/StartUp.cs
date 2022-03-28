namespace _06._Strong_number
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int numberOriginal = number;
            int digit = 0;
            int sum = 0;

            while (number > 0)
            {
                digit = number % 10;
                number /= 10;

                var factorial = 1;

                while (true)
                {

                    if (digit <= 1)
                    {
                        break;
                    }
                    factorial *= digit;
                    digit--;
                }
                sum += factorial;
            }

            if (sum == numberOriginal)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
