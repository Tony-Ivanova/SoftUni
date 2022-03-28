namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int row = size[0];
            int col = size[1];

            char[,] matrix = new char[row, col];

            FillMatrix(matrix);

            string moves = Console.ReadLine();

            int[] playerPositions = PlayerPositions(matrix);

            int startRow = playerPositions[0];
            int startCol = playerPositions[1];

            bool endGame = false;
            bool bunnyWon = false;

            foreach (var move in moves)
            {
                matrix = BunnyMove(matrix);
                switch (move)
                {
                    case 'L':
                        PlaceDot(matrix, startRow, startCol);                       
                        startCol--;
                        if (startCol < 0)
                        {
                            startCol++;
                            endGame = true;
                        }
                        else if (matrix[startRow, startCol] == 'B')
                        {
                            bunnyWon = true;
                        }
                        else
                        {
                            matrix[startRow, startCol] = 'P';                            
                        }
                        break;

                    case 'R':
                        PlaceDot(matrix, startRow, startCol);
                        startCol++;
                        if (startCol > matrix.GetLength(1) - 1)
                        {
                            startCol--;
                            endGame = true;
                        }
                        else if (matrix[startRow, startCol] == 'B')
                        {
                            bunnyWon = true;
                        }
                        else
                        {
                            matrix[startRow, startCol] = 'P';
                        }
                        break;

                    case 'U':
                        PlaceDot(matrix, startRow, startCol);
                        startRow--;
                        if (startRow < 0)
                        {
                            startRow++;
                            endGame = true;
                        }
                        else if (matrix[startRow, startCol] == 'B')
                        {
                            bunnyWon = true;
                        }
                        else
                        {
                            matrix[startRow, startCol] = 'P';
                        }
                        break;

                    case 'D':
                        PlaceDot(matrix, startRow, startCol);
                        startRow++;
                        if (startRow > matrix.GetLength(0) - 1)
                        {
                            startRow--;
                            endGame = true;
                        }
                        else if (matrix[startRow, startCol] == 'B')
                        {
                            bunnyWon = true;
                        }
                        else
                        {
                            matrix[startRow, startCol] = 'P';
                        }
                        break;

                    default:
                        break;
                }


                if (endGame || bunnyWon)
                {
                    break;
                }
            }

            PrintMatrix(matrix);

            if (endGame)
            {
                Console.WriteLine($"won: {startRow} {startCol}");
            }
            else if (bunnyWon)
            {
                Console.WriteLine($"dead: {startRow} {startCol}");
            }
        }

        private static void PlaceDot(char[,] matrix, int startRow, int startCol)
        {
            if (matrix[startRow, startCol] != 'B')
            {
                matrix[startRow, startCol] = '.';
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] BunnyMove(char[,] matrix)
        {
            char[,] newMatrix = (char[,])matrix.Clone();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row > 0)
                        {
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (row < matrix.GetLength(0) - 1)
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                        if (col > 0)
                        {
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (col < matrix.GetLength(1) - 1)
                        {
                            newMatrix[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string symbols = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
        }

        private static int[] PlayerPositions(char[,] matrix)
        {
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            int[] startPosition = new int[] { startRow, startCol };

            return startPosition;
        }
    }
}