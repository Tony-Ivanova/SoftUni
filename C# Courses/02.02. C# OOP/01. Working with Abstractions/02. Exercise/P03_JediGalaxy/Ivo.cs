namespace P03_JediGalaxy
{
    public class Ivo
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public long Score { get; private set; }

        public void UpdateCoordinates(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void CollectPoints(int points)
        {
            Score += points;
        }

        public void MoveIvo(Ivo ivo, int[,] matrix)
        {
            while (ivo.Row >= 0)
            {
                if (ivo.Row < matrix.GetLength(0) && ivo.Col >= 0 && ivo.Col < matrix.GetLength(1))
                {
                    ivo.CollectPoints(matrix[ivo.Row, ivo.Col]);
                }

                ivo.UpdateCoordinates(ivo.Row - 1, ivo.Col + 1);
            }
        }
    }
}
