namespace _04._Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public double Grade { get; set; }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> ourClass = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                string[] splittedInput = Console.ReadLine()
                    .Split(" ");

                student.FirstName = splittedInput[0];
                student.LastName = splittedInput[1];
                student.Grade = double.Parse(splittedInput[2]);
                ourClass.Add(student);
            }

            foreach (Student student in ourClass.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
