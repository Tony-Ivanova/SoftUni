namespace _08._Factorial_Division
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            decimal firstNumber = decimal.Parse(Console.ReadLine());
            decimal secondNumber = decimal.Parse(Console.ReadLine());

            decimal tempoFirst = factorialFirst(firstNumber);
            decimal tempoSecond = factorialSecond(secondNumber);
            decimal result = FinalResult(tempoFirst, tempoSecond);

            Console.WriteLine($"{result:f2}");
        }

        private static decimal factorialFirst(decimal firstNumber)
        {
            decimal tempoFirst = 1;
            for (int i = 1; i <= firstNumber; i++)
            {
                tempoFirst = tempoFirst * i;
            }
            return tempoFirst;
        }
        private static decimal factorialSecond(decimal secondNumber)
        {
            decimal tempoSecond = 1;
            for (int i = 1; i <= secondNumber; i++)
            {
                tempoSecond = tempoSecond * i;
            }
            return tempoSecond;
        }
        private static decimal FinalResult(decimal tempoFirst, decimal tempoSecond)
        {
            decimal result = tempoFirst / tempoSecond;
            return result;
        }
    }
}