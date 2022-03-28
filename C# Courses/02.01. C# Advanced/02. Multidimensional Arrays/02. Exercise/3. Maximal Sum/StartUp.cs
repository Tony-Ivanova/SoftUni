namespace _3._Maximal_Sum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] tokens = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            char[,] matrix = new char[rows, cols];

            FillMatrix(matrix);

            int sizeOfPerfectMatrix = 3;
            int[,] matrixToBeFilled = new int[sizeOfPerfectMatrix, sizeOfPerfectMatrix];

            int maxSum = 0;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                                    + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                                    + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        matrixToBeFilled[0, 0] = matrix[i, j];
                        matrixToBeFilled[0, 1] = matrix[i, j + 1];
                        matrixToBeFilled[0, 2] = matrix[i, j + 2];

                        matrixToBeFilled[1, 0] = matrix[i + 1, j];
                        matrixToBeFilled[1, 1] = matrix[i + 1, j + 1];
                        matrixToBeFilled[1, 2] = matrix[i + 1, j + 2];

                        matrixToBeFilled[2, 0] = matrix[i + 2, j];
                        matrixToBeFilled[2, 1] = matrix[i + 2, j + 1];
                        matrixToBeFilled[2, 2] = matrix[i + 2, j + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            PrintMatrix(matrixToBeFilled);
        }

        private static void PrintMatrix(int[,] matrixToBeFilled)
        {
            for (int row = 0; row < matrixToBeFilled.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToBeFilled.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrixToBeFilled[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] numbers = Console.ReadLine()
                                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (char)numbers[j];
                }
            }
        }
    }
}
