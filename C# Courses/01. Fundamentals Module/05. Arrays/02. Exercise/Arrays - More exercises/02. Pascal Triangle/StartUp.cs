namespace _02._Pascal_Triangle
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            if (n >= 1 && n <= 60)
            {
                for (int row = 0; row < n; row++)
                {
                    int val = 1;
                    for (int colm = 0; colm <= row; colm++)
                    {
                        Console.Write(val + " ");
                        val = val * (row - colm) / (colm + 1);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
