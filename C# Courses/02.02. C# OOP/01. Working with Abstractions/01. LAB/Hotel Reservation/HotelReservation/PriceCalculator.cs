namespace HotelReservation
{
    public class PriceCalculator
    {
        private decimal pricePerDay;
        private int numberOfDays;
        private Season season;
        private DiscountType discountType;

        public PriceCalculator(decimal pricePerDay, int numberOfDays, Season season, DiscountType discountType)
        {
            this.pricePerDay = pricePerDay;
            this.numberOfDays = numberOfDays;
            this.season = season;
            this.discountType = discountType;
        }

        public decimal CalculatePrice()
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discountType / 100;

            decimal priceBeforeDiscount = numberOfDays * pricePerDay * multiplier;
            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }
    }
}
