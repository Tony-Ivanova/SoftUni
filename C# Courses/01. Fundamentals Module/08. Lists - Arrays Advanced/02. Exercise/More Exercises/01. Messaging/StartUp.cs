namespace _01._Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToList();

            string text = Console.ReadLine();

            List<int> newDigits = new List<int>();

            for (int j = 0; j < numbers.Count; j++)
            {
                int sum = 0;
                int currentNumber = numbers[j];

                while (currentNumber != 0)
                {
                    sum += currentNumber % 10;
                    currentNumber /= 10;
                }
                newDigits.Add(sum);
            }

            var result = new List<char>();

            for (int j = 0; j < newDigits.Count; j++)
            {
                int letter = 0;
                int index = newDigits[j];

                if (index > text.Length)
                {
                    index -= text.Length;
                }
                letter = (text[index]);
                text = text.Remove(index, 1);

                result.Add((char)letter);
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
