namespace _07._NxN_Matrix
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            DrawMatrix(n);
        }
        private static void DrawMatrix(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                for (int column = 1; column < n; column++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine(n + " ");
            }
        }

    }
}