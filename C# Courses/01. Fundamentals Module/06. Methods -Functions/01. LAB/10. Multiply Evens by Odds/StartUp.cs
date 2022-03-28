namespace _10._Multiply_Evens_by_Odds
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int result = GetMultipleOfEvenAndOdds(Math.Abs(number));

            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int number)
        {
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            return oddSum * evenSum;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int last = number % 10;
                number /= 10;

                if (last % 2 != 0)
                {
                    sum += last;
                }
            }
            return sum;
        }

        public static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int last = number % 10;
                number /= 10;

                if (last % 2 == 0)
                {
                    sum += last;
                }
            }
            return sum;
        }
    }
}
