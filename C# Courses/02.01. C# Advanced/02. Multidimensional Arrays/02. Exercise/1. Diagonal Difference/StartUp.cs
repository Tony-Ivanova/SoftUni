namespace _1._Diagonal_Difference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            FillMatrix(matrix);           

            int sumLefToRight = SumMatrixFromLeftToRight(matrix);            
            int sumRightToLeft = SumMatrixFromRightToLeft(matrix, size);

            int difference = Math.Abs(sumRightToLeft - sumLefToRight);
            Console.WriteLine(difference);
        }

        private static int SumMatrixFromRightToLeft(int[,] matrix, int size)
        {
            int sumRightToLeft = 0;
            int currentRightRow = 0;
            int currentRightColumn = size - 1;

            while (true)
            {
                if (currentRightColumn < 0 || currentRightRow >= matrix.GetLength(1))
                {
                    break;
                }

                sumRightToLeft += matrix[currentRightColumn, currentRightRow];
                currentRightRow++;
                currentRightColumn--;
            }

            return sumRightToLeft;
        }

        private static int SumMatrixFromLeftToRight(int[,] matrix)
        {
            int sumLeftToRight = 0;
            int currentLeftRow = 0;
            int currentLeftColumn = 0;

            while (true)
            {
                if (currentLeftRow >= matrix.GetLength(0) || currentLeftRow >= matrix.GetLength(1))
                {
                    break;
                }

                sumLeftToRight += matrix[currentLeftColumn, currentLeftRow];
                currentLeftColumn++;
                currentLeftRow++;
            }

            return sumLeftToRight;
        }

        private static void FillMatrix(int[,] matrix)
        {
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
        }
    }
}
