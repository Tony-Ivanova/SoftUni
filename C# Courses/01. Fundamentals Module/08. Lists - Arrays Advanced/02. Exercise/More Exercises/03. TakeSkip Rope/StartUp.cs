namespace _03._TakeSkip_Rope
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var firstString = Console.ReadLine().ToCharArray();
            var numbers = new List<char>();
            var nonNumbers = new List<char>();

            for (int i = 0; i < firstString.Length; i++)
            {
                char currentChar = firstString[i];

                if (char.IsDigit(currentChar))
                {
                    numbers.Add((char)currentChar);
                }
                else
                {
                    nonNumbers.Add(currentChar);
                }
            }

            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = (int)numbers[i] - 48;

                if (i % 2 == 0)
                {
                    take.Add(currentNumber);
                }
                else
                {
                    skip.Add(currentNumber);
                }
            }

            var result = new List<char>();

            for (int i = 0; i < take.Count; i++)
            {
                for (int k = 0; k < take[i]; k++)
                {
                    if (nonNumbers.Count != 0)
                    {
                        result.Add(nonNumbers[0]);
                        nonNumbers.RemoveAt(0);
                    }
                }
                for (int j = 0; j < skip[i]; j++)
                {
                    if (nonNumbers.Count != 0)
                    {
                        nonNumbers.RemoveAt(0);
                    }

                }
                if (nonNumbers.Count == 0)
                {
                    break;
                }

            }

            Console.WriteLine(string.Join("", result));
        }
    }
}

