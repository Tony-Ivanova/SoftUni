namespace DefiningClasses
{
    using System;

    public class DateModifier
    {
        public DateModifier(DateTime start, DateTime end)
        {
            this.StartDate = start;
            this.EndDate = end;
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double GetDaysDifference()
        {
            return Math.Abs((StartDate - EndDate).TotalDays);
        }

    }
}
