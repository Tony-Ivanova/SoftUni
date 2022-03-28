namespace _01._Smallest_of_Three_Numbers
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int result = int.Parse(Console.ReadLine());

            for (int i = 0; i < 2; i++)
            {
                int number = int.Parse(Console.ReadLine());
                result = SmallerNumber(number, result);
            }
            Console.WriteLine(result);
        }
        private static int SmallerNumber(int firstNumber, int secondNumber)
        {
            if(firstNumber < secondNumber)
            {
                return firstNumber;
            }
            return secondNumber;
        }
    }
}
