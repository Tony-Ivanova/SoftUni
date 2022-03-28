namespace _02._From_Left_to_The_Right
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            long numberofLines = long.Parse(Console.ReadLine());
            long digits = 0;
            long a = 0;
            long b = 0;
            long sum = 0;

            for (long i = 0; i < numberofLines; i++)
            {
                string line = Console.ReadLine();
                string[] numbers = line.Split(' ');
                a = long.Parse(numbers[0]);
                b = long.Parse(numbers[1]);
                sum = 0;

                if (a > b)
                {
                    while (a != 0)
                    {
                        digits = a % 10;
                        a /= 10;
                        sum += Math.Abs(digits);
                    }
                    Console.WriteLine($"{sum}");

                }

                else
                {
                    while (b != 0)
                    {
                        digits = b % 10;
                        b /= 10;
                        sum += Math.Abs(digits);
                    }

                    Console.WriteLine($"{sum}");
                }


            }
        }
    }
}
