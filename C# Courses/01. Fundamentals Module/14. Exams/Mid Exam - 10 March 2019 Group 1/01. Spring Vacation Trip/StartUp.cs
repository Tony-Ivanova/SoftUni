namespace _01._Spring_Vacation_Trip
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            decimal fuelPrice = decimal.Parse(Console.ReadLine());
            decimal food = decimal.Parse(Console.ReadLine());
            decimal lodging = decimal.Parse(Console.ReadLine());
            int discount = 0;

           
            decimal foodGroup = days * food * people;
            decimal hotelGroup = lodging * people * days;
            
            if(people > 10)
            {
                hotelGroup *= 0.75m;
            }

            decimal currentExpenses = foodGroup + hotelGroup;
            bool enoughMoney = true;

            for (int i = 1; i <= days; i++)
            {
                decimal distance = decimal.Parse(Console.ReadLine());

                decimal travelExpenses = distance * fuelPrice;

                currentExpenses += travelExpenses;

                if(i%3==0 || i % 5 == 0)
                {
                    currentExpenses += currentExpenses * 0.40m;
                }

                decimal additionalMoney = 0;

                if (i % 7 == 0)
                {
                    additionalMoney = currentExpenses / people;
                    currentExpenses -= additionalMoney;
                }

                if (currentExpenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {Math.Abs(currentExpenses - budget):f2}$ more.");
                    enoughMoney = false;
                    break;
                }
            }

            if (enoughMoney)
            {
                Console.WriteLine($"You have reached the destination. You have {Math.Abs(currentExpenses - budget):f2}$ budget left.");
            }
        }
    }
}
