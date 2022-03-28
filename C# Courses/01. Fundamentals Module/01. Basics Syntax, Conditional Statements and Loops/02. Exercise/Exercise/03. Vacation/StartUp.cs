namespace _03._Vacation
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int groupOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();

            double stundetPerOne = 0;
            double businessPerOne = 0;
            double regularPerOne = 0;

            switch (day)
            {
                case "Friday":
                    stundetPerOne = 8.45;
                    businessPerOne = 10.90;
                    regularPerOne = 15;
                    break;
                case "Saturday":
                    stundetPerOne = 9.80;
                    businessPerOne = 15.60;
                    regularPerOne = 20;
                    break;
                case "Sunday":
                    stundetPerOne = 10.46;
                    businessPerOne = 16;
                    regularPerOne = 22.50;
                    break;
            }

            double finalPrice = 0;

            if (typeOfPeople == "Students")
            {
                finalPrice = groupOfPeople * stundetPerOne;

                if (groupOfPeople >= 30)
                {
                    finalPrice = finalPrice - (finalPrice * 0.15);
                }
            }
            else if (typeOfPeople == "Business")
            {
                finalPrice = groupOfPeople * businessPerOne;

                if (groupOfPeople >= 100)
                {
                    finalPrice = finalPrice - businessPerOne * 10;
                }
            }
            else if (typeOfPeople == "Regular")
            {
                finalPrice = groupOfPeople * regularPerOne;

                if (groupOfPeople >= 10 && groupOfPeople <= 20)
                {
                    finalPrice = finalPrice - (finalPrice * 0.05);
                }
            }

            Console.WriteLine($"Total price: {finalPrice:f2}");
        }
    }
}
