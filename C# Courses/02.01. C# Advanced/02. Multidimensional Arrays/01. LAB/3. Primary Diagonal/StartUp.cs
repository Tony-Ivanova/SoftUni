namespace _3._Primary_Diagonal
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int currentRow = 0;
            int currentColumn = 0;
            int sum = 0;

            while (true)
            {
                if (currentRow >= matrix.GetLength(0) || currentColumn >= matrix.GetLength(1))
                {
                    break;
                }

                sum += matrix[currentColumn, currentRow];
                currentColumn++;
                currentRow++;
            }

            Console.WriteLine(sum);
        }
    }
}
