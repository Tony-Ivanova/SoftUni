namespace _03._Last_Stop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if(command == "Change")
                {
                    int paintingNumber = int.Parse(tokens[1]);
                    int changedNumber = int.Parse(tokens[2]);

                    if (numbers.Contains(paintingNumber))
                    {
                        int index = numbers.IndexOf(paintingNumber);
                        numbers[index] = changedNumber;
                    }
                }
                else if(command == "Hide")
                {
                    int paintingNumber = int.Parse(tokens[1]);

                    if (numbers.Contains(paintingNumber))
                    {
                        numbers.Remove(paintingNumber);
                    }
                }
                else if(command == "Switch")
                {
                    int paintingNumber = int.Parse(tokens[1]);
                    int paintingNumberSecond = int.Parse(tokens[2]);

                    if (numbers.Contains(paintingNumber)
                               && numbers.Contains(paintingNumberSecond))
                    {
                        int index1 = numbers.IndexOf(paintingNumber);
                        int index2 = numbers.IndexOf(paintingNumberSecond);
                        numbers[index1] = paintingNumberSecond;
                        numbers[index2] = paintingNumber;
                    }
                }
                else if (command == "Insert")
                {
                    int place = int.Parse(tokens[1]) + 1;
                    int paintingNumber = int.Parse(tokens[2]);

                    if (place >= 0 && place <= numbers.Count)
                    {
                        numbers.Insert(place, paintingNumber);
                    }
                }
                else if(command == "Reverse")
                {
                    numbers.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
