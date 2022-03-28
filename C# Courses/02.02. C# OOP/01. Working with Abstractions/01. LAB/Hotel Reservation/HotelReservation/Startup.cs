using System;

namespace HotelReservation
{
    public class Startup
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(tokens[0]);
            int numberOfDays = int.Parse(tokens[1]);
            Season season = Enum.Parse<Season>(tokens[2]);
            DiscountType discountType = DiscountType.None;

            if (tokens.Length == 4)
            {
                discountType = Enum.Parse<DiscountType>(tokens[3]);
            }

            var priceCalculator = new PriceCalculator(pricePerDay, numberOfDays, season, discountType);

            Console.WriteLine(priceCalculator.CalculatePrice().ToString("F2"));            
        }
    }
}
