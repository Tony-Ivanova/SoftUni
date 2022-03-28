using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=MinionORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Hristo",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
