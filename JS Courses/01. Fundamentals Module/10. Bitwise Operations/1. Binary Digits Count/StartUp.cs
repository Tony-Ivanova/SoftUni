namespace _1._Binary_Digits_Count
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            var number = new List<int>();

            while (n != 0)
            {
                int resultN = n % 2;
                number.Add(resultN);
                n /= 2;
            }
            number.Reverse();

            int result = number.Where(x => x == b).Count();
            Console.WriteLine(result);
        }
    }
}
