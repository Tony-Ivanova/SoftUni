namespace _4._Matrix_Shuffling
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

            var matrix = new string[rows, cols];

            FillMatrix(matrix);
                        
            while (true)
            {
                string input = Console.ReadLine();

                if(input == "END")
                {
                    break;
                }

                string[] tokensNew = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokensNew[0] == "swap")
                {
                    if (tokensNew.Length - 1 == 4)
                    {
                        int rowWhere = int.Parse(tokensNew[1]);
                        int colWhere = int.Parse(tokensNew[2]);
                        int rowSwapWith = int.Parse(tokensNew[3]);
                        int colSwapWith = int.Parse(tokensNew[4]);

                        if (rowWhere < 0 || rowWhere >= rows 
                            || colWhere < 0 || colWhere >= cols 
                            || rowSwapWith < 0 || rowSwapWith >= rows 
                            || colSwapWith < 0 || colSwapWith >= cols)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            string doubleElement = matrix[rowSwapWith, colSwapWith];
                            string doubleReplace = matrix[rowWhere, colWhere];

                            matrix[rowSwapWith, colSwapWith] = doubleReplace;
                            matrix[rowWhere, colWhere] = doubleElement;

                            PrintMatrix(matrix);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
        }
    }
}
