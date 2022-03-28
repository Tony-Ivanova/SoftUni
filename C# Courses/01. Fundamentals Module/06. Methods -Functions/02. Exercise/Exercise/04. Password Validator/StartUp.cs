namespace _04._Password_Validator
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string password = Console.ReadLine();

            bool isBetween6and10Symbols = checkLengthofPassword(password);

            bool containsOnlyDigitsandLetters = ContainsOnlyDigitsandLetters(password);

            bool containsMinimum2Digits = checkMinimum2Digits(password);

            PrintResult(isBetween6and10Symbols, containsOnlyDigitsandLetters, containsMinimum2Digits);
        }

        private static void PrintResult(bool isBetween6and10Symbols, bool containsOnlyDigitsandLetters, bool containsMinimum2Digits)
        {
            if (!isBetween6and10Symbols)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!containsOnlyDigitsandLetters)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!containsMinimum2Digits)
            {
                Console.WriteLine("Password must have at least 2 digits");

            }
            if (isBetween6and10Symbols && containsOnlyDigitsandLetters && containsMinimum2Digits)
            {
                Console.WriteLine($"Password is valid");
            }
        }

        private static bool checkLengthofPassword(string password)
        {
            return password.Length >= 6 && password.Length <= 10 ? true : false;
        }

        private static bool checkMinimum2Digits(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (char.IsDigit(symbol))
                {
                    counter++;
                }
            }
            return counter >= 2 ? true : false;
        }

        private static bool ContainsOnlyDigitsandLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
