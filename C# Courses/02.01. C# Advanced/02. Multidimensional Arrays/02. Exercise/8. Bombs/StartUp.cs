namespace _8._Bombs
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            FillMatrix(matrix);

            string[] coords = Console.ReadLine().Split();

            foreach (var coord in coords)
            {
                int[] coordArgs = coord.Split(',')
                                       .Select(int.Parse)
                                       .ToArray();
                int row = coordArgs[0];
                int col = coordArgs[1];

                BombCells(row, col, matrix);
            }

            PrintCellInfo(matrix);
            PrintMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] numbers = Console.ReadLine()
                                     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
        }

        private static void BombCells(int row, int col, int[,] matrix)
        {
            int damage = matrix[row, col];

            if (damage > 0)
            {
                BombCell(row - 1, col - 1, damage, matrix);
                BombCell(row - 1, col, damage, matrix);
                BombCell(row - 1, col + 1, damage, matrix);
                BombCell(row, col - 1, damage, matrix);
                BombCell(row, col + 1, damage, matrix);
                BombCell(row + 1, col - 1, damage, matrix);
                BombCell(row + 1, col, damage, matrix);
                BombCell(row + 1, col + 1, damage, matrix);
                matrix[row, col] = 0;
            }
        }

        private static void BombCell(int row, int col, int damage, int[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1) &&
                matrix[row, col] > 0)
            {
                matrix[row, col] -= damage;
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void PrintCellInfo(int[,] matrix)
        {
            int aliveCellsCount = 0;
            int aliveCellsSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCount ++;
                        aliveCellsSum += matrix[row, col];
                    }                    
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
        }
    }
}