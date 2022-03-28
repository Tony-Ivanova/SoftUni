namespace _09.Sum_Of_Odd_Numbers
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 1; i <= number * 2; i += 2)
            {
                sum += i;
                Console.WriteLine($"{i}");
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
