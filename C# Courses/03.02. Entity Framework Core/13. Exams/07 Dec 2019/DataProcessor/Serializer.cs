namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();

            var projects = context
                .Projects
                .ToArray()
                .Where(x => x.Tasks.Count > 0)
                .Select(e => new ExportProjectDto
                {
                    Name = e.Name,
                    TaskCount = e.Tasks.Count,
                    DueDate = e.DueDate.HasValue ? "Yes" : "No",
                    Tasks = e.Tasks
                            .Select(t => new ExportTaskJsonDto
                            {
                                 Name = t.Name,
                                 LabelType = t.LabelType.ToString()
                            })
                            .OrderBy(t => t.Name)
                            .ToArray()
                })
                .OrderByDescending(x => x.TaskCount)
                .ThenBy(x => x.Name)
                .ToArray();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                             .Where(et => et.Task.OpenDate >= date)
                             .OrderByDescending(et => et.Task.DueDate)
                             .ThenBy(et => et.Task.Name)
                             .Select(et => new
                             {
                                 TaskName = et.Task.Name,
                                 OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                 DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                 LabelType = et.Task.LabelType.ToString(),
                                 ExecutionType = et.Task.ExecutionType.ToString(),
                             })
                             .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;
        }
    }
}