namespace _4._Symbol_in_Matrix
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colElements = Console.ReadLine()
                                            .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            char toFind = char.Parse(Console.ReadLine());
            bool isTrue = false;
            string where = "";

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (toFind == matrix[row, col])
                    {
                        isTrue = true;
                        where = $"({row}, {col})";
                        break;
                    }
                }

                if (isTrue == true)
                {
                    break;
                }
            }

            if (isTrue == true)
            {
                Console.WriteLine(where);
            }
            else
            {
                Console.WriteLine($"{toFind} does not occur in the matrix");
            }
        }
    }
}
