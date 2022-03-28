namespace _6._Jagged_Array_Manipulator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            double[][] matrix = new double[row][];

            FillMatrix(matrix);

            MultiplyElements(matrix);

            while (true)
            {
                string[] tokens = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "End")
                {
                    break;
                }

                int currentRow = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                double value = double.Parse(tokens[3]);

                if (!IsCoordinatesValid(matrix, currentRow, column))
                {
                    continue;
                }

                if (command == "Add")
                {
                    matrix[currentRow][column] += value;
                }

                else if (command == "Subtract")
                {
                    matrix[currentRow][column] -= value;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void MultiplyElements(double[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if (matrix[i].Count() == matrix[i + 1].Count())
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }
        }

        private static void FillMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double[] currentRow = Console.ReadLine()
                                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(double.Parse)
                                                  .ToArray();

                matrix[i] = currentRow;
            }
        }

        private static bool IsCoordinatesValid(double[][] matrix, int row, int column)
        {
            if (row >= 0 && row < matrix.Length)
            {
                if (column >= 0 && column < matrix[row].Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}