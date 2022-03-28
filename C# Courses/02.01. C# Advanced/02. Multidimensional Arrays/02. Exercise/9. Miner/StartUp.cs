namespace _9._Miner
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            List<string> moves = new List<string>(Console.ReadLine()
                                                         .Split());

            string[,] matrix = new string[size, size];

            int[] matrixPositions = MatrixPositions(matrix);

            int startRow = matrixPositions[0];
            int startCol = matrixPositions[1];
            int coalCounter = matrixPositions[2];

            bool endGame = false;

            foreach (var move in moves)
            {
                switch (move)
                {
                    case "left":
                        if (startCol - 1 >= 0)
                        {
                            if (matrix[startRow, startCol - 1] == "c")
                            {
                                matrix[startRow, startCol - 1] = "*";
                                coalCounter--;
                            }
                            else if (matrix[startRow, startCol - 1] == "e")
                            {
                                endGame = true;
                            }
                            startCol--;
                        }
                        break;

                    case "right":
                        if (startCol + 1 <= matrix.GetLength(1) - 1)
                        {

                            if (matrix[startRow, startCol + 1] == "c")
                            {
                                matrix[startRow, startCol + 1] = "*";
                                coalCounter--;
                            }
                            else if (matrix[startRow, startCol + 1] == "e")
                            {
                                endGame = true;
                            }
                            startCol++;
                        }
                        break;

                    case "up":
                        if (startRow - 1 >= 0)
                        {
                            if (matrix[startRow - 1, startCol] == "c")
                            {
                                matrix[startRow - 1, startCol] = "*";
                                coalCounter--;
                            }
                            else if (matrix[startRow - 1, startCol] == "e")
                            {
                                endGame = true;
                            }
                            startRow--;

                        }
                        break;

                    case "down":
                        if (startRow + 1 <= matrix.GetLength(0) - 1)
                        {
                            if (matrix[startRow + 1, startCol] == "c")
                            {
                                matrix[startRow + 1, startCol] = "*";
                                coalCounter--;
                            }
                            else if (matrix[startRow + 1, startCol] == "e")
                            {
                                endGame = true;
                            }
                            startRow++;
                        }
                        break;

                    default:
                        break;
                }

                if (coalCounter == 0 || endGame)
                {
                    break;
                }
            }

            if (coalCounter == 0)
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
            else if (endGame)
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
            }
            else
            {
                Console.WriteLine($"{coalCounter} coals left. ({startRow}, {startCol})");
            }
        }

        private static int[] MatrixPositions(string[,] matrix)
        {
            int startRow = -1;
            int startCol = -1;
            int coalCounter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputRow = Console.ReadLine()
                                           .Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (inputRow[col] == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }

                    if (inputRow[col] == "c")
                    {
                        coalCounter++;
                    }
                }
            }

            int[] startPosition = new int[] { startRow, startCol, coalCounter };

            return startPosition;
        }
    }
}