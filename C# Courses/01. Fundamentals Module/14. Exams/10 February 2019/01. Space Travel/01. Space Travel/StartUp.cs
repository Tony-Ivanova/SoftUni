namespace Space_Travel
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                var currentWord = string.Empty;
                var planet = Console.ReadLine();
                var input = Console.ReadLine();

                if (input == "71793272797769")
                {
                    Console.WriteLine("GO HOME");
                    Console.WriteLine("Going home.");
                    break;
                }

                var numbers = input.ToCharArray();

                for (int i = 0; i < numbers.Length; i += 2)
                {
                    string currentChar = $"{numbers[i]}{numbers[i + 1]}";
                    int currentNumber = int.Parse(currentChar);
                    char currentLetter = (char)currentNumber;
                    currentWord += currentLetter;
                }

                Console.WriteLine(currentWord);
            }
        }
    }
}