namespace _2._Squares_in_Matrix
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

            int howManyMatrixesExist = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    char leftUp = matrix[i, j];
                    char rightUp = matrix[i, j + 1];
                    char leftDown = matrix[i + 1, j];
                    char rightDown = matrix[i + 1, j + 1];

                    if (leftUp == leftDown && rightUp == rightDown && leftUp == rightUp)
                    {
                        howManyMatrixesExist++;
                    }
                }
            }

                Console.WriteLine(howManyMatrixesExist);
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] symbols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = symbols[j];
                }
            }
        }
    }
}
