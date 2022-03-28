namespace _11.Multiplication_Table_2._0
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            if (times > 10)
            {
                var product = number * times;
                Console.WriteLine($"{number} X {times} = {product}");
            }
            else
            {
                for (int i = times; i <= 10; i++)
                {

                    var product = number * i;
                    Console.WriteLine($"{number} X {i} = {product}");
                }
            }
        }
    }
}
