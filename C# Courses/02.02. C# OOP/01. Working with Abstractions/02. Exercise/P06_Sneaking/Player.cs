namespace P06_Sneaking
{
    using System;
    using System.Linq;

    public class Player
    {
        public Player(char name)
        {
            this.Name = name;
        }

        public char Name { get; set; }

        public int[] PlayerCoordinates(char[][] matrix)
        {
            int[] coordinates = null;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains(this.Name))
                {
                    coordinates = new int[] { i, Array.IndexOf(matrix[i], this.Name) };
                }
            }

            return coordinates;
        }

        public void Move(char move, char[][] matrix, int[] coordinates)
        {
            switch (move)
            {
                case 'U':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[--coordinates[0]][coordinates[1]] = this.Name;
                    break;
                case 'D':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[++coordinates[0]][coordinates[1]] = this.Name;
                    break;
                case 'L':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[coordinates[0]][--coordinates[1]] = this.Name;
                    break;
                case 'R':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[coordinates[0]][++coordinates[1]] = this.Name;
                    break;
                default:
                    break;
            }
        }

        public bool CheckIfAlive(char[][] matrix)
        {
            bool isAlive = true;

            for (var line = 0; line < matrix.Length; line++)
            {
                if (matrix[line].Contains('b') && matrix[line].Contains(this.Name))
                {
                    if (Array.IndexOf(matrix[line], 'b') < Array.IndexOf(matrix[line], this.Name))
                    {
                        matrix[line][Array.IndexOf(matrix[line], this.Name)] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                        isAlive = false;
                    }
                }
                else if (matrix[line].Contains('d') && matrix[line].Contains('S'))
                {
                    if (Array.IndexOf(matrix[line], 'd') > Array.IndexOf(matrix[line], this.Name))
                    {
                        matrix[line][Array.IndexOf(matrix[line], this.Name)] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                        isAlive = false;
                    }
                }
            }

            return isAlive;
        }
    }
}
