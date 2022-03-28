namespace _07._Student_Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var students = new Dictionary<string, List<double>>();

            var number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                var name = Console.ReadLine();
                var note = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }

                students[name].Add(note);
            }

            students = students.Where(x => x.Value.Average() >= 4.50)
                               .OrderByDescending(x => x.Value.Average())
                               .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in students)
            {
                List<double> grades = kvp.Value;
                Console.WriteLine($"{kvp.Key} -> {grades.Average():f2}");
            }
        }
    }
}
