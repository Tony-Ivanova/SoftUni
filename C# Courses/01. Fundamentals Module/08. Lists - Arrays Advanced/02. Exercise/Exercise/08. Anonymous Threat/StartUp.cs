namespace _08._Anonymous_Threat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }

                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "merge")
                {
                    int start = int.Parse(tokens[1]);
                    int end = int.Parse(tokens[2]);

                    if (start < 0)
                    {
                        start = 0;
                    }

                    if (end >= words.Count)
                    {
                        end = words.Count - 1;
                    }

                    for (int i = start; i < end; i++)
                    {
                        words[start] = words[start] + words[start + 1];
                        words.RemoveAt(start + 1);
                    }

                }
                else if (command == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);

                    int numberOfLetters = words[index].Length / partitions;
                    string current = words[index];

                    List<string> divided = new List<string>();

                    for (int i = 0; i < partitions; i++)
                    {
                        divided.Add(current.Substring(0, numberOfLetters));
                        current = current.Remove(0, numberOfLetters);
                    }

                    divided[divided.Count - 1] = divided[divided.Count - 1] + current;
                    words.RemoveAt(index);
                    words.InsertRange(index, divided);
                }
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}

