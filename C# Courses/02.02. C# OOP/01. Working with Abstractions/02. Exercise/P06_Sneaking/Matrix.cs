namespace P06_Sneaking
{
using System;
    public class Matrix
    {
        public Matrix(int rowsCount)
        {
            this.RowsCount = rowsCount;
        }

        public int RowsCount { get; set; }


        public char[][] InitializeMatrix()
        {
            char[][] matrix = new char[this.RowsCount][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string line = Console.ReadLine();

                matrix[i] = line.ToCharArray();             
            }

            return matrix;
        }

        public char[][] UpdateEnemies(char[][] matrix)
        {           
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'b')
                    {
                        if (j == matrix[i].Length - 1)
                        {
                            matrix[i][j] = 'd';
                        }
                        else
                        {
                            matrix[i][j] = '.';
                            matrix[i][++j] = 'b';
                        }
                    }
                    else if (matrix[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            matrix[i][j] = 'b';
                        }
                        else
                        {
                            matrix[i][j] = '.';
                            matrix[i][j - 1] = 'd';
                        }
                    }
                }
            }

            return matrix;
        }

        public void PrintMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(String.Join("", line));
            }
            Environment.Exit(0);
        }
    }
}
