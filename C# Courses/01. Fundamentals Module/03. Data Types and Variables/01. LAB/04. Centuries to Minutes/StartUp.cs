namespace _04._Centuries_to_Minutes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int hoursInADay = 24;
            int minutesInAHour = 60;
            double daysInAYear = 365.2422;
            int yearsInACentury = 100;

            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * yearsInACentury;
            int days = (int)(years * daysInAYear);
            int hours = days * hoursInADay;
            int minutes = hours * minutesInAHour;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
