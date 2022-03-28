namespace _08._Beer_Kegs
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var numberOfLines = 3 * number;

            var biggestVolume = 0d;
            var typeOfKeg = string.Empty;

            for (int i = 0; i < numberOfLines; i+=3)
            {
                var model = Console.ReadLine();
                var radius = double.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());

                var volume = Math.PI * Math.Pow(radius, 2) * height;
                if (biggestVolume < volume)
                {
                    biggestVolume = volume;
                    typeOfKeg = model;
                }
            }

            Console.WriteLine(typeOfKeg);

        }
    }
}
