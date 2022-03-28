namespace _7._Pascal_Triangle
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];
            triangle[0] = new long[1];
            triangle[0][0] = 1;

            for (long row = 1; row < height; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][triangle[row].Length - 1] = 1;

                for (int col = 1; col < triangle[row].Length - 1; col++)
                {
                    triangle[row][col] += triangle[row - 1][col] + triangle[row - 1][col - 1];
                }

            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
