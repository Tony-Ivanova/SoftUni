namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Text;
    using System.Linq;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";


        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectsDto[]), new XmlRootAttribute("Projects"));
            var projectsDtos = (ImportProjectsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var validProjects = new List<Project>();

            foreach (var projectDto in projectsDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                DateTime projectOpenDate;
                var isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }



                DateTime? projectDueDate;

                if (!String.IsNullOrEmpty(projectDto.DueDate))
                {
                    DateTime projectDueDateValue;
                    var isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDateValue);

                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    projectDueDate = projectDueDateValue;
                }
                else
                {
                    projectDueDate = null;
                }


                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    var isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    if(taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDueDate.HasValue)
                    {
                        if (taskDueDate > projectDueDate.Value)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    project.Tasks.Add(new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    });
                }

                validProjects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportEmployees(TeisterMaskContext context, string xmlString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(xmlString);

            var sb = new StringBuilder();
            var validEmployees = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var task in employeeDto.Tasks.Distinct())
                {
                    if (context.Tasks.Find(task) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {                   
                        Employee = employee,
                        TaskId = task
                    });

                }

                validEmployees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}