namespace _01._Company_Roster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public string Department { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string employeeName = tokens[0];
                decimal salary = decimal.Parse(tokens[1]);
                string departmentName = tokens[2];

                Employee employee = new Employee
                {
                    Name = employeeName,
                    Salary = salary,
                    Department = departmentName
                };

                employees.Add(employee);
            }

            var result = employees
                    .GroupBy(x => x.Department)
                    .Select(e => new
                    {
                        Department = e.Key,
                        AverageSalary = e.Average(emp => emp.Salary),
                        Employees = e.OrderByDescending(emp => emp.Salary)
                    })
                    .OrderByDescending(x => x.AverageSalary)
                    .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");

            foreach (var employee in result.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }
}
