namespace _02._Tron_Racers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static int firstPlayerRow = -1;
        public static int firstPlayerCol = -1;

        public static int secondPlayerRow = -1;
        public static int secondPlayerCol = -1;
        
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size][];


            for (int row = 0; row < size; row++)
            {
                var currentLine = Console.ReadLine()
                                .ToCharArray();

                matrix[row] = currentLine;

                if (currentLine.Contains('f'))
                {
                    firstPlayerRow = row;
                    firstPlayerCol = Array.IndexOf(currentLine, 'f');
                }
                if (currentLine.Contains('s'))
                {
                    secondPlayerRow = row;
                    secondPlayerCol = Array.IndexOf(currentLine, 's');
                }
            }

            while (true)
            {
                var inputCommands = Console.ReadLine()
                                           .Split();

                var firstCommand = inputCommands[0];
                var isFirstPlayerDead = MoveFirstPlayer(matrix, firstCommand);

                if (isFirstPlayerDead)
                {
                    break;
                }

                var secondCoomand = inputCommands[1];

                var isSecondPlayerDead = MoveSecondPlayer(matrix, secondCoomand);

                if (isSecondPlayerDead)
                {
                    break;
                }

            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool MoveSecondPlayer(char[][] matrix, string secondCoomand)
        {
            var isDead = false; 

            if (secondCoomand == "down")
            {
                if (secondPlayerRow + 1 > matrix.Length - 1)
                {
                    secondPlayerRow = -1;
                }

                if (matrix[secondPlayerRow + 1][secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow + 1][secondPlayerCol] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[secondPlayerRow + 1][secondPlayerCol] = 's';
                    secondPlayerRow++;
                }
            }
            else if (secondCoomand == "up")
            {
                if (secondPlayerRow - 1 < 0)
                {
                    secondPlayerRow = matrix.Length;
                }

                if (matrix[secondPlayerRow - 1][secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow - 1][secondPlayerCol] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[secondPlayerRow - 1][secondPlayerCol] = 's';
                    secondPlayerRow--;
                }
            }
            else if (secondCoomand == "right")
            {
                if (secondPlayerCol + 1 > matrix[secondPlayerRow].Length - 1)
                {
                    secondPlayerCol = -1;
                }

                if (matrix[secondPlayerRow][secondPlayerCol + 1] == 'f')
                {
                    matrix[secondPlayerRow][secondPlayerCol + 1] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[secondPlayerRow][secondPlayerCol + 1] = 's';
                    secondPlayerCol++;
                }
            }
            else if (secondCoomand == "left")
            {
                if (secondPlayerCol - 1 < 0)
                {
                    secondPlayerCol = matrix[secondPlayerRow].Length;
                }

                if (matrix[secondPlayerRow][secondPlayerCol - 1] == 'f')
                {
                    matrix[secondPlayerRow][secondPlayerCol - 1] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[secondPlayerRow][secondPlayerCol - 1] = 's';
                    secondPlayerCol--;
                }
            }

            return isDead;
        }

        private static bool MoveFirstPlayer(char[][] matrix, string firstCommand)
        {
            var isDead = false;

            if (firstCommand == "down")
            {
                if (firstPlayerRow + 1 > matrix.Length - 1)
                {
                    firstPlayerRow = -1;
                }

                if (matrix[firstPlayerRow + 1][firstPlayerCol] == 's')
                {
                    matrix[firstPlayerRow + 1][firstPlayerCol] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[firstPlayerRow + 1][firstPlayerCol] = 'f';
                    firstPlayerRow++;
                }
            }
            else if (firstCommand == "up")
            {
                if (firstPlayerRow - 1 < 0)
                {
                    firstPlayerRow = matrix.Length;
                }

                if (matrix[firstPlayerRow - 1][firstPlayerCol] == 's')
                {
                    matrix[firstPlayerRow - 1][firstPlayerCol] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[firstPlayerRow - 1][firstPlayerCol] = 'f';
                    firstPlayerRow--;
                }
            }
            else if (firstCommand == "right")
            {
                if (firstPlayerCol + 1 > matrix[firstPlayerRow].Length - 1)
                {
                    firstPlayerCol = -1;
                }

                if (matrix[firstPlayerRow][firstPlayerCol + 1] == 's')
                {
                    matrix[firstPlayerRow][firstPlayerCol + 1] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[firstPlayerRow][firstPlayerCol + 1] = 'f';
                    firstPlayerCol++;
                }
            }
            else if (firstCommand == "left")
            {
                if (firstPlayerCol - 1 < 0)
                {
                    firstPlayerCol = matrix[firstPlayerRow].Length;
                }

                if (matrix[firstPlayerRow][firstPlayerCol - 1] == 's')
                {
                    matrix[firstPlayerRow][firstPlayerCol - 1] = 'x';
                    isDead = true;
                }
                else
                {
                    matrix[firstPlayerRow][firstPlayerCol - 1] = 'f';
                    firstPlayerCol--;
                }
            }

            return isDead;
        }
    }
}
