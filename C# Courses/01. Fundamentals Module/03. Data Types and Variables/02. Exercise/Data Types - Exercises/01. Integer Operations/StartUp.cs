namespace _01._Integer_Operations
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            var result = (firstNumber + secondNumber) / thirdNumber * fourthNumber;

            Console.WriteLine(result);
        }
    }
}
