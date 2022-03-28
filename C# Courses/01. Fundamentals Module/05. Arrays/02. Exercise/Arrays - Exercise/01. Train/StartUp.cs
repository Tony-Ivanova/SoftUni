namespace _01._Train
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int countOfWagons = int.Parse(Console.ReadLine());

            int[] peopleRiding = new int[countOfWagons];
            int sum = 0;

            for (int i = 0; i < peopleRiding.Length; i++)
            {
                peopleRiding[i] = int.Parse(Console.ReadLine());
                sum += peopleRiding[i];
            }

            for (int i = 0; i < countOfWagons; i++)
            {
                Console.Write(peopleRiding[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
