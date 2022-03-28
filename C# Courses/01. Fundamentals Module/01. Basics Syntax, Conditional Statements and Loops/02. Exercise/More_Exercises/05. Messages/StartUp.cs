namespace _05._Messages
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            var result = string.Empty;

            for (int i = 1; i <= countOfNumbers; i++)
            {
                var digits = Console.ReadLine();

                var mainDigit = int.Parse(digits[0].ToString());
                var offset = (mainDigit - 2) * 3;
                var letter = ' ';


                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }

                if (mainDigit == 0)
                {
                    letter = ' ';
                }
                else
                {
                    var letterIndex = (offset + (digits.Length - 1));
                    letter = (char)(letterIndex + 97);
                }

                result += letter;
            }

            Console.WriteLine(result);
        }
    }
}
