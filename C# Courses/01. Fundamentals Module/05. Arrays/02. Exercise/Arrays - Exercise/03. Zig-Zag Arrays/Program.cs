namespace _03._Zig_Zag_Arrays
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int a = 0;
            int b = 0;

            string result1 = string.Empty;
            string result2 = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                a = row[0];
                b = row[1];

                if (i % 2 != 0)
                {
                    result1 += a + " ";
                    result2 += b + " ";

                }
                else if (i % 2 == 0)
                {
                    result1 += b + " ";
                    result2 += a + " ";
                }
            }

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}
