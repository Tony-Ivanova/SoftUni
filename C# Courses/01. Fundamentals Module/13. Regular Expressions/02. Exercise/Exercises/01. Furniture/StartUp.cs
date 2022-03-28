namespace _01._Furniture
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string pattern = @">>(?<furniture>[A-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            
            List<string> boughtFurniture = new List<string>();
            double moneySpent = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);

                    string furniture = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    boughtFurniture.Add(furniture);
                    moneySpent += quantity * price;
                }
            }

            Console.WriteLine("Bought furniture:");
            if (boughtFurniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, boughtFurniture));
            }

            Console.WriteLine($"Total money spend: {moneySpent:F2}");
        }
    }
}
