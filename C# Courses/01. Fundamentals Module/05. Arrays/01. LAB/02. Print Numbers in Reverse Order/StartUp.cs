namespace _02._Print_Numbers_in_Reverse_Order
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());
            var numbers = new int[numbersCount];

            for (int i = 0; i < numbersCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = numbersCount - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
