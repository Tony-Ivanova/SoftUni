namespace P03_JediGalaxy
{
    public class Evil
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public void UpdateCoordinates(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void MoveEvil(Evil evil, int[,] matrix)
        {
            while (evil.Row >= 0)
            {
                if (evil.Row < matrix.GetLength(0) && evil.Col >= 0 && evil.Col < matrix.GetLength(1))
                {
                    matrix[evil.Row, evil.Col] = 0;
                }

                evil.UpdateCoordinates(evil.Row - 1, evil.Col - 1);
            }
        }
    }
}
