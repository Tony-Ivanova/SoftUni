namespace P06_Sneaking
{
    using System;
    using System.Linq;
    public class Nikoladze
    {
        public Nikoladze(char name)
        {
            this.Name = name;
        }

        public char Name { get; set; }

        public bool CheckIfAlive(char[][] matrix)
        {
            bool isNikoladzeAlive = true;

            for (var line = 0; line < matrix.Length; line++)
            {
                if (matrix[line].Contains(this.Name) && matrix[line].Contains('S'))
                {
                    matrix[line][Array.IndexOf(matrix[line], this.Name)] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    isNikoladzeAlive = false;
                }
            }

            return isNikoladzeAlive;
        }
    }
}
