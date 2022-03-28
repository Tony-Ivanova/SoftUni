namespace P03_JediGalaxy
{
    using System;
    using System.Linq;
    public class Matrix
    {
        public Matrix(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int[,] InitializingMatrix()
        {
            int value = 0;

            int[,] matrix = new int[this.X, this.Y];

            for (int i = 0; i < this.X; i++)
            {
                for (int j = 0; j < this.Y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }

        public void UpdateCoordinates(string command, Ivo ivo, Evil evil)
        {
            var ivoCoordinates = command
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            ivo.UpdateCoordinates(ivoCoordinates[0], ivoCoordinates[1]);

            var evilCoordinates = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            evil.UpdateCoordinates(evilCoordinates[0], evilCoordinates[1]);
        }
    }
}
