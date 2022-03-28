namespace _06._Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";

            MatchCollection emailAddresses = Regex.Matches(input, pattern);

            foreach (Object email in emailAddresses)
            {
                Console.WriteLine(email);
            }
        }
    }
}
