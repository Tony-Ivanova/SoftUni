namespace _02._Match_Phone_Number
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string listOfPhones = Console.ReadLine();

            string pattern = @"^\s*\+359( |-)2\1[0-9]{3}\1[0-9]{4}\b";
            Regex regex = new Regex(pattern);

            MatchCollection validPhoneNumbers = regex.Matches(listOfPhones);

            foreach (Match phone in validPhoneNumbers)
            {
                Console.Write($"{phone.Value} ");
            }

            Console.WriteLine();
        }
    }
}
