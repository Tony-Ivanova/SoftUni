namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;

    using SoftUni.Data;
    using SoftUni.Models;
    public class StartUp
    {
        //Problem 02.
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var outputToPrint = GetEmployeesWithSalaryOver50000(context);

                Console.WriteLine(outputToPrint);
            }
        }

        //Problem 03.
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Name = String.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Name} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04.
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString();
        }

        //Problem 05.
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06.
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Add(address);

            var nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addressTexts = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var a in addressTexts)
            {
                sb.AppendLine(a.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 07.
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    Employee = $"{e.FirstName} {e.LastName}",
                    Manager = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Employee} - Manager: {e.Manager}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.Name} - {p.StartDate.ToString()} - {(p.EndDate == null ? "not finished" : p.EndDate.ToString())}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08.
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    AddressTextSb = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(e => e.EmployeeCount)
                .ThenBy(t => t.TownName)
                .ThenBy(a => a.AddressTextSb)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressTextSb}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09.
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    JobTitleEmployee = e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name
                    })
                    .OrderBy(p => p.ProjectName)
                    .ToList()
                }).First();

            sb.AppendLine($"{employee.Name} - {employee.JobTitleEmployee}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine(project.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10.
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepName = d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    EmployeeName = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepName} - {department.ManagerName}");
                foreach (var employee in department.EmployeeName)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11.
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    ProjectNameCurrent = x.Name,
                    DescriptionCurrent = x.Description,
                    StartDateCurrent = x.StartDate
                })
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.ProjectNameCurrent}");
                sb.AppendLine($"{project.DescriptionCurrent}");
                sb.AppendLine($"{String.Format("{0:M/d/yyyy h:mm:ss tt}", project.StartDateCurrent)}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12.
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(x => x.Department.Name == "Engineering" ||
                x.Department.Name == "Tool Design" ||
                x.Department.Name == "Marketing" ||
                x.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesToPrint = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var em in employeesToPrint)
            {
                sb.AppendLine($"{em.FirstName} {em.LastName} (${em.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13.
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var em in employees)
            {
                sb.AppendLine($"{em.FirstName} {em.LastName} - {em.JobTitle} - (${em.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14.
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projectInProjects = context.Projects.Find(2);
            var projectInEmployeesProjects = context.EmployeesProjects.
                FirstOrDefault(x => x.ProjectId == 2);

            context.EmployeesProjects.Remove(projectInEmployeesProjects);
            context.Projects.Remove(projectInProjects);

            context.SaveChanges();

            var projects = context
                .Projects
                .Select(x => new
                {
                    x.Name
                })
                .Take(10)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15.
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context
                .Towns
                .FirstOrDefault(x => x.Name == "Seattle");

            var addressesInTown = context
                .Addresses
                .Where(x => x.Town == town);

            var employees = context
                .Employees
                .Where(e => addressesInTown.Contains(e.Address));

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesInTown);

            int addressesCount = addressesInTown.Count();

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
