namespace _10.Multiplication_Table
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                var product = number * i;
                Console.WriteLine($"{number} X {i} = {product}");
            }
        }
    }
}
