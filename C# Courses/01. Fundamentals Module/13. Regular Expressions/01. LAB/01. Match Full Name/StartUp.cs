namespace _01._Match_Full_Name
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string listOfNames = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            Regex regex = new Regex(pattern);

            MatchCollection validNames = regex.Matches(listOfNames);

            foreach (Match name in validNames)
            {
                Console.Write($"{name.Value} ");
            }

            Console.WriteLine();
        }
    }
}
