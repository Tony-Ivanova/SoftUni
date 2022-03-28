namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var createMatrix = new Matrix(dimestions[0], dimestions[1]);
            var matrix = createMatrix.InitializingMatrix();

            var ivo = new Ivo();
            var evil = new Evil();

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                createMatrix.UpdateCoordinates(command, ivo, evil);

                evil.MoveEvil(evil, matrix);

                ivo.MoveIvo(ivo, matrix);
                
                command = Console.ReadLine();
            }

            Console.WriteLine(ivo.Score);
        }
    }
}
