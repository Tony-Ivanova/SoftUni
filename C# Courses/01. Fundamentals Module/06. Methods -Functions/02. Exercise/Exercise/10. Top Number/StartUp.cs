namespace _10._Top_Number
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            for (long i = 1; i <= number; i++)
            {
                if (Sum(i) && Odd(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool Sum(long i)
        {
            long sum = 0;
            while (i != 0)
            {
                sum += i % 10;
                i /= 10;
            }
            if (sum % 8 == 0)
            {
                return true;
            }
            return false;
        }

        public static bool Odd(long i)
        {
            while (i != 0)
            {
                if ((i % 10) % 2 != 0)
                {
                    return true;
                }
                i /= 10;
            }
            return false;
        }
    }
}