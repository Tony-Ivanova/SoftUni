namespace CarManufacturer
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nMdel: {car.Model}\nYear: {car.Year}");
        }
    }
}
