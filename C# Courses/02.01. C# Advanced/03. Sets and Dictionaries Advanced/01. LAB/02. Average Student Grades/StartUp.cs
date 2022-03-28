namespace _02._Average_Student_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split();
                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(grade);
            }

            foreach (var kvp in students)
            {
                List<double> grades = kvp.Value;

                Console.Write($"{kvp.Key} -> ");

                foreach (var item in kvp.Value)
                {
                    Console.Write($"{item:f2} ");
                }

                double sum = kvp.Value.Sum() / kvp.Value.Count;
                Console.WriteLine($"(avg: {sum:f2})");
            }
        }
    }
}
