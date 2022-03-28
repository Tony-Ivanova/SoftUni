namespace P06_Sneaking
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            var currentMatrix = new Matrix(rowsCount);
            var matrix = currentMatrix.InitializeMatrix();

            var nikoladze = new Nikoladze('N');
            var player = new Player('S');
            int[] playerCoordinates = player.PlayerCoordinates(matrix);

            string command = Console.ReadLine();

            foreach (var move in command)
            {
                matrix = currentMatrix.UpdateEnemies(matrix);


                bool isPlayerAlive = player.CheckIfAlive(matrix);
                
                if (!isPlayerAlive)
                {
                    currentMatrix.PrintMatrix(matrix);
                }

                player.Move(move, matrix, playerCoordinates);

                bool isNikoladzeAlive = nikoladze.CheckIfAlive(matrix);
               
                if (!isNikoladzeAlive)
                {
                    currentMatrix.PrintMatrix(matrix);
                }
            }
        }
    }
}

