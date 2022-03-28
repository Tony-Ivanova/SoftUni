namespace _03._SoftUni_Bar_Income
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string pattern = @"^%(?<customer>[A-Za-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+)\$";
            decimal total = 0m;

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "end of race")
                {
                    break;
                }

                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);

                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    decimal bill = quantity * price;

                    Console.WriteLine($"{customer}: {product} - {bill:f2}");

                    total += bill;
                }
            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
