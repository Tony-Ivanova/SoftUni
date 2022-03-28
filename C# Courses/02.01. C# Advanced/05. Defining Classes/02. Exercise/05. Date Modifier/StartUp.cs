namespace DefiningClasses
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var start = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            var end = Console.ReadLine()
                             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

            DateTime startDate = new DateTime(start[0], start[1], start[2]);
            DateTime endDate = new DateTime(end[0], end[1], end[2]);

            DateModifier date = new DateModifier(startDate, endDate);

            Console.WriteLine(date.GetDaysDifference());
        }
    }
}
