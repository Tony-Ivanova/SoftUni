namespace _08._Town_Info
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string town = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            double area = double.Parse(Console.ReadLine());

            Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");
        }
    }
}
