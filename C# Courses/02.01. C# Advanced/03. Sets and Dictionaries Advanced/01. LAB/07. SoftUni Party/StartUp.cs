namespace _07._SoftUni_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            HashSet<string> reservations = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }

                reservations.Add(input);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (reservations.Contains(input))
                {
                    reservations.Remove(input);
                }
            }

            Console.WriteLine(reservations.Count);

            List<string> vipReservations = reservations.Where(x => char.IsDigit(x.ToString()[0])).ToList();
            List<string> otherReservations = reservations.Where(x => char.IsLetter(x.ToString()[0])).ToList();
            if (vipReservations.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipReservations));
            }
            if (otherReservations.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, otherReservations));
            }
        }
    }
}
