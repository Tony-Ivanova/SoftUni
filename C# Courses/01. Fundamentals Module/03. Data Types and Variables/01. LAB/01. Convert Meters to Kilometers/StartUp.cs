namespace _01._Convert_Meters_to_Kilometers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {          
            int distanceInMeters = int.Parse(Console.ReadLine());

            float convertedDistanceInKm = distanceInMeters / 1000.0f;
            Console.WriteLine($"{convertedDistanceInKm:f2}");
        }
    }
}
