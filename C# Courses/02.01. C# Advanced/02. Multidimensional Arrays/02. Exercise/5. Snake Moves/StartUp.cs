namespace _5._Snake_Moves
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

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(char[,] matrix)
        {
            int counter = 0;

            char[] snake = Console.ReadLine()
                                  .ToCharArray();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (counter == snake.Length)
                    {
                        counter = 0;
                    }
                   
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snake[counter];
                        counter++;
                    }
                    else
                    {
                        matrix[row, matrix.GetLength(1) - col - 1] = snake[counter];
                        counter++;
                    }
                }
            }
        }
    }
}
