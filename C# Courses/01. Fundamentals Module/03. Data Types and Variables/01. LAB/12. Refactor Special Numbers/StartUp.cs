namespace _12._Refactor_Special_Numbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int num = 1; num <= number; num++)
            {
                int sumOfDigits = 0;
                int digits = num;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }
                bool isTrue = false;
                isTrue = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine($"{num} -> {isTrue}");
            }
        }
    }
}
