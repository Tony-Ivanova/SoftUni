namespace _1._Winning_Ticket
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string[] tickets = Console
                .ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"(\@{6,20}|\#{6,20}|\${6,20}|\^{6,20})";

            StringBuilder result = new StringBuilder();

            Regex regex = new Regex(pattern);

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    result.Append($"invalid ticket{Environment.NewLine}");
                    continue;
                }

                Match leftMatch = regex.Match(ticket.Substring(0, 10));
                Match rightMatch = regex.Match(ticket.Substring(10, 10));

                int minLength = Math.Min(leftMatch.Length, rightMatch.Length);

                if (!leftMatch.Success || !rightMatch.Success)
                {
                    result.Append($"ticket \"{ticket}\" - no match{Environment.NewLine}");
                    continue;
                }

                string leftPart = leftMatch.Value.Substring(0, minLength);
                string rightPart = rightMatch.Value.Substring(0, minLength);

                if (leftPart == rightPart)
                {
                    string matchedSymbol = leftPart.Substring(0, 1);

                    if (leftPart.Length == 10)
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLength}{matchedSymbol} Jackpot!{Environment.NewLine}");
                    }
                    else
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLength}{matchedSymbol}{Environment.NewLine}");
                    }
                }
                else
                {
                    result.Append($"ticket \"{ ticket}\" - no match{Environment.NewLine}");
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
