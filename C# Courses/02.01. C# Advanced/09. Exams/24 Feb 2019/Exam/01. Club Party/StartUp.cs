namespace _01._Club_Party
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            var inputLine = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Reverse()
                                   .ToList();

            var halls = new Queue();
            var hallsAndGuests = new Dictionary<char, List<int>>();
            var usingCapacity = maxCapacity;
            var currentList = new List<int>();

            for (int i = 0; i < inputLine.Count; i++)
            {
                var currentNumberOfGuests = 0;
                var validNumberOfGuests = int.TryParse(inputLine[i], out currentNumberOfGuests);


                if (validNumberOfGuests && halls.Count > 0)
                {
                    if (usingCapacity - currentNumberOfGuests >= 0)
                    {
                        currentList.Add(currentNumberOfGuests);
                        usingCapacity -= currentNumberOfGuests;
                    }
                    else
                    {
                        var currentHall = (char)halls.Peek();
                        hallsAndGuests.Add(currentHall, new List<int>());
                        hallsAndGuests[currentHall].AddRange(currentList);
                        halls.Dequeue();
                        currentList.Clear();
                        usingCapacity = maxCapacity;
                        i--;
                    }
                }
                else if (!validNumberOfGuests)
                {
                    char currentHall = char.Parse(inputLine[i]);
                    halls.Enqueue(currentHall);
                }
            }

            foreach (var kvp in hallsAndGuests)
            {
                char letter = kvp.Key;
                List<int> list = kvp.Value;
                Console.WriteLine($"{letter} -> {string.Join(", ", list)}");
            }
        }
    }
}
