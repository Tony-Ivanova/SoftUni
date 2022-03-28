namespace _08._Company_Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var company = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split(" -> ");
                var firm = tokens[0];
                var employee = tokens[1];

                if (!company.ContainsKey(firm))
                {
                    company[firm] = new List<string>();
                }

                if (!company[firm].Contains(employee))
                {
                    company[firm].Add(employee);
                }
            }

            foreach (var kvp in company.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
               
                foreach (var id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
