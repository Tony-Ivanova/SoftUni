namespace _06._Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var students = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var tokens = input.Split(" : ");
                var course = tokens[0];
                var name = tokens[1];

                if (!students.ContainsKey(course))
                {
                    students[course] = new List<string>();
                }

                students[course].Add(name);
            }

            foreach (var kvp in students.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
              
                foreach (var student in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
