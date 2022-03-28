namespace _05._Special_Numbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int digits = i;
                int sum = 0;

                while (digits > 0)
                {
                    sum += digits % 10;
                    digits = digits / 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
