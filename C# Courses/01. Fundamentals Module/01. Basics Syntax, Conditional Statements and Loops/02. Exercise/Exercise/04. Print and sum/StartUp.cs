namespace _04._Print_and_sum
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = firstNumber; i <= lastNumber; i++)
            {
                sum += i;
                Console.Write($"{i} ");
            }
            Console.WriteLine("");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
