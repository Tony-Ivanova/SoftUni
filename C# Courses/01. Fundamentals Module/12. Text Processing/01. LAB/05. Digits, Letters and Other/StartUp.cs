namespace _05._Digits__Letters_and_Other
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string otherChars = string.Empty;

            foreach (var character in input)
            {
                if (char.IsDigit(character))
                {
                    digits += character;
                }
                else if (char.IsLetter(character))
                {
                    letters += character;
                }
                else
                {
                    otherChars += character;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherChars);
        }
    }
}
