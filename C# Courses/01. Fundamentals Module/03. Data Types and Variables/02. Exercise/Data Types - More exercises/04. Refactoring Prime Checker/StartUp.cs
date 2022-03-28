namespace _04._Refactoring_Prime_Checker
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int endNumber = int.Parse(Console.ReadLine());
            for (int eachNumber = 2; eachNumber <= endNumber; eachNumber++)
            {
                bool isPrime = true;
                for (int checkingForPrime = 2; checkingForPrime < eachNumber; checkingForPrime++)
                {
                    if (eachNumber % checkingForPrime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{eachNumber} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}
