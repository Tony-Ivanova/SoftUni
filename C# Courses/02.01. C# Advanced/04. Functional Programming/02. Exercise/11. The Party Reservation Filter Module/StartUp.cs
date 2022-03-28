namespace _11._The_Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> invitations = Console.ReadLine()
                                              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                              .ToList();

            HashSet<string> filter = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }

                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                var currentFilter = tokens[1] + " " + tokens[2];

                if (command == "Add filter")
                {
                    filter.Add(currentFilter);
                }
                else if (command == "Remove filter")
                {
                    filter.Remove(currentFilter);
                }
            }

            Func<string, string, bool> predicate;

            foreach (var item in filter)
            {
                string[] tokens = item.Split(" ");

                string filterType;
                string filterParameter = tokens[1];

                if (tokens.Length == 3)
                {
                    filterType = tokens[0] + " " + tokens[1];
                    filterParameter = tokens[2];
                }
                else
                {
                    filterType = tokens[0];
                    filterParameter = tokens[1];
                }

                predicate = GetFunc(filterType);
                invitations.RemoveAll(x => predicate(x, filterParameter));
            }

            Console.WriteLine(string.Join(" ", invitations));
        }

        static Func<string, string, bool> GetFunc(string filterType)
        {
            if (filterType == "Starts with")
            {
                return (x, c) => x.StartsWith(c);
            }
            else if (filterType == "Ends with")
            {
                return (x, c) => x.EndsWith(c);
            }
            else if (filterType == "Length")
            {
                return (x, c) => x.Length == int.Parse(c);
            }
            else if (filterType == "Contains")
            {
                return (x, c) => x.Contains(c);
            }
            return null;
        }
    }
}