namespace _06._Parking_Lot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            HashSet<string> cars = new HashSet<string>();

            while(true)
            {
                string input = Console.ReadLine();

                if(input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string inOrOut = tokens[0];
                string parkingNumber = tokens[1];

                if(inOrOut == "IN")
                {
                    cars.Add(parkingNumber);
                }
                else if(inOrOut == "OUT")
                {
                    cars.Remove(parkingNumber);
                }
            }

            if (cars.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

